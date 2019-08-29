using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class OrderFulfilmentListView : IOrderFulfilmentListView
    {

        /// <summary>
        /// Gets or sets the order fulfilments.
        /// </summary>
        /// <value>The order fulfilments.</value>
        public IList<IOrderFulfilment> OrderFulfilments { get; set; }

        /// <summary>
        /// Gets or sets the fulfilment status code.
        /// </summary>
        /// <value>
        /// The fulfilment status code.
        /// </value>
        public string FulfilmentStatusCode { get; set; }
    }
}
