using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
   public  interface IUserListView
    {
        /// <summary>
        /// Gets or sets the get user registration list.
        /// </summary>
        /// <value>
        /// The get user registration list.
        /// </value>
         IList<IUserModel> UserRegistrationList { get; set; }
        /// <summary>
        /// Gets or sets the first name of the selected.
        /// </summary>
        /// <value>
        /// The first name of the selected.
        /// </value>
        string selectedFirstName { get; set; }
        /// <summary>
        /// Gets or sets the selected email address.
        /// </summary>
        /// <value>
        /// The selected email address.
        /// </value>
        string selectedEmailAddress { get; set; }

        
    }
}
