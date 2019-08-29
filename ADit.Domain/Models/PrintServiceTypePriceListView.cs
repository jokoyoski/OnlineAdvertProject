using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class PrintServiceTypePriceListView : IPrintServiceTypePriceListView
    {
        /// <summary>
        /// Gets or sets the selected print service type price identifier.
        /// </summary>
        /// <value>
        /// The selected print service type price identifier.
        /// </value>
        public int SelectedPrintServiceTypePriceId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the print service type price collection.
        /// </summary>
        /// <value>
        /// The print service type price collection.
        /// </value>
        public IList<IPrintServiceTypePrice> PrintServiceTypePriceCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
