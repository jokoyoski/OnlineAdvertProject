using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IRadioProduction" />
    public class RadioProductionModel :IRadioProduction
    {

        /// <summary>
        /// Gets or sets the radio production identifier.
        /// </summary>
        /// <value>
        /// The radio production identifier.
        /// </value>
        public int RadioProductionId { get; set; }
        /// <summary>
        /// Gets or sets the radio transaction identifier.
        /// </summary>
        /// <value>
        /// The radio transaction identifier.
        /// </value>
        public Nullable<int> RadioTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the radio user production digital identifier.
        /// </summary>
        /// <value>
        /// The radio user production digital identifier.
        /// </value>
        public Nullable<int> RadioUserProductionDigitalId { get; set; }
        /// <summary>
        /// Gets or sets the radio manager production digital identifier.
        /// </summary>
        /// <value>
        /// The radio manager production digital identifier.
        /// </value>
        public Nullable<int> RadioManagerProductionDigitalId { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public Nullable<System.DateTime> DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the production manager note.
        /// </summary>
        /// <value>
        /// The production manager note.
        /// </value>
        public string ProductionManagerNote { get; set; }
        /// <summary>
        /// Gets or sets the user note.
        /// </summary>
        /// <value>
        /// The user note.
        /// </value>
        public string UserNote { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
        /// <summary>
        /// Gets or sets the production manager identifier.
        /// </summary>
        /// <value>
        /// The production manager identifier.
        /// </value>
        public Nullable<int> ProductionManagerId { get; set; }
    }
}

