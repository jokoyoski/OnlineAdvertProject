using ADit.Interfaces;
using System;
using System.Collections.Generic;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
   
    public class OnlineArtworkPriceListView : IOnlineArtworkPriceListView
    {
        /// <summary>
        /// Gets or sets the art work price identifier.
        /// </summary>
        /// <value>
        /// The art work price identifier.
        /// </value>
        public int ArtWorkPriceId { get; set; }
        /// <summary>
        /// Gets or sets the service type code.
        /// </summary>
        /// <value>
        /// The service type code.
        /// </value>
        public string ServiceTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }
        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        public System.DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        public Nullable<System.DateTime> DateInactive { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }


        /// <summary>
        /// Gets or sets the selected artwork price identifier.
        /// </summary>
        /// <value>
        /// The selected artwork price identifier.
        /// </value>
        public int SelectedArtworkPriceId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the online artwork price ListView.
        /// </summary>
        /// <value>
        /// The online artwork price ListView.
        /// </value>
        public IEnumerable<IOnlineArtworkPrice> onlineArtworkPriceListView { get; set; }

        /// <summary>
        /// Gets or sets the get art work price.
        /// </summary>
        /// <value>
        /// The get art work price.
        /// </value>
        public IList<IOnlineArtworkPrice> GetArtWorkPrice { get; set; }
        /// <summary>
        /// Gets or sets the service type code.
        /// </summary>
        /// <value>
        /// The service type code.
        /// </value>
        public string SelectedServiceTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the design element price collection.
        /// </summary>
        /// <value>
        /// The design element price collection.
        /// </value>
        public IList<IOnlineArtworkPrice> OnlineArtWorkPriceCollection { get; set; }
    }
}
  