using ADit.Domain.Resources;
using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ADit.Domain.Utilities
{
  public   class GetDropDownPrintServiceColors
    {
        // Prints the service type items.
        /// </summary>
        /// <param name="serviceTypeCollection">The service type collection.</param>
        /// <param name="serviceTypeId">The service type identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> PrintServiceColorItems(IList<IPrintServiceColor> serviceTypeCollection,
            int serviceTypeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectPrintServiceColor,
                    Value = "-1",
                    Selected = (serviceTypeId < 1)
                }
            };

            if (serviceTypeCollection.Any())
            {
                list.AddRange(serviceTypeCollection.Select(t => new SelectListItem
                {
                    Text = t.PrintServiceTypeColor,
                    Value = t.PrintServiceTypeColorId.ToString(),
                    Selected = (t.PrintServiceTypeColorId.Equals(serviceTypeId))
                }));
            }

            return list;

        }








        internal static IList<SelectListItem> PrintMediaTypeItems(IList<IPrintMediaType> mediaTypeCollection,
           int printTypeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectePrintMediaType,
                    Value = "-1",
                    Selected = (printTypeId < 1)
                }
            };

            if (mediaTypeCollection.Any())
            {
                list.AddRange(mediaTypeCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.PrintMediaTypeId.ToString(),
                    Selected = (t.PrintMediaTypeId.Equals(printTypeId))
                }));
            }

            return list;

        }
    }
}
