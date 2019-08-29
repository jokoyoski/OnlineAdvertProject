using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Interfaces
{
    public interface IFulfilmentFactory
    {

        /// <summary>
        /// Creates the fulfilment service summary.
        /// </summary>
        /// <param name="fulfilmentSummary">The fulfilment summary.</param>
        /// <returns></returns>
        IFulfilmentServiceSummaryView CreateFulfilmentServiceSummary(
            IList<IFulfilmentServiceSummaryModel> fulfilmentSummary);
        /// <summary>
        /// Gets the fufillment print transaction.
        /// </summary>
        /// <param name="printTransaction">The print transaction.</param>
        /// <param name="printTransactionAirings">The print transaction airings.</param>
        /// <param name="orderFulfilmentStatuses">The order fulfilment statuses.</param>
        /// <param name="CurrentStatusCode">The current status code.</param>
        /// <param name="OrderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns></returns>
        IPrintMediaModelView GetFufillmentPrintTransaction(IPrintTransaction printTransaction,
            IList<IPrintTransactionAiring> printTransactionAirings,
            IList<IOrderFulfilmentStatus> orderFulfilmentStatuses, string CurrentStatusCode,string CurrentStatusDescription ,int OrderFulfilmentId);

        /// <summary>
        /// Gets the fulfiment transaction.
        /// </summary>
        /// <param name="tvOrder">The tv order.</param>
        /// <param name="tvTransactionAirings">The tv transaction airings.</param>
        /// <param name="materialTypes">The material types.</param>
        /// <param name="orderFulfilmentStatuses">The order fulfilment statuses.</param>
        /// <param name="CurrentStatusCode">The current status code.</param>
        /// <param name="OrderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns></returns>
        ITvView GetFulfimentTransaction(ITvOrder tvOrder, IList<ITvTransactionAiring> tvTransactionAirings,
            IList<IMaterialType> materialTypes, IList<IOrderFulfilmentStatus> orderFulfilmentStatuses,
            string CurrentStatusCode,string currentStatusDescription ,int OrderFulfilmentId);

        /// <summary>
        /// Gets the fulfilment branding transaction.
        /// </summary>
        /// <param name="brandingTransaction">The branding transaction.</param>
        /// <param name="brandingTransactionColors">The branding transaction colors.</param>
        /// <param name="brandingTransactionAttachment">The branding transaction attachment.</param>
        /// <param name="brandingTransactionDesignElement">The branding transaction design element.</param>
        /// <param name="brandingTransactionMaterial">The branding transaction material.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="orderFulfilmentStatuses">The order fulfilment statuses.</param>
        /// <param name="CurrentStatusCode">The current status code.</param>
        /// <param name="OrderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns></returns>
        IBrandingView GetFulfilmentBrandingTransaction(IBrandingTransaction brandingTransaction,
            IList<IBrandingTransactionColor> brandingTransactionColors,
            IBrandingTransactionAttachment brandingTransactionAttachment,
            IBrandingTransactionDesignElement brandingTransactionDesignElement,
            IBrandingTransactionMaterial brandingTransactionMaterial, IDigitalFile digitalFile,
            IList<IOrderFulfilmentStatus> orderFulfilmentStatuses, string CurrentStatusCode,string CurrentStatusDescription, int OrderFulfilmentId);

        /// <summary>
        /// Gets the fulfilment online transaction.
        /// </summary>
        /// <param name="onlineTransaction">The online transaction.</param>
        /// <param name="onlineTransactionAiring">The online transaction airing.</param>
        /// <param name="onlineTransactionExtraService">The online transaction extra service.</param>
        /// <param name="orderFulfilmentStatuses">The order fulfilment statuses.</param>
        /// <param name="CurrentStatusCode">The current status code.</param>
        /// <param name="OrderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns></returns>
        IOnlineView GetFulfilmentOnlineTransaction(IOnlineTransaction onlineTransaction,
            IList<IOnlineTransactionAiringUI> onlineTransactionAiring,
            IOnlineTransactionExtraService onlineTransactionExtraService,
            IList<IOrderFulfilmentStatus> orderFulfilmentStatuses, string CurrentStatusCode,string CurrentStatusDescription ,int OrderFulfilmentId);

        /// <summary>
        /// Gets the order fufilments.
        /// </summary>
        /// <param name="orderFufilments">The order fufilments.</param>
        /// <returns></returns>
        IOrderFulfilmentListView GetOrderFufilments(IList<IOrderFulfilment> orderFufilments);

        /// <param name="radioOrder"></param>
        /// <param name="radioAiringTransactionModels"></param>
        /// <param name="materialTypes"></param>
        /// <param name="messages"></param>
        /// <param name="replies"></param>
        /// <returns></returns>
        IRadioMainView GetFulfilmentTransaction(IRadioOrder radioOrder,
            IList<IMaterialType> activeMaterialTypeCollection,
            IList<IRadioTransactionAiring> radioAiringTransactionModels,
            IList<IOrderFulfilmentStatus> orderFulfilmentStatuses, string CurrentStatusCode,string currentStatusDescription ,int OrderFulfilmentId,
            string processingMessage);

        /// <summary>
        /// Creates the fulfilment summary.
        /// </summary>
        /// <param name="fulfilmentSummary">The fulfilment summary.</param>
        /// <returns></returns>
        IFulfilmentStatusSummaryViewModel CreateFulfilmentSummary(
            IList<IFulfilmentStatusSummaryModel> fulfilmentSummary);
    }
}