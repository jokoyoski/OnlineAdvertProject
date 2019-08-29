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
    public static class GetOnlinePurposeDropdownList
    {
        /// <summary>
        /// Called when [purpose list items].
        /// </summary>
        /// <param name="OnlinePurposeCollection">The online purpose collection.</param>
        /// <param name="selectedOnlinePurposeId">The selected online purpose identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> OnlinePurposeListItems(IList<IOnlinePurpose> OnlinePurposeCollection,
            int selectedOnlinePurposeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                   Text = Common.SelectOnlinePurposeText,
                    Value = "-1",
                    Selected = (selectedOnlinePurposeId < 1)
                }
            };

            if (OnlinePurposeCollection.Any())
            {
                list.AddRange(OnlinePurposeCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,  //this is the Title
                    Value = t.OnlinePurposeId.ToString(),  //Id
                    Selected = (t.OnlinePurposeId.Equals(selectedOnlinePurposeId))
                }));
            }

            return list;
        }
    }
}
