using System.Threading.Tasks;
using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Models.Transactions;

namespace ADit.Interfaces
{
    public interface ITransactionService
    {
        /// <summary>
        /// Pendings the fulfilment.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        void PendingFulfilment(int userId);

        /// <summary>
        /// Updates the cart.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        void UpdateCart(int orderId);


        /// <summary>
        /// Gets the cart summary.
        /// </summary>
        /// <returns></returns>
        IOrderSummaryListView GetCartSummary(IOrder order, string message);


        /// <summary>
        /// Initializes the transaction.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount, int orderId);


        /// <summary>
        /// Verifies the transaction.
        /// </summary>
        /// <param name="referenceCode">The reference code.</param>
        /// <returns></returns>
        Task<TransactionResponseModel> VerifyTransaction(string referenceCode);


        /// <summary>
        /// Gets the order number information.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="orderNumber">The order number.</param>
        /// <returns></returns>
        IOrder GetOrderNumberInfo(int userId, int orderNumber);


        /// <summary>
        /// Gets the order by user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IOrder GetPendingOrderByUserId(int userId);


        /// <summary>
        /// Processes the payment.
        /// </summary>
        /// <param name="refereneCode">The referene code.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="response">The response.</param>
        /// <returns>System.String.</returns>
        string ProcessPayment(string refereneCode, int orderId, int userId, TransactionResponseModel response);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        string DeleteOrder(int orderId);

        /// <summary>
        /// Makes the payment call.
        /// </summary>
        /// <param name="paymentData">The payment data.</param>
        /// <returns></returns>
        Task<PaymentInitalizationResponseModel> MakePaymentCall(IPaymentCallModel paymentData);
    }
}