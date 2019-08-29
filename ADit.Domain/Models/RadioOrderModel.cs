using ADit.Interfaces;
using System.Collections.Generic;

namespace ADit.Domain.Models
{
    public class RadioOrderModel : IRadioOrderModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the approval type price identifier.
        /// </summary>
        /// <value>
        /// The approval type price identifier.
        /// </value>
        public int ApprovalTypePriceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        public bool IsHaveMaterial { get; set; }

        /// <summary>
        /// Gets or sets the script description.
        /// </summary>
        /// <value>
        /// The script description.
        /// </value>
        public string ScriptDescription { get; set; }

        /// <summary>
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        public decimal FinalAmount { get; set; }

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
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public int MaterialTypeId { get; set; }

        /// <summary>
        /// Gets or sets the scripting price.
        /// </summary>
        /// <value>
        /// The scripting price.
        /// </value>
        public decimal ScriptingPrice { get; set; }

        /// <summary>
        /// Gets or sets the production price.
        /// </summary>
        /// <value>
        /// The production price.
        /// </value>
        public decimal ProductionPrice { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval type price.
        /// </summary>
        /// <value>
        /// The apcon approval type price.
        /// </value>
        public decimal ApconApprovalTypePrice { get; set; }

        /// <summary>
        /// Gets or sets the airing instruction.
        /// </summary>
        /// <value>
        /// The airing instruction.
        /// </value>
        public string AiringInstruction { get; set; }

        /// <summary>
        /// Gets or sets the production digital file.
        /// </summary>
        /// <value>
        /// The production digital file.
        /// </value>
        public byte[] ProductionDigitalFile { get; set; }

        /// <summary>
        /// Gets or sets the name of the production digital file.
        /// </summary>
        /// <value>
        /// The name of the production digital file.
        /// </value>
        public string ProductionDigitalFileName { get; set; }

        /// <summary>
        /// Gets or sets the type of the production digital file.
        /// </summary>
        /// <value>
        /// The type of the production digital file.
        /// </value>
        public string ProductionDigitalFileType { get; set; }

        /// <summary>
        /// Gets or sets the production digital file extention.
        /// </summary>
        /// <value>
        /// The production digital file extention.
        /// </value>
        public string ProductionDigitalFileExtention { get; set; }

        /// <summary>
        /// Gets or sets the scripting file identifier.
        /// </summary>
        /// <value>
        /// The scripting file identifier.
        /// </value>
        public int ScriptingFileId { get; set; }

        /// <summary>
        /// Gets or sets the production file identifier.
        /// </summary>
        /// <value>
        /// The production file identifier.
        /// </value>
        public int ProductionFileId { get; set; }

        /// <summary>
        /// Gets or sets the scripting digital file.
        /// </summary>
        /// <value>
        /// The scripting digital file.
        /// </value>
        public byte[] ScriptingDigitalFile { get; set; }

        /// <summary>
        /// Gets or sets the name of the scripting digital file.
        /// </summary>
        /// <value>
        /// The name of the scripting digital file.
        /// </value>
        public string ScriptingDigitalFileName { get; set; }

        /// <summary>
        /// Gets or sets the type of the scripting digital file.
        /// </summary>
        /// <value>
        /// The type of the scripting digital file.
        /// </value>
        public string ScriptingDigitalFileType { get; set; }

        /// <summary>
        /// Gets or sets the scripting digital file extention.
        /// </summary>
        /// <value>
        /// The scripting digital file extention.
        /// </value>
        public string ScriptingDigitalFileExtention { get; set; }

        /// <summary>
        /// Gets or sets the duation type code.
        /// </summary>
        /// <value>
        /// The duation type code.
        /// </value>
        public string DuationTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval identifier.
        /// </summary>
        /// <value>
        /// The apcon approval identifier.
        /// </value>
        public int ApconApprovalId { get; set; }

        /// <summary>
        /// Gets or sets the radio station list.
        /// </summary>
        /// <value>
        /// The radio station list.
        /// </value>
        public List<Dictionary<string, string>> RadioStationList { get; set; }

        /// <summary>
        /// Gets or sets the material sripting price identifier.
        /// </summary>
        /// <value>
        /// The material sripting price identifier.
        /// </value>
        public int MaterialSriptingPriceId { get; set; }

        /// <summary>
        /// Gets or sets the material production price identifier.
        /// </summary>
        /// <value>
        /// The material production price identifier.
        /// </value>
        public int MaterialProductionPriceId { get; set; }
    }
}