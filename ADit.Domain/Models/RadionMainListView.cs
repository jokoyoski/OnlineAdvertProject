using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class RadionMainListView : IRadioMainListView
    {
        /// <summary>
        /// Gets or sets the radio collection.
        /// </summary>
        /// <value>
        /// The radio collection.
        /// </value>
        public IList<IRadioTransaction> radioCollection { get; set; }
        /// <summary>
        /// Gets or sets the selected transaction identifier.
        /// </summary>
        /// <value>
        /// The selected transaction identifier.
        /// </value>
        public int SelectedTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the selected transaction code.
        /// </summary>
        /// <value>
        /// The selected transaction code.
        /// </value>
        public string SelectedTransactionCode { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
