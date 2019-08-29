using System;

namespace ADit.Interfaces
{
    public interface IOnlinePackagesDurationPrice
    {
        /// <summary>
        /// Gets or sets the online package duration price identifier.
        /// </summary>
        /// <value>
        /// The online package duration price identifier.
        /// </value>
        int OnlinePackageDurationPriceId { get; set; }
        /// <summary>
        /// Gets or sets the online package identifier.
        /// </summary>
        /// <value>
        /// The online package identifier.
        /// </value>
        int OnlinePackageId { get; set; }
        /// <summary>
        /// Gets or sets the online duration identifier.
        /// </summary>
        /// <value>
        /// The online duration identifier.
        /// </value>
        int OnlineDurationId { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        DateTime DateInactive { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}
