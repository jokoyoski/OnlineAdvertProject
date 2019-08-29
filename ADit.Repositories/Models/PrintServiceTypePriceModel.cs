using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IPrintServiceTypePrice" />
    public class PrintServiceTypePriceModel :IPrintServiceTypePrice
    {
        /// <summary>
        /// Gets or sets the service color description.
        /// </summary>
        /// <value>
        /// The service color description.
        /// </value>
        public string ServiceColorDescription { get; set; }
        /// <summary>
        /// Gets or sets the print service color identifier.
        /// </summary>
        /// <value>
        /// The print service color identifier.
        /// </value>
       public  Nullable<int> PrintServiceColorId { get; set; }
        /// <summary>
        /// Gets or sets the print service type price identifier.
        /// </summary>
        /// <value>
        /// The print service type price identifier.
        /// </value>
        public int PrintServiceTypePriceId { get; set; }
        /// <summary>
        /// Gets or sets the print service type identifier.
        /// </summary>
        /// <value>
        /// The print service type identifier.
        /// </value>
        public int PrintServiceTypeId { get; set; }
        /// <summary>
        /// Gets or sets the service type description.
        /// </summary>
        /// <value>
        /// The service type description.
        /// </value>

        public string ServiceTypeDescription { set; get; }

        /// <summary>
        /// Gets or sets the newspaper description.
        /// </summary>
        /// <value>
        /// The newspaper description.
        /// </value>
        public string NewspaperDescription { set; get; }


        /// <summary>
        /// Gets or sets the news paper identifier.
        /// </summary>
        /// <value>
        /// The news paper identifier.
        /// </value>
        public int NewsPaperId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
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
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the print media type identifier.
        /// </summary>
        /// <value>
        /// The print media type identifier.
        /// </value>
        public int PrintMediaTypeId { get; set; }
    }
}
