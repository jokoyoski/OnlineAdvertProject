using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IPrintTransaction
    {
        /// <summary>
        /// Gets or sets the print file description.
        /// </summary>
        /// <value>
        /// The print file description.
        /// </value>
        string PrintFileDescription { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
        /// <summary>
        /// Gets or sets the type of the duration.
        /// </summary>
        /// <value>
        /// The type of the duration.
        /// </value>
        string DurationType { get; set; }
        /// <summary>
        /// Gets or sets the design element.
        /// </summary>
        /// <value>
        /// The design element.
        /// </value>
        string DesignElement { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        string Category { get; set; }
        /// <summary>
        /// Gets or sets the type of the apcon.
        /// </summary>
        /// <value>
        /// The type of the apcon.
        /// </value>
        string ApconType { get; set; }
        /// <summary>
        /// Gets or sets the sent to.
        /// </summary>
        /// <value>
        /// The sent to.
        /// </value>
        string sentTo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int? ScriptFileId { get; set; }
        /// <summary>
        /// 
        /// </summary>
         int TransactionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
       string Details { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Nullable<DateTime> dateUpdated { get; set; }
        int SentToId { get; set; }
        int PrintTransactionId { get; set; }
        int OrderId { get; set; }
        bool IsHaveMaterial { get; set; }
        Nullable<int> MaterialDigitalFileId { get; set; }
        string ApconApprovalNumber { get; set; }
        Nullable<int> ApconApprovalTypeId { get; set; }
        Nullable<int> ApconApprovalTypePriceId { get; set; }
        decimal ApconApprovalAmount { get; set; }
        int PrintCategoryId { get; set; }
        int DesignElementId { get; set; }
        Nullable<int> DesignElementPriceId { get; set; }
        decimal DesignAmount { get; set; }
        string DurationTypeCode { get; set; }
        int DurationQuantity { get; set; }
        int NumberOfInserts { get; set; }
        System.DateTime DateCreated { get; set; }
        string TransactionStatusCode { get; set; }
        int UserId { get; set; }
        List<int> SelectedTvStationIds { get; set; }

        string OrderTitle { get; set; }
        decimal ApconAmount { get; set; }
        decimal DesignElmentAmount { get; set; }
        int ColorId { get; set; }
        decimal TotalPrice { get; set; }
        string ColorDescription { get; set; }
        string UserName { get; set; }
        IDigitalFile DigitalFile { get; set; }
        string AiringInstruction { get; set; }
    }
}