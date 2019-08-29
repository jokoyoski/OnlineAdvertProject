using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// The Registration Repository Model
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IRegistration" />
    /// <seealso cref="IRegistration" />
    public class RegistrationRepModel : IRegistration
    {
       public  string UserType { get; set; }
        /// <summary>
        /// Gets or sets the forget password code.
        /// </summary>
        /// <value>
        /// The forget password code.
        /// </value>
        public string ForgetPasswordCode { get; set; }
        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        public int UserRegistrationId { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the phonenumber.
        /// </summary>
        /// <value>
        /// The phonenumber.
        /// </value>
        public string Phonenumber { get; set; }
        /// <summary>
        /// Gets or sets the is user verified.
        /// </summary>
        /// <value>
        /// The is user verified.
        /// </value>
        public Nullable<bool> IsUserVerified { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is locked.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is locked; otherwise, <c>false</c>.
        /// </value>
        public bool IsLocked { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date verified.
        /// </summary>
        /// <value>
        /// The date verified.
        /// </value>
        public DateTime? DateVerified { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:ADit.Interfaces.IRegistration" /> is consent.
        /// </summary>
        /// <value>
        /// <c>true</c> if consent; otherwise, <c>false</c>.
        /// </value>
        public bool Consent { get; set; }

    }


   
}
