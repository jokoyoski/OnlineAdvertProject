using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IPrintMediaModelDetail" />
    public class PrintMediaModelDetail : IPrintMediaModelDetail
    {
        /// <summary>
        /// Gets or sets the artwork identifier.
        /// </summary>
        /// <value>
        /// The artwork identifier.
        /// </value>
        public int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the artwork description.
        /// </summary>
        /// <value>
        /// The artwork description.
        /// </value>
        public string ArtworkDescription { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type price identifier.
        /// </value>
        public int ApconApprovalTypePriceId { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval identifier.
        /// </summary>
        /// <value>
        /// The apcon approval identifier.
        /// </value>
        public int ApconApprovalId { get; set; }
        /// <summary>
        /// Gets or sets the apcon description.
        /// </summary>
        /// <value>
        /// The apcon description.
        /// </value>
        public string ApconDescription { get; set; }
        /// <summary>
        /// Gets or sets the apcon amount.
        /// </summary>
        /// <value>
        /// The apcon amount.
        /// </value>
        public decimal ApconAmount { get; set; }
        /// <summary>
        /// Gets or sets the design elment price identifier.
        /// </summary>
        /// <value>
        /// The design elment price identifier.
        /// </value>
        public int DesignElmentPriceId { get; set; }
        /// <summary>
        /// Gets or sets the design elment identifier.
        /// </summary>
        /// <value>
        /// The design elment identifier.
        /// </value>
        public int DesignElmentId { get; set; }
        /// <summary>
        /// Gets or sets the design elment description.
        /// </summary>
        /// <value>
        /// The design elment description.
        /// </value>
        public string DesignElmentDescription { get; set; }
        /// <summary>
        /// Gets or sets the design elment amount.
        /// </summary>
        /// <value>
        /// The design elment amount.
        /// </value>
        public decimal DesignElmentAmount { get; set; }
        /// <summary>
        /// Gets or sets the print category identifier.
        /// </summary>
        /// <value>
        /// The print category identifier.
        /// </value>
        public int PrintCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the print category description.
        /// </summary>
        /// <value>
        /// The print category description.
        /// </value>
        public string PrintCategoryDescription { get; set; }
        /// <summary>
        /// Gets or sets the color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        public int ColorId { get; set; }
        /// <summary>
        /// Gets or sets the color description.
        /// </summary>
        /// <value>
        /// The color description.
        /// </value>
        public string ColorDescription { get; set; }
        /// <summary>
        /// Gets or sets the newspaper identifier.
        /// </summary>
        /// <value>
        /// The newspaper identifier.
        /// </value>
        public int NewspaperId { get; set; }
        /// <summary>
        /// Gets or sets the newspaper description.
        /// </summary>
        /// <value>
        /// The newspaper description.
        /// </value>
        public string NewspaperDescription { get; set; }
        /// <summary>
        /// Gets or sets the print service identifier.
        /// </summary>
        /// <value>
        /// The print service identifier.
        /// </value>
        public int PrintServiceId { get; set; }
        /// <summary>
        /// Gets or sets the print service description.
        /// </summary>
        /// <value>
        /// The print service description.
        /// </value>
        public string PrintServiceDescription { get; set; }
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
        public System.DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        public Nullable<System.DateTime> DateInactive { get; set; }
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

    }
}
