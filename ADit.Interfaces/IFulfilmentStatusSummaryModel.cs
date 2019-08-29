namespace ADit.Interfaces
{
    public interface IFulfilmentStatusSummaryModel
    {
        /// <summary>
        /// Gets or sets the fulfilment status.
        /// </summary>
        /// <value>
        /// The fulfilment status.
        /// </value>
        string FulfilmentStatus { get; set; }


        /// <summary>
        /// Gets or sets the fulfilment status description.
        /// </summary>
        /// <value>
        /// The fulfilment status description.
        /// </value>
        string FulfilmentStatusDescription { get; set; }


        /// <summary>
        /// Gets or sets the orders per status count.
        /// </summary>
        /// <value>
        /// The orders per status count.
        /// </value>
        int OrdersPerStatusCount { get; set; }

        /// <summary>
        /// Gets or sets the service code.
        /// </summary>
        /// <value>
        /// The service code.
        /// </value>
        string ServiceDescription { get; set; }


       
    }
}