using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioSationListView
    {
        /// <summary>
        /// Gets or sets the selected radio station identifier.
        /// </summary>
        /// <value>
        /// The selected radio station identifier.
        /// </value>
        int SelectedRadioStationId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the radio station collection.
        /// </summary>
        /// <value>
        /// The radio station collection.
        /// </value>
        IList<IRadioStationModel> RadioStationCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
