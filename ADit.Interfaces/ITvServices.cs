using System.Collections.Generic;
using System.Web;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvServices
    {

        /// <summary>
        /// <summary>
        /// Deletes the tv order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string DeleteTvOrder(int transactionId);
      
        /// <summary>
        /// Gets the tv user transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        ITvView GetTvUserTransaction(int transactionId, int userId);


        /// <summary>
        /// Checks the tv service.
        /// </summary>
        /// <param name="tVServicePricesList">The t v service prices list.</param>
        /// <returns></returns>

        bool CheckTvService(ITVServicePricesListView tVServicePricesList);

        /// <summary>
        /// Gets the delete service price ListView.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ITVServicePricesListView GetDeleteServicePriceListView(int id);
        /// <summary>
        /// Gets the tvview.
        /// </summary>
        /// <returns></returns>
        ITVTransactionUIView GetTvview();


        /// <summary>
        /// Processviews the specified tv view.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedTvStationIds">The selected tv station ids.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        string processTVMainInfo(ITvTransactionUI radioMainTransaction, IEnumerable<ITvTransactionAiringUI> transactionAiring, List<int> selectedTvStationIds,
            HttpPostedFileBase scriptingMaterial, HttpPostedFileBase productionMaterial, out int orderId);

        /// <summary>
        /// Creates the tv transaction updated view.
        /// </summary>
        /// <param name="tvMainTransaction">The tv main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedTvStationIds">The selected tv station ids.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITVTransactionUIView CreateTvTransactionUpdatedView(ITvTransactionUI tvMainTransaction, IEnumerable<ITvTransactionAiringUI> transactionAiring,
            List<int> selectedTvStationIds, string processingMessage);
        /// <summary>
        /// Gets the tv station view model.
        /// </summary>
        /// <param name="selectedTvStationId">The selected tv station identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITvStationListView GetTvStationViewModel(int selectedTvStationId, string selectedDescription, string message);


        /// <summary>
        /// Processes the tv station information.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        string ProcessTvStationInfo(ITvStationView tvStationView);


        /// <summary>
        /// Gets the tv station view.
        /// </summary>
        /// <returns></returns>
        ITvStationView GetTvStationView();


        /// <summary>
        /// Gets the tv station view.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITvStationView GetTvStationView(ITvStationView tvStationView, string message);



        /// <summary>
        /// Gets the selected tv station information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ITvStationView GetSelectedTvStationInfo(int id);


        /// <summary>
        /// Updates the tv station information.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        string UpdateTvStationInfo(ITvStationView tvStationView);

        /// <summary>
        /// Gets the tv scripting price view.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ITvView GetTvScriptingPriceView(int id);


        /// <summary>
        /// Gets the tv production price view.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ITvView GetTvProductionPriceView(int id);

        /// <summary>
        /// Processes the delete tv station information.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <returns></returns>

        string ProcessDeleteTvStationInfo(int tvStationId);


        //  ITvView EditTvOrder(int orderIndex);

        /// <summary>
        /// Gets the edit tv cart view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITVTransactionUIView GetEditTvCartView(int transactionId);

        /// <summary>
        /// Gets the tv airing view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITVTransactionAiringView GetTvAiringView(int transactionId, string processingMessage);

        /// <summary>
        /// Processes the add tv airing.
        /// </summary>
        /// <param name="tvAiringInfo">The tv airing information.</param>
        /// <returns></returns>
        string ProcessAddTVAiring(ITVTransactionAiringView tvAiringInfo);

        /// <summary>
        /// Updates the tv transaction.
        /// </summary>
        /// <param name="tvInfo">The tv information.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns></returns>
        string UpdateTvTransaction(ITvTransactionUI tvMainTransaction,
            IEnumerable<ITvTransactionAiringUI> transactionAiring, List<int> selectedTvStationIds,
            HttpPostedFileBase scriptingMaterial, HttpPostedFileBase productionMaterial, out int orderId);

        /// <summary>
        /// Gets the itv service prices list.
        /// </summary>
        /// <param name="selectedTvServicesPriceId">The selected tv services price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITVServicePricesListMainView GetITVServicePricesList(int selectedTvServicesPriceId, string selectedDescription, string processingMessage);
        /// <summary>
        /// Updates the tv service price list.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <returns></returns>
        string UpdateTvServicePriceList(ITVServicePricesListView tVServicePricesListView);
        /// <summary>
        /// Saves the tv service price list.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <returns></returns>
        string saveTvServicePriceList(ITVServicePricesListView tVServicePricesListView);
        /// <summary>
        /// Getedits the tv service price ListView.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ITVServicePricesListView GeteditTvServicePriceListView(int id);
        /// <summary>
        /// Deletes the service price ListView.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        string deleteServicePriceListView(int id);
        // ITVServicePricesListView GeteditTvServicePriceListView(int Id, string message);




        /// <summary>
        /// Gets the add tv services ListView.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITVServicePricesListView GetAddTvServicesListView(ITVServicePricesListView tVServicePricesListView,
          string processingMessage);




        /// <summary>
        /// Gets the tv service prices ListView.
        /// </summary>
        /// <returns></returns>
        ITVServicePricesListView GetTVServicePricesListView();
        /// <summary>
        /// Gets the updated tv services ListView.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>

        ITVServicePricesListView GetUpdatedTvServicesListView(ITVServicePricesListView tVServicePricesListView, string processingMessage);
        //ITVServicePricesListView GetUpdatedTvServicesListView(ITVServicePricesListView tVServicePricesListView,string processingMessage);

        /// <summary>
        /// Gets the tv station effective price.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        decimal GetTvStationEffectivePrice(int tvStationId, int timingId, int timeBeltId,int materialTypeId);


        IDigitalFile GetScriptFileForDownload(int Id);
    }
}
