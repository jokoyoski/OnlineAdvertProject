using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    public interface IRadioTransactionAiringView
    {
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
        /// Gets or sets the radio stations list.
        /// </summary>
        /// <value>
        /// The radio stations list.
        /// </value>
        IList<SelectListItem> RadioStationsList { get; set; }

        /// <summary>
        /// Gets or sets the timing.
        /// </summary>
        /// <value>
        /// The timing.
        /// </value>
        IList<SelectListItem> Timing { get; set; }


        /// <summary>
        /// Gets or sets the duration type code list.
        /// </summary>
        /// <value>
        /// The duration type code list.
        /// </value>
        IList<SelectListItem> DurationTypeCodeList { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }


        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        int CartId { get; set; }
    }
}