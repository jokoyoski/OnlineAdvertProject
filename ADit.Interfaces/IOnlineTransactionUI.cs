using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineTransactionUI
    {
        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        int OnlineTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the online purpose identifier.
        /// </summary>
        /// <value>
        /// The online purpose identifier.
        /// </value>
        int OnlinePurposeId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the online platform identifier.
        /// </summary>
        /// <value>
        /// The online platform identifier.
        /// </value>
        int OnlinePlatformId { get; set; }
        /// <summary>
        /// Gets or sets the online platform price identifier.
        /// </summary>
        /// <value>
        /// The online platform price identifier.
        /// </value>
        int OnlinePlatformPriceId { get; set; }
        /// <summary>
        /// Gets or sets the online platform amount.
        /// </summary>
        /// <value>
        /// The online platform amount.
        /// </value>
        decimal OnlinePlatformAmount { get; set; }
        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        string AdditionalInformation { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is have art work.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have art work; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveArtWork { get; set; }
        /// <summary>
        /// Gets or sets the art work identifier.
        /// </summary>
        /// <value>
        /// The art work identifier.
        /// </value>
        Nullable<int> ArtWorkId { get; set; }
        /// <summary>
        /// Gets or sets the art work price identifier.
        /// </summary>
        /// <value>
        /// The art work price identifier.
        /// </value>
        Nullable<int> ArtWorkPriceId { get; set; }
        /// <summary>
        /// Gets or sets the art work amount.
        /// </summary>
        /// <value>
        /// The art work amount.
        /// </value>
        Nullable<decimal> OnlineArtworkAmount { get; set; }
        /// <summary>
        /// Gets or sets the artwork digital file identifier.
        /// </summary>
        /// <value>
        /// The artwork digital file identifier.
        /// </value>
         int ArtworkDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        decimal FinalAmount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the online extra service amount.
        /// </summary>
        /// <value>
        /// The online extra service amount.
        /// </value>
        decimal OnlineExtraServiceAmount { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        string TransactionStatusCode { get; set; }

        int OnlineExtraServiceId { get; set; }


        int OnlineExtraServicePriceId { get; set; }

        /// <summary>
        /// Gets or sets the material file description.
        /// </summary>
        /// <value>The material file description.</value>
        string MaterialFileDescription { get; set; }

    }
}
