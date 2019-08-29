using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineTransactionAiring
    {
        /// <summary>
        /// Gets or sets the online purpose.
        /// </summary>
        /// <value>
        /// The online purpose.
        /// </value>
        string OnlinePurpose { get; set; }
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
        /// Gets or sets the online duration identifier.
        /// </summary>
        /// <value>
        /// The online duration identifier.
        /// </value>
        int OnlineDurationId { get; set; }
        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
        /// </value>
        int OnlinePlatformId { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }
        /// <summary>
        /// Gets or sets the platform description.
        /// </summary>
        /// <value>
        /// The platform description.
        /// </value>
        string PlatformDescription { get; set; }
        /// <summary>
        /// Gets or sets the duration description.
        /// </summary>
        /// <value>
        /// The duration description.
        /// </value>
        string DurationDescription { get; set; }
    }
}
