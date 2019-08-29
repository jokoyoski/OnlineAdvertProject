using System.Collections.Generic;
using ADit.Interfaces;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineDurationList" />
    public class OnlineDurationList : IOnlineDurationList
    {
        /// <summary>
        /// Gets or sets the duration of the online.
        /// </summary>
        /// <value>
        /// The duration of the online.
        /// </value>
        public IEnumerable<IOnlineDuration> OnlineDuration { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the select description.
        /// </summary>
        /// <value>
        /// The select description.
        /// </value>
        public string SelectDescription { get; set; }
    }
}
