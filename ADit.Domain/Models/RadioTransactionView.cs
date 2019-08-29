using ADit.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    public class RadioTransactionView : IRadioTransactionView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadioTransactionView"/> class.
        /// </summary>
        public RadioTransactionView()
        {
            this.ApconApprovalTypeList = new List<SelectListItem>();
            this.DurationTypeList = new List<SelectListItem>();
            this.MaterialTypeTimeList = new List<SelectListItem>();
            this.ProductionPriceList = new List<IMaterialProductionPrice>();
            this.ScriptingPriceList = new List<IMaterialScriptingPrice>();
            this.ScriptMaterialQuestionList = new List<SelectListItem>();
            this.SelectedAiringList = new List<IRadioTransactionAiring>();
            this.StationList = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        public int RadioTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the script material question list.
        /// </summary>
        /// <value>
        /// The script material question list.
        /// </value>
        public IList<SelectListItem> ScriptMaterialQuestionList { get; set; }

        /// <summary>
        /// Gets or sets the selected script material question.
        /// </summary>
        /// <value>
        /// The selected script material question.
        /// </value>
        public string SelectedScriptMaterialQuestion { get; set; }

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
        /// Gets or sets the apcon approval type list.
        /// </summary>
        /// <value>
        /// The apcon approval type list.
        /// </value>
        public IList<SelectListItem> ApconApprovalTypeList { get; set; }

        /// <summary>
        /// Gets or sets the selected apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The selected apcon approval type price identifier.
        /// </value>
        public int SelectedApconApprovalTypePriceId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval amount.
        /// </summary>
        /// <value>
        /// The apcon approval amount.
        /// </value>
        public decimal ApconApprovalAmount { get; set; }

        /// <summary>
        /// Gets or sets the scripting price list.
        /// </summary>
        /// <value>
        /// The scripting price list.
        /// </value>
        public IList<IMaterialScriptingPrice> ScriptingPriceList { get; set; }

        /// <summary>
        /// Gets or sets the production price list.
        /// </summary>
        /// <value>
        /// The production price list.
        /// </value>
        public IList<IMaterialProductionPrice> ProductionPriceList { get; set; }

        /// <summary>
        /// Gets or sets the selected material scripting price identifier.
        /// </summary>
        /// <value>
        /// The selected material scripting price identifier.
        /// </value>
        public IList<int> SelectedMaterialScriptingPriceId { get; set; }

        /// <summary>
        /// Gets or sets the selected material production price identifier.
        /// </summary>
        /// <value>
        /// The selected material production price identifier.
        /// </value>
        public IList<int> SelectedMaterialProductionPriceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        public bool IsHaveMaterial { get; set; }

        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        public int DigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the script description.
        /// </summary>
        /// <value>
        /// The script description.
        /// </value>
        public string ScriptDescription { get; set; }

        /// <summary>
        /// Gets or sets the station list.
        /// </summary>
        /// <value>
        /// The station list.
        /// </value>
        public IList<SelectListItem> StationList { get; set; }

        /// <summary>
        /// Gets or sets the material type time list list.
        /// </summary>
        /// <value>
        /// The material type time list list.
        /// </value>
        public IList<SelectListItem> MaterialTypeTimeList { get; set; }

        /// <summary>
        /// Gets or sets the duration type list.
        /// </summary>
        /// <value>
        /// The duration type list.
        /// </value>
        public IList<SelectListItem> DurationTypeList { get; set; }

        /// <summary>
        /// Gets or sets the airing list.
        /// </summary>
        /// <value>
        /// The airing list.
        /// </value>
        public IList<IRadioTransactionAiring> SelectedAiringList { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
