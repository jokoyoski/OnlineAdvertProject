using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlinePlatformPackagePriceView" />
    public class OnlinePlatformPackagePriceView : IOnlinePlatformPackagePriceView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnlinePlatformPackagePriceView"/> class.
        /// </summary>
        public OnlinePlatformPackagePriceView()
        {
            this.ProcessingMessage = string.Empty;
            this.OnlinePlatform = OnlinePlatform;
            this.OnlineDurationsList = OnlineDurationsList;
            this.DurationsType = DurationsType;
        }
        /// <summary>
        /// Gets or sets the online platform price identifier.
        /// </summary>
        /// <value>
        /// The online platform price identifier.
        /// </value>
        public int OnlinePlatformPriceId { get; set; }
        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
        /// </value>
        public int OnlinePlatformId { get; set; }
        /// <summary>
        /// Gets or sets the online platform.
        /// </summary>
        /// <value>
        /// The online platform.
        /// </value>
        public IList<SelectListItem> OnlinePlatform { get; set; }
        /// <summary>
        /// Gets or sets the online durations list.
        /// </summary>
        /// <value>
        /// The online durations list.
        /// </value>
        public IList<SelectListItem> OnlineDurationsList { get; set; }
        /// <summary>
        /// Gets or sets the durations type code.
        /// </summary>
        /// <value>
        /// The durations type code.
        /// </value>
        public string DurationsTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the type of the durations.
        /// </summary>
        /// <value>
        /// The type of the durations.
        /// </value>
        public IList<SelectListItem> DurationsType { get; set; }
        /// <summary>
        /// Gets or sets the online duration identifier.
        /// </summary>
        /// <value>
        /// The online duration identifier.
        /// </value>
        public int OnlineDurationId { get; set; }
        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        public int DurationQuantity { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [Required] public decimal Amount { get; set; }
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
      
       
      }
    }
