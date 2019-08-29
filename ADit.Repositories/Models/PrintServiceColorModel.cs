using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Repositories.Models
{
   public  class PrintServiceColorModel : IPrintServiceColor
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
       public   int PrintServiceTypeColorId { get; set; }
        /// <summary>
        /// Gets or sets the color of the print service type.
        /// </summary>
        /// <value>
        /// The color of the print service type.
        /// </value>
      public  string PrintServiceTypeColor { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool IsActive { get; set; }


    }
}
