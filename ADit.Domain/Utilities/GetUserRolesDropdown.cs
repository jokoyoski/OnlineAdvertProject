using ADit.Domain.Resources;
using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ADit.Domain.Utilities
{
   internal static class GetUserRolesDropdown
    {/// <summary>
    /// /
    /// </summary>
    /// <param name="userRolesModels"></param>
    /// <param name="selecteduserRoles"></param>
    /// <returns></returns>
        internal static IList<SelectListItem> UserRolesListItems(IList<IUserRolesModel> userRolesModels,
             int selecteduserRoles)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectUserRoles,
                    Value = "-1",
                    Selected = (selecteduserRoles < 1)
                }
            };

            if (userRolesModels.Any())
            {
                list.AddRange(userRolesModels.Select(t => new SelectListItem
                {
                    Text = t.UserRolesDescription,
                    Value = t.UserRolesId.ToString(),
                    Selected = (t.UserRolesId.Equals(selecteduserRoles))
                }));
            }

            return list;
        }
    }
}
