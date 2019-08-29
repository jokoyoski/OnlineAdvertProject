using AA.Infrastructure.Interfaces;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using System;
using System.Collections.Generic;
using System.Web;

namespace ADit.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOrderServices" />
    public class OrderServices : IOrderServices
    {
        /// <summary>
        /// The order repository
        /// </summary>
        private readonly IOrderRepository orderRepository;
        private readonly IOrderSummaryFactory orderSummaryFactory;
        private readonly IEmailFactory emailFactory;
        private readonly IEnvironment environment;
        private readonly IEmail emailService;
        private readonly ILookupRepository lookupRepository;
        private readonly IDigitalFileServices digitalFileServices;
        private readonly IAccountRepository accountRepository;

        public OrderServices(IOrderRepository orderRepository, IEnvironment environment,
            ILookupRepository lookupRepository, IEmail emailService,
            IEmailFactory emailFactory, IAccountRepository accountRepository, IOrderSummaryFactory orderSummaryFactory,
            IDigitalFileServices digitalFileServices)
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
        }

        /// <summary>
        /// Gets the order number by order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public IOrder GetOrderNumberByOrderId(int orderId)
        {
            return this.lookupRepository.GetOrderNumberByOrderId(orderId);
        }
        
        /// <summary>
        /// Gets the pending fulfilment payment.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IfulfilmentPaymentListView GetPendingFulfilmentPayment(int userId,string processingMessage)
        {
            var scripting = this.orderRepository.GetScriptingFulfilmentPayment(userId);

            var production = this.orderRepository.GetProductionFulfilmentPayment(userId);


            return this.orderSummaryFactory.GetFulfilmentPayments(scripting, production,processingMessage);
            //  return this
        }

        /// <summary>
        /// Gets the order identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>System.Int32.</returns>
        public int GetOrderIdentifier(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentOutOfRangeException("userId");
            }

            // get pending order for user
            var order = this.lookupRepository.GetPendingOrderByUserId(userId);

            // if pending order exist then return the orderId
            if (order != null)
            {
                return order.OrderId;
            }

            // Create order and return OrderId
            this.orderRepository.CreateOrder(userId, out var orderId);

            // generate Order Number and  update Order record
            var paddedUserId = userId.ToString().PadLeft(5, '0');
            var paddedOrderId = orderId.ToString().PadLeft(6, '0');
            var orderNumber = $"{paddedUserId}-{paddedOrderId}";
            this.orderRepository.UpdateOrderNumber(orderId, orderNumber);

            return orderId;
        }

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IOrderListView GetOrders(int userId)
        {
            var order = this.orderRepository.GetOrders(userId);

            return this.orderSummaryFactory.GetOrders(order);
        }


       

        /// <summary>
        /// Changes the order status.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="OrderId">The order identifier.</param>
        public void ChangeOrderStatus(int orderId)
        {
            this.orderRepository.ChangeOrderStatus(orderId);
        }


        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <returns>IOrderListView.</returns>
        public IOrderListView GetAllOrders()
        {
            var orders = this.orderRepository.GetAllOrders();

            return this.orderSummaryFactory.GetOrders(orders);
        }


        public void SendNewOrderEmail(string email, int totalAmount, string orderNumber)
        {
            //Get All Contact from the Contact table to receive the New Order Mail
            var emailList = this.lookupRepository.GetContactList();

            foreach (var j in emailList)
            {
                // email send implementation here
                var emailDetail =
                    this.emailFactory.CreateSendEmailToAdmin(orderNumber, email, "", j.Email,
                        "Order"); //999 is the registrationId from database

                var emailKey = this.environment[EnvironmentValues.EmailKey];

                this.emailService.Send(emailKey, "admin@automataassociates.com", "ADit Team", emailDetail.Subject,
                    emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);
            }
        }


       

      
    }
}