using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioScriptTransactionListView
    {
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        string Subject { get; set; }
        /// <summary>
        /// Gets or sets the message list.
        /// </summary>
        /// <value>
        /// The message list.
        /// </value>
        IList<IMessage> messageList { get; set; }
        /// <summary>
        /// Gets or sets the replies list.
        /// </summary>
        /// <value>
        /// The replies list.
        /// </value>
        IList<IReplies> repliesList { get; set; }
        /// <summary>
        /// Checks if approved.
        /// </summary>
        /// <param name="sentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="ServiceCode">The service code.</param>
        /// <returns></returns>
        bool CheckIfApproved(int sentToId, int transactionId, string materialType, string ServiceCode);
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        int? MessageId { get; set; }
        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        int? DigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the replies identifier.
        /// </summary>
        /// <value>
        /// The replies identifier.
        /// </value>
        int RepliesId { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the sent to identifier.
        /// </summary>
        /// <value>
        /// The sent to identifier.
        /// </value>
        int SentToId { get; set; }
        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        string AdditionalInfo { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int userId { get; set; }
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        int transactionId { get; set; }
        /// <summary>
        /// Gets or sets the script details.
        /// </summary>
        /// <value>
        /// The script details.
        /// </value>
        string ScriptDetails { get; set; }
        /// <summary>
        /// Gets or sets the digital script file identifier.
        /// </summary>
        /// <value>
        /// The digital script file identifier.
        /// </value>
        int digitalScriptFileId { get; set; }
        /// <summary>
        /// Gets or sets the service code.
        /// </summary>
        /// <value>
        /// The service code.
        /// </value>
        string ServiceCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        string MaterialType { get; set; }
        /// <summary>
        /// Gets or sets the uploaded script detail.
        /// </summary>
        /// <value>
        /// The uploaded script detail.
        /// </value>
        IDigitalFile UploadedScriptDetail { get; set; }
        /// <summary>
        /// Gets or sets the radio script transaction.
        /// </summary>
        /// <value>
        /// The radio script transaction.
        /// </value>
        IList<IRadioScriptTransaction> radioScriptTransaction { get; set; }
        /// <summary>
        /// Gets or sets the digital file list.
        /// </summary>
        /// <value>
        /// The digital file list.
        /// </value>
        IList<IDigitalFile> digitalFileList { get; set; }
    }
}
