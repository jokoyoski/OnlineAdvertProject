using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
   public  class RadioAiringTransactionModel : IRadioAiringTransactionModel
    {
        public RadioAiringTransactionModel()
        {
            RadioStation = new List<IRadioStationModel>();
            DurationTypeCode = new List<IList<SelectListItem>>();
            MaterialTypeTiming = new List<IList<SelectListItem>>();
            DurationQuantity = new List<int>();
            AiringNumberPerDay = new List<int>();
            StartDate = new List<DateTime>();
            TimeBelts = new List<IList<SelectListItem>>();

            EndDate = new List<DateTime>();
            Slots = new List<int>();
            TotalSlot = new List<int>();

            Price = new List<decimal>();

        }

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


       

        /// <summary>
        /// Gets or sets the tv station.
        /// </summary>
        /// <value>
        /// The tv station.
        /// </value>
        public IList<IRadioStationModel> RadioStation { get; set; }

        /// <summary>
        /// Gets or sets the duration code.
        /// </summary>
        /// <value>
        /// The duration code.
        /// </value>
        public IList<IList<SelectListItem>> DurationTypeCode { get; set; }


       // public IList<IList<SelectListItem>> TimeBelts { get; set; }

        /// <summary>
        /// Gets or sets the timing.
        /// </summary>
        /// <value>
        /// The timing.
        /// </value>
        public IList<IList<SelectListItem>> MaterialTypeTiming { get; set; }


        public IList<DateTime> StartDate { get; set; }
        public IList<DateTime> EndDate { get; set; }
        public IList<IList<SelectListItem>> TimeBelts { get; set; }

        public IList<int> Slots { get; set; }
        public IList<int>TotalSlot { get; set; }
        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        public IList<int> DurationQuantity { get; set; }

        /// <summary>
        /// Gets or sets the airing number per day.
        /// </summary>
        /// <value>
        /// The airing number per day.
        /// </value>
        public IList<int> AiringNumberPerDay { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public IList<decimal> Price { get; set; }
    }
}
