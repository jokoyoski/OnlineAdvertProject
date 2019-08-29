using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    public interface IUserRolesView
    {

        /// <summary>
        /// Gets or sets the user roles identifier.
        /// </summary>
        /// <value>
        /// The user roles identifier.
        /// </value>
        int UserRolesId { get; set; }

        /// <summary>
        /// Gets or sets the user roles list.
        /// </summary>
        /// <value>
        /// The user roles list.
        /// </value>
        IList<IUserRolesModel> UserRoles { get; set; }


        /// <summary>
        /// Gets or sets the user roles list.
        /// </summary>
        /// <value>
        /// The user roles list.
        /// </value>
         IList<SelectListItem> UserRolesList { get; set; }


        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
         string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the created by.
        /// </summary>
        /// <value>
        /// The name of the created by.
        /// </value>
        string CreatedByName { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string processingMessage { get; set; }

    }
}
