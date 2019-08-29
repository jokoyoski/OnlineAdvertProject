using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingAttachmentTransactionListView
    {
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        string Subject { get; set; }
        /// <summary>
        /// Gets or sets the sent to identifier.
        /// </summary>
        /// <value>
        /// The sent to identifier.
        /// </value>
        int SentToId { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        int? MessageId { get; set; }
        /// <summary>
        /// Gets or sets the replies identifier.
        /// </summary>
        /// <value>
        /// The replies identifier.
        /// </value>
        int RepliesId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the sent by.
        /// </summary>
        /// <value>
        /// The sent by.
        /// </value>
        int SentBy { get; set; }
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
        /// Gets or sets the material details.
        /// </summary>
        /// <value>
        /// The material details.
        /// </value>
        string MaterialDetails { get; set; }
        /// <summary>
        /// Gets or sets the digital material file identifier.
        /// </summary>
        /// <value>
        /// The digital material file identifier.
        /// </value>
        int digitalMaterialFileId { get; set; }
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
        /// Gets or sets the uploaded material detail.
        /// </summary>
        /// <value>
        /// The uploaded material detail.
        /// </value>
        int? UploadedMaterialDetail { get; set; }
        /// <summary>
        /// Gets or sets the branding attachment transactions.
        /// </summary>
        /// <value>
        /// The branding attachment transactions.
        /// </value>
        IList<IBrandingAttachmentTransaction> brandingAttachmentTransactions { get; set; }
        
    }
}
