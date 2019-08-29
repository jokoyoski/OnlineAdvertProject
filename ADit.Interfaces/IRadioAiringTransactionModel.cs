using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioAiringTransactionModel
    {
        /// <summary>
        /// Gets or sets the time belts.
        /// </summary>
        /// <value>
        /// The time belts.
        /// </value>


        IList<IList<SelectListItem>> TimeBelts { get; set; }
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
        /// Gets or sets the slots.
        /// </summary>
        /// <value>
        /// The slots.
        /// </value>
        IList<int> Slots { get; set; }

        /// <summary>
        /// Gets or sets the total slot.
        /// </summary>
        /// <value>
        /// The total slot.
        /// </value>
        IList<int> TotalSlot { get; set; }
        /// <summary>
        /// Gets or sets the radio transaction airing identifier.
        /// </summary>
        /// <value>
        /// The radio transaction airing identifier.
        /// </value>
        int RadioTransactionAiringId { get; set; }

        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        int RadioTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the tv station.
        /// </summary>
        /// <value>
        /// The tv station.
        /// </value>
        IList<IRadioStationModel> RadioStation { get; set; }

        /// <summary>
        /// Gets or sets the duration code.
        /// </summary>
        /// <value>
        /// The duration code.
        /// </value>
        IList<IList<SelectListItem>> DurationTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the timing.
        /// </summary>
        /// <value>
        /// The timing.
        /// </value>
        IList<IList<SelectListItem>> MaterialTypeTiming { get; set; }

        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        IList<int> DurationQuantity { get; set; }

        /// <summary>
        /// Gets or sets the airing number per day.
        /// </summary>
        /// <value>
        /// The airing number per day.
        /// </value>
        IList<int> AiringNumberPerDay { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        IList<decimal> Price { get; set; }
    }
}
