using AA.Infrastructure.Interfaces;
using AA.Infrastructure.Models;
using ADit.Domain.Models;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using PayStackDotNetSDK.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace ADit.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IFulfilmentService" />
    public class FulfilmentService : IFulfilmentService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IPrintRepository printRepository;
        private readonly ITvRepository tvRepository;
        private readonly IOnlineRepository onlineRepository;
        private readonly IOrderSummaryFactory orderSummaryFactory;
        private readonly IBrandingRepository brandingRepository;
        private readonly IOrderServices orderServices;
        private readonly IFulfilmentRepository fulfilmentRepository;
        private readonly IFulfilmentFactory fulfilmentFactory;
        private readonly IEmailFactory emailFactory;
        private readonly IEnvironment environment;
        private readonly IRadioRepository radioRepository;
        private readonly IEmail emailService;
        private readonly ILookupRepository lookupRepository;
        private readonly IDigitalFileRepository digitalFileRepository;
        private readonly IDigitalFileServices digitalFileServices;
        private readonly IAccountRepository accountRepository;
        private readonly ITransactionService transactionService;
        private readonly ISessionStateService session;

        public FulfilmentService(IOrderRepository orderRepository, ITvRepository tvRepository,
            IPrintRepository printRepository, IDigitalFileRepository digitalFileRepository,
            IOnlineRepository onlineRepository, IOrderServices orderServices, IEnvironment environment,
            IFulfilmentRepository fulfilmentRepository,
            ILookupRepository lookupRepository, IEmail emailService,
            IEmailFactory emailFactory, IAccountRepository accountRepository, IBrandingRepository brandingRepository,
            IRadioRepository radioRepository, IFulfilmentFactory fulfilmentFactory,
            IOrderSummaryFactory orderSummaryFactory,
            IDigitalFileServices digitalFileServices, ITransactionService transactionService, ISessionStateService session)
        {
            this.lookupRepository = lookupRepository;
            this.orderRepository = orderRepository;
            this.emailFactory = emailFactory;
            this.orderSummaryFactory = orderSummaryFactory;
            this.emailFactory = emailFactory;
            this.emailService = emailService;
            this.environment = environment;
            this.accountRepository = accountRepository;
            this.digitalFileServices = digitalFileServices;
            this.fulfilmentRepository = fulfilmentRepository;
            this.fulfilmentFactory = fulfilmentFactory;
            this.radioRepository = radioRepository;
            this.orderServices = orderServices;
            this.onlineRepository = onlineRepository;
            this.brandingRepository = brandingRepository;
            this.digitalFileRepository = digitalFileRepository;
            this.tvRepository = tvRepository;
            this.printRepository = printRepository;
            this.transactionService = transactionService;
            this.session = session;
        }

        /// <summary>
        /// Gets the fulfilment summary.
        /// </summary>
        /// <returns></returns>
        public IFulfilmentStatusSummaryViewModel GetFulfilmentSummary()
        {
            var fulfilmentSummary = fulfilmentRepository.GetFulfilmentStatusSummary();

            return fulfilmentFactory.CreateFulfilmentSummary(fulfilmentSummary);
        }

        /// <summary>
        /// Gets the fulfilment order by fulfilment identifier.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns>IOrderFulfilment.</returns>
        public IOrderFulfilment GetFulfilmentOrderByFulfilmentId(int orderFulfilmentId)
        {
            var aFulfilment = this.fulfilmentRepository.GetFulfilmentOrderByFulfilmentId(orderFulfilmentId);

            return aFulfilment;
        }

        /// <summary>
        /// Picks the order.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="isSendMail">if set to <c>true</c> [is send mail].</param>
        /// <param name="createdByUserId">The created by user identifier.</param>
        /// <returns>System.String.</returns>
        public string PickOrder(int orderFulfilmentId, bool isSendMail, int createdByUserId)
        {
            var result = string.Empty;

            //Get userID
            var userId = (int)session.GetSessionValue(SessionKey.UserId);
            var customerEmail = this.accountRepository.GetUserId(createdByUserId).Email;

            //change order status to Scripting from Submitted
            var toStatus = FulfilmentStatus.Scripting;
            var processingMessage = this.fulfilmentRepository.ChangeOrderStatus(orderFulfilmentId, toStatus, userId);

            //if it is sendmail , send mail to customer that order is assigned and ready for processing
            if (isSendMail)
            {
                // email send implementation here
                var emailDetail = this.emailFactory.CreatePickOrderEmail(orderFulfilmentId,customerEmail);

                var emailKey = this.environment[EnvironmentValues.EmailKey];

                this.emailService.Send(emailKey, "team@aditng.com", "Adit Team", emailDetail.Subject, emailDetail.Recipients,
                    emailDetail.Recipients, "", emailDetail.Body);
            }

            //log user activity activity
            var theActivity = "Order picked";
            this.accountRepository.LogUserActivity(userId.ToString(), theActivity, orderFulfilmentId.ToString());

            return result;
        }
        
        /// <summary>
        /// Gets the fulfilment service summary.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        public IFulfilmentServiceSummaryView GetFulfilmentServiceSummary(string statusCode)
        {
            var fulfilmentSummary = fulfilmentRepository.GetFulfilmentServiceSummaryByStatusCode(statusCode);

            return fulfilmentFactory.CreateFulfilmentServiceSummary(fulfilmentSummary);
        }

        /// <summary>
        /// Sends the new fulfilmnet email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="totalAmount">The total amount.</param>
        /// <param name="paymentPurpose">The payment purpose.</param>
        public void SendNewFulfilmnetEmail(string email, int totalAmount, string paymentPurpose)
        {

            //TODO: why send email to everybody?

            //Get All Contact from the Contact table to receive the New Order Mail
            var emailList = lookupRepository.GetContactList();

            foreach (var j in emailList)
            {
                // email send implementation here
                var emailDetail = emailFactory.CreateAdminFulfilmentPayment(email, totalAmount,paymentPurpose); 
                var emailKey = environment[EnvironmentValues.EmailKey];

                emailService.Send(emailKey, "admin@automataassociates.com", "ADit Team", emailDetail.Subject,
                    emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);
            }
        }


        /// <summary>
        /// Updates the fulfilment scripting.
        /// </summary>
        /// <param name="orderPaymentId">The order payment identifier.</param>
        /// <param name="refrenceCode">The refrence code.</param>
        /// <returns></returns>
        public string UpdateFulfilmentScripting(int orderPaymentId, string refrenceCode)
        {
            return orderRepository.updateOrderPaymentScripingFulfilment(orderPaymentId, refrenceCode);
        }

        /// <summary>
        /// Updates the fulfilment production.
        /// </summary>
        /// <param name="orderPaymentId">The order payment identifier.</param>
        /// <param name="refrenceCode">The refrence code.</param>
        /// <returns></returns>
        public string UpdateFulfilmentProduction(int orderPaymentId, string refrenceCode)
        {
            return orderRepository.updateOrderPaymentProductionFulfilment(orderPaymentId, refrenceCode);
        }

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <returns>IOrderListView.</returns>
        public IOrderFulfilmentListView GetFulfilmentOrders(string fufilmentCode)
        {
            var orders = string.IsNullOrEmpty(fufilmentCode)
                ? fulfilmentRepository.GetFulfilmentOrders()
                : fulfilmentRepository.GetFulfilmentOrdersByCode(fufilmentCode);

            return fulfilmentFactory.GetOrderFufilments(orders);
        }

        /// <summary>
        /// Gets the fulfilment orders.
        /// </summary>
        /// <param name="scriptingStatusList">The scripting status list.</param>
        /// <returns>IOrderFulfilmentListView.</returns>
        public IOrderFulfilmentListView GetFulfilmentOrders(IList<string> scriptingStatusList)
        {
            if (scriptingStatusList == null)
            {
                throw new ArgumentNullException(nameof(scriptingStatusList));
            }

            var orders = this.fulfilmentRepository.GetFulfilmentOrdersByCode(scriptingStatusList);

            var orderFulfilmentListViewModel = this.fulfilmentFactory.GetOrderFufilments(orders);

            return orderFulfilmentListViewModel;
        }



        /// <summary>
        /// </summary>
        /// <param name="orderFulfilmentActivity"></param>
        /// <param name="fileBase"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">orderFulfilmentActivity</exception>
        /// <!-- Badly formed XML comment ignored for member "M:ADit.Interfaces.IOrderServices.SaveOrderFulfilment(ADit.Interfaces.IOrderFulfilmentActivityView,System.Web.HttpPostedFileBase)" -->
        public string SaveOrderFulfilment(IOrderFulfilmentActivityView orderFulfilmentActivity,
            HttpPostedFileBase fileBase)
        {
            if (orderFulfilmentActivity == null)
            {
                throw new ArgumentNullException(nameof(orderFulfilmentActivity));
            }

            int DigitalFileId = 0;
            var attachmentList = new List<IStagedAttachment>();

            //Updating Status and Storing Fulfilment Activity

            orderFulfilmentActivity.FromStatus = orderFulfilmentActivity.currentStatusCode; //from status
            orderFulfilmentActivity.ToStatus = orderFulfilmentActivity.FulfilmentStatusCode; //tostatus

            var orderActivity =
                fulfilmentRepository.SaveOrderFulfilment(orderFulfilmentActivity, out int OrderActivityId);


            if (!string.IsNullOrEmpty(orderFulfilmentActivity.MailMessage) && string.IsNullOrEmpty(orderActivity))

            {
                //Store User Upload
                if (fileBase != null)
                {
                    digitalFileServices.SaveFile(FileType.Image, fileBase, out DigitalFileId);
                    if (DigitalFileId > 0) //we do not need to call this function if a user does not upload
                    {
                        orderRepository.saveOrderFulfilmentDocument(orderFulfilmentActivity, OrderActivityId,
                            DigitalFileId);

                        var fileContent = digitalFileRepository.GetDigitalFileDetail(DigitalFileId); //get the file by Id

                        var aContent = new byte[10]; // this is just sample
                        var anAttachment = new StagedAttachment
                        {
                            ContentType = fileContent.ContentType,
                            Filename = fileContent.Filename,
                            TheContent = fileContent.FileContent,
                        };

                        attachmentList.Add(anAttachment);

                    }
                }

                var userDetails = lookupRepository.GetUserDetails(orderFulfilmentActivity.CreatedByUserId);

                var emailDetail = emailFactory.SendFulfilmentMail(orderFulfilmentActivity,
                    $"{userDetails.FirstName} {userDetails.LastName}",
                    userDetails.Email);

                var emailKey = environment[EnvironmentValues.EmailKey];

                emailService.Send(emailKey, "admin@aditng.com", "ADit ",
                    emailDetail.Subject, emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body, attachmentList);
            }

            //Update Status Code in Order Fulfilment Table
            orderRepository.UpdateStatusCode(orderFulfilmentActivity.OrderFulfilmentId,
                orderFulfilmentActivity.FulfilmentStatusCode);


            return orderActivity;
        }

        /// <summary>
        /// Saves the scripting fulfilment payment.
        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">fulfilPayment</exception>
        public string SaveScriptingFulfilmentPayment(IFulfilmentPaymentView fulfilmentPayment)
        {
            if (fulfilmentPayment == null)
            {
                throw new ArgumentNullException("fulfilPayment");
            }

            var userDetails = lookupRepository.GetUserDetails(fulfilmentPayment.UserId);
            var orderDetails = orderRepository.GetOrderNumberByOrderId(fulfilmentPayment.OrderId);

            var emailDetail = emailFactory.SendScriptingFulfilmentPaymentMail(fulfilmentPayment,
                userDetails.FirstName, userDetails.Email, orderDetails.OrderNumber);

            var emailKey = environment[EnvironmentValues.EmailKey];

            emailService.Send(emailKey, "admin@automataAssociates.com", "ADit Administrator", emailDetail.Subject,
                emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);


            return orderRepository.saveOrderPaymentScripingFulfilment(fulfilmentPayment);
        }

        /// <summary>
        /// Saves the production fulfilment payment.
        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">fulfilPayment</exception>
        public string SaveProductionFulfilmentPayment(IFulfilmentPaymentView fulfilmentPayment)
        {
            if (fulfilmentPayment == null)
            {
                throw new ArgumentNullException("fulfilPayment");
            }

            var userDetails = lookupRepository.GetUserDetails(fulfilmentPayment.UserId);
            var orderDetails = orderRepository.GetOrderNumberByOrderId(fulfilmentPayment.OrderId);

            var emailDetail = emailFactory.SendScriptingFulfilmentPaymentMail(fulfilmentPayment,
                userDetails.FirstName, userDetails.Email, orderDetails.OrderNumber);

            var emailKey = environment[EnvironmentValues.EmailKey];

            emailService.Send(emailKey, "admin@automataAssociates.com", "ADit Administrator", emailDetail.Subject,
                emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);


            return orderRepository.saveOrderPaymentProductionFulfilment(fulfilmentPayment);
        }

        /// <summary>
        /// Gets the fulfilment online transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IOnlineView GetFulfilmentOnlineTransaction(int orderFulfilmentId, string processingMessage)
        {
            var orderInFulfilment = orderRepository.GetOrderFulfilmentById(orderFulfilmentId);

            //Get Online Order
            var onlineOrder =
                onlineRepository.GetUserOnlineOrderById(orderInFulfilment.ServiceTransactionId);


            // var onlineAttachmentTransaction = this.onlineRepository.GetOnlineAttachmentTransactionById(userId, transactionId);
            var onlneAiringTransaction = onlineRepository.GetOnlineTransactionAiring(orderInFulfilment.ServiceTransactionId);
            var onlineTransactionExtraService =
                onlineRepository.GetOnlineExtraServiceTransactionById(orderInFulfilment.ServiceTransactionId);

            orderServices.ChangeOrderStatus(orderInFulfilment.OrderId); //changes the order status



            var orderFulfilmentStatus = orderRepository.GetFulfilmentStatuses(orderInFulfilment.OrderStatusCode);


            return fulfilmentFactory.GetFulfilmentOnlineTransaction(onlineOrder, onlneAiringTransaction,
                onlineTransactionExtraService, orderFulfilmentStatus, orderInFulfilment.FufilmentStatusCode, orderInFulfilment.FufilmentStatusDescription,
                orderInFulfilment.OrderFulfilmentId);
        }

        /// <summary>
        /// Gets the user branding view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        public IBrandingView GetFulfilmentBrandingView(int orderFulfilmentId, string processingMessage)
        {
            var orderInFulfilment = orderRepository.GetOrderFulfilmentById(orderFulfilmentId);

            var brandingTransaction = brandingRepository.GetTransactionDetails(orderInFulfilment.ServiceTransactionId);
            var brandingAttachmentTransaction =
                brandingRepository.GetBrandingAttachmentTransactionsById(orderInFulfilment.ServiceTransactionId);
            var brandingColor = brandingRepository.GetSelectedColor(orderInFulfilment.ServiceTransactionId);
            var bradningDesignTransaction =
                brandingRepository.GetBrandingTransactionDesignElementById(orderInFulfilment.ServiceTransactionId);
            var brandingMaterialTransaction =
                brandingRepository.GetIBrandingTransactionMaterialById(orderInFulfilment.ServiceTransactionId);

            orderServices.ChangeOrderStatus(orderInFulfilment.OrderId); //changes the order status



            var orderFulfilmentStatus = orderRepository.GetFulfilmentStatuses(orderInFulfilment.OrderStatusCode);

            var digitalFile =
                digitalFileRepository.GetDigitalFileDetail(brandingTransaction.BrandingFileId ?? -1);
            return fulfilmentFactory.GetFulfilmentBrandingTransaction(brandingTransaction, brandingColor,
                brandingAttachmentTransaction, bradningDesignTransaction, brandingMaterialTransaction, digitalFile,
                orderFulfilmentStatus, orderInFulfilment.FufilmentStatusCode, orderInFulfilment.FufilmentStatusDescription, orderInFulfilment.OrderFulfilmentId);
        }

        /// <summary>
        /// Gets the tv user transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public ITvView GetFulfilmentTvTransaction(int orderFulfilmentId, string processingMessage)
        {
            var orderInFulfilment = orderRepository.GetOrderFulfilmentById(orderFulfilmentId);

            //Get Radio Order
            var tvOrder = tvRepository.GetUserTvOrderById(orderInFulfilment.ServiceTransactionId
            ); // The the Selected Transaction from the Repos
            var materialType = lookupRepository.GetMaterialType();
            //Get Radio Airing Details
            var radioAiringDetails = tvRepository.GetTvTransactionAiring(tvOrder.TvTransactionId);
            orderServices.ChangeOrderStatus(orderInFulfilment.OrderId); //changes the order status


            var orderFulfilmentStatus = orderRepository.GetFulfilmentStatuses(orderInFulfilment.OrderStatusCode);
            return fulfilmentFactory.GetFulfimentTransaction(tvOrder, radioAiringDetails, materialType,
                orderFulfilmentStatus, orderInFulfilment.FufilmentStatusCode, orderInFulfilment.FufilmentStatusDescription, orderInFulfilment.OrderFulfilmentId);
        }


        /// <summary>
        /// Gets the fufillment print transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public IPrintMediaModelView GetFufillmentPrintTransaction(int orderFulfilmentId, string processingMessage)
        {

            var orderInFulfilment = orderRepository.GetOrderFulfilmentById(orderFulfilmentId);

            var printTransaction = printRepository.GetPrintTransactionById(orderInFulfilment.ServiceTransactionId);
            var printAiringTransaction = printRepository.GetPrintTransactionAiringById(orderInFulfilment.ServiceTransactionId);

            orderServices.ChangeOrderStatus(orderInFulfilment.OrderId); //changes the order status


            var orderFulfilmentStatus = orderRepository.GetFulfilmentStatuses(orderInFulfilment.OrderStatusCode);

            return fulfilmentFactory.GetFufillmentPrintTransaction(printTransaction, printAiringTransaction,
                orderFulfilmentStatus, orderInFulfilment.FufilmentStatusCode, orderInFulfilment.FufilmentStatusDescription, orderInFulfilment.OrderFulfilmentId);
        }

        /// <summary>
        /// Initializes the transaction.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public async Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount,
           int orderId, string paymentPurpose)
        {

            var url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

            var user = accountRepository.GetRegistrationByEmail(email);
            if (user == null)
            {
                throw new System.ArgumentNullException(nameof(user));
            }


            //Create The Payment Model 
            var paymentData = new PaymentCallModel
            {
                User = user,
                ReturnUrl = $"{url}{"/Fulfilment/FulfilmentCompleted?orderId="}{orderId}{"&paymentPurpose="}{paymentPurpose}",
                Amount = amount,
            };
            return await transactionService.MakePaymentCall(paymentData);


        }





    }
}