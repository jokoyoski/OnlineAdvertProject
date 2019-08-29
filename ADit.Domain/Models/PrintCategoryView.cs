using System;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class PrintCategoryView : IPrintCategoryView
    {
        /// <summary>
        /// Gets or sets the print category identifier.
        /// </summary>
        /// <value>
        /// The print category identifier.
        /// </value>
        public int PrintCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
