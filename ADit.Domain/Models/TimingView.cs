using ADit.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    public class TimingView : ITimingView
    {

        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
       public int TimingId { get; set; }
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
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
        public   string ProcessingMessage { get; set; }


        /// <summary>
        /// Gets or sets the parent timing drop down.
        /// </summary>
        /// <value>
        /// The parent timing drop down.
        /// </value>
        public IList<SelectListItem> ParentTimingDropDown { get; set; }

    }
}
