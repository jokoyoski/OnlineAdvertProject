using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITvFactory
    {
     /// <summary>
        /// Gets the user transaction.
        /// </summary>
        /// <param name="tvOrder">The tv order.</param>
        /// <param name="tvTransactionAirings">The tv transaction airings.</param>
        /// <param name="materialTypes">The material types.</param>
        /// <returns></returns>

        ITvScriptTrsancsationListView GetTvScriptTrsancsationListView(int transactionId, int SentToId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tvOrder"></param>
        /// <param name="tvTransactionAirings"></param>
        /// <param name="materialTypes"></param>
        /// <returns></returns>

       
        ITvView GetUserTransaction(ITvOrder tvOrder, IList<ITvTransactionAiring> tvTransactionAirings, IList<IMaterialType> materialTypes);
        /// <summary>
        /// Gets the script message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetScriptMessageRepliesListView(IList<IReplies> replies, IMessage message,int sentToId,int transactionId,int OrderId);
        /// <summary>
        /// Gets the material message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetMaterialMessageRepliesListView(IList<IReplies> replies, IMessage message,int sentToId, int transactionId,int OrderId);

        /// <summary>
        /// Gets the tv script trsancsation ListView.
        /// </summary>
        /// <param name="tvScriptingTransactionModelViews">The tv scripting transaction model views.</param>
        /// <param name="tvTransaction">The tv transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        ITvScriptTrsancsationListView GetTvScriptTrsancsationListView(
            IList<ITvScriptingTransactionModelView> tvScriptingTransactionModelViews, ITvTransaction tvTransaction,
            IDigitalFile digitalFile, int? Id, int RepliesId,IList<IMessage>messages,IList<IReplies>replies);

        /// <summary>
        /// Gets the tv material transaction ListView.
        /// </summary>
        /// <param name="tvMaterialTransactions">The tv material transactions.</param>
        /// <param name="tvTransaction">The tv transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        ITvTransactionMaterialListView GetTvMaterialTransactionListView(
            IList<ITvMaterialTransactionModel> tvMaterialTransactions, ITvTransaction tvTransaction,
            IDigitalFile digitalFile, int? Id, int RepliesId,IList<IMessage>messages,IList<IReplies>replies);

        /// <summary>
        /// Gets the updated tv services ListView.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="timing">The timing.</param>
        /// <returns></returns>
        ITVServicePricesListView GetUpdatedTvServicesListView(ITVServicePricesListView tVServicePricesListView,
            string processingMessage, IList<ITvStation> tvStation, IList<ITiming> timing);


        /// <summary>
        /// Gets the tv service prices ListView.
        /// </summary>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="timing">The timing.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        ITVServicePricesListView GetTVServicePricesListView(IList<ITvStation> tvStation, IList<ITiming> timing,
            IList<ITimeBelt> timeBelts,IList<IMaterialType>materialTypes);

        /// <summary>
        /// Getedits the tv service price ListView.
        /// </summary>
        /// <param name="tVServicePricesList">The t v service prices list.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        ITVServicePricesListView GeteditTvServicePriceListView(ITVServicePricesList tVServicePricesList,
            IList<ITvStation> tvStation, IList<ITiming> Timing, IList<ITimeBelt> timeBelts,IList<IMaterialType>materialTypes);

        /// <summary>
        /// Gets the itv service prices list.
        /// </summary>
        /// <param name="SelectedTvServicesPriceId">The selected tv services price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="tVServicePricesList">The t v service prices list.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITVServicePricesListMainView GetITVServicePricesList(int SelectedTvServicesPriceId, string selectedDescription,
            IList<ITVServicePricesList> tVServicePricesList, string processingMessage);

        /// <summary>
        /// Gets the tv view.
        /// </summary>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="timing">The timing.</param>
        /// <param name="materialQuestion">The material question.</param>
        /// <param name="timeBelt">The time belt.</param>
        /// <returns></returns>
        ITVTransactionUIView GetTvView(IList<IApconApprovalType> apconApprovalType, IList<IMaterialType> materialType,
            IList<ITvStation> tvStation, IList<IDurationType> durationType, IList<ITiming> timing,
            IList<IScriptMaterialQuestion> materialQuestion, IList<ITimeBelt> timeBelt);


        /// <summary>
        /// Creates the updated view.
        /// </summary>
        /// <param name="apconApprovalTypeCollections">The apcon approval type collections.</param>
        /// <param name="materialTypeCollections">The material type collections.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="durationTypeCollections">The duration type collections.</param>
        /// <param name="timingCollections">The timing collections.</param>
        /// <param name="materialQuestionCollections">The material question collections.</param>
        /// <param name="timeBeltList">The time belt list.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="tvMainTransaction">The tv main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedTvStationIds">The selected tv station ids.</param>
        /// <returns></returns>
        ITVTransactionUIView CreateUpdatedView(IList<IApconApprovalType> apconApprovalTypeCollections,
            IList<IMaterialType> materialTypeCollections, IList<ITvStation> tvStation,
            IList<IDurationType> durationTypeCollections, IList<IMaterialTypeTimingModel> timingCollections,
            IList<IScriptMaterialQuestion> materialQuestionCollections, IList<ITimeBelt> timeBeltList,
            string processingMessage, ITvTransactionUI tvMainTransaction,
               IEnumerable<ITvTransactionAiringUI> transactionAiring, List<int> selectedTvStationIds);


        /// <summary>
        /// Creates the tv station ListView.
        /// </summary>
        /// <param name="tvStationListCollection">The tv station list collection.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedTvStationId">The selected tv station identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        ITvStationListView CreateTvStationListView(IList<ITvStation> tvStationListCollection, string message,
            int selectedTvStationId, string selectedDescription);


        /// <summary>
        /// Creates the tv station view.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITvStationView CreateTvStationView(ITvStationView tvStationView, string message);


        /// <summary>
        /// Creates the tv station view.
        /// </summary>
        /// <returns></returns>
        ITvStationView CreateTvStationView();

        /// <summary>
        /// Gets the edit tv station view.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        ITvStationView GetEditTvStationView(ITvStation tvStationView);


        /// <summary>
        /// Gets the scripting price for tv.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        ITvView GetScriptingPriceForTv(IMaterialScriptingPrice price);

        /// <summary>
        /// Gets the production price for tv.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        ITvView GetProductionPriceForTv(IMaterialProductionPrice price);

        /// <summary>
        /// Gets the tv transaction edit view.
        /// </summary>
        /// <param name="tvOrder">The tv order.</param>
        /// <param name="tvTransactionAiring">The tv transaction airing.</param>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="materialQuestion">The material question.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="durationTypeCollections">The duration type collections.</param>
        /// <param name="timingCollections">The timing collections.</param>
        /// <param name="timeBeltCollections">The time belt collections.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITVTransactionUIView GetTvTransactionEditView(ITvOrder tvOrder, IList<ITvTransactionAiringUI> tvTransactionAiring, IList<int>SelectionTvIds,
            IList<IApconApprovalType> apconApprovalType,
            IList<IMaterialType> materialType,
            IList<IScriptMaterialQuestion> materialQuestion, IList<ITvStation> tvStation,
            IList<IDurationType> durationTypeCollections,
            IList<ITiming> timingCollections,
            IList<ITimeBelt> timeBeltCollections,
            string processingMessage);


        /// <summary>
        /// Gets the tv airing view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="tvStationList">The tv station list.</param>
        /// <param name="durationTypeList">The duration type list.</param>
        /// <param name="timingList">The timing list.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITVTransactionAiringView GetTvAiringView(int transactionId,
            IList<ITvStation> tvStationList, IList<IDurationType> durationTypeList,
            IList<ITiming> timingList, string processingMessage);
    }
}