using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    public class CartView : ICart
    {
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        public int CartId { get; set; }
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        public string ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the item code.
        /// </summary>
        /// <value>
        /// The item code.
        /// </value>
        public string ItemCode { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the print transaction identifier.
        /// </summary>
        /// <value>
        /// The print transaction identifier.
        /// </value>
        public int PrintTransactionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
       
        public bool IsHaveMaterial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> MaterialDigitalFileId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ApconApprovalNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ApconApprovalTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ApconApprovalTypePriceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal ApconApprovalAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PrintCategoryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DesignElementId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> DesignElementPriceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal DesignAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DurationTypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DurationQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfInserts { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string TransactionStatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> PrintCategoryList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> PrintNewspaperList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> PrintServiceTypeList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> ColorList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> DesignElementList { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public int NewsPaperId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ColorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
       
        public IList<SelectListItem> DurationList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> ApconApprovalList { get; set; }

        /// <summary>
        /// Gets or sets the print service type identifier.
        /// </summary>
        /// <value>
        /// The print service type identifier.
        /// </value>
        public int PrintServiceTypeId { get; set; }

    }
}


