using ADit.Interfaces;

namespace ADit.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Domain.Models.OnlineView" />
    /// <seealso cref="ADit.Interfaces.IOnlineOrderModel" />
    public class OnlineOrderModel : OnlineView, IOnlineOrderModel
    {

        /// <summary>
        /// Gets or sets the artwork digital file.
        /// </summary>
        /// <value>
        /// The artwork digital file.
        /// </value>
        public byte[] ArtworkDigitalFile { get; set; }
        /// <summary>
        /// Gets or sets the name of the artwork digital file.
        /// </summary>
        /// <value>
        /// The name of the artwork digital file.
        /// </value>
        public string ArtworkDigitalFileName { get; set; }
        /// <summary>
        /// Gets or sets the type of the artwork digital file.
        /// </summary>
        /// <value>
        /// The type of the artwork digital file.
        /// </value>
        public string ArtworkDigitalFileType { get; set; }
        /// <summary>
        /// Gets or sets the artwork digital file extension.
        /// </summary>
        /// <value>
        /// The artwork digital file extension.
        /// </value>
        public string ArtworkDigitalFileExtension { get; set; }
        /// <summary>
        /// Gets or sets the art work price identifier.
        /// </summary>
        /// <value>
        /// The art work price identifier.
        /// </value>
        public int ArtWorkPriceId { get; set; }
       

    }
}
