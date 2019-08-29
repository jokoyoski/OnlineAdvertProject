using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvMaterialTransactionModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        System.DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        string Details { get; set; }
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
        /// Gets or sets the material file identifier.
        /// </summary>
        /// <value>
        /// The material file identifier.
        /// </value>
        Nullable<int> MaterialFileId { get; set; }
        /// <summary>
        /// Gets or sets the sentby.
        /// </summary>
        /// <value>
        /// The sentby.
        /// </value>
        string Sentby { get; set; }
        /// <summary>
        /// Gets or sets the sent to identifier.
        /// </summary>
        /// <value>
        /// The sent to identifier.
        /// </value>
        int SentToId { get; set; }
    }
}
