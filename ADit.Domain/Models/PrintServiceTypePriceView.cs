using System;
using System.Collections.Generic;
using ADit.Interfaces;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ADit.Domain.Models
{
    public class PrintServiceTypePriceView : IPrintServiceTypePriceView
    {
        ///
        /// Gets or sets the print service color collection.
        /// </summary>
        /// <value>
        /// The print service color collection.
        /// </value>
       public  IList<SelectListItem> PrintMediaTypeCollection { get; set; }
        /// <summary>
        /// Gets or sets the print service color identifier.
        /// </summary>
        /// <value>
        /// The print service color identifier.
        /// </value>
        public   Nullable<int> PrintServiceColorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PrintServiceTypePriceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PrintServiceTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NewsPaperId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Required]
        public decimal Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateInactive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the print service type collection.
        /// </summary>
        /// <value>
        /// The print service type collection.
        /// </value>
        public IList<SelectListItem> PrintServiceTypeCollection { get; set; }

        /// <summary>
        /// Gets or sets the print news paper collection.
        /// </summary>
        /// <value>
        /// The print news paper collection.
        /// </value>
        public IList<SelectListItem> PrintNewsPaperCollection { get; set; }
        /// <summary>
        /// Gets or sets the print service type collection.
        /// </summary>
        /// <value>
        /// The print service type collection.
        /// </value>
        public IList<SelectListItem> PrintServiceColorCollection { get; set; }

        /// <summary>
        /// Gets or sets the print media type identifier.
        /// </summary>
        /// <value>
        /// The print media type identifier.
        /// </value>
      public  int PrintMediaTypeId { get; set; }

    }
}
