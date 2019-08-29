using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IMessage" />
    public class MessageModel: IMessage
    {

        /// <summary>
        /// Gets or sets a value indicating whether this instance is admin read.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is admin read; otherwise, <c>false</c>.
        /// </value>
       public  bool? isAdminRead { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        public DateTime dateModified { get; set; }
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the is approved.
        /// </summary>
        /// <value>
        /// The is approved.
        /// </value>
        public bool IsApproved { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// </summary>
        public int TransactionId { get; set; }
        /// <summary>
        /// </summary>
        public Nullable<int> DigitalFileId { get; set; }
        /// <summary>
        /// </summary>
        public int SentToId { get; set; }
        /// <summary>
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// </summary>
        public bool IsRead { get; set; }
        /// <summary>
        /// </summary>
        public string ServiceCode { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public string MaterialType { get; set; }

        /// <summary>
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }
    }
}
