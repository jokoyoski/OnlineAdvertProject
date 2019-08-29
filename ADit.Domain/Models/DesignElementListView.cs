using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class DesignElementListView : IDesignElementListView
    {
        /// <summary>
        /// Gets or sets the selected design element identifier.
        /// </summary>
        /// <value>
        /// The selected design element identifier.
        /// </value>
        public int SelectedDesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the design element collection.
        /// </summary>
        /// <value>
        /// The design element collection.
        /// </value>
        public IList<IDesignElement> DesignElementCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
