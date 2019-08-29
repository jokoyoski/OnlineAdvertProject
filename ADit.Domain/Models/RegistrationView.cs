using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ADit.Interfaces;
using Compare = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace ADit.Domain.Models
{
    public class RegistrationView : IRegistrationView
    {
        public RegistrationView()
        {
            this.ProcessingMessage = string.Empty;
            this.DateCreated = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        public int UserRegistrationId { get; set; }

        /// <summary>
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        public string Phonenumber { get; set; }

        /// <summary>
        /// </summary>
        public DateTime DateCreated { get; set; }


        [DisplayName("Password")]
        [Required] public string Password { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RegistrationView"/> is consent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if consent; otherwise, <c>false</c>.
        /// </value>
        [Required(ErrorMessage = "You have to agree with the terms  of services")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You have to agree with the terms  of services")]
        public bool Consent { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }

    public class EmailVerificationView : IEmailVerificationView
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}