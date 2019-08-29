using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IOrderFulfilmentListView
    {
        /// <summary>
        /// Gets or sets the fulfilment status code.
        /// </summary>
        /// <value>
        /// The fulfilment status code.
        /// </value>
        string FulfilmentStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the order fulfilments.
        /// </summary>
        /// <value>The order fulfilments.</value>
        IList<IOrderFulfilment> OrderFulfilments { get; set; }

    }
}
