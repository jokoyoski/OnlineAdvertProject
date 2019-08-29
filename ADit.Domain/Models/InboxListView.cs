using ADit.Interfaces;

namespace ADit.Domain.Models
{
    public class InboxListView : IInboxListView
    {
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string processingMessage { get; set; }
        
    }
}
