using ADit.Interfaces;
using System;
using System.Collections.Generic;

namespace ADit.Repositories.Models
{
    public class RadioTransactionAiringModel : IRadioTransactionAiring
    {

        /// <summary>
        /// Gets or sets the name of the material typ timing.
        /// </summary>
        /// <value>
        /// The name of the material typ timing.
        /// </value>
        public string MaterialTypTimingName { get; set; }
        /// <summary>
        /// Gets or sets the name of the time belt.
        /// </summary>
        /// <value>
        /// The name of the time belt.
        /// </value>
        public string TimeBeltName { get; set; }
        /// <summary>
        /// Gets or sets the slots.
        /// </summary>
        /// <value>
        /// The slots.
        /// </value>
        public int Slots { get; set; }
        /// <summary>
        /// Gets or sets the total slots.
        /// </summary>
        /// <value>
        /// The total slots.
        /// </value>
        public int TotalSlots { get; set; }
        /// <summary>
        /// Gets or sets the time belt identifier.
        /// </summary>
        /// <value>
        /// The time belt identifier.
        /// </value>
        public int TimeBeltId { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Gets or sets the radio transaction airing identifier.
        /// </summary>
        /// <value>
        /// The radio transaction airing identifier.
        /// </value>
        public int RadioTransactionAiringId { get; set; }

        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        public int RadioTransactionId { get; set; }
        public string MaterialQuestionId { get; set; }
        /// <summary>
        /// Gets or sets the radio station identifier.
        /// </summary>
        /// <value>
        /// The radio station identifier.
        /// </value>
        public int RadioStationId { get; set; }

        /// <summary>
        /// Gets or sets the material type timing identifier.
        /// </summary>
        /// <value>
        /// The material type timing identifier.
        /// </value>
        public int MaterialTypeTimingId { get; set; }

        /// <summary>
        /// Gets or sets the duration type code.
        /// </summary>
        /// <value>
        /// The duration type code.
        /// </value>
        public string DurationTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        public int DurationQuantity { get; set; }

        /// <summary>
        /// Gets or sets the airing number per day.
        /// </summary>
        /// <value>
        /// The airing number per day.
        /// </value>
        public int AiringNumberPerDay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }


        /// <summary>
        /// Gets or sets the name of the radio station.
        /// </summary>
        /// <value>
        /// The name of the radio station.
        /// </value>
        public string RadioStationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the material type.
        /// </summary>
        /// <value>
        /// The name of the material type.
        /// </value>
        public string TimingName { get; set; }


        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public string DurationName { get; set; }

        public decimal Price { get; set; }

        public IList<IRadioStationModel> RadioStation { get; set; }
    }
}