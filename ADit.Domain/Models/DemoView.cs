using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class DemoView : IDemoView
    {
        /// <summary>
        /// Gets or sets the station.
        /// </summary>
        /// <value>
        /// The station.
        /// </value>
        public string[] Station { get; set; }
        /// <summary>
        /// Gets or sets the timing.
        /// </summary>
        /// <value>
        /// The timing.
        /// </value>
        public string[] Timing { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public string[] Duration { get; set; }
    }
}