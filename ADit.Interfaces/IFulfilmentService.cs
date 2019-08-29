using System.Collections.Generic;
using PayStackDotNetSDK.Models;
using System.Threading.Tasks;
using System.Web;

namespace ADit.Interfaces
{
    public interface IFulfilmentService
    {

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="orderFulfilmentId"></param>
        ///// <param name="userId"></param>

        //void ChangeOrderStatus(int orderFulfilmentId, int userId);

        /// <summary>
        /// Gets the fulfilment service summary.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        IFulfilmentServiceSummaryView GetFulfilmentServiceSummary(string statusCode);

        /// <summary>
        /// Updates the fulfilment production.
        /// </summary>
        /// <param name="orderPaymentId">The order payment identifier.</param>
        /// <param name="refrenceCode">The refrence code.</param>
        /// <returns></returns>
        string UpdateFulfilmentProduction(int orderPaymentId, string refrenceCode);

        /// <summary>
        /// Updates the fulfilment scripting.
        /// </summary>
        /// <param name="orderPaymentId">The order payment identifier.</param>
        /// <param name="refrenceCode">The refrence code.</param>
        /// <returns></returns>
        string UpdateFulfilmentScripting(int orderPaymentId, string refrenceCode);
        /// <summary>
        /// Sends the new fulfilmnet email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="totalAmount">The total amount.</param>
        /// <param name="paymentPurpose">The payment purpose.</param>
        void SendNewFulfilmnetEmail(string email, int totalAmount, string paymentPurpose);

        /// <summary>
        /// Initializes the transaction.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount,
               int orderId, string paymentPurpose);
        /// </summary>
        /// <param name="fulfilmentPayment"></param>
        /// <returns></returns>
        string SaveProductionFulfilmentPayment(IFulfilmentPaymentView fulfilmentPayment);


        /// <summary>
        /// Saves the scripting fulfilment payment.
        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <returns></returns>
        string SaveScriptingFulfilmentPayment(IFulfilmentPaymentView fulfilmentPayment);

        /// <summary>
        /// Gets the fulfilment transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        ITvView GetFulfilmentTvTransaction(int orderFulfilmentId, string processingMessage);
        /// <summary>
        /// Saves the order fulfilment.
        /// </summary>
        /// <param name="orderFulfilmentActivity">The order fulfilment activity.</param>
        /// <param name="fileBase">The file base.</param>
        /// <returns></returns>
        string SaveOrderFulfilment(IOrderFulfilmentActivityView orderFulfilmentActivity,
            HttpPostedFileBase fileBase);


        ///// <summary>
        ///// Gets the radio fulfilment transaction.
        ///// </summary>
        ///// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        ///// <param name="processingMessage">The processing message.</param>
        ///// <returns></returns>
        //IRadioMainView GetRadioFulfilmentTransaction(int orderFulfilmentId, string processingMessage);


        /// <summary>
        /// Gets the fulfilment orders.
        /// </summary>
        /// <param name="fulfilmentCode">The fulfilment code.</param>
        /// <returns>IOrderFulfilmentListView.</returns>
        IOrderFulfilmentListView GetFulfilmentOrders(string fulfilmentCode);
        
        /// <summary>
        /// Gets the fulfilment orders.
        /// </summary>
        /// <param name="scriptingStatusList">The scripting status list.</param>
        /// <returns>IOrderFulfilmentListView.</returns>
        IOrderFulfilmentListView GetFulfilmentOrders(IList<string> scriptingStatusList);

        /// <summary>
        /// Gets the fulfilment online transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        IOnlineView GetFulfilmentOnlineTransaction(int orderFulfilmentId, string processingMessage);
        /// <summary>
        /// Gets the fulfilment branding view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        IBrandingView GetFulfilmentBrandingView(int orderFulfilmentId, string processingMessage);

        /// <summary>
        /// Gets the fufillment print transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        IPrintMediaModelView GetFufillmentPrintTransaction(int orderFulfilmentId, string processingMessage);


        /// <summary>
        /// Gets the fulfilment summary.
        /// </summary>
        /// <returns></returns>
        IFulfilmentStatusSummaryViewModel GetFulfilmentSummary();

        /// <summary>
        /// Gets the fulfilment order by fulfilment identifier.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns>IOrderFulfilment.</returns>
        IOrderFulfilment GetFulfilmentOrderByFulfilmentId(int orderFulfilmentId);

        /// <summary>
        /// Picks the order.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="isSendMail">if set to <c>true</c> [is send mail].</param>
        /// <param name="createdByUserId">The created by user identifier.</param>
        /// <returns>System.String.</returns>
        string PickOrder(int orderFulfilmentId, bool isSendMail, int createdByUserId);

    }
}
