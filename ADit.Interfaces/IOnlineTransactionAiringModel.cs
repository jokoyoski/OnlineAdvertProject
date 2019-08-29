using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineTransactionAiringModel
    {
        /// <summary>
        /// Gets or sets the online transaction airing identifier.
        /// </summary>
        /// <value>
        /// The online transaction airing identifier.
        /// </value>
        int OnlineTransactionAiringId { get; set; }
        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        /// <value>
        /// The platform.
        /// </value>
        IList<IOnlinePlatform> Platform { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        IList<IList<SelectListItem>> Duration { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        IList<decimal> Price { get; set; }
    }
}
