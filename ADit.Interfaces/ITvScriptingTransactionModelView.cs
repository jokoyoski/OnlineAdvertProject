using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvScriptingTransactionModelView
    {
        /// <summary>
        /// Gets or sets the sent to.
        /// </summary>
        /// <value>
        /// The sent to.
        /// </value>
        string SentTo { get; set; }
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
        /// Gets or sets the script details.
        /// </summary>
        /// <value>
        /// The script details.
        /// </value>
        string ScriptDetails { get; set; }
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
        /// Gets or sets the script file identifier.
        /// </summary>
        /// <value>
        /// The script file identifier.
        /// </value>
        Nullable<int> ScriptFileId { get; set; }
        /// <summary>
        /// Gets or sets the sentby.
        /// </summary>
        /// <value>
        /// The sentby.
        /// </value>
        string Sentby { get; set; }
    }
}
