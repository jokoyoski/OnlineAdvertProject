using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
  public  class PrintView : IPrintView
    {

       /// public 
        /// <summary>
        /// 
        /// </summary>
        public int PrintTransactionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderNumber { get; set; }
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
        public System.DateTime DateCreated { get; set; }
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

       public  int NewsPaperId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ColorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary> 
        /// 
        /// </summary>
        public IList<SelectListItem> DurationList { get; set; }
        /// <summary>
        /// 
        /// </summary>
       public IList<SelectListItem> ApconApprovalList { get; set; }/// <summary>
       /// 
       /// </summary>
        public int PrintServiceTypeId { get; set; }
    }
}
