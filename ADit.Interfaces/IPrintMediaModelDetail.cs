using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrintMediaModelDetail
    {
        /// <summary>
        /// Gets or sets the artwork identifier.
        /// </summary>
        /// <value>
        /// The artwork identifier.
        /// </value>
        int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the artwork description.
        /// </summary>
        /// <value>
        /// The artwork description.
        /// </value>
        string ArtworkDescription { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type price identifier.
        /// </value>
        int ApconApprovalTypePriceId { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval identifier.
        /// </summary>
        /// <value>
        /// The apcon approval identifier.
        /// </value>
        int ApconApprovalId { get; set; }
        /// <summary>
        /// Gets or sets the apcon description.
        /// </summary>
        /// <value>
        /// The apcon description.
        /// </value>
        string ApconDescription { get; set; }
        /// <summary>
        /// Gets or sets the apcon amount.
        /// </summary>
        /// <value>
        /// The apcon amount.
        /// </value>
        decimal ApconAmount { get; set; }
        /// <summary>
        /// Gets or sets the design elment price identifier.
        /// </summary>
        /// <value>
        /// The design elment price identifier.
        /// </value>
        int DesignElmentPriceId { get; set; }
        /// <summary>
        /// Gets or sets the design elment identifier.
        /// </summary>
        /// <value>
        /// The design elment identifier.
        /// </value>
        int DesignElmentId { get; set; }
        /// <summary>
        /// Gets or sets the design elment description.
        /// </summary>
        /// <value>
        /// The design elment description.
        /// </value>
        string DesignElmentDescription { get; set; }
        /// <summary>
        /// Gets or sets the design elment amount.
        /// </summary>
        /// <value>
        /// The design elment amount.
        /// </value>
        decimal DesignElmentAmount { get; set; }
        /// <summary>
        /// Gets or sets the print category identifier.
        /// </summary>
        /// <value>
        /// The print category identifier.
        /// </value>
        int PrintCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the print category description.
        /// </summary>
        /// <value>
        /// The print category description.
        /// </value>
        string PrintCategoryDescription { get; set; }
        /// <summary>
        /// Gets or sets the color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        int ColorId { get; set; }
        /// <summary>
        /// Gets or sets the color description.
        /// </summary>
        /// <value>
        /// The color description.
        /// </value>
        string ColorDescription { get; set; }
        /// <summary>
        /// Gets or sets the newspaper identifier.
        /// </summary>
        /// <value>
        /// The newspaper identifier.
        /// </value>
        int NewspaperId { get; set; }
        /// <summary>
        /// Gets or sets the newspaper description.
        /// </summary>
        /// <value>
        /// The newspaper description.
        /// </value>
        string NewspaperDescription { get; set; }
        /// <summary>
        /// Gets or sets the print service identifier.
        /// </summary>
        /// <value>
        /// The print service identifier.
        /// </value>
        int PrintServiceId { get; set; }
        /// <summary>
        /// Gets or sets the print service description.
        /// </summary>
        /// <value>
        /// The print service description.
        /// </value>
        string PrintServiceDescription { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }

        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        System.DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        Nullable<System.DateTime> DateInactive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

    }
}
