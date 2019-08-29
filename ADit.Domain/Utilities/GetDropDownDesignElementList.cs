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
    public static class GetDropDownDesignElementList
    {
        /// <summary>
        /// Designs the element list items.
        /// </summary>
        /// <param name="designElement">The design element.</param>
        /// <param name="selectedDesignElementId">The selected design element identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> DesignElementListItems(IList<IDesignElement> designElement,
           int selectedDesignElementId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectDesignElementText,
                    Value = "-1",
                    Selected = (selectedDesignElementId < 1)
                }
            };

            if (designElement.Any())
            {
                list.AddRange(designElement.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.DesignElementId.ToString(),
                    Selected = (t.DesignElementId.Equals(selectedDesignElementId))
                }));
            }

            return list;
        }
    }
}

