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
    public static class GetDropdownDurationTypeList
    {
        /// <summary>
        /// Durations the type list items.
        /// </summary>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="selectedDurationTypecode">The selected duration typecode.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> DurationTypeListItems(IList<IDurationType> durationType,
           string selectedDurationTypecode)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectAdvertDuration,
                    Value = "-1",
                    Selected = (selectedDurationTypecode == "")
                }
            };

            if (durationType.Any())
            {
                list.AddRange(durationType.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.DurationTypeCode.ToString(),
                    Selected = (t.DurationTypeCode.Equals(selectedDurationTypecode))
                }));
            }

            return list;
        }
    }
}
