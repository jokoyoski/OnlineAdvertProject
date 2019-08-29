using ADit.Interfaces;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IColorView" />
    public class ColorView: IColorView
    {
        /// <summary>
        /// </summary>
        public int ColorId { get; set; }
        /// <summary>
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}

