using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRegistration
    {

        string UserType { get; set; }
        /// <summary>
        /// Gets or sets the forget password code.
        /// </summary>
        /// <value>
        /// The forget password code.
        /// </value>
        string ForgetPasswordCode { get; set; }

        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        int UserRegistrationId { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        string LastName { get; set; }
        /// <summary>
        /// Gets or sets the phonenumber.
        /// </summary>
        /// <value>
        /// The phonenumber.
        /// </value>
        string Phonenumber { get; set; }
        /// <summary>
        /// Gets or sets the is user verified.
        /// </summary>
        /// <value>
        /// The is user verified.
        /// </value>
        Nullable<bool> IsUserVerified { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is locked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is locked; otherwise, <c>false</c>.
        /// </value>
        bool IsLocked { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date verified.
        /// </summary>
        /// <value>
        /// The date verified.
        /// </value>
        DateTime? DateVerified { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IRegistration"/> is consent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if consent; otherwise, <c>false</c>.
        /// </value>
        bool Consent { get; set; }

    }
}
