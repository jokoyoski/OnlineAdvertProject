using AA.Infrastructure.Extensions;
using ADit.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
  public   class TvTransactionUIView : ITVTransactionUIView
    {
        public TvTransactionUIView()
        {
            this.ProcessingMessage = string.Empty;
            this.ApconApprovalType = new List<SelectListItem>();
            this.ScriptQuestion = new List<SelectListItem>();
            this.ActiveMaterialType = new List<SelectListItem>();
            this.TimingType = new List<SelectListItem>();
            this.TimeBeltList = new List<SelectListItem>();
            this.TvStationList = new List<ITvStation>();
            this.AiringDetailsList = new List<ITvTransactionAiringUI>();
            this.SelectedTvStationIds = new List<int>();
        }
       public  string ScriptingMaterialCode { get; set; }
        /// <summary>
        /// Gets or sets the material file description.
        /// </summary>
        /// <value>
        /// The material file description.
        /// </value>
        public string MaterialFileDescription { get; set; }
        /// <summary>
        /// Gets or sets the script file description.
        /// </summary>
        /// <value>
        /// The script file description.
        /// </value>
        public string ScriptFileDescription { get; set; }


        /// <summary>
        /// Gets or sets the selected radio station ids.
        /// </summary>
        /// <value>
        /// The selected radio station ids.
        /// </value>
        public List<int> SelectedTvStationIds { get; set; }

        /// <summary>
        /// Gets or sets the script question.
        /// </summary>
        /// <value>
        /// The script question.
        /// </value>
        public IList<SelectListItem> ScriptQuestion { get; set; }
        /// <summary>
        /// Gets or sets the type of the apcon approval.
        /// </summary>
        /// <value>
        /// The type of the apcon approval.
        /// </value>
        public IList<SelectListItem> ApconApprovalType { get; set; }
        /// <summary>
        /// Gets or sets the type of the active material.
        /// </summary>
        /// <value>
        /// The type of the active material.
        /// </value>
        public IList<SelectListItem> ActiveMaterialType { get; set; }
        /// <summary>
        /// Gets or sets the type of the timing.
        /// </summary>
        /// <value>
        /// The type of the timing.
        /// </value>
        public IList<SelectListItem> TimingType { get; set; }
        /// <summary>
        /// Gets or sets the time belt list.
        /// </summary>
        /// <value>
        /// The time belt list.
        /// </value>
        public IList<SelectListItem> TimeBeltList { get; set; }
        /// <summary>
        /// Gets or sets the radio station list.
        /// </summary>
        /// <value>
        /// The radio station list.
        /// </value>
        public IList<ITvStation> TvStationList { get; set; }

       
        /// <summary>
        /// Gets or sets the airing details list.
        /// </summary>
        /// <value>
        /// The airing details list.
        /// </value>
        public IList<ITvTransactionAiringUI> AiringDetailsList { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the tv transaction identifier.
        /// </summary>
        /// <value>
        /// The tv transaction identifier.
        /// </value>
        public int TvTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        public bool IsHaveMaterial { get; set; }
        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        public int MaterialDigitalFileId { get; set; }
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
        /// <c>true</c> if this instance is have apcon approval; otherwise, <c>false</c>.
        /// </value>
        public bool IsHaveApconApproval { get; set; }

        /// <summary>
        /// Gets or sets the material question identifier.
        /// </summary>
        /// <value>The material question identifier.</value>
        public int MaterialQuestionId { get; set; }

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
        public int ApconApprovalTypePriceId { get; set; }
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
        public string AiringInstruction { get; set; }
        /// <summary>
        /// Gets or sets the transaction status code.
        /// </summary>
        /// <value>
        /// The transaction status code.
        /// </value>
        public string TransactionStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the script digital file identifier.
        /// </summary>
        /// <value>
        /// The script digital file identifier.
        /// </value>
        public int ScriptDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        public string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public int MaterialTypeId { get; set; }
        /// <summary>
        /// Gets or sets the material production price identifier.
        /// </summary>
        /// <value>
        /// The material production price identifier.
        /// </value>
        public int MaterialProductionPriceId { get; set; }
        /// <summary>
        /// Gets or sets the production amount.
        /// </summary>
        /// <value>
        /// The production amount.
        /// </value>
        public decimal ProductionAmount { get; set; }
        /// <summary>
        /// Gets or sets the material scripting price identifier.
        /// </summary>
        /// <value>
        /// The material scripting price identifier.
        /// </value>
        public int MaterialScriptingPriceId { get; set; }
        /// <summary>
        /// Gets or sets the scripting amount.
        /// </summary>
        /// <value>
        /// The scripting amount.
        /// </value>
        public decimal ScriptingAmount { get; set; }
        /// <summary>
        /// Gets or sets the script material question code.
        /// </summary>
        /// <value>
        /// The script material question code.
        /// </value>
        public string ScriptMaterialQuestionCode { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        int ITvTransactionUI.ApconApprovalTypeId { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


        /// <summary>
        /// Gets the radio station description.
        /// </summary>
        /// <param name="radioStationId">The radio station identifier.</param>
        /// <returns>System.String.</returns>
        public string GetTvStationDescription(int TvStationId)
        {
            if (!this.TvStationList.Any())
            {
                return string.Empty;
            }

            if (TvStationId < 1)
            {
                return string.Empty;
            }

            var description = this.TvStationList.Where(y => y.TVStationId.Equals(TvStationId)).Select(x => x.Description).FirstOrDefault();

            return description;

        }

        /// <summary>
        /// Gets the timing DDL.
        /// </summary>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns>IList&lt;SelectListItem&gt;.</returns>
        public IList<SelectListItem> GetTimingDDL(int timingId)
        {
            this.TimingType.Each(x => x.Selected = false);
            this.TimingType.Where(x => x.Value == "-1").Each(y => y.Selected = true);

            var result = new List<SelectListItem>();

            if (timingId < 1)
            {
                return this.TimingType;
            }

            this.TimingType.Each(x => x.Selected = false);
            this.TimingType.Where(x => x.Value == timingId.ToString()).Each(y => y.Selected = true);

            return this.TimingType;
        }

        /// <summary>
        /// Gets the timing belt DDL.
        /// </summary>
        /// <param name="timingBeltId">The timing belt identifier.</param>
        /// <returns>IList&lt;SelectListItem&gt;.</returns>
        public IList<SelectListItem> GetTimingBeltDDL(int timingBeltId)
        {
            this.TimeBeltList.Each(x => x.Selected = false);
            this.TimeBeltList.Where(x => x.Value == "-1").Each(y => y.Selected = true);

            var result = new List<SelectListItem>();

            if (timingBeltId < 1)
            {
                return this.TimeBeltList;
            }

            this.TimeBeltList.Each(x => x.Selected = false);
            this.TimeBeltList.Where(x => x.Value == timingBeltId.ToString()).Each(y => y.Selected = true);

            return this.TimeBeltList;
        }
    }
}
