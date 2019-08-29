using ADit.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ADit.Domain.Resources;

namespace ADit.Domain.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetDropDownPrintCategoryList
    {
        /// <summary>
        /// Prints the category items.
        /// </summary>
        /// <param name="PrinCategoriesCollection">The prin categories collection.</param>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> PrintCategoryItems(IList<IPrintCategory> PrinCategoriesCollection,
            int printCategoryId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectDropDownPrintCategoryText,
                    Value = "-1",
                    Selected = (printCategoryId < 1)
                }
            };

            if (PrinCategoriesCollection.Any())
            {
                list.AddRange(PrinCategoriesCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.PrintCategoryId.ToString(),
                    Selected = (t.PrintCategoryId.Equals(printCategoryId))
                }));
            }

            return list;
        }

    }
}
