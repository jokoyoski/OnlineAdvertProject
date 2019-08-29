using System;

namespace ADit.Interfaces
{
  public   interface IMessage
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is admin read.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is admin read; otherwise, <c>false</c>.
        /// </value>
        bool? isAdminRead { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        string OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        DateTime dateModified { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsApproved { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int TransactionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Nullable<int> DigitalFileId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int SentToId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsRead { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string ServiceCode { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        string MaterialType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string AdminName { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; set; }
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        string Subject { get; set; }

    }
}
