using ADit.Interfaces;
using System;

namespace ADit.Domain.Models
{
    public class PrintTransactionUI:IPrintTransactionUI
    {

        /// <summary>
        /// Gets or sets the print transaction identifier.
        /// </summary>
        /// <value>
        /// The print transaction identifier.
        /// </value>
        public int PrintTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type identifier.
        /// </value>
        public  int ApconApprovalTypeId { get; set; }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the design element amount.
        /// </summary>
        /// <value>
        /// The design element amount.
        /// </value>
        public decimal DesignElementAmount { get; set; }

        
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
      public   int UserId { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        public   string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
      public   bool isHaveMaterial { get; set; }
        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
      public   Nullable<int> MaterialDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the print category identifier.
        /// </summary>
        /// <value>
        /// The print category identifier.
        /// </value>
       public  int PrintCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the color description.
        /// </summary>
        /// <value>
        /// The color description.
        /// </value>
      public   string ColorDescription { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval number.
        /// </summary>
        /// <value>
        /// The apcon approval number.
        /// </value>
      public   string ApconApprovalNumber { get; set; }

        /// <summary>
        /// Gets or sets the apcon amount.
        /// </summary>
        /// <value>
        /// The apcon amount.
        /// </value>
      public   decimal ApconAmount { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type price identifier.
        /// </value>
       public  Nullable<int> ApconApprovalTypePriceId { get; set; }
        /// <summary>
        /// Gets or sets the design element identifier.
        /// </summary>
        /// <value>
        /// The design element identifier.
        /// </value>
      public   int DesignElementId { get; set; }
        /// <summary>
        /// Gets or sets the design element price identifier.
        /// </summary>
        /// <value>
        /// The design element price identifier.
        /// </value>
       public Nullable<int> DesignElementPriceId { get; set; }
        /// <summary>
        /// Gets or sets the airing instruction.
        /// </summary>
        /// <value>
        /// The airing instruction.
        /// </value>
    public     string AiringInstruction { get; set; }
    }
}
