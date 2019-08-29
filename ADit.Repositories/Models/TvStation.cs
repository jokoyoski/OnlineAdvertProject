using ADit.Interfaces;

namespace ADit.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITvStation" />
    public class TvStationModel :ITvStation
    {
        /// <summary>
        /// Gets or sets the tv station identifier.
        /// </summary>
        /// <value>
        /// The tv station identifier.
        /// </value>
        public int TVStationId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
