using System.Collections.Generic;

namespace ADit.Interfaces
{
   public  interface ITvStationListView
    {
        /// <summary>
        /// Gets or sets the selected branding material identifier.
        /// </summary>
        /// <value>
        /// The selected branding material identifier.
        /// </value>
        int SelectedTvStationId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }

        /// <summary>
        /// Gets or sets the branding material collection.
        /// </summary>
        /// <value>
        /// The branding material collection.
        /// </value>
        IList<ITvStation> TvStationCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
        string ProcessingMessage { get; set; }
    }
}
