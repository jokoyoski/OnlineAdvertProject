using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrintCategoryListView
    {
        /// <summary>
        /// Gets or sets the selected print category identifier.
        /// </summary>
        /// <value>
        /// The selected print category identifier.
        /// </value>
        int SelectedPrintCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the print category collection.
        /// </summary>
        /// <value>
        /// The print category collection.
        /// </value>
        IList<IPrintCategory> PrintCategoryCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
