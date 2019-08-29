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
    public class GetDropDownTimeBelt
    {

        /// <summary>
        /// Times the belt items.
        /// </summary>
        /// <param name="timeBelts">The time belts.</param>
        /// <param name="selectedId">The selected identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> TimeBeltItems(IList<ITimeBelt> timeBelts,
           int selectedId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectTimingBelt,
                    Value = "-1",
                    Selected = (selectedId < 1)
                }
            };

            if (timeBelts.Any())
            {
                list.AddRange(timeBelts.Select(t => new SelectListItem
                {
                    Text = t.name,
                    Value = t.TimeBeltId.ToString(),
                    Selected = (t.TimeBeltId.Equals(selectedId))
                }));
            }

            return list;
        }
    }
}
  