using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Repositories.Models
{
   public class FulfilmentStatusRuleModel : IFulfilmentStatusRule
    {

        /// <summary>
        /// Gets or sets the fulfilment status identifier.
        /// </summary>
        /// <value>
        /// The fulfilment status identifier.
        /// </value>
       public int FulfilmentStatusId { get; set; }

        /// <summary>
        /// Gets or sets from status identifier.
        /// </summary>
        /// <value>
        /// From status identifier.
        /// </value>
      public  string FromStatusId { get; set; }

        /// <summary>
        /// Gets or sets to status identifier.
        /// </summary>
        /// <value>
        /// To status identifier.
        /// </value>
      public  string ToStatusId { get; set; }
    }
}
