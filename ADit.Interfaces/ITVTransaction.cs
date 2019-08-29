using System;
using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface ITvTransaction
    {

        int SentToId { get; set; }
        /// <summary>
        /// Gets or sets the tv transaction identifier.
        /// </summary>
        /// <value>
        /// The tv transaction identifier.
        /// </value>
        int TVTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        int OrderId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is have material.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is have material; otherwise, <c>false</c>.
        /// </value>
        bool IsHaveMaterial { get; set; }

        /// <summary>
        /// Gets or sets the production digital file identifier.
        /// </summary>
        /// <value>
        /// The production digital file identifier.
        /// </value>
        Nullable<int> ProductionDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the scripting digital file identifier.
        /// </summary>
        /// <value>
        /// The scripting digital file identifier.
        /// </value>
        Nullable<int> ScriptingDigitalFileId { get; set; }

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
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }

        /// <summary>
        /// Gets or sets the order title.
        /// </summary>
        /// <value>
        /// The order title.
        /// </value>
        string OrderTitle { get; set; }


        /// <summary>
        /// Gets or sets the scripting amount.
        /// </summary>
        /// <value>
        /// The scripting amount.
        /// </value>
        decimal ScriptingAmount { get; set; }

        /// <summary>
        /// Gets or sets the prouction amount.
        /// </summary>
        /// <value>
        /// The prouction amount.
        /// </value>
        decimal ProductionAmount { get; set; }


        /// <summary>
        /// Gets or sets the total tv stattion.
        /// </summary>
        /// <value>
        /// The total tv stattion.
        /// </value>


         int TotalTvStation { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
         decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }


        /// <summary>
        /// Gets or sets the tv transaction airing.
        /// </summary>
        /// <value>
        /// The tv transaction airing.
        /// </value>
        List<ITvTransactionAiring> TvTransactionAiring { get; set; }
        string UserName { get; set; }

        int MessageId { get; set; }

         int RepliesId { get; set; }

         IDigitalFile DigitalFile { get; set; }
    }
}