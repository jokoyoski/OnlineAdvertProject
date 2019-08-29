using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
   public  interface IPrintServiceColor
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int PrintServiceTypeColorId { get; set; }
        /// <summary>
        /// Gets or sets the color of the print service type.
        /// </summary>
        /// <value>
        /// The color of the print service type.
        /// </value>
        string PrintServiceTypeColor { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
       bool IsActive { get; set; }
    }
}
