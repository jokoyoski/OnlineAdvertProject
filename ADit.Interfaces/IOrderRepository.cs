using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface  IOrderRepository
    {

        /// <summary>
        /// Updates the order payment production fulfilment.
        /// </summary>
        /// <param name="orderpaymentId">The orderpayment identifier.</param>
        /// <param name="refrenceCode">The refrence code.</param>
        /// <returns></returns>
        string updateOrderPaymentProductionFulfilment(int orderpaymentId, string refrenceCode);
        /// <summary>
        /// Updates the order payment scriping fulfilment.
        /// </summary>
        /// <param name="orderpaymentId">The orderpayment identifier.</param>
        /// <param name="refrenceCode">The refrence code.</param>
        /// <returns></returns>
        string updateOrderPaymentScripingFulfilment(int orderpaymentId, string refrenceCode);
        /// <summary>
        /// Gets the scripting fulfilment payment.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IList<IFulfilmentPayment> GetScriptingFulfilmentPayment(int Id);
        /// <summary>
        /// Gets the production fulfilment payment.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IList<IFulfilmentPayment> GetProductionFulfilmentPayment(int Id);
        /// <summary>
        /// Saves the order payment production fulfilment.
        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <returns></returns>
        string saveOrderPaymentProductionFulfilment(IFulfilmentPaymentView fulfilmentPayment);
        /// <summary>
        /// Saves the order payment scriping fulilment.
        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <returns></returns>
        string saveOrderPaymentScripingFulfilment(IFulfilmentPaymentView fulfilmentPayment);
        /// <summary>
        /// Gets the order fulfilment status code.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        IOrderFulfilmentStatus GetOrderFulfilmentStatusCode(string statusCode);
        /// <summary>
        /// Updates the status code.
        /// </summary>
        /// <param name="orderFulfilmentStatusCodeView">The order fulfilment status code view.</param>
        /// <returns></returns>
        string UpdateStatusCode(int transactionId,string currentStatusCode);
        /// <summary>
        /// Gets the order fulfilment by ChangeOrderStatus.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOrderFulfilment GetOrderFulfilmentById(int transactionId);
        /// <summary>
        /// Gets the fulfilment status rule.
        /// </summary>
        /// <returns></returns>
        IList<IFulfilmentStatusRule> GetFulfilmentStatusRule();
        /// <summary>
        /// Gets the fulfilment statuses.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        IList<IOrderFulfilmentStatus> GetFulfilmentStatuses(string statusCode);
        /// Saves the order fulfilment document.
        /// </summary>
        /// <param name="orderFulfilmentActivityView">The order fulfilment activity view.</param>
        /// <param name="OrderFulfilmentActivityId">The order fulfilment activity identifier.</param>
        /// <param name="DigitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        string saveOrderFulfilmentDocument(IOrderFulfilmentActivityView orderFulfilmentActivityView, int OrderFulfilmentActivityId, int DigitalFileId);
     
        /// <summary>
        /// Changes the order status.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        void ChangeOrderStatus(int orderId);
      
        /// <summary>
        /// Gets the order number by order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        IOrder GetOrderNumberByOrderId(int orderId);
        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        IList<IOrder> GetOrders(int UserId);

        /// <summary>
        /// Gets the radio transactions.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>IList&lt;IRadioTransaction&gt;.</returns>
        IList<IRadioTransaction> GetRadioTransactions(int orderId);

        /// <summary>
        /// Gets the tv transactions.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>IList&lt;ITvTransaction&gt;.</returns>
        IList<ITvTransaction> GetTvTransactions(int orderId);

        /// <summary>
        /// Gets the online transactions.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>IList&lt;IOnlineTransaction&gt;.</returns>
        IList<IOnlineTransaction> GetOnlineTransactions(int orderId);

        /// <summary>
        /// Gets the print transactions.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>IList&lt;IPrintTransaction&gt;.</returns>
        IList<IPrintTransaction> GetPrintTransactions(int orderId);

        /// <summary>
        /// Gets the branding transactions.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>IList&lt;IBrandingTransaction&gt;.</returns>
        IList<IBrandingTransaction> GetBrandingTransactions(int orderId);

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>IList&lt;IOrder&gt;.</returns>
        IList<IOrder> GetAllOrders();


        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>processing message</returns>
        string CreateOrder(int userId, out int orderId);

        /// <summary>
        /// Updates the order number.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="orderNumber">The order number.</param>
        /// <returns>processing message</returns>
        string UpdateOrderNumber(int orderId, string orderNumber);

        /// <summary>
        /// Updates the ordertatus.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>System.String.</returns>
        string UpdateOrderStatus(int orderId, string status);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        string DeleteAllOrder(int orderId);
    }
}
