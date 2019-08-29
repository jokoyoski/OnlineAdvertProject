using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
   public  interface IUserRolesModel
    {
        /// <summary>
        /// Gets or sets the user roles identifier.
        /// </summary>
        /// <value>
        /// The user roles identifier.
        /// </value>
        int UserRolesId { get; set; }

        /// <summary>
        /// Gets or sets the user roles description.
        /// </summary>
        /// <value>
        /// The user roles description.
        /// </value>
        string UserRolesDescription { get; set; }
    }
}
