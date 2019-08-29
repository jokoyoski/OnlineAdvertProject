using System.Collections.Generic;
using System.Web;

namespace ADit.Interfaces
{
    public interface IRadioServices

    {/// <summary>
     
       
        /// Deletes the radio order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string DeleteRadioOrder(int transactionId);
        /// <summary>
     
        /// Gets the radio main view.
        /// </summary>
        /// <returns>IRadioTransactionUIView.</returns>
        IRadioTransactionUIView GetRadioMainView();

        /// <summary>
        /// Gets the radio main view.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns>IRadioTransactionUIView.</returns>
        IRadioTransactionUIView GetRadioMainView(IRadioTransactionUI radioMainTransaction, IEnumerable<IRadioTransactionAiringUI> transactionAiring,
            List<int> selectedRadioStationIds, string processingMessage);
        
        /// <summary>
        /// Gets the radio main view by transaction identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>IRadioMainView.</returns>
        IRadioTransactionUIView GetRadioMainViewByTransactionId(int transactionId);


        /// <summary>
        /// Processes the radio main information.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>System.String.</returns>
        string ProcessRadioMainInfo(IRadioTransactionUI radioMainTransaction, IEnumerable<IRadioTransactionAiringUI> transactionAiring, List<int> selectedRadioStationIds,
            HttpPostedFileBase scriptingMaterial, HttpPostedFileBase productionMaterial, out int orderId);
        
        /// <summary>
        /// Updates the radio main information.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns>System.String.</returns>
        string UpdateRadioMainInfo(IRadioTransactionUI radioMainTransaction, IEnumerable<IRadioTransactionAiringUI> transactionAiring, List<int> selectedRadioStationIds,
            HttpPostedFileBase scriptingMaterial, HttpPostedFileBase productionMaterial);








        decimal GetRadioStationEffectivePrice(int tvStationId, int timingId, int timeBeltId,int materialTypeId);
       
      
            IDigitalFile GetScriptFileForDownload(int Id);
        string getEditRadioById(IRadioMainView radioMainView);
        

        string ProcessProductionPriceInfo(IMaterialProductionPriceView productionInfo);
        IMaterialProductionPriceView GetProductionPriceView();
        IMaterialProductionPriceView GetProductionPriceView(IMaterialProductionPriceView view, string message);
        IMaterialScriptingPriceView GetScriptingPriceView();
        IMaterialScriptingPriceView GetScriptingPriceView(IMaterialScriptingPriceView view, string message);
        string ProcessScriptingPriceInfo(IMaterialScriptingPriceView scriptingInfo);

        IRadioSationListView GetRadioStationListViewModel(int selectedRadioStationId, string selectedDescription,
            string message);

        IRadioStationView GetRadioStationView();
        IRadioStationView GetRadioStationView(IRadioStationView radioView, string message);

        IScriptingPriceListView GetScriptingPriceViewModel(int selectedMaterialScriptingPriceId, string selectedDescription,
            string selectedServiceTypeCode, string message);
        IProductionPriceListView GetProductionPriceViewModel(int selectedMaterialProductionPriceId,
            string selectedDescription, string selectedServiceTypeCode, string message);

        ITiming GetMaterialTimingRegistrationView(int Id);
        string ProcessEditRadio(IRadioStationView radioview);
        string ProcessEditScriptingPrice(IMaterialScriptingPriceView scriptview);
        string ProcessEditProductionPrice(IMaterialProductionPriceView productionview);
        string DeleteRadioById(int Id);
        IRadioStationView GetRadioStationById(int Id, string message);
        IMaterialScriptingPriceView GetMaterialScriptingPriceById(int Id, string message);
        IMaterialProductionPriceView GetMaterialProductionPriceById(int Id, string message);
        string ProcessDeleteRadioStation(int radio);
        string ProcessDeleteMaterialScriptingPrice(int Id);
        string ProcessDeleteMaterialProductionPrice(int production);
        IMaterialProductionPriceView GetDeleteMaterialProductionPriceById(int Id);
        IMaterialScriptingPriceView GetDeleteMaterialScriptingPriceById(int Id);
        string ProcessRadioStation(IRadioStationView radioInfo);
       
        /// <summary>
        /// Gets the radio transaction view.
        /// </summary>
        /// <returns></returns>
        IRadioTransactionView GetRadioTransactionView();

        IRadioMainView GetScriptingPriceView(int Id);

        
      
        IRadioMainView GetProductionPriceView(int Id);
     
        IRadioMainListView GetRadioTransaction();
        IRadioProductionListView GetRadioProductionListView(int Id);
        //IRadioMainView CreateUpdatedView(IRadioMainView radioMainView, string processingMessage);
        //IRadioMainListView GetRadioTransaction();



        /// <summary>
        /// Gets the radio airing view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IRadioTransactionAiringView GetRadioAiringView(int transactionId,string processingMessage);

        /// <summary>
        /// Processes the add radio airing.
        /// </summary>
        /// <param name="radioAiringInfo">The radio airing information.</param>
        /// <returns></returns>
        string ProcessAddRadioAiring(IRadioTransactionAiringView radioAiringInfo);


        /// <summary>
        /// Updates the radio transaction.
        /// </summary>
        /// <param name="radioMainView">The radio main view.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns></returns>
        string UpdateRadioTransaction(IRadioMainView radioMainView, HttpPostedFileBase scriptingMaterial,
            HttpPostedFileBase productionMaterial);

        /// <summary>
        /// Saveradioes the production.
        /// </summary>
        /// <param name="radioProduction">The radio production.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns></returns>
        string SaveradioProduction(IRadioProductionView radioProduction, HttpPostedFileBase productionMaterial);

        /// <summary>
        /// Gets the user radio order by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IRadioMainView GetUserRadioOrderById(int transactionId, int userId,string processingMessage);

        /// <summary>
        /// Gets the radio price.
        /// </summary>
        /// <param name="radioStationId">The radio station identifier.</param>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <param name="timing">The timing.</param>
        /// <returns></returns>
        IRadioServicePriceListModel GetRadioPrice(int radioStationId,  int timing,int materialTypeId);
      
    }
}
