using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain
{
  public  class TvServicePriceListMainView :ITVServicePricesListMainView
    {
        
    /// <summary>
    /// 
    /// </summary>
     public    IList<ITVServicePricesList> tVServicePricesListCollection { get; set; }
      
        /// <summary>
        /// 
        /// </summary>
      public int SelectedTvServicesPriceId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
      public   string selectedDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
       public  string processingMessage { get; set; }
    }
}
