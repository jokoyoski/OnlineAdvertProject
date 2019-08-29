using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ADit.Interfaces;
using Compare = System.ComponentModel.DataAnnotations.CompareAttribute;
using System.Linq;

namespace ADit.Domain.Models
{
    public class RadioMainView : IRadioMainView
    {
        public RadioMainView()
        {
            this.ProcessingMessage = string.Empty;
            this.ApconApprovalType = new List<SelectListItem>();
            this.MaterialType = new List<SelectListItem>();
            this.DurationType = new List<SelectListItem>();
            this.TimingType = new List<SelectListItem>();
            this.RadioType = new List<SelectListItem>();
            this.RadioStationType = new List<SelectListItem>();
        }


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
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int userId { get; set; }

        /// <summary>
        /// Gets or sets the daterange.
        /// </summary>
        /// <value>
        /// The daterange.
        /// </value>
        public string[] daterange { get; set; }

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

        //public  int[] TimingId { get; set; }
        public int[] TimeBeltId { get; set; }

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
        public int[] totalSlots { get; set; }


        /// <summary>
        /// Gets or sets the type of the apcon.
        /// </summary>
        /// <value>
        /// The type of the apcon.
        /// </value>
        public string ApconType { get; set; }


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the is have scripts.
        /// </summary>
        /// <value>
        /// The is have scripts.
        /// </value>
        public IList<SelectListItem> IsHaveScripts { get; set; }

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
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        public int RadioTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the radio identifier.
        /// </summary>
        /// <value>
        /// The radio identifier.
        /// </value>
        public int RadioId { get; set; }


        /// <summary>
        /// Gets or sets the type of the radio.
        /// </summary>
        /// <value>
        /// The type of the radio.
        /// </value>
        public IList<SelectListItem> RadioType { get; set; }

        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        public int MaterialDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the script material question code.
        /// </summary>
        /// <value>
        /// The script material question code.
        /// </value>
        public string ScriptMaterialQuestionCode { get; set; }

        /// <summary>
        /// Gets or sets the time belt list.
        /// </summary>
        /// <value>
        /// The time belt list.
        /// </value>
        public IList<SelectListItem> TimeBeltList { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval price collection.
        /// </summary>
        /// <value>
        /// The apcon approval price collection.
        /// </value>
        public IList<IApconApprovalTypePrice> ApconApprovalPriceCollection { get; set; }

        /// <summary>
        /// Gets or sets the type of the apcon approval.
        /// </summary>
        /// <value>
        /// The type of the apcon approval.
        /// </value>
        public IList<SelectListItem> ApconApprovalType { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type price identifier.
        /// </value>
        public int ApconApprovalTypePriceId { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type identifier.
        /// </value>
        public int ApconApprovalTypeId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval amount.
        /// </summary>
        /// <value>
        /// The apcon approval amount.
        /// </value>
        public decimal ApconApprovalAmount { get; set; }

        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public IList<SelectListItem> MaterialType { get; set; }

        /// <summary>
        /// Gets or sets the type of the active material.
        /// </summary>
        /// <value>
        /// The type of the active material.
        /// </value>
        public IList<SelectListItem> ActiveMaterialType { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public int MaterialTypeId { get; set; }


        public string MaterialTypeName { get; set; }

        /// <summary>
        /// Gets or sets the material scripting price identifier.
        /// </summary>
        /// <value>
        /// The material scripting price identifier.
        /// </value>
        public int MaterialScriptingPriceId { get; set; }


        /// <summary>
        /// Gets or sets the material production price identifier.
        /// </summary>
        /// <value>
        /// The material production price identifier.
        /// </value>
        public int MaterialProductionPriceId { get; set; }

        /// <summary>
        /// Gets or sets the scripting amount.
        /// </summary>
        /// <value>
        /// The scripting amount.
        /// </value>
        public decimal ScriptingAmount { get; set; }

        /// <summary>
        /// Gets or sets the script description.
        /// </summary>
        /// <value>
        /// The script description.
        /// </value>
        public string ScriptDescription { get; set; }

        /// <summary>
        /// Gets or sets the production description.
        /// </summary>
        /// <value>
        /// The production description.
        /// </value>
        public string ProductionDescription { get; set; }

        /// <summary>
        /// Gets or sets the production amount.
        /// </summary>
        /// <value>
        /// The production amount.
        /// </value>
        public decimal ProductionAmount { get; set; }

        /// <summary>
        /// Gets or sets the radio station identifier.
        /// </summary>
        /// <value>
        /// The radio station identifier.
        /// </value>
        public int[] RadioStationId { get; set; }

        /// <summary>
        /// </summary>
        public IList<SelectListItem> RadioStationType { get; set; }

        /// <summary>
        /// Gets or sets the radio station description.
        /// </summary>
        /// <value>
        /// The radio station description.
        /// </value>
        public string RadioStationDescription { get; set; }

        /// <summary>
        /// Gets or sets the duration code.
        /// </summary>
        /// <value>
        /// The duration code.
        /// </value>
        public string[] DurationCode { get; set; }

        public IList<SelectListItem> DurationType { get; set; }
        public string MaterialQuestionId { get; set; }
        public IList<SelectListItem> ScriptQuestion { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        [Required(ErrorMessage = "Order Title is required")]
        public string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the airing description.
        /// </summary>
        /// <value>
        /// The airing description.
        /// </value>
        [Required(ErrorMessage = "Please provided additional information for this transaction")]
        public string AiringDescription { get; set; }

        /// <summary>
        /// Gets or sets the timing description.
        /// </summary>
        /// <value>
        /// The timing description.
        /// </value>
        public string TimingDescription { get; set; }

        /// <summary>
        /// Gets or sets the type of the timing.
        /// </summary>
        /// <value>
        /// The type of the timing.
        /// </value>
        public IList<SelectListItem> TimingType { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        public bool IsHaveMaterial { get; set; }

        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        public System.DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
        public int[] TimingId { get; set; }

        /// <summary>
        /// Gets or sets the date inactive.
        /// </summary>
        /// <value>
        /// The date inactive.
        /// </value>
        public Nullable<System.DateTime> DateInactive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// </summary>
        public int Airing { get; set; }

        /// <summary>
        /// </summary>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval number.
        /// </summary>
        /// <value>
        /// The apcon approval number.
        /// </value>
        public string ApconApprovalNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsHaveApconApproval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ScriptDigitalFileId { get; set; }

        /// <summary>


        public decimal FinalAmount { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// Gets or sets the radio airing list.
        /// </summary>
        /// <value>
        /// The radio airing list.
        /// </value>
        public IList<IRadioTransactionAiring> RadioAiringList { get; set; }


        public IRadioAiringTransactionModel RadioAiringListDetails { get; set; }

        public IList<IRadioStationModel> RadioStationList { get; set; }

        public int[] DurationQuantity { get; set; }

        public int[] AiringNumberPerDay { get; set; }


        public decimal[] RadioStationPrice { get; set; }

        public bool[] IsRadioSelected { get; set; }

        public List<Dictionary<string, string>> RadioChannelList { get; set; }
        // public DateTime[] StartDate { get; set; }
        // public DateTime[] EndDate { get; set; }


        public List<string> RadioStationNameList { get; set; }
        public List<string> TimingList { get; set; }
        public List<int> SlotsList { get; set; }
        public List<int> TotalSlotsList { get; set; }
        public List<decimal> PricesList { get; set; }
        public List<DateTime> StartDateList { get; set; }
        public List<DateTime> EndDateList { get; set; }
        public List<string> TimeBeltNamesList { get; set; }
    }
}