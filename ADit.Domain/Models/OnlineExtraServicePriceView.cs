﻿using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineExtraServicePriceView" />
    public class OnlineExtraServicePriceView : IOnlineExtraServicePriceView
    {

        /// <summary>
        /// Gets or sets the online extra service price identifier.
        /// </summary>
        /// <value>
        /// The online extra service price identifier.
        /// </value>
        public int OnlineExtraServicePriceId { get; set; }
        /// <summary>
        /// Gets or sets the online extra service identifier.
        /// </summary>
        /// <value>
        /// The online extra service identifier.
        /// </value>
        public int OnlineExtraServiceId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [Required]
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
        /// Gets or sets the online extra service.
        /// </summary>
        /// <value>
        /// The online extra service.
        /// </value>
        public IList<SelectListItem> OnlineExtraService { get; set; }
        /// <summary>
        /// Gets or sets the online extra description.
        /// </summary>
        /// <value>
        /// The online extra description.
        /// </value>
        public string OnlineExtraDescription { get; set; }
    }
}
