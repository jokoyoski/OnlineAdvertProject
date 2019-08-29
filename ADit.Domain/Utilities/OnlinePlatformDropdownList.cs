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
    public static class GetOnlinePlatformDropdownList
    {
        /// <summary>
        /// Called when [platform list items].
        /// </summary>
        /// <param name="OnlinePlatformCollection">The online platform collection.</param>
        /// <param name="selectedOnlinePlatformId">The selected online platform identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> OnlinePlatformListItems(IList<IOnlinePlatform> OnlinePlatformCollection,
            int selectedOnlinePlatformId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                   Text = Common.SelectOnlinePlatformText,
                    Value = "-1",
                    Selected = (selectedOnlinePlatformId < 1)
                }
            };

            if (OnlinePlatformCollection.Any())
            {
                list.AddRange(OnlinePlatformCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,  //this is the Title
                    Value = t.OnlinePlatformId.ToString(),  //Id
                    Selected = (t.OnlinePlatformId.Equals(selectedOnlinePlatformId))
                }));
            }

            return list;
        }
    }
}
