using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineArtworkTransactionView
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        /// <value>
        /// The date updated.
        /// </value>
        DateTime dateUpdated { get; set; }


        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        string Details { get; set; }
        /// <summary>
        /// Gets or sets the artwork file identifier.
        /// </summary>
        /// <value>
        /// The artwork file identifier.
        /// </value>
        int ArtworkFileId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        int TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the sent by.
        /// </summary>
        /// <value>
        /// The sent by.
        /// </value>
        string sentBY { get; set; }
    }
}
