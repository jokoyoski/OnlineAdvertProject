using System.Collections.Generic;
using ADit.Interfaces;

namespace ADit.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOrderListView" />
    public class OrderListView : IOrderListView
    {
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public IList<IOrder> Orders { get; set; }
    }
}