using ADit.Interfaces;
using System;

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IMaterialTypeTimingModel" />
    public class MaterialTypeTimingModel : IMaterialTypeTimingModel
    {

        /// <summary>
        /// Gets or sets the material type timing identifier.
        /// </summary>
        /// <value>
        /// The material type timing identifier.
        /// </value>
        public int MaterialTypeTimingId { get; set; }

        /// <summary>
        /// Gets or sets the service type code.
        /// </summary>
        /// <value>
        /// The service type code.
        /// </value>
        public string ServiceTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public int MaterialTypeId { get; set; }

        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
        public int TimingId { get; set; }

        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public string MaterialType { get; set; }

        /// <summary>
        /// Gets or sets the timing.
        /// </summary>
        /// <value>
        /// The timing.
        /// </value>
        public string Timing { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
        
    }
}
