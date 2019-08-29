using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    public interface IRadioTransactionUIView : IRadioTransactionUI
    {
        /// <summary>
        /// Gets or sets the selected radio station ids.
        /// </summary>
        /// <value>The selected radio station ids.</value>
        List<int> SelectedRadioStationIds { get; set; }

        /// <summary>
        /// Gets or sets the script question.
        /// </summary>
        /// <value>
        /// The script question.
        /// </value>
        IList<SelectListItem> ScriptQuestion { get; set; }

        /// <summary>
        /// Gets or sets the type of the apcon approval.
        /// </summary>
        /// <value>
        /// The type of the apcon approval.
        /// </value>
        IList<SelectListItem> ApconApprovalType { get; set; }

        /// <summary>
        /// Gets or sets the type of the active material.
        /// </summary>
        /// <value>
        /// The type of the active material.
        /// </value>
        IList<SelectListItem> ActiveMaterialType { get; set; }

        /// <summary>
        /// Gets or sets the type of the timing.
        /// </summary>
        /// <value>
        /// The type of the timing.
        /// </value>
        IList<SelectListItem> TimingType { get; set; }

        /// <summary>
        /// Gets or sets the time belt list.
        /// </summary>
        /// <value>
        /// The time belt list.
        /// </value>
        IList<SelectListItem> TimeBeltList { get; set; }

        /// <summary>
        /// Gets or sets the radio station list.
        /// </summary>
        /// <value>
        /// The radio station list.
        /// </value>
        IList<IRadioStationModel> RadioStationList { get; set; }

        /// <summary>
        /// Gets or sets the airing details list.
        /// </summary>
        /// <value>
        /// The airing details list.
        /// </value>
        IList<IRadioTransactionAiringUI>  AiringDetailsList { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value> 
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets the radio station description.
        /// </summary>
        /// <param name="radioStationId">The radio station identifier.</param>
        /// <returns>System.String.</returns>
        string GetRadioStationDescription(int radioStationId);

        /// <summary>
        /// Gets the timing DDL.
        /// </summary>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns>IList&lt;SelectListItem&gt;.</returns>
        IList<SelectListItem> GetTimingDDL(int timingId);

        /// <summary>
        /// Gets the timing belt DDL.
        /// </summary>
        /// <param name="timingBeltId">The timing belt identifier.</param>
        /// <returns>IList&lt;SelectListItem&gt;.</returns>
        IList<SelectListItem> GetTimingBeltDDL(int timingBeltId);
    }
}
