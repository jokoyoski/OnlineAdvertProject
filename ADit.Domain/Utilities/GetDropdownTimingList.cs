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
    public static class GetDropdownTimingList
    {
        /// <summary>
        /// Timings the list items.
        /// </summary>
        /// <param name="timing">The timing.</param>
        /// <param name="selectedTiming">The selected timing.</param>
        /// <returns></returns>

        internal static IList<SelectListItem> TimingListItems(IList<ITiming> timing,
                     int selectedTiming)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectTimingText,
                    Value = "-1",
                    Selected = ( selectedTiming < 1)
                }
            };

            if (timing.Any())
            {
                list.AddRange(timing.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.TimingId.ToString(),
                    Selected = (t.TimingId.Equals(selectedTiming))
                }));
            }

            return list.Distinct().ToList();
        }

        /// <summary>
        /// Timings the list.
        /// </summary>
        /// <param name="timing">The timing.</param>
        /// <param name="selectedTiming">The selected timing.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> TimingList(IList<IMaterialTypeTimingModel> timing,
                     int selectedTiming)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectTimingText,
                    Value = "-1",
                    Selected = ( selectedTiming < 1)
                }
            };

            if (timing.Any())
            {
                list.AddRange(timing.Select(t => new SelectListItem
                {
                    Text = t.Timing,
                    Value = t.TimingId.ToString(),
                    Selected = (t.TimingId.Equals(selectedTiming))
                }));
            }

            return list.Distinct().ToList();
        }
    }
}
