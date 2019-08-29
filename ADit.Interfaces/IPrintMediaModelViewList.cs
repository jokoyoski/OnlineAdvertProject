using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrintMediaModelViewList
    {
        /// <summary>
        /// Gets or sets the selected radio transaction identifier.
        /// </summary>
        /// <value>
        /// The selected radio transaction identifier.
        /// </value>
        int selectedRadioTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string selectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the print collection.
        /// </summary>
        /// <value>
        /// The print collection.
        /// </value>
        IList<IPrintTransaction> printCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing messages.
        /// </summary>
        /// <value>
        /// The processing messages.
        /// </value>
        string ProcessingMessages { get; set; }
    }
}
