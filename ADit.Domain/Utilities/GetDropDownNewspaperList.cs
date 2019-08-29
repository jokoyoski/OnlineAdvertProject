using ADit.Domain.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ADit.Interfaces;

namespace ADit.Domain.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetDropDownNewspaperList
    {

        /// <summary>
        /// Newses the paper items.
        /// </summary>
        /// <param name="NewspaperCollection">The newspaper collection.</param>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> NewsPaperItems(IList<INewsPaper> NewspaperCollection,
            int newsPaperId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectDropDownNewsPaperText,
                    Value = "-1",
                    Selected = (newsPaperId < 1)
                }
            };

            if (NewspaperCollection.Any())
            {
                list.AddRange(NewspaperCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.NewsPaperId.ToString(),
                    Selected = (t.NewsPaperId.Equals(newsPaperId))
                }));
            }

            return list;
        }

    }
}
