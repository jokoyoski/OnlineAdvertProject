using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITvView" />
    public class TvView : ITvView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TvView"/> class.
        /// </summary>
        public TvView()

        {
            APCONTypeList = new List<SelectListItem>();
            MaterialList = new List<SelectListItem>();
            AdvertDurationList = new List<SelectListItem>();
            NumberOfAringList = new List<SelectListItem>();
            TimingList = new List<SelectListItem>();
            MaterialQuestion = new List<SelectListItem>();
            TimeBeltList = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the order fulfilment identifier.
        /// </summary>
        /// <value>
        /// The order fulfilment identifier.
        /// </value>
        public int OrderFulfilmentId { get; set; }
        /// <summary>
        /// Gets or sets the current status code.
        /// </summary>
        /// <value>
        /// The current status code.
        /// </value>
        public string CurrentStatusCode { get; set; }


        /// <summary>
        /// Gets or sets the current status description.
        /// </summary>
        /// <value>
        /// The current status description.
        /// </value>
        public string CurrentStatusDescription { get; set; }
        /// <summary>
        /// Gets or sets the status code list.
        /// </summary>
        /// <value>
        /// The status code list.
        /// </value>
        public IList<SelectListItem> StatusCodeList { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the messages lists.
        /// </summary>
        /// <value>
        /// The messages lists.
        /// </value>
        public IList<IMessage> messagesLists { get; set; }

        /// <summary>
        /// Gets or sets the replies lists.
        /// </summary>
        /// <value>
        /// The replies lists.
        /// </value>
        public IList<IReplies> repliesLists { get; set; }
        /// <summary>
        /// Gets if material is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactonId">The transacton identifier.</param>
        /// <returns></returns>

        /// <summary>
        /// Gets if script is approved.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool getIfScriptIsApproved(int SentToId, int transactionId, string MaterialType)
        {
            //checks the messags if it was approved 
            var Approval = messagesLists.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId && x.MaterialType == MaterialType && x.ServiceCode == "Television");

            if (Approval == null)
            {
                return false;
            }


            if (Approval.IsApproved == true)
            {
                return true;
            }
            else  //if it hasnr been approved the message table , we then proceed to chceck from the reply table to see if it was approved 
            {
                var RepliesApproval = repliesLists.Where(x => x.MessageId == Approval.Id).ToList();
                if (RepliesApproval == null)
                {
                    return false;
                }
                foreach (var j in RepliesApproval)
                {
                    if (j.IsApproved == true)
                    {
                        return true;
                    }
                    //if it was approved in the reply table, return true

                }
            }


            return false; //return false if it dosent



        }
        /// <summary>
        /// Gets the inital message.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="ServiceType"></param>
        /// <returns></returns>
        public bool getInitalMessage(int SentToId, int transactionId, string MaterialType)
        {
            var initMessage = messagesLists.FirstOrDefault(x => x.SentToId == SentToId && x.TransactionId == transactionId && x.MaterialType == MaterialType && x.ServiceCode == "Television");

            if (initMessage == null)
            {
                return false;
            }
            if (initMessage.Message != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string email { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the tv transaction identifier.
        /// </summary>
        /// <value>
        /// The tv transaction identifier.
        /// </value>
        public int TVTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>

        public string  ScriptingMaterialCode { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>

        [Required]
        public bool IsHaveMaterial { get; set; }

        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        public int ScriptingDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the production digital file identifier.
        /// </summary>
        /// <value>
        /// The production digital file identifier.
        /// </value>
        public int? ProductionDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the script description.
        /// </summary>
        /// <value>
        /// The script description.
        /// </value>
        public string ScriptDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have apcon approval.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have apcon approval; otherwise, <c>false</c>.
        /// </value>
        public bool IsHaveApconApproval { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval number.
        /// </summary>
        /// <value>
        /// The apcon approval number.
        /// </value>
        public string ApconApprovalNumber { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type identifier.
        /// </value>
        public int? ApconApprovalTypeId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type price identifier.
        /// </value>
        public int? ApconApprovalTypePriceId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval amount.
        /// </summary>
        /// <value>
        /// The apcon approval amount.
        /// </value>
        public decimal ApconApprovalAmount { get; set; }

        /// <summary>
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        public decimal FinalAmount { get; set; }

        /// <summary>
        /// Gets or sets the airing instruction.
        /// </summary>
        /// <value>
        /// The airing instruction.
        /// </value>
        [Required(ErrorMessage = "Please provided additional information for this transaction")]
        public string AiringInstruction { get; set; }

        /// <summary>
        /// Gets or sets the duration type code.
        /// </summary>
        /// <value>
        /// The duration type code.
        /// </value>
        public string DurationTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the slots.
        /// </summary>
        /// <value>
        /// The slots.
        /// </value>
        public int[] Slots { get; set; }

        /// <summary>
        /// Gets or sets the total slots.
        /// </summary>
        /// <value>
        /// The total slots.
        /// </value>
        public int[] TotalSlots { get; set; }


        /// <summary>
        /// Gets or sets the tv station price.
        /// </summary>
        /// <value>
        /// The tv station price.
        /// </value>
        public decimal[] TvStationPrice { get; set; }


        /// <summary>
        /// Gets or sets the is tv selected.
        /// </summary>
        /// <value>
        /// The is tv selected.
        /// </value>
        public bool[] IsTVSelected { get; set; }


        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        public string TransactionStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the apcon type DLL.
        /// </summary>
        /// <value>
        /// The apcon type DLL.
        /// </value>
        public IList<SelectListItem> APCONTypeList { get; set; }

        /// <summary>
        /// Gets or sets the material list.
        /// </summary>
        /// <value>
        /// The material list.
        /// </value>
        public IList<SelectListItem> MaterialList { get; set; }

        /// <summary>
        /// Gets or sets the tv station list.
        /// </summary>
        /// <value>
        /// The tv station list.
        /// </value>
        public IList<ITvStation> TvStationList { get; set; }

        /// <summary>
        /// Gets or sets the advert duration list.
        /// </summary>
        /// <value>
        /// The advert duration list.
        /// </value>
        public IList<SelectListItem> AdvertDurationList { get; set; }

        /// <summary>
        /// Gets or sets the number of aring list.
        /// </summary>
        /// <value>
        /// The number of aring list.
        /// </value>
        public IList<SelectListItem> NumberOfAringList { get; set; }

        /// <summary>
        /// Gets or sets the timing list.
        /// </summary>
        /// <value>
        /// The timing list.
        /// </value>

        public IList<SelectListItem> TimingList { get; set; }


        /// <summary>
        /// Gets or sets the time belt.
        /// </summary>
        /// <value>
        /// The time belt.
        /// </value>
        public IList<SelectListItem> TimeBeltList { get; set; }


        /// <summary>
        /// Gets or sets the timing list.
        /// </summary>
        /// <value>
        /// The timing list.
        /// </value>
        public string[] DurationType { get; set; }

        /// <summary>
        /// Gets or sets the tv station identifier.
        /// </summary>
        /// <value>
        /// The tv station identifier.
        /// </value>
        public int[] TVStationId { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// ApconApprovalTypeId
        /// The material type identifier.
        /// </value>
        public int? ProductionTypeId { get; set; }

        /// <summary>
        /// Gets or sets the scripting type identifier.
        /// </summary>
        /// <value>
        /// The scripting type identifier.
        /// </value>

        public int? ScriptingTypeId { get; set; }

        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
        public int[] TimingId { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>

        public int[] TimeBeltId { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public int MaterialTypeId { get; set; }

        /// <summary>
        /// </summary>
        public decimal SelectedApconAprovalPrice { get; set; }

        /// <summary>
        /// Gets or sets the production amount.
        /// </summary>
        /// <value>
        /// The production amount.
        /// </value>
        public decimal ProductionAmount { get; set; }

        /// <summary>
        /// Gets or sets the scripting amount.
        /// </summary>
        /// <value>
        /// The scripting amount.
        /// </value>
        public decimal ScriptingAmount { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        [Required(ErrorMessage = "Order Title is required")]
        public string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the material production type identifier.
        /// </summary>
        /// <value>
        /// The material production type identifier.
        /// </value>
        [Required(ErrorMessage = "Production Price is required")]
        public int MaterialProductionTypeId { get; set; }


        /// <summary>
        /// Gets or sets the material scripting type identifier.
        /// </summary>
        /// <value>
        /// The material scripting type identifier.
        /// </value>

        [Required(ErrorMessage = "Scipting Price is required")]
        public int MaterialScriptingTypeId { get; set; }

        /// <summary>
        /// Gets or sets the material question.
        /// </summary>
        /// <value>
        /// The material question.
        /// </value>
        public IList<SelectListItem> MaterialQuestion { get; set; }

        /// <summary>
        /// Gets or sets the material question identifier.
        /// </summary>
        /// <value>
        /// The material question identifier.
        /// </value>
        public string MaterialQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }


        /// <summary>
        /// Gets or sets the tv airing list.
        /// </summary>
        /// <value>
        /// The tv airing list.
        /// </value>
        public IList<ITvTransactionAiring> TVAiringList { get; set; }

        /// <summary>
        /// Gets or sets the tv transaction details.
        /// </summary>
        /// <value>
        /// The tv transaction details.
        /// </value>
        public ITvTransactionAiringModel TvTransactionDetails { get; set; }


        /// <summary>
        /// Gets or sets the tv channel list.
        /// </summary>
        /// <value>
        /// The tv channel list.
        /// </value>
        public List<Dictionary<string, string>> TvChannelList { get; set; }


        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime[] StartDate { get; set; }


        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime[] EndDate { get; set; }

        /// <summary>
        /// Gets or sets the tv station name list.
        /// </summary>
        /// <value>
        /// The tv station name list.
        /// </value>
        public List<string> TvStationNameList { get; set; }
        /// <summary>
        /// Gets or sets the timing name list.
        /// </summary>
        /// <value>
        /// The timing name list.
        /// </value>
        public List<string> TimingNameList { get; set; }
        /// <summary>
        /// Gets or sets the slots list.
        /// </summary>
        /// <value>
        /// The slots list.
        /// </value>
        public List<int> SlotsList { get; set; }
        /// <summary>
        /// Gets or sets the total slots list.
        /// </summary>
        /// <value>
        /// The total slots list.
        /// </value>
        public List<int> TotalSlotsList { get; set; }
        /// <summary>
        /// Gets or sets the prices list.
        /// </summary>
        /// <value>
        /// The prices list.
        /// </value>
        public List<decimal> PricesList { get; set; }
        /// <summary>
        /// Gets or sets the start date list.
        /// </summary>
        /// <value>
        /// The start date list.
        /// </value>
        public List<DateTime> StartDateList { get; set; }
        /// <summary>
        /// Gets or sets the end date list.
        /// </summary>
        /// <value>
        /// The end date list.
        /// </value>
        public List<DateTime> EndDateList { get; set; }
        /// <summary>
        /// Gets or sets the time belt names list.
        /// </summary>
        /// <value>
        /// The time belt names list.
        /// </value>
        public List<string> TimeBeltNamesList { get; set; }

        /// <summary>
        /// </summary>
        public string ApconType { get; set; }
    }
}