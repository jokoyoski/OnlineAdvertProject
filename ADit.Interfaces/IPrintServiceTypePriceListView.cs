using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrintServiceTypePriceListView
    {
        /// <summary>
        /// Gets or sets the selected print service type price identifier.
        /// </summary>
        /// <value>
        /// The selected print service type price identifier.
        /// </value>
        int SelectedPrintServiceTypePriceId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the print service type price collection.
        /// </summary>
        /// <value>
        /// The print service type price collection.
        /// </value>
        IList<IPrintServiceTypePrice> PrintServiceTypePriceCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
