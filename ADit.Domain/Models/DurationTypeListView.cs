using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
   public class DurationTypeListView :IDurationTypeListView
    {
        /// <summary>
        /// Gets or sets the selected branding material identifier.
        /// </summary>
        /// <value>
        /// The selected branding material identifier.
        /// </value>
        public string SelectedDurationTypeId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the branding material collection.
        /// </summary>
        /// <value>
        /// The branding material collection.
        /// </value>
        public IList<IDurationType> DurationTypeCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
        public string ProcessingMessage { get; set; }
    }
}
    

