using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineTransactionAiringUI
    {

        /// <summary>
        /// Gets or sets the online duration desccription.
        /// </summary>
        /// <value>
        /// The online duration desccription.
        /// </value>
        string OnlineDurationDesccription { get; set; }
        /// <summary>
        /// Gets or sets the online platform description.
        /// </summary>
        /// <value>
        /// The online platform description.
        /// </value>
         string OnlinePlatformDescription { get; set; }
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
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        bool IsSelected { get; set; }
    }
}
