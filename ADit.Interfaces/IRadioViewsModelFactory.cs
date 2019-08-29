using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRadioViewsModelFactory
    {
        /// <summary>
        /// 
        /// </summary>
       
        /// <summary>
        /// Creates the radio main view.
        /// </summary>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <param name="radioStations">The radio stations.</param>
        /// <param name="timing">The timing.</param>
        /// <param name="scriptMaterialQuestion">The script material question.</param>
        /// <param name="activeMaterialTypeCollection">The active material type collection.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns>
        /// IRadioTransactionUIView.
        /// </returns>
        IRadioTransactionUIView CreateRadioMainView(IList<IApconApprovalType> apconApprovalType,
            IList<IRadioStationModel> radioStations, IList<ITiming> timing,
            IList<IScriptMaterialQuestion> scriptMaterialQuestion, IList<IMaterialType> activeMaterialTypeCollection,
            IList<ITimeBelt> timeBelts);

        /// <summary>
        /// Creates the radio main view.
        /// </summary>
        /// <param name="approvalList">The approval list.</param>
        /// <param name="radioStationList">The radio station list.</param>
        /// <param name="timing">The timing.</param>
        /// <param name="scriptMaterialQuestion">The script material question.</param>
        /// <param name="activeMaterialType">Type of the active material.</param>
        /// <param name="timeBeltList">The time belt list.</param>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns>
        /// IRadioTransactionUIView.
        /// </returns>
        IRadioTransactionUIView CreateRadioMainView(IList<IApconApprovalType> approvalList,
            IList<IRadioStationModel> radioStationList, IList<ITiming> timing,
            IList<IScriptMaterialQuestion> scriptMaterialQuestion, IList<IMaterialType> activeMaterialType,
            IList<ITimeBelt> timeBeltList, IRadioTransactionUI radioMainTransaction,
            IEnumerable<IRadioTransactionAiringUI> transactionAiring, List<int> selectedRadioStationIds,
            string processingMessage);


        /// <summary>
        /// Gets the user transaction.
        /// </summary>
        /// <param name="radioOrder">The radio order.</param>
        /// <param name="radioAiringTransactionModels">The radio airing transaction models.</param>
        /// <param name="materialTypes">The material types.</param>
        /// <returns></returns>
        IRadioMainView GetUserTransaction(IRadioOrder radioOrder,
            IList<IRadioTransactionAiring> radioAiringTransactionModels, IList<IMaterialType> materialTypes);


        /// <summary>
        /// Creates the radio station.
        /// </summary>
        /// <returns></returns>
        IRadioStationView CreateRadioStation();

        /// <summary>
        /// Creates the radio station.
        /// </summary>
        /// <param name="radioView">The radio view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IRadioStationView CreateRadioStation(IRadioStationView radioView, string message);

        /// <summary>
        /// Creates the material production price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <returns></returns>
        IMaterialProductionPriceView CreateMaterialProductionPriceView(IList<IServiceType> serviceType,
            IList<IMaterialType> materialType);

        /// <summary>
        /// Creates the material production price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="view">The view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialProductionPriceView CreateMaterialProductionPriceView(IList<IServiceType> serviceType,
            IList<IMaterialType> materialType, IMaterialProductionPriceView view, string message);

        /// <summary>
        /// Edits the material production price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="productionPrice">The production price.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialProductionPriceView EditMaterialProductionPriceView(IList<IServiceType> serviceType,
            IList<IMaterialType> materialType, IMaterialProductionPrice productionPrice, string message);

        /// <summary>
        /// Creates the updated material production price view.
        /// </summary>
        /// <param name="productionInfo">The production information.</param>
        /// <param name="processingMessages">The processing messages.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <returns></returns>
        IMaterialProductionPriceView CreateUpdatedMaterialProductionPriceView(
            IMaterialProductionPriceView productionInfo, string processingMessages,
            IList<IServiceType> serviceType, IList<IMaterialType> materialType);

        /// <summary>
        /// Creates the radio station view.
        /// </summary>
        /// <param name="radioStationCollection">The radio station collection.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedRadioStationId">The selected radio station identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        IRadioSationListView CreateRadioStationView(IList<IRadioStationModel> radioStationCollection, string message,
            int selectedRadioStationId, string selectedDescription);

        /// <summary>
        /// Creates the scripting price view.
        /// </summary>
        /// <param name="materialScriptingType">Type of the material scripting.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedMaterialScriptingPriceId">The selected material scripting price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <returns></returns>
        IScriptingPriceListView CreateScriptingPriceView(IList<IMaterialScriptingPrice> materialScriptingType,
            string message,
            int selectedMaterialScriptingPriceId, string selectedDescription, string selectedServiceTypeCode);

        /// <summary>
        /// Creates the production price view.
        /// </summary>
        /// <param name="materialProductionType">Type of the material production.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedMaterialProductionPriceId">The selected material production price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <returns></returns>
        IProductionPriceListView CreateProductionPriceView(IList<IMaterialProductionPrice> materialProductionType,
            string message,
            int selectedMaterialProductionPriceId, string selectedDescription, string selectedServiceTypeCode);

        /// <summary>
        /// Creates the timing list vew.
        /// </summary>
        /// <param name="timingCollection">The timing collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITimingListView CreateTimingListVew(IList<ITiming> timingCollection, string message);

        /// <summary>
        /// Creates the timing view.
        /// </summary>
        /// <param name="timingCollection">The timing collection.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ITimingView CreateTimingView(IList<ITiming> timingCollection, int id);

        /// <summary>
        /// Creates the material scripting price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <returns></returns>
        IMaterialScriptingPriceView CreateMaterialScriptingPriceView(IList<IServiceType> serviceType,
            IList<IMaterialType> materialType);

        /// <summary>
        /// Creates the material scripting price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="view">The view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialScriptingPriceView CreateMaterialScriptingPriceView(IList<IServiceType> serviceType,
            IList<IMaterialType> materialType, IMaterialScriptingPriceView view, string message);

        /// <summary>
        /// Creates the updated material scripting price view.
        /// </summary>
        /// <param name="scriptingInfo">The scripting information.</param>
        /// <param name="processingMessages">The processing messages.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <returns></returns>
        IMaterialScriptingPriceView CreateUpdatedMaterialScriptingPriceView(IMaterialScriptingPriceView scriptingInfo,
            string processingMessages,
            IList<IServiceType> serviceType, IList<IMaterialType> materialType);

        /// <summary>
        /// Gets the edit radio station type view.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IRadioStationView GetEditRadioStationTypeView(IRadioStationModel radio, string message);

        /// <summary>
        /// Edits the material scripting price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="scriptingPrice">The scripting price.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialScriptingPriceView EditMaterialScriptingPriceView(IList<IServiceType> serviceType,
            IList<IMaterialType> materialType, IMaterialScriptingPrice scriptingPrice, string message);


        /// <summary>
        /// Gets the scripting price for radio.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        IRadioMainView GetScriptingPriceForRadio(IMaterialScriptingPrice price);

        /// <summary>
        /// Gets the production price for radio.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        IRadioMainView GetProductionPriceForRadio(IMaterialProductionPrice price);

        /// <summary>
        /// Gets the radio transaction.
        /// </summary>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <returns></returns>
        IRadioMainListView getRadioTransaction(IList<IRadioTransaction> radioTransaction);


        /// <summary>
        /// Gets the radio airing view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="radioStationList">The radio station list.</param>
        /// <param name="durationTypeList">The duration type list.</param>
        /// <param name="timingList">The timing list.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IRadioTransactionAiringView GetRadioAiringView(int transactionId,
            IList<IRadioStationModel> radioStationList, IList<IDurationType> durationTypeList,
            IList<ITiming> timingList, string processingMessage);


        /// <summary>
        /// Gets the radio material transaction ListView.
        /// </summary>
        /// <param name="radioMaterialTransaction">The radio material transaction.</param>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <returns></returns>
        IRadioTransactionMaterialListView GetRadioMaterialTransactionListView(
            IList<IRadioMaterialTransaction> radioMaterialTransaction, IRadioTransaction radioTransaction);


        /// <summary>
        /// Gets the radio transaction edit view.
        /// </summary>
        /// <param name="radioOrder">The radio order.</param>
        /// <param name="radioTransactionAiring">The radio transaction airing.</param>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="radioStationType">Type of the radio station.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="timing">The timing.</param>
        /// <param name="scriptMaterialQuestion">The script material question.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns>
        /// IRadioMainView.
        /// </returns>
        IRadioMainView GetRadioTransactionEditView(IRadioOrder radioOrder,
            IList<IRadioTransactionAiring> radioTransactionAiring, IList<IApconApprovalType> apconApprovalType,
            IList<IMaterialType> materialType,
            IList<IRadioStationModel> radioStationType, IList<IDurationType> durationType,
            IList<IMaterialTypeTimingModel> timing, IList<IScriptMaterialQuestion> scriptMaterialQuestion,
            string processingMessage, IList<ITimeBelt> timeBelts);

        /// <summary>
        /// Gets the radio transaction by identifier.
        /// </summary>
        /// <param name="radioOrder">The radio order.</param>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="radioTransactionAiring">The radio transaction airing.</param>
        /// <returns></returns>
        IRadioMainView getRadioTransactionById(IRadioOrder radioOrder, IList<IApconApprovalType> apconApprovalType,
            IList<IMaterialType> materialType, string processingMessage,
            IList<IRadioTransactionAiring> radioTransactionAiring);


        /// <summary>
        /// Gets the radio production view by identifier.
        /// </summary>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <returns></returns>
        IRadioMainView GetRadioProductionViewById(IRadioTransaction radioTransaction);


        /// <summary>
        /// Creates the radio transaction view.
        /// </summary>
        /// <param name="apconApprovalTypePriceList">The apcon approval type price list.</param>
        /// <param name="durationTypeList">The duration type list.</param>
        /// <param name="scriptMaterialQuestionList">The script material question list.</param>
        /// <param name="materialTypeTimeList">The material type time list.</param>
        /// <param name="productionPriceList">The production price list.</param>
        /// <param name="scriptingPriceList">The scripting price list.</param>
        /// <param name="radioStationList">The radio station list.</param>
        /// <returns></returns>
        IRadioTransactionView CreateRadioTransactionView(
            IList<IApconApprovalTypePrice> apconApprovalTypePriceList, IList<IDurationType> durationTypeList,
            IList<IScriptMaterialQuestion> scriptMaterialQuestionList,
            IList<IMaterialTypeTimingDetail> materialTypeTimeList,
            IList<IMaterialProductionPrice> productionPriceList, IList<IMaterialScriptingPrice> scriptingPriceList,
            IList<IRadioStationModel> radioStationList);


        /// <summary>
        /// Gets the radio main ListView.
        /// </summary>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <param name="radioProduction">The radio production.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <returns></returns>
        IRadioProductionListView GetRadioMainListView(IRadioTransaction radioTransaction,
            IList<IRadioProduction> radioProduction, IDigitalFile digitalFile);

        /// <summary>
        /// Gets the radio script transaction ListView.
        /// </summary>
        /// <param name="radioScriptTransaction">The radio script transaction.</param>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="repliesId">The replies identifier.</param>
        /// <returns></returns>
        IRadioScriptTransactionListView GetRadioScriptTransactionListView(
            IList<IRadioScriptTransaction> radioScriptTransaction, IRadioTransaction radioTransaction,
            IDigitalFile digitalFile, int? id, int repliesId, IList<IMessage> messages, IList<IReplies> replies);

        /// <summary>
        /// Gets all radio transaction.
        /// </summary>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <returns></returns>
        IRadioTransactionListView getAllRadioTransaction(IList<IRadioTransaction> radioTransaction,
            IList<IMessage> messages, string ProcessingMessage, IList<IMessage> messagelist, IList<IReplies> replies);

        /// <summary>
        /// Gets the script message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetScriptMessageRepliesListView(IList<IReplies> replies, IMessage message, int SentToId,
            int transactionId, int OrderId);

        /// <summary>
        /// Gets the radio material transaction ListView.
        /// </summary>
        /// <param name="radioMaterialTransactions">The radio material transactions.</param>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="repliesId">The replies identifier.</param>
        /// <returns></returns>
        IRadioTransactionMaterialListView GetRadioMaterialTransactionListView(
            IList<IRadioMaterialTransaction> radioMaterialTransactions, IRadioTransaction radioTransaction,
            IDigitalFile digitalFile, int? id, int repliesId, IList<IMessage> messages, IList<IReplies> replies);

        /// <summary>
        /// Gets the material message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetMaterialMessageRepliesListView(IList<IReplies> replies, IMessage message,
            int SentToId, int transactionId, int OrderId);
    }
}