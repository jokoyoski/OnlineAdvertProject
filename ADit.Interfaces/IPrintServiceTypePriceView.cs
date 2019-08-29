using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    public interface IPrintServiceTypePriceView
    {
        /// <summary>
        /// Gets or sets the print service color identifier.
        /// </summary>
        /// <value>
        /// The print service color identifier.
        /// </value>
        Nullable<int> PrintServiceColorId { get; set; }
        /// <summary>
        /// Gets or sets the print service color collection.
        /// </summary>
        /// <value>
        /// The print service color collection.
        /// </value>
        IList<SelectListItem> PrintServiceColorCollection { get; set; }
        /// <summary>
        /// Gets or sets the print service color identifier.
        /// </summary>
        /// <value>
        /// The print service color identifier.
        /// </value>       Nullable<int> PrintServiceColorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int PrintServiceTypePriceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int PrintServiceTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int NewsPaperId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        decimal Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        System.DateTime EffectiveDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Nullable<System.DateTime> DateInactive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string ProcessingMessage { get; set; }

        IList<SelectListItem> PrintServiceTypeCollection { get; set; }

        /// <summary>
        /// Gets or sets the print news paper collection.
        /// </summary>
        /// <value>
        /// The print news paper collection.
        /// </value>
        IList<SelectListItem> PrintNewsPaperCollection { get; set; }


        /// Gets or sets the print service color collection.
        /// </summary>
        /// <value>
        /// The print service color collection.
        /// </value>
        IList<SelectListItem> PrintMediaTypeCollection { get; set; }
        /// <summary>
        /// Gets or sets the print media type identifier.
        /// </summary>
        /// <value>
        /// The print media type identifier.
        /// </value>
        int PrintMediaTypeId { get; set; }
    }
}
