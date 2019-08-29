using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    public class TVServicesPricesListView : ITVServicePricesListView
    {
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string processingMessage { get; set; }

        /// <summary>
        /// Gets or sets the tv services price list identifier.
        /// </summary>
        /// <value>
        /// The tv services price list identifier.
        /// </value>
        public int TvServicesPriceListId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the tv station identifier.
        /// </summary>
        /// <value>
        /// The tv station identifier.
        /// </value>
        public int TvStationId { get; set; }

        /// <summary>
        /// Gets or sets the tv collection.
        /// </summary>
        /// <value>
        /// The tv collection.
        /// </value>
        public IList<SelectListItem> tvCollection { get; set; }

        /// <summary>
        /// Gets or sets the timing belt identifier.
        /// </summary>
        /// <value>
        /// The timing belt identifier.
        /// </value>
        public int TimingBeltId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> timeBeltCollection { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public IList<SelectListItem> TimingCollection { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int TimingId { get; set; }

        /// <summary>
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// </summary>
        public DateTime DateEffective { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? DateInActive { get; set; }

        /// <summary>
        /// </summary>
        public DateTime DateCraeted { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string selectedDescription { get; set; }
        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public int MaterialTypeId { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public IList<SelectListItem> MaterialType { get; set; }
    }
}