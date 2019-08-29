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
    public static class GetDropDownTvStationList
    {


        /// <summary>
        /// Tvs the station.
        /// </summary>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> tvStation(IList<ITvStation> tvStation,
               int tvStationId)
            {
                var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.GetTvStationText,
                    Value = "-1",
                    Selected = (tvStationId < 1)
                }
            };

                if (tvStation.Any())
                {
                    list.AddRange(tvStation.Select(t => new SelectListItem
                    {
                        Text = t.Description,
                        Value = t.TVStationId.ToString(),
                        Selected = (t.TVStationId.Equals(tvStationId))
                    }));
                }

                return list;
            }
        }
    }

