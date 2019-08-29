using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioMainView
    {/// <summary>
    /// 
    /// </summary>

        string CurrentStatusDescription { get; set; }
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
        int OrderFulfilmentId { get; set; }

        /// <summary>
        /// Gets or sets the current status code.
        /// </summary>
        /// <value>
        /// The current status code.
        /// </value>
        string CurrentStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the status code list.
        /// </summary>
        /// <value>
        /// The status code list.
        /// </value>
        IList<SelectListItem> StatusCodeList { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int userId { get; set; }


        /// <summary>
        /// Gets or sets the radio station name list.
        /// </summary>
        /// <value>
        /// The radio station name list.
        /// </value>
        List<string> RadioStationNameList { get; set; }

        /// <summary>
        /// Gets or sets the timing list.
        /// </summary>
        /// <value>
        /// The timing list.
        /// </value>
        List<string> TimingList { get; set; }

        /// <summary>
        /// Gets or sets the slots list.
        /// </summary>
        /// <value>
        /// The slots list.
        /// </value>
        List<int> SlotsList { get; set; }

        /// <summary>
        /// Gets or sets the total slots list.
        /// </summary>
        /// <value>
        /// The total slots list.
        /// </value>
        List<int> TotalSlotsList { get; set; }

        /// <summary>
        /// Gets or sets the prices list.
        /// </summary>
        /// <value>
        /// The prices list.
        /// </value>
        List<decimal> PricesList { get; set; }

        /// <summary>
        /// Gets or sets the start date list.
        /// </summary>
        /// <value>
        /// The start date list.
        /// </value>
        List<DateTime> StartDateList { get; set; }

        /// <summary>
        /// Gets or sets the end date list.
        /// </summary>
        /// <value>
        /// The end date list.
        /// </value>
        List<DateTime> EndDateList { get; set; }

        /// <summary>
        /// Gets or sets the time belt names list.
        /// </summary>
        /// <value>
        /// The time belt names list.
        /// </value>
        List<string> TimeBeltNamesList { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the type of the apcon.
        /// </summary>
        /// <value>
        /// The type of the apcon.
        /// </value>
        string ApconType { get; set; }

        /// <summary>
        /// Gets or sets the daterange.
        /// </summary>
        /// <value>
        /// The daterange.
        /// </value>
        string[] daterange { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        DateTime[] StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        DateTime[] EndDate { get; set; }

        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
        int[] TimingId { get; set; }

        /// <summary>
        /// Gets or sets the time belt identifier.
        /// </summary>
        /// <value>
        /// The time belt identifier.
        /// </value>
        int[] TimeBeltId { get; set; }

        /// <summary>
        /// Gets or sets the slots.
        /// </summary>
        /// <value>
        /// The slots.
        /// </value>
        int[] Slots { get; set; }

        /// <summary>
        /// Gets or sets the total slots.
        /// </summary>
        /// <value>
        /// The total slots.
        /// </value>
        int[] totalSlots { get; set; }

        /// <summary>
        /// Gets or sets the time belt list.
        /// </summary>
        /// <value>
        /// The time belt list.
        /// </value>
        IList<SelectListItem> TimeBeltList { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        int RadioTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the radio identifier.
        /// </summary>
        /// <value>
        /// The radio identifier.
        /// </value>
        int RadioId { get; set; }

        /// <summary>
        /// Gets or sets the type of the radio.
        /// </summary>
        /// <value>
        /// The type of the radio.
        /// </value>
        IList<SelectListItem> RadioType { get; set; }

        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        int MaterialDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the script material question code.
        /// </summary>
        /// <value>
        /// The script material question code.
        /// </value>
        string ScriptMaterialQuestionCode { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval price collection.
        /// </summary>
        /// <value>
        /// The apcon approval price collection.
        /// </value>
        IList<IApconApprovalTypePrice> ApconApprovalPriceCollection { get; set; }

        /// <summary>
        /// Gets or sets the type of the apcon approval.
        /// </summary>
        /// <value>
        /// The type of the apcon approval.
        /// </value>
        IList<SelectListItem> ApconApprovalType { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type price identifier.
        /// </value>
        int ApconApprovalTypePriceId { get; set; }

        /// <summary>
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        decimal FinalAmount { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type identifier.
        /// </value>
        int ApconApprovalTypeId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval amount.
        /// </summary>
        /// <value>
        /// The apcon approval amount.
        /// </value>
        decimal ApconApprovalAmount { get; set; }

        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        IList<SelectListItem> MaterialType { get; set; }

        /// <summary>
        /// Gets or sets the type of the active material.
        /// </summary>
        /// <value>
        /// The type of the active material.
        /// </value>
        IList<SelectListItem> ActiveMaterialType { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        int MaterialTypeId { get; set; }


        string MaterialTypeName { get; set; }

        /// <summary>
        /// Gets or sets the material scripting price identifier.
        /// </summary>
        /// <value>
        /// The material scripting price identifier.
        /// </value>
        int MaterialScriptingPriceId { get; set; }

        /// <summary>
        /// Gets or sets the material production price identifier.
        /// </summary>
        /// <value>
        /// The material production price identifier.
        /// </value>
        int MaterialProductionPriceId { get; set; }

        /// <summary>
        /// Gets or sets the scripting amount.
        /// </summary>
        /// <value>
        /// The scripting amount.
        /// </value>
        decimal ScriptingAmount { get; set; }

        /// <summary>
        /// Gets or sets the script description.
        /// </summary>
        /// <value>
        /// The script description.
        /// </value>
        string ScriptDescription { get; set; }

        /// <summary>
        /// Gets or sets the material question identifier.
        /// </summary>
        /// <value>
        /// The material question identifier.
        /// </value>
        string MaterialQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the production description.
        /// </summary>
        /// <value>
        /// The production description.
        /// </value>
        string ProductionDescription { get; set; }

        /// <summary>
        /// Gets or sets the production amount.
        /// </summary>
        /// <value>
        /// The production amount.
        /// </value>
        decimal ProductionAmount { get; set; }

        /// <summary>
        /// Gets or sets the radio station identifier.
        /// </summary>
        /// <value>
        /// The radio station identifier.
        /// </value>
        int[] RadioStationId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveMaterial { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>

        string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the type of the radio station.
        /// </summary>
        /// <value>
        /// The type of the radio station.
        /// </value>
        IList<SelectListItem> RadioStationType { get; set; }

        /// <summary>
        /// Gets or sets the script question.
        /// </summary>
        /// <value>
        /// The script question.
        /// </value>
        IList<SelectListItem> ScriptQuestion { get; set; }

        /// <summary>
        /// Gets or sets the radio station description.
        /// </summary>
        /// <value>
        /// The radio station description.
        /// </value>
        string RadioStationDescription { get; set; }

        /// <summary>
        /// Gets or sets the duration code.
        /// </summary>
        /// <value>
        /// The duration code.
        /// </value>
        string[] DurationCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the duration.
        /// </summary>
        /// <value>
        /// The type of the duration.
        /// </value>
        IList<SelectListItem> DurationType { get; set; }

        /// <summary>
        /// Gets or sets the airing description.
        /// </summary>
        /// <value>
        /// The airing description.
        /// </value>
        string AiringDescription { get; set; }

        /// <summary>
        /// Gets or sets the timing description.
        /// </summary>
        /// <value>
        /// The timing description.
        /// </value>
        string TimingDescription { get; set; }

        /// <summary>
        /// Gets or sets the type of the timing.
        /// </summary>
        /// <value>
        /// The type of the timing.
        /// </value>
        IList<SelectListItem> TimingType { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }

        /// <summary>
        /// Gets or sets the is have scripts.
        /// </summary>
        /// <value>
        /// The is have scripts.
        /// </value>
        IList<SelectListItem> IsHaveScripts { get; set; }

        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        System.DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have apcon approval.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have apcon approval; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveApconApproval { get; set; }

        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        Nullable<System.DateTime> DateInactive { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval number.
        /// </summary>
        /// <value>
        /// The apcon approval number.
        /// </value>
        string ApconApprovalNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }


        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }


        /// <summary>
        /// Gets or sets the airing.
        /// </summary>
        /// <value>
        /// The airing.
        /// </value>
        int Airing { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the script digital file identifier.
        /// </summary>
        /// <value>
        /// The script digital file identifier.
        /// </value>
        int ScriptDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }


        /// <summary>
        /// Gets or sets the radio airing list.
        /// </summary>
        /// <value>
        /// The radio airing list.
        /// </value>
        IList<IRadioTransactionAiring> RadioAiringList { get; set; }

        /// <summary>
        /// Gets or sets the radio airing list details.
        /// </summary>
        /// <value>
        /// The radio airing list details.
        /// </value>
        IRadioAiringTransactionModel RadioAiringListDetails { get; set; }

        /// <summary>
        /// Gets or sets the radio station list.
        /// </summary>
        /// <value>
        /// The radio station list.
        /// </value>
        IList<IRadioStationModel> RadioStationList { get; set; }

        /// <summary>
        /// Gets or sets the duration quantity.
        /// </summary>
        /// <value>
        /// The duration quantity.
        /// </value>
        int[] DurationQuantity { get; set; }

        /// <summary>
        /// Gets or sets the airing number per day.
        /// </summary>
        /// <value>
        /// The airing number per day.
        /// </value>
        int[] AiringNumberPerDay { get; set; }


        /// <summary>
        /// Gets or sets the radio station price.
        /// </summary>
        /// <value>
        /// The radio station price.
        /// </value>
        decimal[] RadioStationPrice { get; set; }

        /// <summary>
        /// Gets or sets the is radio selected.
        /// </summary>
        /// <value>
        /// The is radio selected.
        /// </value>
        bool[] IsRadioSelected { get; set; }

        /// <summary>
        /// Gets or sets the radio channel list.
        /// </summary>
        /// <value>
        /// The radio channel list.
        /// </value>
        List<Dictionary<string, string>> RadioChannelList { get; set; }
    }
}