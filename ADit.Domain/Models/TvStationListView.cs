using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class TvStationListView :ITvStationListView
    {

        /// <summary>
        /// Gets or sets the selected branding material identifier.
        /// </summary>
        /// <value>
        /// The selected branding material identifier.
        /// </value>
      public  int SelectedTvStationId { get; set; }

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
       public IList<ITvStation> TvStationCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
      public  string ProcessingMessage { get; set; }
    }
}
