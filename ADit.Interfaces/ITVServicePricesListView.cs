using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ADit.Interfaces
{
   public  interface ITVServicePricesListView
    {

        IList<SelectListItem> timeBeltCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string processingMessage { get; set; }


        /// <summary>
        /// Gets or sets the tv collection.
        /// </summary>
        /// <value>
        /// The tv collection.
        /// </value>
        IList<SelectListItem> tvCollection { get; set; }


        /// <summary>
        /// Gets or sets the tv services price list identifier.
        /// </summary>
        /// <value>
        /// The tv services price list identifier.
        /// </value>
        int TvServicesPriceListId { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the tv station identifier.
        /// </summary>
        /// <value>
        /// The tv station identifier.
        /// </value>
        int TvStationId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> TimingCollection{ get; set; }
        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        int MaterialTypeId { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
         IList<SelectListItem> MaterialType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int TimingId { get; set; }


        /// <summary>
        /// Gets or sets the timing belt identifier.
        /// </summary>
        /// <value>
        /// The timing belt identifier.
        /// </value>
        int TimingBeltId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        decimal Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime DateEffective { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime? DateInActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime DateCraeted { get; set; }
    }
}
