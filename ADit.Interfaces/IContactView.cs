using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactView
    {
        /// <summary>
        /// Gets or sets the contact list.
        /// </summary>
        /// <value>
        /// The contact list.
        /// </value>
        IList<SelectListItem> contactList
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the decsription.
        /// </summary>
        /// <value>
        /// The decsription.
        /// </value>
        string Decsription { get; set; }
        /// <summary>
        /// Gets or sets the contact identifier.
        /// </summary>
        /// <value>
        /// The contact identifier.
        /// </value>
        int ContactId { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>
        /// The customer email.
        /// </value>
        string customerEmail { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }
    }
}
