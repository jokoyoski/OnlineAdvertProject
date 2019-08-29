using System;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvTransactionAiring
    {
        /// <summary>
        /// Gets or sets the name of the material typ timing.
        /// </summary>
        /// <value>
        /// The name of the material typ timing.
        /// </value>
        string MaterialTypTimingName { get; set; }
        /// <summary>
        /// Gets or sets the name of the time belt.
        /// </summary>
        /// <value>
        /// The name of the time belt.
        /// </value>
        string TimeBeltName { get; set; }



        /// <summary>
        /// Gets or sets the tv transaction airing identifier.
        /// </summary>
        /// <value>
        /// The tv transaction airing identifier.
        /// </value>
        int TVTransactionAiringId { get; set; }

        /// <summary>
        /// Gets or sets the tv transaction identifier.
        /// </summary>
        /// <value>
        /// The tv transaction identifier.
        /// </value>
        int TVTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the tv station identifier.
        /// </summary>
        /// <value>
        /// The tv station identifier.
        /// </value>
        int TVStationId { get; set; }

        /// <summary>
        /// Gets or sets the material type timing identifier.
        /// </summary>
        /// <value>
        /// The material type timing identifier.
        /// </value>
        int MaterialTypeTimingId { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }

        /// <summary>
        /// Gets or sets the name of the tv station.
        /// </summary>
        /// <value>
        /// The name of the tv station.
        /// </value>
        string TVStationName { get; set; }


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
        int Slots { get; set; }



        /// <summary>
        /// Gets or sets the total slots.
        /// </summary>
        /// <value>
        /// The total slots.
        /// </value>
        int TotalSlots { get; set; }

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
        /// Gets or sets the time belt identifier.
        /// </summary>
        /// <value>
        /// The time belt identifier.
        /// </value>
        int TimeBeltId { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal Price { get; set; }
    }
}