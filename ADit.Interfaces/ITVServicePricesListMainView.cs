using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface   ITVServicePricesListMainView
    {
        /// <summary>
        /// Gets or sets the t v service prices list collection.
        /// </summary>
        /// <value>
        /// The t v service prices list collection.
        /// </value>
        IList<ITVServicePricesList> tVServicePricesListCollection { get; set; }
        /// <summary>
        /// Gets or sets the selected tv services price identifier.
        /// </summary>
        /// <value>
        /// The selected tv services price identifier.
        /// </value>
        int SelectedTvServicesPriceId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string selectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string processingMessage { get; set; }
    }
}
