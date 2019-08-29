using System.Collections.Generic;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
   public class NewsPaperListView
    {
        /// <summary>
        /// Gets or sets the selected print news paper identifier.
        /// </summary>
        /// <value>
        /// The selected print news paper identifier.
        /// </value>
        public string SelectedPrintNewsPaperId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the print news paper collection.
        /// </summary>
        /// <value>
        /// The print news paper collection.
        /// </value>
        public IList<INewsPaper> PrintNewsPaperCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

    }
}
