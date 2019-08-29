using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvView
    {


        /// <summary>
        /// Gets or sets the current status description.
        /// </summary>
        /// <value>
        /// The current status description.
        /// </value>
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
        /// Gets or sets the messages lists.
        /// </summary>
        /// <value>
        /// The messages lists.
        /// </value>
        IList<IMessage> messagesLists { get; set; }

        /// <summary>
        /// Gets or sets the replies lists.
        /// </summary>
        /// <value>
        /// The replies lists.
        /// </value>
        IList<IReplies> repliesLists { get; set; }
        /// <summary>
        /// Gets the inital message.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        bool getInitalMessage(int SentToId, int transactionId, string ServiceType);

        /// <summary>
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        bool getIfScriptIsApproved(int SentToId, int transactionId, string ServiceType);
        /// <summary>
        /// Gets or sets the scripting material code.
        /// </summary>
        /// <value>
        /// The scripting material code.
        /// </value>
        string ScriptingMaterialCode { get; set; }

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
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the tv station name list.
        /// </summary>
        /// <value>
        /// The tv station name list.
        /// </value>
        List<string> TvStationNameList { get; set; }
        /// <summary>
        /// Gets or sets the timing name list.
        /// </summary>
        /// <value>
        /// The timing name list.
        /// </value>
        List<string> TimingNameList { get; set; }
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
        /// Gets or sets the tv transaction identifier.
        /// </summary>
        /// <value>
        /// The tv transaction identifier.
        /// </value>
        int TVTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the type of the apcon.
        /// </summary>
        /// <value>
        /// The type of the apcon.
        /// </value>
        string ApconType { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveMaterial { get; set; }

        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        int? ProductionDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the scripting type identifier.
        /// </summary>
        /// <value>
        /// The scripting type identifier.
        /// </value>
        int ScriptingDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the script description.
        /// </summary>
        /// <value>
        /// The script description.
        /// </value>
        string ScriptDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have apcon approval.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have apcon approval; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveApconApproval { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval number.
        /// </summary>
        /// <value>
        /// The apcon approval number.
        /// </value>
        string ApconApprovalNumber { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type identifier.
        /// </value>
        Nullable<int> ApconApprovalTypeId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type price identifier.
        /// </value>
        Nullable<int> ApconApprovalTypePriceId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval amount.
        /// </summary>
        /// <value>
        /// The apcon approval amount.
        /// </value>
        decimal ApconApprovalAmount { get; set; }

        /// <summary>
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        decimal FinalAmount { get; set; }

        /// <summary>
        /// Gets or sets the airing instruction.
        /// </summary>
        /// <value>
        /// The airing instruction.
        /// </value>
        string AiringInstruction { get; set; }

        /// <summary>
        /// Gets or sets the duration type code.
        /// </summary>
        /// <value>
        /// The duration type code.
        /// </value>
        string DurationTypeCode { get; set; }

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
        int[] TotalSlots { get; set; }


        /// <summary>
        /// Gets or sets the tv station price.
        /// </summary>
        /// <value>
        /// The tv station price.
        /// </value>
        decimal[] TvStationPrice { get; set; }


        /// <summary>
        /// Gets or sets the is tv selected.
        /// </summary>
        /// <value>
        /// The is tv selected.
        /// </value>
        bool[] IsTVSelected { get; set; }


        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        string TransactionStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the apcon type DLL.
        /// </summary>
        /// <value>
        /// The apcon type DLL.
        /// </value>
        IList<SelectListItem> APCONTypeList { get; set; }

        /// <summary>
        /// Gets or sets the material list.
        /// </summary>
        /// <value>
        /// The material list.
        /// </value>
        IList<SelectListItem> MaterialList { get; set; }

        /// <summary>
        /// Gets or sets the tv station list.
        /// </summary>
        /// <value>
        /// The tv station list.
        /// </value>
        IList<ITvStation> TvStationList { get; set; }

        /// <summary>
        /// Gets or sets the advert duration list.
        /// </summary>
        /// <value>
        /// The advert duration list.
        /// </value>
        IList<SelectListItem> AdvertDurationList { get; set; }

        /// <summary>
        /// Gets or sets the number of aring list.
        /// </summary>
        /// <value>
        /// The number of aring list.
        /// </value>
        IList<SelectListItem> NumberOfAringList { get; set; }


        /// <summary>
        /// Gets or sets the timing list.
        /// </summary>
        /// <value>
        /// The timing list.
        /// </value>
        IList<SelectListItem> TimingList { get; set; }

        /// <summary>
        /// Gets or sets the time belt.
        /// </summary>
        /// <value>
        /// The time belt.
        /// </value>
        IList<SelectListItem> TimeBeltList { get; set; }

        /// <summary>
        /// Gets or sets the tv station identifier.
        /// </summary>
        /// <value>
        /// The tv station identifier.
        /// </value>
        int[] TVStationId { get; set; }


        /// <summary>
        /// Gets or sets the type of the duration.
        /// </summary>
        /// <value>
        /// The type of the duration.
        /// </value>
        string[] DurationType { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        int MaterialTypeId { get; set; }

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
        /// Gets or sets the selected apcon aproval price.
        /// </summary>
        /// <value>
        /// The selected apcon aproval price.
        /// </value>
        decimal SelectedApconAprovalPrice { get; set; }

        /// <summary>
        /// Gets or sets the production amount.
        /// </summary>
        /// <value>
        /// The production amount.
        /// </value>
        decimal ProductionAmount { get; set; }

        /// <summary>
        /// Gets or sets the scripting amount.
        /// </summary>
        /// <value>
        /// The scripting amount.
        /// </value>
        decimal ScriptingAmount { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the material production type identifier.
        /// </summary>
        /// <value>
        /// The material production type identifier.
        /// </value>
        int MaterialProductionTypeId { get; set; }

        /// <summary>
        /// Gets or sets the material scripting type identifier.
        /// </summary>
        /// <value>
        /// The material scripting type identifier.
        /// </value>
        int MaterialScriptingTypeId { get; set; }

        /// <summary>
        /// Gets or sets the material question.
        /// </summary>
        /// <value>
        /// The material question.
        /// </value>
        IList<SelectListItem> MaterialQuestion { get; set; }

        /// <summary>
        /// Gets or sets the material question identifier.
        /// </summary>
        /// <value>
        /// The material question identifier.
        /// </value>
        string MaterialQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }


        /// <summary>
        /// Gets or sets the tv airing list.
        /// </summary>
        /// <value>
        /// The tv airing list.
        /// </value>
        IList<ITvTransactionAiring> TVAiringList { get; set; }

        /// <summary>
        /// Gets or sets the tv transaction details.
        /// </summary>
        /// <value>
        /// The tv transaction details.
        /// </value>
        ITvTransactionAiringModel TvTransactionDetails { get; set; }

        /// <summary>
        /// Gets or sets the tv channel list.
        /// </summary>
        /// <value>
        /// The tv channel list.
        /// </value>
        List<Dictionary<string, string>> TvChannelList { get; set; }


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
    }
}