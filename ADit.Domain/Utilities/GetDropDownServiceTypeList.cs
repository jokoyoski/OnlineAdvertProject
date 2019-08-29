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
    public static class GetDropDownServiceTypeList
    {
        /// <summary>
        /// Prints the service type items.
        /// </summary>
        /// <param name="serviceTypeCollection">The service type collection.</param>
        /// <param name="serviceTypeId">The service type identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> PrintServiceTypeItems(IList<IPrintServiceType> serviceTypeCollection,
            int serviceTypeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectDropDownServiceTypeText,
                    Value = "-1",
                    Selected = (serviceTypeId < 1)
                }
            };

            if (serviceTypeCollection.Any())
            {
                list.AddRange(serviceTypeCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.PrintServiceTypeId.ToString(),
                    Selected = (t.PrintServiceTypeId.Equals(serviceTypeId))
                }));
            }

            return list;

        }

        /// <summary>
        /// Services the type list items.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="servicetypeCode">The servicetype code.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ServiceTypeListItems(IList<IServiceType> serviceType, string servicetypeCode)
            {
                var list = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = Common.SelectDropDownServiceTypeText,
                        Value = "-1",
                        Selected = (servicetypeCode  == "")
                    }
                };
                if (serviceType.Any())
                {
                    list.AddRange(serviceType.Select(t => new SelectListItem
                    {
                        Text = t.Description,
                        Value = t.ServiceTypeCode,
                        Selected = (t.ServiceTypeCode.Equals(servicetypeCode))
                    }));
                }
                return list;
            }

        /// <summary>
        /// Prints the service type price items.
        /// </summary>
        /// <param name="serviceTypeCollection">The service type collection.</param>
        /// <param name="serviceTypeId">The service type identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> PrintServiceTypePriceItems(IList<IPrintServiceTypePrice> serviceTypeCollection,
            int serviceTypeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectDropDownServiceTypeText,
                    Value = "-1",
                    Selected = (serviceTypeId < 1)
                }
            };

            if (serviceTypeCollection.Any())
            {
                list.AddRange(serviceTypeCollection.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.PrintServiceTypeId.ToString(),
                    Selected = (t.PrintServiceTypeId.Equals(serviceTypeId))
                }));
            }

            return list;

        }

    }
}
