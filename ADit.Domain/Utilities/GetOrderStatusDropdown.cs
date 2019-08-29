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
   public class GetOrderStatusDropdown
    {
        internal static IList<SelectListItem>OrderSelectListItem(IList<IOrderFulfilmentStatus> orderFulfilmentStatuses,
             int orderStatus)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectOrderStatus,
                    Value = "",
                    Selected = ( orderStatus < 1)
                }
            };

            if (orderFulfilmentStatuses.Any())
            {
                list.AddRange(orderFulfilmentStatuses.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.FulfilmentStatusCode.ToString(),
                    Selected = (t.FulfilmentStatusCode.Equals(orderStatus))
                }));
            }

            return list;
        }
    }
}
