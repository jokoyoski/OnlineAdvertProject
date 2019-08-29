using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvTransactionView
    {
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        string Subject { get; set; }
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
        string materialType { get; set; }
        /// <summary>
        /// Gets or sets the sent to identifier.
        /// </summary>
        /// <value>
        /// The sent to identifier.
        /// </value>
        int SentToId { get; set; }
        /// <summary>
        /// Gets or sets the tv transaction identifier.
        /// </summary>
        /// <value>
        /// The tv transaction identifier.
        /// </value>
        int TVTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        string Details { get; set; }
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        int OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets the sent by.
        /// </summary>
        /// <value>
        /// The sent by.
        /// </value>
        int SentBy { get; set; }
        /// <summary>
        /// Gets or sets the digital script file identifier.
        /// </summary>
        /// <value>
        /// The digital script file identifier.
        /// </value>
        Nullable<int> digitalScriptFileId { get; set; }

        /// <summary>
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        decimal FinalAmount { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the uploaded script detail.
        /// </summary>
        /// <value>
        /// The uploaded script detail.
        /// </value>
        IDigitalFile UploadedScriptDetail { get; set; }
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        Nullable<int> MessageId { get; set; }
        /// <summary>
        /// Gets or sets the replies identifier.
        /// </summary>
        /// <value>
        /// The replies identifier.
        /// </value>
        int RepliesId { get; set; }
        /// <summary>
        /// Gets or sets the tv script transaction.
        /// </summary>
        /// <value>
        /// The tv script transaction.
        /// </value>
        IList<ITvScriptingTransactionModelView> tvScriptTransaction { get; set; }
        /// <summary>
        /// Gets or sets the digital material file identifier.
        /// </summary>
        /// <value>
        /// The digital material file identifier.
        /// </value>
        Nullable<int> digitalMaterialFileId { get; set; }
        /// <summary>
        /// Gets or sets the uploaded material detail.
        /// </summary>
        /// <value>
        /// The uploaded material detail.
        /// </value>
        IDigitalFile UploadedMaterialDetail { get; set; }
        /// <summary>
        /// Gets or sets the tv material transaction.
        /// </summary>
        /// <value>
        /// The tv material transaction.
        /// </value>
        IList<ITvMaterialTransactionModel> tvMaterialTransaction { get; set; }
    }
}
