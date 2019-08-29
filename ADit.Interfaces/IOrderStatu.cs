namespace ADit.Interfaces
{
   public interface IOrderStatu
    {
        /// <summary>
        /// Gets or sets the order status code.
        /// </summary>
        /// <value>
        /// The order status code.
        /// </value>
        string OrderStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
    }
}
