using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IOnlineDurationList
    {
        /// <summary>
        /// Gets or sets the duration of the online.
        /// </summary>
        /// <value>
        /// The duration of the online.
        /// </value>
        IEnumerable<IOnlineDuration> OnlineDuration { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the select description.
        /// </summary>
        /// <value>
        /// The select description.
        /// </value>
        string SelectDescription { get; set; }
    }
}
