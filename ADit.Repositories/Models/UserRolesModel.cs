using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Repositories.Models
{
   public class UserRolesModel :IUserRolesModel
    {/// <summary>
     /// Gets or sets the user roles identifier.
     /// </summary>
     /// <value>
     /// The user roles identifier.
     /// </value>
        public int UserRolesId { get; set; }

        /// <summary>
        /// Gets or sets the user roles description.
        /// </summary>
        /// <value>
        /// The user roles description.
        /// </value>
        public string UserRolesDescription { get; set; }
    }
}
