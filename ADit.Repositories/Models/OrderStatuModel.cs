using ADit.Interfaces;  

namespace ADit.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOrderStatu" />
    public class OrderStatuModel : IOrderStatu
    {
        /// <summary>
        /// Gets or sets the order status code.
        /// </summary>
        /// <value>
        /// The order status code.
        /// </value>
        public string OrderStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
