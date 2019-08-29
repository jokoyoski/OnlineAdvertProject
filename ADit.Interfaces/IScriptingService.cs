using System.Web;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScriptingService
    {
        /// <summary>
        /// Gets the script radio order view.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>IRadioMainView.</returns>
        IRadioMainView GetScriptRadioOrderView(int orderFulfilmentId, string message);

    }
}
