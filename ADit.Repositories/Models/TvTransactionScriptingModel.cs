using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TvTransactionScriptingModel
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get;set; }
        /// <summary>
        /// Gets or sets the tv transaction scripting identifier.
        /// </summary>
        /// <value>
        /// The tv transaction scripting identifier.
        /// </value>
        public int TVTransactionScriptingId { get; set; }
        /// <summary>
        /// Gets or sets the tv transaction identifier.
        /// </summary>
        /// <value>
        /// The tv transaction identifier.
        /// </value>
        public int TVTransactionId { get; set; }
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
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
    }
}


