using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrintNewsPaperListView
    {
        /// <summary>
        /// Gets or sets the selected print news paper identifier.
        /// </summary>
        /// <value>
        /// The selected print news paper identifier.
        /// </value>
        int SelectedPrintNewsPaperId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the print news paper collection.
        /// </summary>
        /// <value>
        /// The print news paper collection.
        /// </value>
        IList<INewsPaper> PrintNewsPaperCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
