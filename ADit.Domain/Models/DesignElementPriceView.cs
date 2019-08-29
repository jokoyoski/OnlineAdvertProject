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
    /// <seealso cref="ADit.Interfaces.IDesignElementPriceView" />
    public class DesignElementPriceView : IDesignElementPriceView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignElementPriceView"/> class.
        /// </summary>
        public DesignElementPriceView()
        {
            this.ProcessingMessage = string.Empty;
            this.ServiceType = ServiceType;
            this.DesignElementType = DesignElementType;

        }
        /// <summary>
        /// Gets or sets the material scripting price identifier.
        /// </summary>
        /// <value>
        /// The material scripting price identifier.
        /// </value>



        public int DesignElementPriceId { get; set; }
        /// <summary>
        /// Gets or sets the service type code.
        /// </summary>
        /// <value>
        /// The service type code.
        /// </value>

        [Required]
        public string ServiceTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        public IList<SelectListItem> ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a design element")]
        public int DesignElementId { get; set; }

        /// <summary>
        /// Gets or sets the type of the design element.
        /// </summary>
        /// <value>
        /// The type of the design element.
        /// </value>
        public IList<SelectListItem> DesignElementType { get; set; }
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

        [Required]
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        public DateTime? DateInactive { get; set; }
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
