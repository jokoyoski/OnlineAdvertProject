using ADit.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ADit.Domain.Models
{
  public  class LogOnView :ILogOnView
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        /// 
        
       [Required]
      public  string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
      public  string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to [remember me].
        /// </summary>
        /// <value><c>true</c> if [remember me]; otherwise, <c>false</c>.</value>
       public bool RememberMe { get; set; }

        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>The return URL.</value>
      public  string ReturnUrl { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
      public  string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the info message.
        /// </summary>
        /// <value>The info message.</value>
      public  string InfoMessage { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has info message.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has info message; otherwise, <c>false</c>.
        /// </value>
       public bool HasInfoMessage { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has invalid credentials.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has invalid credentials; otherwise, <c>false</c>.
        /// </value>
        /// 

      public  bool HasInvalidCredentials { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has invalid user name.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has invalid user name; otherwise, <c>false</c>.
        /// </value>
     public   bool HasInvalidUserName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has invalid password.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has invalid password; otherwise, <c>false</c>.
        /// </value>
      public  bool HasInvalidPassword { get; set; }

    }
}
