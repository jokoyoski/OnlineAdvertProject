using System;
using System.ComponentModel.DataAnnotations;

namespace ADit.Interfaces
{
    public interface IRegistrationView
    {



        int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Phonenumber { get; set; }
        /// <summary>
        /// 
        /// </summary>


        DateTime DateCreated { get; set; }
        [Required]
        string Password { get; set; }
        [Required]
        string ConfirmPassword { get; set; }


        bool Consent { get; set; }

        string ProcessingMessage { get; set; }



    }
    public interface IEmailVerificationView
    {

        [Required]
         string Email { get; set; }
       string ProcessingMessage { get; set; }
    }
}