using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IFulfilmentRepository
    {
        /// <summary>
        /// Gets the fulfilment service summary by status code.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        IList<IFulfilmentServiceSummaryModel> GetFulfilmentServiceSummaryByStatusCode(string statusCode);
        /// <summary>
        /// Gets the fulfilment orders by code.
        /// </summary>
        /// <param name="fufilmentStage">The fufilment stage.</param>
        /// <returns></returns>
        IList<IOrderFulfilment> GetFulfilmentOrdersByCode(string fufilmentStage);
        /// <summary>
        /// Gets the fulfilment orders.
        /// </summary>
        /// <returns></returns>
        IList<IOrderFulfilment> GetFulfilmentOrders();
        
        /// <summary>
        /// Saves the order fulfilment.
        /// </summary>
        /// <param name="orderFulfilmentActivityView">The order fulfilment activity view.</param>
        /// <param name="orderFulfilmentActivityId">The order fulfilment activity identifier.</param>
        /// <returns></returns>
        string SaveOrderFulfilment(IOrderFulfilmentActivityView orderFulfilmentActivityView,
            out int orderFulfilmentActivityId);

        /// <summary>
        /// Gets the fulfilment status summary.
        /// </summary>
        /// <returns></returns>
        IList<IFulfilmentStatusSummaryModel> GetFulfilmentStatusSummary();

        /// <summary>
        /// Gets the fulfilment order by fulfilment identifier.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns>IOrderFulfilment.</returns>
        IOrderFulfilment GetFulfilmentOrderByFulfilmentId(int orderFulfilmentId);

        /// <summary>
        /// Changes the order status.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="toStatus">To status.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>System.String.</returns>
        string ChangeOrderStatus(int orderFulfilmentId, string toStatus, int userId);

        /// <summary>
        /// Gets the fulfilment orders by code.
        /// </summary>
        /// <param name="scriptingStatusList">The scripting status list.</param>
        /// <returns>IList&lt;IOrderFulfilment&gt;.</returns>
        IList<IOrderFulfilment> GetFulfilmentOrdersByCode(IList<string> scriptingStatusList);
    }
}
