using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    public interface ITvTransactionAiringModel
    {
        /// <summary>
        /// Gets or sets the radio transaction airing identifier.
        /// </summary>
        /// <value>
        /// The radio transaction airing identifier.
        /// </value>
        int TvTransactionAiringId { get; set; }

        /// <summary>
        /// Gets or sets the tv station.
        /// </summary>
        /// <value>
        /// The tv station.
        /// </value>
        IList<ITvStation> TvStation { get; set; }

        /// <summary>
        /// Gets or sets the duration code.
        /// </summary>
        /// <value>
        /// The duration code.
        /// </value>
        IList<IList<SelectListItem>> DurationCode { get; set; }

        /// <summary>
        /// Gets or sets the timing.
        /// </summary>
        /// <value>
        /// The timing.
        /// </value>
        IList<IList<SelectListItem>> Timing { get; set; }

        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        IList<int> Slots { get; set; }

        /// <summary>
        /// Gets or sets the airing number per day.
        /// </summary>
        /// <value>
        /// The airing number per day.
        /// </value>
        IList<int> TotalSlots { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        IList<decimal> Price { get; set; }


        /// <summary>
        /// Gets or sets the time belt.
        /// </summary>
        /// <value>
        /// The time belt.
        /// </value>
        IList<IList<SelectListItem>> TimeBelt { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        IList<DateTime> StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        IList<DateTime> EndDate { get; set; }


        /// <summary>
        /// Gets or sets the days.
        /// </summary>
        /// <value>
        /// The days.
        /// </value>
        IList<int> Days { get; set; }
    }
}