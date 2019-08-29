using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Domain.Models
{
   public class PrintServiceColorListView  : IPrintServiceColorListView
    {
        /// <summary>
        /// Gets or sets the get print media types.
        /// </summary>
        /// <value>
        /// The get print media types.
        /// </value>
        public IList<IPrintServiceColor> GetPrintServiceColor { get; set; }
        /// <summary>
        /// Gets or sets the selected print media type identifier.
        /// </summary>
        /// <value>
        /// The selected print media type identifier.
        /// </value>
        public int SelectedPrintServiceTypeColorId { get; set; }
        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        public string SelectedPrintServiceTypeColor { get; set; }
        public List<IPrintMediaType> GetPrintMediaTypes { get; internal set; }
    }
}
