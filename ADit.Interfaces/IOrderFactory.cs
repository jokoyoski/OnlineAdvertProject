using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrderFactory
    {
        /// <summary>
        /// Gets the order summary ListView.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        IOrderSummaryListView GetOrderSummaryListView(IList<IOrder> orders);
    }
}
