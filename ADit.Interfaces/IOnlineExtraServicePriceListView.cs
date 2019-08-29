using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineExtraServicePriceListView
    {

        /// <summary>
        /// Gets or sets the select online extra service price identifier.
        /// </summary>
        /// <value>
        /// The select online extra service price identifier.
        /// </value>
        int SelectOnlineExtraServicePriceId { get; set; }

        /// <summary>
        /// Gets or sets the select online extra service identifier.
        /// </summary>
        /// <value>
        /// The select online extra service identifier.
        /// </value>
        int SelectOnlineExtraServiceId { get; set; }

        /// <summary>
        /// Gets or sets the select amount.
        /// </summary>
        /// <value>
        /// The select amount.
        /// </value>
        decimal SelectAmount { get; set; }

        /// <summary>
        /// Gets or sets the select comment.
        /// </summary>
        /// <value>
        /// The select comment.
        /// </value>
        string SelectComment { get; set; }

        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        System.DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        Nullable<System.DateTime> DateInactive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the online extra service price collection.
        /// </summary>
        /// <value>
        /// The online extra service price collection.
        /// </value>
        IList<IOnlineExtraServicePrice> OnlineExtraServicePriceCollection { get; set; }
    }
}
