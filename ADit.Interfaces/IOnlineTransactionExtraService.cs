using System;

namespace ADit.Interfaces
{


    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineTransactionExtraService
    {
        /// <summary>
        /// Gets or sets the online extra service.
        /// </summary>
        /// <value>
        /// The online extra service.
        /// </value>
        string OnlineExtraService { get; set; }
        /// <summary>
        /// Gets or sets the online transaction extra service identifier.
        /// </summary>
        /// <value>
        /// The online transaction extra service identifier.
        /// </value>
        int OnlineTransactionExtraServiceId { get; set; }

        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        int OnlineTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the online extra service identifier.
        /// </summary>
        /// <value>
        /// The online extra service identifier.
        /// </value>
        int OnlineExtraServiceId { get; set; }

        /// <summary>
        /// Gets or sets the online extra service price identifier.
        /// </summary>
        /// <value>
        /// The online extra service price identifier.
        /// </value>
        int OnlineExtraServicePriceId { get; set; }

        /// <summary>
        /// Gets or sets the online extra service amount.
        /// </summary>
        /// <value>
        /// The online extra service amount.
        /// </value>
        decimal OnlineExtraServiceAmount { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }
    }
}
