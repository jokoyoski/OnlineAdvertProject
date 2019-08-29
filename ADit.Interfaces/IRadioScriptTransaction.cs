using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface  IRadioScriptTransaction
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
        Nullable<DateTime> dateUpdated { get; set; }


        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        string Details { get; set; }
        /// <summary>
        /// Gets or sets the script file identifier.
        /// </summary>
        /// <value>
        /// The script file identifier.
        /// </value>
        Nullable<int> ScriptFileId { get; set; }

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
        /// Gets or sets the sent to.
        /// </summary>
        /// <value>
        /// The sent to.
        /// </value>
        string sentTo { get; set; }
    }
}
