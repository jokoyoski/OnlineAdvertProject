using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineTransactionAiringView
    {
        /// <summary>
        /// Gets or sets the online transaction airing identifier.
        /// </summary>
        /// <value>
        /// The online transaction airing identifier.
        /// </value>
        int OnlineTransactionAiringId { get; set; }
        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        int OnlineTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the platform identifier.
        /// </summary>
        /// <value>
        /// The platform identifier.
        /// </value>
        int PlatformId { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        int Duration { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the platform list.
        /// </summary>
        /// <value>
        /// The platform list.
        /// </value>
        IList<SelectListItem> PlatformList { get; set; }
        /// <summary>
        /// Gets or sets the duration list.
        /// </summary>
        /// <value>
        /// The duration list.
        /// </value>
        IList<SelectListItem> DurationList { get; set; }
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        int CartId { get; set; }
        /// <summary>
        /// Gets or sets the processing messages.
        /// </summary>
        /// <value>
        /// The processing messages.
        /// </value>
        string ProcessingMessages { get; set; }
    }
}
