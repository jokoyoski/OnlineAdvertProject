using ADit.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineArtworkTransactionListView" />
    public class OnlineArtworkTransactionListView : IOnlineArtworkTransactionListView
    {

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        /// 
        [Required]
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the sent to identifier.
        /// </summary>
        /// <value>
        /// The sent to identifier.
        /// </value>
        public int SentToId { get; set; }
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        public int? MessageId { get; set; }
        /// <summary>
        /// Gets or sets the replies identifier.
        /// </summary>
        /// <value>
        /// The replies identifier.
        /// </value>
        public int RepliesId { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        public string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the sent by.
        /// </summary>
        /// <value>
        /// The sent by.
        /// </value>
        public int SentBy { get; set; }
        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        public string AdditionalInfo { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int userId { get; set; }
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public int transactionId { get; set; }
        /// <summary>
        /// Gets or sets the material details.
        /// </summary>
        /// <value>
        /// The material details.
        /// </value>
        /// 
        [Required]
        public string MaterialDetails { get; set; }
        /// <summary>
        /// Gets or sets the artwork file identifier.
        /// </summary>
        /// <value>
        /// The artwork file identifier.
        /// </value>
        public int? ArtworkFileId { get; set; }
        /// <summary>
        /// Gets or sets the service code.
        /// </summary>
        /// <value>
        /// The service code.
        /// </value>
        public string ServiceCode { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public string MaterialType { get; set; }
        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        public int DigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the uploaded material detail.
        /// </summary>
        /// <value>
        /// The uploaded material detail.
        /// </value>
        public int? UploadedMaterialDetail { get; set; }
        /// <summary>
        /// Gets or sets the online artwork transactons.
        /// </summary>
        /// <value>
        /// The online artwork transactons.
        /// </value>
        public IList<IOnlineArtworkTransacton> onlineArtworkTransactons { get; set; }
        /// <summary>
        /// Gets or sets the digital file list.
        /// </summary>
        /// <value>
        /// The digital file list.
        /// </value>
        public IList<IDigitalFile> digitalFileList { get; set; }
    }
}
