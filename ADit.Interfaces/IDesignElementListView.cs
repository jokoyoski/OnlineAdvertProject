using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDesignElementListView
    {
        /// <summary>
        /// Gets or sets the selected design element identifier.
        /// </summary>
        /// <value>
        /// The selected design element identifier.
        /// </value>
        int SelectedDesignElementId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the design element collection.
        /// </summary>
        /// <value>
        /// The design element collection.
        /// </value>
        IList<IDesignElement> DesignElementCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
