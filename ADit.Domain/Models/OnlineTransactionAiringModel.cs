using ADit.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
 
namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineTransactionAiringModel" />
    public class OnlineTransactionAiringModel : IOnlineTransactionAiringModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineTransactionAiringModel"/> class.
        /// </summary>
        public OnlineTransactionAiringModel()
        {
            Platform = new List<IOnlinePlatform>();
            Duration = new List<IList<SelectListItem>>();
            Price = new List<decimal>();

        }
        /// <summary>
        /// Gets or sets the online transaction airing identifier.
        /// </summary>
        /// <value>
        /// The online transaction airing identifier.
        /// </value>
        public int OnlineTransactionAiringId { get; set; }
        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        /// <value>
        /// The platform.
        /// </value>
        public IList<IOnlinePlatform> Platform { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public IList<IList<SelectListItem>> Duration { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public IList<decimal> Price { get; set; }
    }
}
