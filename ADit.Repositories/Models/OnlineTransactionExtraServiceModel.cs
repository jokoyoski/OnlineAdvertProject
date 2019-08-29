using System;
using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineTransactionExtraService" />
    public class OnlineTransactionExtraServiceModel : IOnlineTransactionExtraService
    {
        /// <summary>
        /// Gets or sets the online extra service.
        /// </summary>
        /// <value>
        /// The online extra service.
        /// </value>
        public string OnlineExtraService { get; set; }
        /// <summary>
        /// Gets or sets the online transaction extra service identifier.
        /// </summary>
        /// <value>
        /// The online transaction extra service identifier.
        /// </value>
        public int OnlineTransactionExtraServiceId { get; set; }
        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        public int OnlineTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the online extra service identifier.
        /// </summary>
        /// <value>
        /// The online extra service identifier.
        /// </value>
        public int OnlineExtraServiceId { get; set; }
        /// <summary>
        /// Gets or sets the online extra service price identifier.
        /// </summary>
        /// <value>
        /// The online extra service price identifier.
        /// </value>
        public int OnlineExtraServicePriceId { get; set; }
        /// <summary>
        /// Gets or sets the online extra service amount.
        /// </summary>
        /// <value>
        /// The online extra service amount.
        /// </value>
        public decimal OnlineExtraServiceAmount { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
    }
}
