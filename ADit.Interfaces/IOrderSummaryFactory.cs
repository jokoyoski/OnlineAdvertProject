using System.Collections.Generic;


namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>fGetFulfilmentPayments
    public interface IOrderSummaryFactory
    {
        /// <summary>
        /// Gets the fulfilment payments.
        /// </summary>
        /// <param name="scriptingFulfilment">The scripting fulfilment.</param>
        /// <param name="productionFulfilment">The production fulfilment.</param>
        /// <returns></returns>
        IfulfilmentPaymentListView GetFulfilmentPayments(IList<IFulfilmentPayment> scriptingFulfilment, IList<IFulfilmentPayment> productionFulfilment,string processingMessage);
        
           
        /// <summary>
        /// Generates the cart summary.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="tvOrders">The tv orders.</param>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <param name="pmOrders">The pm orders.</param>
        /// <param name="brandingTransaction">The branding transaction.</param>
        /// <param name="onlineOrders">The online orders.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOrderSummaryListView GenerateCartSummary(IOrder order, IList<ITvTransaction> tvOrders,
            IList<IRadioTransaction> radioTransaction, IList<IPrintTransaction> pmOrders,
            IList<IBrandingTransaction> brandingTransaction,
            IList<IOnlineTransaction> onlineOrders, string message);



        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        IOrderListView GetOrders(IList<IOrder> orders);


    }
}