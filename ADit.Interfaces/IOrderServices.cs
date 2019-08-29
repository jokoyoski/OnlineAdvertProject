using System.Collections.Generic;
using System.Web;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public 
        interface IOrderServices
   {
        
        
        /// <summary>
        /// Gets the pending fulfilment payment.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IfulfilmentPaymentListView GetPendingFulfilmentPayment(int userId,string processingMessage);
        
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="OrderId">The order identifier.</param>
        void ChangeOrderStatus( int orderId);
       
        /// Gets the order number by order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        IOrder GetOrderNumberByOrderId(int orderId);
        /// <summary>
        /// Gets the order identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int GetOrderIdentifier(int userId);

        /// <summary>
        /// Sends the new order email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="totalAmount">The total amount.</param>
        /// <param name="OrderNumber">The order number.</param>
        void SendNewOrderEmail(string email, int totalAmount, string OrderNumber);

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// IOrderListView.
        /// </returns>
        IOrderListView GetOrders(int userId);

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>
        /// IOrderListView.
        /// </returns>
        IOrderListView GetAllOrders();
    }
}
