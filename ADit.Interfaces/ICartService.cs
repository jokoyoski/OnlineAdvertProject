namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Saves to cart.
        /// </summary>
        /// <param name="printInfo">The print information.</param>
        /// <returns></returns>
        ICart saveToCart(IPrintView printInfo);
    }
}
