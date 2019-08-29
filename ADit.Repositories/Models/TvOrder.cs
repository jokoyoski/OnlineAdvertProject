using System;
using System.Collections.Generic;
using ADit.Interfaces;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITvOrder" />
    public class TvOrder : ITvOrder
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
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
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the scripting digital file identifier.
        /// </summary>
        /// <value>
        /// The scripting digital file identifier.
        /// </value>
        public int ScriptingDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
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
        /// Gets or sets the type of the apcon.
        /// </summary>
        /// <value>
        /// The type of the apcon.
        /// </value>
        public string ApconType { get; set; }
        /// <summary>
        /// Gets or sets the is have scripts.
        /// </summary>
        /// <value>
        /// The is have scripts.
        /// </value>
        public string IsHaveScripts { get; set; }


        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        public int TvTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the radio identifier.
        /// </summary>
        /// <value>
        /// The radio identifier.
        /// </value>
        public int TvId { get; set; }


        /// <summary>
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        public int? MaterialDigitalFileId { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [script material question code].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [script material question code]; otherwise, <c>false</c>.
        /// </value>
        public string ScriptMaterialQuestionCode { get; set; }


        /// <summary>
        /// Gets or sets the apcon approval price collection.
        /// </summary>
        /// <value>
        /// The apcon approval price collection.
        /// </value>
        public IList<IApconApprovalTypePrice> ApconApprovalPriceCollection { get; set; }


        /// <summary>
        /// Gets or sets the apcon approval type price identifier.
        /// </summary>
        /// <value>
        /// The apcon approval type price identifier.
        /// </value>
        public int? ApconApprovalTypePriceId { get; set; }


        /// <summary>
        /// Gets or sets the apcon approval identifier.
        /// </summary>
        /// <value>
        /// The apcon approval identifier.
        /// </value>
        public int? ApconApprovalId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval amount.
        /// </summary>
        /// <value>
        /// The apcon approval amount.
        /// </value>
        public decimal ApconApprovalAmount { get; set; }


        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public int MaterialTypeId { get; set; }

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
        public int[] TvStationId { get; set; }


        /// <summary>
        /// Gets or sets the radio station description.
        /// </summary>
        /// <value>
        /// The radio station description.
        /// </value>
        public string TvStationDescription { get; set; }

        /// <summary>
        /// Gets or sets the duration code.
        /// </summary>
        /// <value>
        /// The duration code.
        /// </value>
        public string[] DurationCode { get; set; }

        /// <summary>
        /// Gets or sets the radio station.
        /// </summary>
        /// <value>
        /// The radio station.
        /// </value>
        public IList<int> TvStation { get; set; }


        /// <summary>
        /// Gets or sets the apcon type price.
        /// </summary>
        /// <value>
        /// The apcon type price.
        /// </value>
        public decimal ApconTypePrice { get; set; }

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
        /// Gets or sets the final amount.
        /// </summary>
        /// <value>
        /// The final amount.
        /// </value>
        public decimal FinalAmount { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is have apcon approval.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have apcon approval; otherwise, <c>false</c>.
        /// </value>
        public bool IsHaveApconApproval { get; set; }


        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }


        /// <summary>
        /// Gets or sets the apcon approval number.
        /// </summary>
        /// <value>
        /// The apcon approval number.
        /// </value>
        public string ApconApprovalNumber { get; set; }


        /// <summary>
        /// Gets or sets the airing description.
        /// </summary>
        /// <value>
        /// The airing description.
        /// </value>
        public string AiringDescription { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        public string OrderTitle { get; set; }

        /// <summary>
        /// Gets or sets the order numer.
        /// </summary>
        /// <value>
        /// The order numer.
        /// </value>
        public int OrderNumber { get; set; }
    }
}