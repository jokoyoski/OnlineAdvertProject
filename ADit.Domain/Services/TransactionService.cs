using System.Web;
using AA.Infrastructure.Interfaces;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using ADit.Domain.Models;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Methods.Transactions;
using PayStackDotNetSDK.Models.Transactions;
using System.Threading.Tasks;
using PayStackDotNetSDK.Models;
using System;

namespace ADit.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITransactionService" />
    public class TransactionService : ITransactionService
    {
        private readonly ISessionStateService session;


        private readonly IOrderSummaryFactory orderSummaryFactory;

        private readonly ITvRepository tvRepository;

        private readonly IPrintRepository pmRepository;

        private readonly IRadioRepository radioRepository;

        private readonly ILookupRepository lookupRepository;

        private readonly IBrandingRepository brandingRepository;

        private readonly IOnlineRepository onlineRepository;

        private readonly IGeneralRepository generalRepository;

        private readonly IAccountRepository accountRepository;

        private readonly IOrderRepository orderRepository;


        public TransactionService(ISessionStateService session, IBrandingRepository brandingRepository,
            ILookupRepository lookupRepository, IGeneralRepository generalRepository,
            IRadioRepository radioRepository,
            IDigitalFileServices digitalFileServices,
            IOrderSummaryFactory orderSummaryFactory, ITvRepository tvRepository, IOnlineRepository onlineRepository,
            IPrintRepository pmRepository, IAccountRepository accountRepository, IOrderRepository orderRepository)
        {
            this.session = session;

            this.orderSummaryFactory = orderSummaryFactory;

            this.tvRepository = tvRepository;
            this.onlineRepository = onlineRepository;
            this.pmRepository = pmRepository;
            this.radioRepository = radioRepository;
            this.lookupRepository = lookupRepository;
            this.brandingRepository = brandingRepository;
            this.generalRepository = generalRepository;
            this.accountRepository = accountRepository;
            this.orderRepository = orderRepository;
        }


        /// <summary>
        /// Updates the cart.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public void UpdateCart(int orderId)
        {
            //Get Current Cart Value
            var cart = 0;

            if (orderId > 0)
            {
                var tvOrderCount = this.tvRepository.GetActiveTvTransaction(orderId).Count;
                var pmOrderCount = this.pmRepository.GetActivePmTransaction(orderId).Count;
                var radioOrderCount = this.radioRepository.GetActiveRadioTranasction(orderId).Count;
                var brandingOrderCount = this.brandingRepository.getActiveBrandingTransaction(orderId).Count;
                var onlineOrderCount = this.onlineRepository.getActiveOnlineTransaction(orderId).Count;

                cart = radioOrderCount + brandingOrderCount + pmOrderCount + tvOrderCount + onlineOrderCount;
            }

            session.AddValueToSession(SessionKey.CartNumber, cart);
        }


        public void PendingFulfilment(int userId)
        {
            var scripting = this.orderRepository.GetScriptingFulfilmentPayment(userId).Count;

            var production = this.orderRepository.GetProductionFulfilmentPayment(userId).Count;

            int orderCount = scripting + production;

            session.AddValueToSession(SessionKey.PendingFulfilmentNumber, orderCount);
        }

        /// <summary>
        /// Gets the cart summary.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="MaterialDigitalFileId">The material digital file identifier.</param>
        /// <exception cref="System.ArgumentNullException">view</exception>
        public void ProcessPrintMediaView(IPrintMediaModelView view, HttpPostedFileBase MaterialDigitalFileId)
        {
        }


        /// <summary>
        /// Gets the cart summary.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IOrderSummaryListView GetCartSummary(IOrder order, string message)
        {
            //Get television transaction related to this user
            var tvOrder = this.tvRepository.GetActiveTvTransaction(order.OrderId);

            var onlineOrder = this.onlineRepository.getActiveOnlineTransaction(order.OrderId);

            var radioOrder = this.radioRepository.GetActiveRadioTranasction(order.OrderId);

            //Get The Print Media 
            var pmOrder = this.pmRepository.GetActivePmTransaction(order.OrderId);

            //Get Branding Transaction
            var brandingOrder = this.brandingRepository.getActiveBrandingTransaction(order.OrderId);

            var model = this.orderSummaryFactory.GenerateCartSummary(order, tvOrder, radioOrder, pmOrder, brandingOrder,
                onlineOrder,
                message);

            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string DeleteOrder(int orderId)
        {
            if (orderId < 0)
            {
                throw new ArgumentNullException(nameof(orderId));
            }


            return this.orderRepository.DeleteAllOrder(orderId);
        }


        /// <summary>
        /// Initializes the transaction.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="orderNumber"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public async Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount,
            int orderId)
        {
            var url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);


            var user = this.accountRepository.GetRegistrationByEmail(email);

            if (user == null)
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            //Create The Payment Model 
            var paymentData = new PaymentCallModel
            {
                User = user,
                ReturnUrl = $"{url}{"/Order/TransactionCompleted?orderId="}{orderId}",
                Amount = amount *100,
            };
            return await this.MakePaymentCall(paymentData);
        }


        /// <summary>
        /// Verifies the transaction.
        /// </summary>
        /// <param name="referenceCode">The reference code.</param>
        /// <returns></returns>
        public async Task<TransactionResponseModel> VerifyTransaction(string referenceCode)
        {
            var connectionInstance = new PaystackTransaction("sk_test_8d8ee16467e203041eb380366571f2ea7b5264e6");

            var response = await connectionInstance.VerifyTransaction(referenceCode);

            return response;
        }


        /// <summary>
        /// Processes the payment.
        /// </summary>
        /// <param name="refereneCode">The referene code.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="response">The response.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        public string ProcessPayment(string refereneCode, int orderId, int userId, TransactionResponseModel response)
        {
            var paymentDetails = new PaymentModel
            {
                OrderId = orderId,
                TotalAmount = response.data.amount,
                AmountPaid = response.data.amount,
                ReferenceCode = refereneCode,
                UserId = userId,
            };

            //Store Payment to Database
            var processingMessage = this.generalRepository.SavePaymentTransaction(paymentDetails);


            //Update Order Code
            var message = this.orderRepository.UpdateOrderStatus(orderId, OrderStatus.Paid);


            return processingMessage;
        }


        /// <summary>
        /// Gets the order number information.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="orderId">The order number.</param>
        /// <returns></returns>
        public IOrder GetOrderNumberInfo(int userId, int orderId)
        {
            var orderNumberStatus = this.lookupRepository.GetOrderNumbeStatus(userId, orderId);


            return orderNumberStatus;
        }


        /// <summary>
        /// Gets the order by user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IOrder GetPendingOrderByUserId(int userId)
        {
            var order = this.lookupRepository.GetPendingOrderByUserId(userId);

            return order;
        }

        /// <summary>
        /// Makes the payment call.
        /// </summary>
        /// <param name="paymentData">The payment data.</param>
        /// <returns></returns>
        public async Task<PaymentInitalizationResponseModel> MakePaymentCall(IPaymentCallModel paymentData)
        {



            

            var connectionInstance = new PaystackTransaction("sk_live_68f94a89f314e689129f2d69b6e6caaf6b6b228d");

            var response = await connectionInstance.InitializeTransaction(new TransactionRequestModel()
            {
                firstName = paymentData.User.FirstName,
                lastName = paymentData.User.LastName,
                amount = paymentData.Amount, //TODO : Amount is in KOBO, Mulstiply by 100
                currency = Constants.Currency.Naira,
                email = paymentData.User.Email,
                callback_url = paymentData.ReturnUrl,
                transaction_charge = 10
            });

            return response;
        }
    }
}