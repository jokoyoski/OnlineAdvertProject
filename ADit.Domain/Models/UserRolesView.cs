using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
   public class UserRolesView :IUserRolesView
    { /// <summary>
      /// <summary>
      /// Gets or sets the user roles list.
      /// </summary>
      /// <value>
      /// The user roles list.
      /// </value>
        public IList<IUserRolesModel> UserRoles { get; set; }

        /// <summary>
        /// Gets or sets the user roles identifier.
        /// </summary>
        /// <value>
        /// The user roles identifier.
        /// </value>
      public  int UserRolesId { get; set; }

        /// <summary>
        /// Gets or sets the user roles list.
        /// </summary>
        /// <value>
        /// The user roles list.
        /// </value>
        public IList<SelectListItem> UserRolesList { get; set; }


        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the created by.
        /// </summary>
        /// <value>
        /// The name of the created by.
        /// </value>
        public string CreatedByName { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string processingMessage { get; set; }


    }
}
