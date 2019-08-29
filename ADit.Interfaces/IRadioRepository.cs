using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioRepository
    {
        /// <summary>
        /// Deletes the radio order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string DeleteRadioOrder(int transactionId);
       
        /// <summary>
        /// Saves the radio transaction information.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="radioTransactionId">The radio transaction identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string SaveRadioTransactionInfo(IRadioTransactionUI radioMainTransaction, out int radioTransactionId);

        /// <summary>
        /// Saves the radio transaction airing.
        /// </summary>
        /// <param name="radioTransactionId">The radio transaction identifier.</param>
        /// <param name="transactionAiringList">The transaction airing list.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string SaveRadioTransactionAiring(int radioTransactionId, IList<IRadioTransactionAiringUI> transactionAiringList);


        /// <summary>
        /// Gets the radio main transaction by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>IRadioTransactionUI.</returns>
        IRadioTransactionUI GetRadioMainTransactionById(int transactionId);

        /// <summary>
        /// Gets the radio transaction airing by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>IEnumerable&lt;IRadioTransactionAiringUI&gt;.</returns>
        IEnumerable<IRadioTransactionAiringUI> GetRadioTransactionAiringById(int transactionId);
        
        /// <summary>
        /// Updates the radio transaction information.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <returns>System.String.</returns>
        string UpdateRadioTransactionInfo(IRadioTransactionUI radioMainTransaction);
        
        /// <summary>
        /// Deletes the radio transaction airing.
        /// </summary>
        /// <param name="radioTransactionId">The radio transaction identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteRadioTransactionAiring(int radioTransactionId);
        






        /// <summary>
        /// Gets the radio effective price.
        /// </summary>
        /// <param name="RadioStationId">The radio station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        IRadioServicePriceListModel GetRadioEffectivePrice(int RadioStationId, int timingId, int timeBeltId,int materialTypeId);
        
       
        /// <summary>
        /// Gets the active material type for radio.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialType> GetActiveMaterialTypeForRadio();
        /// <summary>
        /// Deletes the radio by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string deleteRadioById(int Id);


        /// <summary>
        /// Saves the material type timing.
        /// </summary>
        /// <param name="radioOrderModel">The radio order model.</param>
        /// <param name="MaterialTypeTimingId">The material type timing identifier.</param>
        /// <returns></returns>
        string SaveMaterialTypeTiming(IRadioOrderModel radioOrderModel, out int MaterialTypeTimingId);
        /// <summary>
        /// Saves the production price.
        /// </summary>
        /// <param name="productionInfo">The production information.</param>
        /// <returns></returns>
        string SaveProductionPrice(IMaterialProductionPriceView productionInfo);
        /// <summary>
        /// Saves the scripting price.
        /// </summary>
        /// <param name="scriptingInfo">The scripting information.</param>
        /// <returns></returns>
        string SaveScriptingPrice(IMaterialScriptingPriceView scriptingInfo);
        /// <summary>
        /// Edits the radio station.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <returns></returns>
        string EditRadioStation(IRadioStationView radio);

        /// <summary>
        /// Deletes the radio station.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <returns></returns>
        string DeleteRadioStation(int radio);
        /// <summary>
        /// Saves the radio station.
        /// </summary>
        /// <param name="radioInfo">The radio information.</param>
        /// <returns></returns>
        string SaveRadioStation(IRadioStationView radioInfo);

        /// <summary>
        /// Gets the user radio order by identifier.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IRadioOrder GetUserRadioOrderById(int cartId);

        /// <summary>
        /// Edits the radio transaction information.
        /// </summary>
        /// <param name="radioOrderModel">The radio order model.</param>
        /// <param name="RadioTransactionId">The radio transaction identifier.</param>
        /// <returns></returns>
        string EditRadioTransactionInfo(IRadioMainView radioOrderModel, out int RadioTransactionId);



        /// <summary>
        /// Gets the active radio tranasction.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IList<IRadioTransaction> GetActiveRadioTranasction(int Id);

        /// <summary>
        /// Gets the radio production view by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IRadioTransaction GetRadioProductionViewById(int Id);

        /// <summary>
        /// Saveradioes the production.
        /// </summary>
        /// <param name="radioProduction">The radio production.</param>
        /// <returns></returns>
        string SaveradioProduction(IRadioProductionView radioProduction);

        /// <summary>
        /// Gets the radio tranasction.
        /// </summary>
        /// <returns></returns>
        IList<IRadioTransaction> GetRadioTranasction();
        /// <summary>
        /// Gets the radio transaction airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<IRadioTransactionAiring> GetRadioTransactionAiring(int transactionId);


        /// <summary>
        /// Saves the radio transaction airing.
        /// </summary>
        /// <param name="radioAiringInfo">The radio airing information.</param>
        /// <returns></returns>
        string SaveRadioTransactionAiring(IRadioTransactionAiringView radioAiringInfo);

        /// <summary>
        /// Gets the radio production list.
        /// </summary>
        /// <returns></returns>
        IList<IRadioProduction> GetRadioProductionList();

        /// <summary>
        /// Gets the radio description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IRadioStationModel GetRadioDescriptionByValue(string description);

        /// <summary>
        /// Updates the radio transaction.
        /// </summary>
        /// <param name="radioOrderModel">The radio order model.</param>
        /// <returns></returns>
        string UpdateRadioTransaction(IRadioMainView radioOrderModel);

        /// <summary>
        /// Gets the radio station price.
        /// </summary>
        /// <param name="radionStationId">The radion station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns></returns>
        IRadioServicePriceListModel GetRadioStationPrice(int radionStationId, int timingId,int materialTypeId);
        /// <summary>
        /// Updates the radio transaction airing.
        /// </summary>
        /// <param name="radioMainView">The radio main view.</param>
        /// <returns></returns>
        string UpdateRadioTransactionAiring(IRadioMainView radioMainView);
       
        /// <summary>
        /// Gets the radio transaction.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IRadioTransaction GetRadioTransaction(int UserId, int transactionId);

        /// <summary>
        /// Gets all radio transaction.
        /// </summary>
        /// <returns></returns>
        IList<IRadioTransaction> GetAllRadioTransaction();
       


    }
}
