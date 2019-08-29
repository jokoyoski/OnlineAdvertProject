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
    public static class GetDropDownListTvStation
    {
        /// <summary>
        /// Tvs the list items.
        /// </summary>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="selectedTvStationType">Type of the selected tv station.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> TvListItems(IList<ITvStation> tvStation,
                      int selectedTvStationType)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.GetTvStationText,
                    Value = "-1",
                    Selected = ( selectedTvStationType < 1)
                }
            };

            if (tvStation.Any())
            {
                list.AddRange(tvStation.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.TVStationId.ToString(),
                    Selected = (t.TVStationId.Equals(selectedTvStationType))
                }));
            }

            return list;
        }
    }
}

