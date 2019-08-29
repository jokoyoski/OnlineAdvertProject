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
    public static class GetDropDownColorList
    {
        /// <summary>
        /// Colors the list items.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="selectedColorId">The selected color identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ColorListItems(IList<IColor> color,
           int[] selectedColorId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectColorText,
                    Value = "-1",
                    Selected = false
                }
            };

            if (color.Any())
            {
                list.AddRange(color.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.ColorId.ToString(),
                    Selected = selectedColorId.Contains(t.ColorId)
                }));
            }

            return list;
        }
    }
}
