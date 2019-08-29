using System.Collections.Generic;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
   public class PrintCategoryListView : IPrintCategoryListView
    {
        /// <summary>
        /// Gets or sets the selected print category identifier.
        /// </summary>
        /// <value>
        /// The selected print category identifier.
        /// </value>
        public int SelectedPrintCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the print category collection.
        /// </summary>
        /// <value>
        /// The print category collection.
        /// </value>
        public IList<IPrintCategory> PrintCategoryCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
