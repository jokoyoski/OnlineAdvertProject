using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    public class FulfilmentStatusSummaryModel: IFulfilmentStatusSummaryModel
    {
        /// <summary>
        /// Gets or sets the fulfilment status.
        /// </summary>
        /// <value>
        /// The fulfilment status.
        /// </value>
        public string FulfilmentStatus { get; set; }

        /// <summary>
        /// Gets or sets the fulfilment status description.
        /// </summary>
        /// <value>
        /// The fulfilment status description.
        /// </value>
        public string FulfilmentStatusDescription { get; set; }

        /// <summary>
        /// Gets or sets the orders per status count.
        /// </summary>
        /// <value>
        /// The orders per status count.
        /// </value>
        public int OrdersPerStatusCount { get; set; }


        /// <summary>
        /// Gets or sets the service code.
        /// </summary>
        /// <value>
        /// The service code.
        /// </value>
       public string ServiceDescription { get; set; }
       
    }
}