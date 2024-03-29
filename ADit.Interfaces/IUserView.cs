﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
  public  interface IUserView
    {  /// <summary>
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
        /// Gets or sets the phonu number.
        /// </summary>
        /// <value>
        /// The phonu number.
        /// </value>
        string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }
    }
}
