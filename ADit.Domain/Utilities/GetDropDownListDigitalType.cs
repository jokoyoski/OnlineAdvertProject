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
    public static class GetDropDownListDigitalType
    {
        /// <summary>
        /// Digitals the type.
        /// </summary>
        /// <param name="digitalType">Type of the digital.</param>
        /// <param name="selectedApconApprovalId">The selected apcon approval identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> DigitalType(IList<IDigitalType> digitalType,
            int selectedApconApprovalId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectApprovalTypeText,
                    Value = "-1",
                    Selected = (selectedApconApprovalId < 1)
                }
            };

            if (digitalType.Any())
            {
                list.AddRange(digitalType.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.DigitalTypeId.ToString(),
                    Selected = (t.DigitalTypeId.Equals(selectedApconApprovalId))
                }));
            }

            return list;
        }
    }
}
