using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrintServiceTypePrice
    {
        /// <summary>
        /// Gets or sets the print media type identifier.
        /// </summary>
        /// <value>
        /// The print media type identifier.
        /// </value>
        int PrintMediaTypeId { get; set; }
        /// <summary>
        /// Gets or sets the service color description.
        /// </summary>
        /// <value>
        /// The service color description.
        /// </value>
        string ServiceColorDescription { get; set; }
        /// <summary>
        /// Gets or sets the print service color identifier.
        /// </summary>
        /// <value>
        /// The print service color identifier.
        /// </value>
        Nullable<int> PrintServiceColorId { get; set; }
        /// <summary>
        /// Gets or sets the print service type price identifier.
        /// </summary>
        /// <value>
        /// The print service type price identifier.
        /// </value>
        int PrintServiceTypePriceId { get; set; }
        /// <summary>
        /// Gets or sets the print service type identifier.
        /// </summary>
        /// <value>
        /// The print service type identifier.
        /// </value>
        int PrintServiceTypeId { get; set; }
        /// <summary>
        /// Gets or sets the news paper identifier.
        /// </summary>
        /// <value>
        /// The news paper identifier.
        /// </value>
        int NewsPaperId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; set; }
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
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
        /// <summary>
        /// Gets or sets the newspaper description.
        /// </summary>
        /// <value>
        /// The newspaper description.
        /// </value>
        string NewspaperDescription { get; set; }
        /// <summary>
        /// Gets or sets the service type description.
        /// </summary>
        /// <value>
        /// The service type description.
        /// </value>
        string ServiceTypeDescription { get; set; }
    }
}