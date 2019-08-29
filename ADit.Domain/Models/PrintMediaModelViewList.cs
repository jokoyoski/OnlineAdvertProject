using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class PrintMediaModelViewList : IPrintMediaModelViewList
    {
        /// <summary>
        /// Gets or sets the selected radio transaction identifier.
        /// </summary>
        /// <value>
        /// The selected radio transaction identifier.
        /// </value>
        public int selectedRadioTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string selectedDescription { get; set; } 
            /// <summary>
            /// 
            /// </summary>
        public IList<IPrintTransaction> printCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing messages.
        /// </summary>
        /// <value>
        /// The processing messages.
        /// </value>
        public string ProcessingMessages { get; set; }

    }
}
