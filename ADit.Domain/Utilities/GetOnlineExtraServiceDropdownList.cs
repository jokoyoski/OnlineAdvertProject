using ADit.Domain.Resources;
using ADit.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ADit.Domain.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetOnlineExtraServiceDropdownList
    {
        /// <summary>
        /// Called when [extra service list items].
        /// </summary>
        /// <param name="OnlineExtraServiceCollection">The online extra service collection.</param>
        /// <param name="selectedOnlineExtraServiceId">The selected online extra service identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> OnlineExtraServiceListItems(IList<IOnlineExtraService> OnlineExtraServiceCollection,
            int selectedOnlineExtraServiceId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                   Text = Common.SelectOnlineExraServicesText,
                    Value = "-1",
                    Selected = (selectedOnlineExtraServiceId < 1)
                }
            };

            if (OnlineExtraServiceCollection.Any())
            {
                list.AddRange(OnlineExtraServiceCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,  //this is the Title
                    Value = t.OnlineExtraServiceId.ToString(),  //Id
                    Selected = (t.OnlineExtraServiceId.Equals(selectedOnlineExtraServiceId))
                }));
            }

            return list;
        }
    }
}
