using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITvMaterialTransactionModel" />
    public class TvMaterialTransactionModel : ITvMaterialTransactionModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public System.DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public string Details { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public int TransactionId { get; set; }
        /// <summary>
        /// Gets or sets the material file identifier.
        /// </summary>
        /// <value>
        /// The material file identifier.
        /// </value>
        public Nullable<int> MaterialFileId { get; set; }
        /// <summary>
        /// Gets or sets the sentby.
        /// </summary>
        /// <value>
        /// The sentby.
        /// </value>
        public string Sentby { get; set; }
        /// <summary>
        /// Gets or sets the sent to identifier.
        /// </summary>
        /// <value>
        /// The sent to identifier.
        /// </value>
        public int SentToId { get; set; }

    }
}

