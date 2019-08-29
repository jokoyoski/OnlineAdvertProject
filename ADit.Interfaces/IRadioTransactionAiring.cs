using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioTransactionAiring
    {

        /// <summary>
        /// Gets or sets the name of the material typ timing.
        /// </summary>
        /// <value>
        /// The name of the material typ timing.
        /// </value>
        string MaterialTypTimingName { get; set;
        }
        /// <summary>
        /// Gets or sets the name of the time belt.
        /// </summary>
        /// <value>
        /// The name of the time belt.
        /// </value>
        string TimeBeltName { get; set; }

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
        /// Gets or sets the time belt identifier.
        /// </summary>
        /// <value>
        /// The time belt identifier.
        /// </value>
        int TimeBeltId { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        DateTime EndDate { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the radio transaction airing identifier.
        /// </summary>
        /// <value>
        /// The radio transaction airing identifier.
        /// </value>
        int RadioTransactionAiringId { get; set; }
        /// <summary>
        /// Gets or sets the material question identifier.
        /// </summary>
        /// <value>
        /// The material question identifier.
        /// </value>
        string MaterialQuestionId { get; set; }
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
        /// Gets or sets the material type timing identifier.
        /// </summary>
        /// <value>
        /// The material type timing identifier.
        /// </value>
        int MaterialTypeTimingId { get; set; }

        /// <summary>
        /// Gets or sets the duration type code.
        /// </summary>
        /// <value>
        /// The duration type code.
        /// </value>
        string DurationTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        int DurationQuantity { get; set; }

        /// <summary>
        /// Gets or sets the airing number per day.
        /// </summary>
        /// <value>
        /// The airing number per day.
        /// </value>
        int AiringNumberPerDay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the name of the radio station.
        /// </summary>
        /// <value>
        /// The name of the radio station.
        /// </value>
        string RadioStationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the timing.
        /// </summary>
        /// <value>
        /// The name of the timing.
        /// </value>
        string TimingName { get; set; }


        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        string DurationName { get; set; }
        /// <summary>
        /// Gets or sets the radio station.
        /// </summary>
        /// <value>
        /// The radio station.
        /// </value>
        IList<IRadioStationModel> RadioStation { get; set; }
    }
}
