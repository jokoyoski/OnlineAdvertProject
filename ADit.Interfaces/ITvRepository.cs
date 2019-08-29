using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvRepository
    {
        /// <summary>
        /// Checks the tv serviceprice.
        /// </summary>
        /// <param name="tVServicePricesList">The t v service prices list.</param>
        /// <returns></returns>
        bool CheckTvServiceprice(ITVServicePricesListView tVServicePricesList);
        /// <summary>
        /// Deletes the tv order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string DeleteTvOrder(int transactionId);
        /// <summary>
        /// Deletes the tv transaction airing.
        /// </summary>
        /// <param name="tvTransactionId">The tv transaction identifier.</param>
        /// <returns></returns>
        string DeleteTvTransactionAiring(int tvTransactionId);
        
        /// <summary>
        /// Gets the tv transaction airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<ITvTransactionAiring> GetTvTransactionAiring(int transactionId);
        /// <summary>
        /// Gets the tv transaction airing list.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<ITvTransactionAiringUI> GetTvTransactionAiringList(int transactionId);
       
        
        /// <summary>
        /// Gets the tv transaction.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        ITvTransaction GetTvTransaction(int SentToId, int transactionId);
       
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
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        ITVServicePricesList GeteditTvServicePriceListView(int Id);
        /// <summary>
        /// Deletes the service price ListView.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string deleteServicePriceListView(int Id);
        /// <summary>
        /// Gets the itv service prices list.
        /// </summary>
        /// <returns></returns>
        IList<ITVServicePricesList> GetITVServicePricesList();



        /// <summary>
        /// Saves the material type timings information.
        /// </summary>
        /// <param name="tvView">The tv view.</param>
        /// <param name="MaterialTypeTiming">The material type timing.</param>
        /// <returns></returns>
        string SaveMaterialTypeTimingsInfo(ITvView tvView, out int MaterialTypeTiming);


        /// <summary>
        /// Edits the tv station.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        string EditTvStation(ITvStationView tvStationView);


        /// <summary>
        /// Deletes the tv station information.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <returns></returns>
        string DeleteTvStationInfo(int tvStationId);




        //Saving Television tro Database
        /// <summary>
        /// Saves the tv transaction information.
        /// </summary>
        /// <param name="tvOrder">The tv order.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string SaveTvTransactionInfo(ITvTransactionUI tvOrder, out int transactionId);







        /// <summary>
        /// Saves the tv station information.
        /// </summary>
        /// <param name="tvView">The tv view.</param>
        /// <returns></returns>
        string SaveTvStationInfo(ITvStationView tvView);

        /// <summary>
        /// Gets the active tv transaction.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<ITvTransaction> GetActiveTvTransaction(int userId);


        /// <summary>
        /// Gets the tv description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        ITvStation GetTvDescriptionByValue(string description);


        /// <summary>
        /// Gets the user tv order by identifier.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        ITvOrder GetUserTvOrderById(int cartId);

      
        /// <summary>
        /// Saves the tv transaction airing.
        /// </summary>
        /// <param name="transactionAiringList">The transaction airing list.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string SaveTvTransactionAiring(IList<ITvTransactionAiringUI> transactionAiringList, int transactionId);

        /// <summary>
        /// Updates the tv transaction airing.
        /// </summary>
        /// <param name="tvStationsTransactions">The tv stations transactions.</param>
        /// <returns></returns>
        string UpdateTvTransactionAiring(ITvView tvStationsTransactions);

        /// <summary>
        /// Updates the tv transaction.
        /// </summary>
        /// <param name="tvInfo">The tv information.</param>
        /// <returns></returns>
        string UpdateTvTransaction(ITvTransactionUI tvTransactionUI);

        /// <summary>
        /// Gets the tv station effective price.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        ITVServicePricesList GetTvEffectivePrice(int tvStationId, int timingId, int timeBeltId,int materialTypeId);
    }



}
