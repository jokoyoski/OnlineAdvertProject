using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioMainListView
    {
        /// <summary>
        /// Gets or sets the radio collection.
        /// </summary>
        /// <value>
        /// The radio collection.
        /// </value>
        IList<IRadioTransaction> radioCollection { get; set; }

        /// <summary>
        /// Gets or sets the selected transaction identifier.
        /// </summary>
        /// <value>
        /// The selected transaction identifier.
        /// </value>
        int SelectedTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the selected transaction code.
        /// </summary>
        /// <value>
        /// The selected transaction code.
        /// </value>
        string SelectedTransactionCode { get; set; }




        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
