using System.Collections.Generic;
using System.Web.Mvc;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class RadioTransactionAiringView : IRadioTransactionAiringView
    {
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
        /// Gets or sets the radio stations list.
        /// </summary>
        /// <value>
        /// The radio stations list.
        /// </value>
        public IList<SelectListItem> RadioStationsList { get; set; }

        /// <summary>
        /// Gets or sets the timing.
        /// </summary>
        /// <value>
        /// The timing.
        /// </value>
        public IList<SelectListItem> Timing { get; set; }

        /// <summary>
        /// Gets or sets the duration type code list.
        /// </summary>
        /// <value>
        /// The duration type code list.
        /// </value>
        public IList<SelectListItem> DurationTypeCodeList { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        public int CartId { get; set; }
    }
}