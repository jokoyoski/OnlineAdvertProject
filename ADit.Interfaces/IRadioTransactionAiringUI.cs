using System;

namespace ADit.Interfaces
{
    public interface IRadioTransactionAiringUI
    {

        /// <summary>
        /// Gets or sets the radio transaction airing identifier.
        /// </summary>
        /// <value>
        /// The radio transaction airing identifier.
        /// </value>
        int RadioTransactionAiringId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        bool IsSelected { get; set; }

        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        int RadioTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the radio station identifier.
        /// </summary>
        /// <value>
        /// The radio station identifier.
        /// </value>
        int RadioStationId { get; set; }

        /// <summary>
        /// Gets or sets the time belt identifier.
        /// </summary>
        /// <value>
        /// The time belt identifier.
        /// </value>
        int TimeBeltId { get; set; }

        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
        int TimingId { get; set; }

       /// <summary>
        /// Gets or sets the material type timing identifier.
        /// </summary>
        /// <value>
        /// The material type timing identifier.
        /// </value>
        int MaterialTypeTimingId { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        DateTime? EndDate { get; set; }


        /// <summary>
        /// Gets or sets the slots.
        /// </summary>
        /// <value>
        /// The slots.
        /// </value>
        int Slots { get; set; }

        /// <summary>
        /// Gets or sets the total slots.
        /// </summary>
        /// <value>
        /// The total slots.
        /// </value>
        int TotalSlots { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal RadioStationPrice { get; set; }
 
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}
