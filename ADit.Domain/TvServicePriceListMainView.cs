using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Domain
{
  public  class TvServicePriceListMainView :ITVServicePricesListMainView
    {
     public    IList<ITVServicePricesList> tVServicePricesListCollection { get; set; }
        /// </value>
      public int SelectedTvServicesPriceId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
      public   string SelectedDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
       public  string processingMessage { get; set; }
    }
}
