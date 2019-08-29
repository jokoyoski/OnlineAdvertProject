using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
   public interface IPrintServiceColorListView
    {
        /// <summary>
        /// Gets or sets the get print media types.
        /// </summary>
        /// <value>
        /// The get print media types.
        /// </value>
        IList<IPrintServiceColor> GetPrintServiceColor { get; set; }
        /// <summary>
        /// Gets or sets the selected print media type identifier.
        /// </summary>
        /// <value>
        /// The selected print media type identifier.
        /// </value>
        int SelectedPrintServiceTypeColorId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedPrintServiceTypeColor { get; set; }

    }
}
