using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Domain.Models
{
  public  class PrintMediaTypeView :IPrintMediaType
    { /// <summary>
      /// Gets or sets the print media type identifier.
      /// </summary>
      /// <value>
      /// The print media type identifier.
      /// </value>
      public  int PrintMediaTypeId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
      public  string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
      public  bool IsActive { get; set; }
    }
}
