﻿using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Repositories.Models
{
   public class UserModel :IUserModel
    {
        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        public int UserRegistrationId { get; set; }
        /// <summary>
       /// Gets or sets the first name.
       /// </summary>
       /// <value>
       /// The first name.
       /// </value>
      public  string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
     public   string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phonu number.
        /// </summary>
        /// <value>
        /// The phonu number.
        /// </value>
      public  string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
       public string Email { get; set; }
    }
}