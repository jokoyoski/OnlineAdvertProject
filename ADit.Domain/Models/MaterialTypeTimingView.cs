using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Domain.Models
{
    public class MaterialTypeTimingView : IMaterialTypeTimingView
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
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        public IList<SelectListItem> ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public IList<SelectListItem> MaterialType { get; set; }
        /// <summary>
        /// Gets or sets the type of the timing.
        /// </summary>
        /// <value>
        /// The type of the timing.
        /// </value>
        public IList<SelectListItem> TimingType { get; set; }

    }
}
