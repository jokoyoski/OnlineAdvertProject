using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class RadioStationListView : IRadioSationListView
    {
        /// <summary>
        /// Gets or sets the selected radio station identifier.
        /// </summary>
        /// <value>
        /// The selected radio station identifier.
        /// </value>
        public int SelectedRadioStationId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the radio station collection.
        /// </summary>
        /// <value>
        /// The radio station collection.
        /// </value>
        public IList<IRadioStationModel> RadioStationCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
