using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITvTransactionAiring" />
    public class TvTransactionAiringModel : ITvTransactionAiring
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
        /// Gets or sets the tv transaction airing identifier.
        /// </summary>
        /// <value>
        /// The tv transaction airing identifier.
        /// </value>
        public int TVTransactionAiringId { get; set; }

        /// <summary>
        /// Gets or sets the tv transaction identifier.
        /// </summary>
        /// <value>
        /// The tv transaction identifier.
        /// </value>
        public int TVTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the tv station identifier.
        /// </summary>
        /// <value>
        /// The tv station identifier.
        /// </value>
        public int TVStationId { get; set; }

        /// <summary>
        /// Gets or sets the material type timing identifier.
        /// </summary>
        /// <value>
        /// The material type timing identifier.
        /// </value>
        public int MaterialTypeTimingId { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }


        /// <summary>
        /// Gets or sets the name of the tv station.
        /// </summary>
        /// <value>
        /// The name of the tv station.
        /// </value>
        public string TVStationName { get; set; }


        /// <summary>
        /// Gets or sets the name of the timing.
        /// </summary>
        /// <value>
        /// The name of the timing.
        /// </value>
        public string TimingName { get; set; }


        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public string DurationName { get; set; }


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
        public int Slots { get; set; }

        /// <summary>
        /// Gets or sets the total slots.
        /// </summary>
        /// <value>
        /// The total slots.
        /// </value>
        public int TotalSlots { get; set; }

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
        /// Gets or sets the time belt identifier.
        /// </summary>
        /// <value>
        /// The time belt identifier.
        /// </value>
        public int TimeBeltId { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
    }
}