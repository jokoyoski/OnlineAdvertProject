using System.Collections.Generic;
using ADit.Domain.Models;
using ADit.Interfaces;

namespace ADit.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOrderSummaryFactory" />
    public class OrderSummaryFactory : IOrderSummaryFactory
    {
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
        public IOrderSummaryListView GenerateCartSummary(IOrder order,IList<ITvTransaction> tvOrders,
            IList<IRadioTransaction>radioTransaction, IList<IPrintTransaction> pmOrders,
            IList<IBrandingTransaction>brandingTransaction,
            IList<IOnlineTransaction> onlineOrders,string message)
        {

            var views = new OrderSummaryListView
            {
                TvOrderModel = tvOrders,
                RadioOrderModel = radioTransaction,
                PrintOrderModel = pmOrders,
                BrandOrder = brandingTransaction,
                OnlineOrderModel = onlineOrders,
                processingMessage = message,
                Order = order,
                OrderId = order.OrderId
                
            };
            return views;
        }
        /// <summary>
        /// Gets the fulfilment payments.
        /// </summary>
        /// <param name="scriptingFulfilment">The scripting fulfilment.</param>
        /// <param name="productionFulfilment">The production fulfilment.</param>
        /// <returns></returns>
        public IfulfilmentPaymentListView GetFulfilmentPayments(IList<IFulfilmentPayment>scriptingFulfilment, IList<IFulfilmentPayment> productionFulfilment,string processingMessage)
        {


            var view = new FulfilmentPaymentListView
            {
               
                ProductionFulfilment = productionFulfilment,
                ScriptingFulfilment = scriptingFulfilment,
                procesingMessage=processingMessage,
            };

          return view;
        }

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        public IOrderListView GetOrders(IList<IOrder> orders)
        {
            var order = new OrderListView
            {
                Orders = orders
            };

            return order;
        }

       
    }
}