using ADit.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ADit.Domain.Models
{
   public class DurationTypeView:IDurationTypeView
    {
        /// <summary>
        /// Gets or sets the duration type identifier.
        /// </summary>
        /// <value>
        /// The duration type identifier.
        /// </value>
        public int DurationTypeId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>The processing message.</value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(2)]
        public string DurationTypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
    }
}

