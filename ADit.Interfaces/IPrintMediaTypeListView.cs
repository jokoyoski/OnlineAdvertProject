using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
    public interface IPrintMediaTypeListView
    {
        /// <summary>
        /// Gets or sets the get print media types.
        /// </summary>
        /// <value>
        /// The get print media types.
        /// </value>
        IList<IPrintMediaType> GetPrintMediaTypes { get; set; }
        /// <summary>
        /// Gets or sets the selected print media type identifier.
        /// </summary>
        /// <value>
        /// The selected print media type identifier.
        /// </value>
        int selectedPrintMediaTypeId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string selectedDescription { get; set; }
    }
}
