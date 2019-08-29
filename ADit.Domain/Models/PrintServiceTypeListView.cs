using System.Collections.Generic;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
   public class PrintServiceTypeListView : IPrintServiceTypeListView
    {
        /// <summary>
        /// Gets or sets the selected print service type identifier.
        /// </summary>
        /// <value>
        /// The selected print service type identifier.
        /// </value>
        public int SelectedPrintServiceTypeId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the print service type collection.
        /// </summary>
        /// <value>
        /// The print service type collection.
        /// </value>
        public IList<IPrintServiceType> PrintServiceTypeCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
