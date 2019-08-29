using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioOrder
    {
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
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        string MaterialType { get; set; }

        /// <summary>
        /// Gets or sets the type of the apcon.
        /// </summary>
        /// <value>
        /// The type of the apcon.
        /// </value>
        string ApconType { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string processingMessage { get; set; }

        /// <summary>
        /// Gets or sets the is have scripts.
        /// </summary>
        /// <value>
        /// The is have scripts.
        /// </value>
        string IsHaveScripts { get; set; }

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
        /// Gets or sets the material digital file identifier.
        /// </summary>
        /// <value>
        /// The material digital file identifier.
        /// </value>
        int MaterialDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [script material question code].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [script material question code]; otherwise, <c>false</c>.
        /// </value>
        bool ScriptMaterialQuestionCode { get; set; }

        /// <summary>
        /// Gets or sets the material question identifier.
        /// </summary>
        /// <value>
        /// The material question identifier.
        /// </value>
        string MaterialQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the apcon approval price collection.
        /// </summary>
        /// <value>
        /// The apcon approval price collection.
        /// </value>
        IList<IApconApprovalTypePrice> ApconApprovalPriceCollection { get; set; }

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
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        int MaterialTypeId { get; set; }


        /// <summary>
        /// Gets or sets the name of the material type.
        /// </summary>
        /// <value>
        /// The name of the material type.
        /// </value>
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
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>


        int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }

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
        /// Gets or sets the airing description.
        /// </summary>
        /// <value>
        /// The airing description.
        /// </value>
        string AiringDescription { get; set; }

        /// <summary>
        /// Gets or sets the material type timing identifier.
        /// </summary>
        /// <value>
        /// The material type timing identifier.
        /// </value>
        int[] MaterialTypeTimingId { get; set; }

        /// <summary>
        /// Gets or sets the timing description.
        /// </summary>
        /// <value>
        /// The timing description.
        /// </value>
        string TimingDescription { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; set; }

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
        System.DateTime DateCreated { get; set; }

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
        /// Gets or sets the radio station.
        /// </summary>
        /// <value>
        /// The radio station.
        /// </value>

        IList<int> radioStation { get; set; }

        /// <summary>
        /// Gets or sets the apcon type price.
        /// </summary>
        /// <value>
        /// The apcon type price.
        /// </value>
        decimal ApconTypePrice { get; set; }

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
    }
}