using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioOrderModel
    {
        /// <summary>
        /// Gets or sets the script description.
        /// </summary>
        /// <value>
        /// The script description.
        /// </value>
        string ScriptDescription { get; set; }
        /// <summary>
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        decimal FinalAmount { get; set; }
        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }
        /// <summary>
        /// Gets or sets the material sripting price identifier.
        /// </summary>
        /// <value>
        /// The material sripting price identifier.
        /// </value>
        int MaterialSriptingPriceId { get; set; }
        /// <summary>
        /// Gets or sets the material production price identifier.
        /// </summary>
        /// <value>
        /// The material production price identifier.
        /// </value>
        int MaterialProductionPriceId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveMaterial { get; set; }

        /// <summary>
        /// Gets or sets the approval type price identifier.
        /// </summary>
        /// <value>
        /// The approval type price identifier.
        /// </value>
        int ApprovalTypePriceId { get; set; }

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
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        int MaterialTypeId { get; set; }

        /// <summary>
        /// Gets or sets the scripting price.
        /// </summary>
        /// <value>
        /// The scripting price.
        /// </value>
        decimal ScriptingPrice { get; set; }
        /// <summary>
        /// Gets or sets the production price.
        /// </summary>
        /// <value>
        /// The production price.
        /// </value>
        decimal ProductionPrice { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval type price.
        /// </summary>
        /// <value>
        /// The apcon approval type price.
        /// </value>
        decimal ApconApprovalTypePrice { get; set; }


        /// <summary>
        /// Gets or sets the airing instruction.
        /// </summary>
        /// <value>
        /// The airing instruction.
        /// </value>
        string AiringInstruction { get; set; }


        /// <summary>
        /// Gets or sets the production digital file.
        /// </summary>
        /// <value>
        /// The production digital file.
        /// </value>
        byte[] ProductionDigitalFile { get; set; }
        /// <summary>
        /// Gets or sets the name of the production digital file.
        /// </summary>
        /// <value>
        /// The name of the production digital file.
        /// </value>
        string ProductionDigitalFileName { get; set; }
        /// <summary>
        /// Gets or sets the type of the production digital file.
        /// </summary>
        /// <value>
        /// The type of the production digital file.
        /// </value>
        string ProductionDigitalFileType { get; set; }
        /// <summary>
        /// Gets or sets the production digital file extention.
        /// </summary>
        /// <value>
        /// The production digital file extention.
        /// </value>
        string ProductionDigitalFileExtention { get; set; }
        /// <summary>
        /// Gets or sets the scripting file identifier.
        /// </summary>
        /// <value>
        /// The scripting file identifier.
        /// </value>
        int ScriptingFileId { get; set; }
        /// <summary>
        /// Gets or sets the production file identifier.
        /// </summary>
        /// <value>
        /// The production file identifier.
        /// </value>
        int ProductionFileId { get; set; }
        /// <summary>
        /// Gets or sets the scripting digital file.
        /// </summary>
        /// <value>
        /// The scripting digital file.
        /// </value>
        byte[] ScriptingDigitalFile { get; set; }
        /// <summary>
        /// Gets or sets the name of the scripting digital file.
        /// </summary>
        /// <value>
        /// The name of the scripting digital file.
        /// </value>
        string ScriptingDigitalFileName { get; set; }
        /// <summary>
        /// Gets or sets the type of the scripting digital file.
        /// </summary>
        /// <value>
        /// The type of the scripting digital file.
        /// </value>
        string ScriptingDigitalFileType { get; set; }
        /// <summary>
        /// Gets or sets the scripting digital file extention.
        /// </summary>
        /// <value>
        /// The scripting digital file extention.
        /// </value>
        string ScriptingDigitalFileExtention { get; set; }
        /// <summary>
        /// Gets or sets the apcon approval identifier.
        /// </summary>
        /// <value>
        /// The apcon approval identifier.
        /// </value>
        int ApconApprovalId { get; set; }
        /// <summary>
        /// Gets or sets the duation type code.
        /// </summary>
        /// <value>
        /// The duation type code.
        /// </value>
        string DuationTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the radio station list.
        /// </summary>
        /// <value>
        /// The radio station list.
        /// </value>
        List<Dictionary<string, string>> RadioStationList { get; set; }
    }
}
