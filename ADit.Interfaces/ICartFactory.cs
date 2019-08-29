namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICartFactory
    {

        /// <summary>
        /// Saves to cart.
        /// </summary>
        /// <param name="printInfo">The print information.</param>
        void SaveToCart(IPrintView printInfo);
    }
}
