using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    public class UserListView : IUserListView
    {

        /// <summary>
        /// Gets or sets the get user registration list.
        /// </summary>
        /// <value>
        /// The get user registration list.
        /// </value>
        public IList<IUserModel> UserRegistrationList { get; set; }
        /// </summary>
        /// <value>
        /// The first name of the selected.
        /// </value>
       public string selectedFirstName { get; set; }
        /// <summary>
        /// Gets or sets the selected email address.
        /// </summary>
        /// <value>
        /// The selected email address.
        /// </value>
      public  string selectedEmailAddress { get; set; }




    }
}

