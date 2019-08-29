using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class TvTransactionAiringModel : ITvTransactionAiringModel
    {
        public TvTransactionAiringModel()
        {
            TvStation = new List<ITvStation>();
            DurationCode = new List<IList<SelectListItem>>();
            Timing = new List<IList<SelectListItem>>();
            Slots = new List<int>();
            TotalSlots = new List<int>();
            Price = new List<decimal>();
            TimeBelt = new List<IList<SelectListItem>>();
            StartDate = new List<DateTime>();
            EndDate = new List<DateTime>();
            Days = new List<int>();
        }

        /// <summary>
        /// Gets or sets the radio transaction airing identifier.
        /// </summary>
        /// <value>
        /// The radio transaction airing identifier.
        /// </value>
        public int TvTransactionAiringId { get; set; }

        /// <summary>
        /// Gets or sets the tv station. 
        /// </summary>
        /// <value>
        /// The tv station.
        /// </value> 
        public IList<ITvStation> TvStation { get; set; }

        /// <summary>
        /// Gets or sets the duration code.
        /// </summary>
        /// <value>
        /// The duration code.
        /// </value>
        public IList<IList<SelectListItem>> DurationCode { get; set; }

        /// <summary>
        /// Gets or sets the timing.
        /// </summary>
        /// <value>
        /// The timing.
        /// </value>
        public IList<IList<SelectListItem>> Timing { get; set; }

        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        public IList<int> Slots { get; set; }

        /// <summary>
        /// Gets or sets the airing number per day.
        /// </summary>
        /// <value>
        /// The airing number per day.
        /// </value>
        public IList<int> TotalSlots { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public IList<decimal> Price { get; set; }

        /// <summary>
        /// Gets or sets the time belt identifier.
        /// </summary>
        /// <value>
        /// The time belt identifier.
        /// </value>
        public IList<IList<SelectListItem>> TimeBelt { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public IList<DateTime> StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public IList<DateTime> EndDate { get; set; }

        /// <summary>
        /// Gets or sets the days.
        /// </summary>
        /// <value>
        /// The days.
        /// </value>
        public IList<int> Days { get; set; }
    }
}