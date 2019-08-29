using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    public class TvScriptingTransactionModel : ITvScriptingTransactionModelView
    {
        /// <summary>
        /// Gets or sets the sent to.
        /// </summary>
        /// <value>
        /// The sent to.
        /// </value>
        public string SentTo { get; set; }
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
        /// Gets or sets the script details.
        /// </summary>
        /// <value>
        /// The script details.
        /// </value>
        public string ScriptDetails { get; set; }
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
        /// Gets or sets the script file identifier.
        /// </summary>
        /// <value>
        /// The script file identifier.
        /// </value>
        public Nullable<int> ScriptFileId { get; set; }
        /// <summary>
        /// Gets or sets the sentby.
        /// </summary>
        /// <value>
        /// The sentby.
        /// </value>
        public string Sentby { get; set; } 
    }
}
