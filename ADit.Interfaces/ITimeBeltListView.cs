using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITimeBeltListView
    {
        /// <summary>
        /// Gets or sets the get time belts list.
        /// </summary>
        /// <value>
        /// The get time belts list.
        /// </value>
        IList<ITimeBelt> GetTimeBeltsList { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string selectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the selected identifier.
        /// </summary>
        /// <value>
        /// The selected identifier.
        /// </value>
        string selectedId { get; set; }

    }
}
