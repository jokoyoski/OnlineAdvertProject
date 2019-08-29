using System;

namespace ADit.Interfaces
{


    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineTransaction
    {
       
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
        /// <summary>
        /// Gets or sets the online purpose.
        /// </summary>
        /// <value>
        /// The online purpose.
        /// </value>
        string OnlinePurpose { get; set; }
        /// <summary>
        /// Gets or sets the sent to identifier.
        /// </summary>
        /// <value>
        /// The sent to identifier.
        /// </value>
        int SentToId { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the online transaction identifier.
        /// </summary>
        /// <value>
        /// The online transaction identifier.
        /// </value>
        int OnlineTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal Price { get; set; }
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
        /// Gets or sets the online extra service amount.
        /// </summary>
        /// <value>
        /// The online extra service amount.
        /// </value>
        decimal OnlineExtraServiceAmount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is have art work.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have art work; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveArtWork { get; set; }

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
        Nullable<decimal> ArtWorkAmount { get; set; }

        /// <summary>
        /// Gets or sets the artwork digital file identifier.
        /// </summary>
        /// <value>
        /// The artwork digital file identifier.
        /// </value>
        int? ArtworkDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        string TransactionStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the art work identifier.
        /// </summary>
        /// <value>
        /// The art work identifier.
        /// </value>
        int ArtWorkId { get; set; }
        /// <summary>
        /// Gets or sets the processingmessage.
        /// </summary>
        /// <value>
        /// The processingmessage.
        /// </value>
        string Processingmessage { get; set; }
        /// <summary>
        /// Gets or sets the extra service transaction.
        /// </summary>
        /// <value>
        /// The extra service transaction.
        /// </value>
        IOnlineTransactionExtraService ExtraServiceTransaction { get; set; }
    }
}
