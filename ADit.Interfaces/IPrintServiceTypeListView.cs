using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrintServiceTypeListView
    {
        /// <summary>
        /// Gets or sets the selected print service type identifier.
        /// </summary>
        /// <value>
        /// The selected print service type identifier.
        /// </value>
        int SelectedPrintServiceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the print service type collection.
        /// </summary>
        /// <value>
        /// The print service type collection.
        /// </value>
        IList<IPrintServiceType> PrintServiceTypeCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
