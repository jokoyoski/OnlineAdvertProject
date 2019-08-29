using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineArtworkPriceListView
    {
        /// <summary>
        /// Gets or sets the art work price identifier.
        /// </summary>
        /// <value>
        /// The art work price identifier.
        /// </value>
        int ArtWorkPriceId { get; set; }
        /// <summary>
        /// Gets or sets the service type code.
        /// </summary>
        /// <value>
        /// The service type code.
        /// </value>
        string SelectedServiceTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }
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
        /// Gets or sets the selected artwork price identifier.
        /// </summary>
        /// <value>
        /// The selected artwork price identifier.
        /// </value>
        int SelectedArtworkPriceId {get;set;}
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the online art work price collection.
        /// </summary>
        /// <value>
        /// The online art work price collection.
        /// </value>
        IList<IOnlineArtworkPrice> OnlineArtWorkPriceCollection { get; set; }

    }
}
