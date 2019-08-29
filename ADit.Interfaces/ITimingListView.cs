using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface  ITimingListView
    {
        /// <summary>
        /// Gets or sets the selected branding material identifier.
        /// </summary>
        /// <value>
        /// The selected branding material identifier.
        /// </value>
        int SelectedTimingId { get; set; }

        /// <summary>
        /// Gets or sets the selected description.
        /// </summary>
        /// <value>
        /// The selected description.
        /// </value>
        string SelectedDescription { get; set; }


        /// <summary>
        /// Gets or sets the timing.
        /// </summary>
        /// <value>
        /// The timing.
        /// </value>
        ITiming Timing { get; set; }



        /// <summary>
        /// Gets or sets the branding material collection.
        /// </summary>
        /// <value>
        /// The branding material collection.
        /// </value>
        IList<ITiming> TimingCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

    }
}
