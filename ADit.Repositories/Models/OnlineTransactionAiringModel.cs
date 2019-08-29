using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    public class OnlineTransactionAiringModel : IOnlineTransactionAiring
    {
        /// <summary>
        /// Gets or sets the online purpose.
        /// </summary>
        /// <value>
        /// The online purpose.
        /// </value>
        public string OnlinePurpose { get; set; }
        /// <summary>
        /// Gets or sets the online transaction airing identifier.
        /// </summary>
        /// <value>
        /// The online transaction airing identifier.
        /// </value>
        public int OnlineTransactionAiringId { get; set; }
        /// <summary>
        /// Gets or sets the online duration identifier.
        /// </summary>
        /// <value>
        /// The online duration identifier.
        /// </value>
        public int OnlineDurationId { get; set; }
        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        public int OnlineTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the duration description.
        /// </summary>
        /// <value>
        /// The duration description.
        /// </value>
        public string DurationDescription { get; set; }
        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
        /// </value>
        public int OnlinePlatformId { get; set; }
        /// <summary>
        /// Gets or sets the platform description.
        /// </summary>
        /// <value>
        /// The platform description.
        /// </value>
        public string PlatformDescription { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }

    }
}
