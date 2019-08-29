using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
  public  class TimeBeltListView :ITimeBeltListView
    {
        /// <summary>
        /// Gets or sets the get time belts list.
        /// </summary>
        /// <value>
        /// The get time belts list.
        /// </value>
        public IList<ITimeBelt> GetTimeBeltsList { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string selectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the selected identifier.
        /// </summary>
        /// <value>
        /// The selected identifier.
        /// </value>
        public string selectedId { get; set; }
    }
}
