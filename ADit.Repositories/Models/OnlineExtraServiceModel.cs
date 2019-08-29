using ADit.Interfaces;

namespace ADit.Repositories.Models
{
  public class OnlineExtraServiceModel : IOnlineExtraService
    {
        /// <summary>
        /// Gets or sets the online extra service identifier.
        /// </summary>
        /// <value>
        /// The online extra service identifier.
        /// </value>
        public int OnlineExtraServiceId { get; set; }
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
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
