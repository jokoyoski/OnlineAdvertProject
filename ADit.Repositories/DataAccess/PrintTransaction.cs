//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADit.Repositories.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrintTransaction
    {
        public int PrintTransactionId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public bool IsHaveMaterial { get; set; }
        public Nullable<int> MaterialDigitalFileId { get; set; }
        public string ApconApprovalNumber { get; set; }
        public Nullable<int> ApconApprovalTypeId { get; set; }
        public Nullable<int> ApconApprovalTypePriceId { get; set; }
        public decimal ApconApprovalAmount { get; set; }
        public int PrintCategoryId { get; set; }
        public int DesignElementId { get; set; }
        public Nullable<int> DesignElementPriceId { get; set; }
        public decimal DesignAmount { get; set; }
        public string DurationTypeCode { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string TransactionStatusCode { get; set; }
        public string OrderTitle { get; set; }
        public decimal TotalPrice { get; set; }
        public string ColorDescription { get; set; }
    }
}