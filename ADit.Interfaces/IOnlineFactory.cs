using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary> 
    public interface IOnlineFactory
    {

        /// <summary>
        /// Creates the online duration view.
        /// </summary>
        /// <param name="onlineDurationView">The online duration view.</param>
        /// <returns></returns>
        IOnlineDurationView CreateOnlineDurationView(IOnlineDuration onlineDurationView);
        /// <summary>
        /// Gets the fulfilment online transaction.
        /// </summary>
        /// <param name="onlineTransaction">The online transaction.</param>
        /// <param name="onlineTransactionAiring">The online transaction airing.</param>
        /// <param name="onlineTransactionExtraService">The online transaction extra service.</param>
        /// Gets the online artwork transaction ListView.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <returns></returns>
        IOnlineArtworkTransactionListView GetOnlineArtworkTransactionListView(int transactionId);
        /// <summary>
        /// Gets the user online transaction.
        /// </summary>
        /// <param name="onlineTransaction">The online transaction.</param>
        /// <param name="onlineTransactionAttachment">The online transaction attachment.</param>
        /// <param name="onlineTransactionAiring">The online transaction airing.</param>
        /// <param name="onlineTransactionExtraService">The online transaction extra service.</param>
        /// <returns></returns>
        IOnlineView GetUserOnlineTransaction(IOnlineTransaction onlineTransaction, IList<IOnlineTransactionAiringUI> onlineTransactionAiring, IOnlineTransactionExtraService onlineTransactionExtraService);

        /// <summary>
        /// Gets all online tranasction.
        /// </summary>
        /// <param name="onlineTransactions">The online transactions.</param>
        /// <returns></returns>
        IOnlineTransactionListView GetAllOnlineTranasction(IList<IOnlineTransaction> onlineTransactions, IList<IMessage> messagesList, IList<IReplies> replies);
        /// <summary>
        /// Gets the updated online platform package price view.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView getUpdatedOnlinePlatformPackagePriceView(IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView, IList<IOnlinePlatform> onlinePlatform, IList<IOnlineDuration> durationType);

        /// <summary>
        /// Gets the updated online extra service price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView getUpdatedOnlineExtraServicePriceView(IOnlineExtraServicePriceView onlineExtraServicePriceView, IList<IOnlineExtraService> onlineExtraService);


        /// <summary>
        /// Creates the updated online view.
        /// </summary>
        /// <param name="onlineView">The online view.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <param name="onlinePurpose">The online purpose.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <returns></returns>
        IOnlineView CreateUpdatedOnlineView(IOnlineView onlineView, string ProcessingMessage, IList<IOnlineExtraService> onlineExtraService, IList<IOnlinePurpose> onlinePurpose, IList<IOnlinePlatform> onlinePlatform);

        /// <summary>
        /// Creates the online purpose ListView.
        /// </summary>
        /// <param name="onlinePurposeListCollection">The online purpose list collection.</param>
        /// <param name="selectedOnlinePurposeId">The selected online purpose identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlinePurposeListView CreateOnlinePurposeListView(IList<IOnlinePurpose> onlinePurposeListCollection, int selectedOnlinePurposeId, string selectedDescription, string message);

        /// <summary>
        /// Creates the online platform ListView.
        /// </summary>
        /// <param name="onlinePlatformListCollection">The online platform list collection.</param>
        /// <param name="selectedOnlinePlatformId">The selected online platform identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlinePlatformListView CreateOnlinePlatformListView(IList<IOnlinePlatform> onlinePlatformListCollection, int selectedOnlinePlatformId, string selectedDescription, string message);

        /// <summary>
        /// Creates the online extra service ListView.
        /// </summary>
        /// <param name="onlineExtraServiceListCollection">The online extra service list collection.</param>
        /// <param name="selectedOnlineExtraServiceId">The selected online extra service identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineExtraServiceListView CreateOnlineExtraServiceListView(IList<IOnlineExtraService> onlineExtraServiceListCollection, int selectedOnlineExtraServiceId, string selectedDescription, string message);


        /// <summary>
        /// Creates the online extra service price view.
        /// </summary>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView CreateOnlineExtraServicePriceView(IList<IOnlineExtraService> onlineExtraService);

        /// <summary>
        /// Creates the online extra service list price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceListCollection">The online extra service price list collection.</param>
        /// <param name="selectedOnlineExtraServicePriceId">The selected online extra service price identifier.</param>
        /// <param name="selectedOnlineExtraServiced">The selected online extra serviced.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceListView CreateOnlineExtraServiceListPriceView(IList<IOnlineExtraServicePrice> onlineExtraServicePriceListCollection, int selectedOnlineExtraServicePriceId, int selectedOnlineExtraServiced, string message);

        /// <summary>
        /// Creates the online extra service price view.
        /// </summary>
        /// <param name="extraServicePriceView">The extra service price view.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView CreateOnlineExtraServicePriceView(IOnlineExtraServicePriceView extraServicePriceView, string ProcessingMessage,
           IList<IOnlineExtraService> onlineExtraService);


        /// <summary>
        /// Creates the platfrom package price view.
        /// </summary>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="onlinedurationType">Type of the onlineduration.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView CreatePlatfromPackagePriceView(IList<IOnlinePlatform> onlinePlatform, IList<IOnlineDuration> onlinedurationType, IList<IDurationType> durationType);//confirmed  


        /// <summary>
        /// Creates the platfrom package price view.
        /// </summary>
        /// <param name="Onlineplatform">The onlineplatform.</param>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <param name="onlineDuraionCollections">The online duraion collections.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView CreatePlatfromPackagePriceView(IList<IOnlinePlatform> Onlineplatform, IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView,
            string ProcessingMessage, IList<IOnlineDuration> onlineDuraionCollections, IList<IDurationType> durationType);

        /// <summary>
        /// Creates the artwork price view.
        /// </summary>
        /// <param name="onlineArtworkPrice">The online artwork price.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineArtworkPriceListView CreateArtworkPriceView(IEnumerable<IOnlineArtworkPrice> onlineArtworkPrice, string message);
        /// <summary>
        /// Creates the platform package price ListView.
        /// </summary>
        /// <param name="onlinePlatformPriceListCollection">The online platform price list collection.</param>
        /// <param name="SelectedOnlinePlatformPriceId">The selected online platform price identifier.</param>
        /// <param name="SelectedOnlinePlatformId">The selected online platform identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPlatformPackagePriceListView CreatePlatformPackagePriceListView(IList<IOnlinePlatformPrice> onlinePlatformPriceListCollection, int SelectedOnlinePlatformPriceId, int SelectedOnlinePlatformId, string message);//confirmed


        /// <summary>
        /// Creates the online platfrom package price view.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <param name="Durationtype">The durationtype.</param>
        /// <param name="Onlineplatform">The onlineplatform.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView CreateOnlinePlatfromPackagePriceView(IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView,
            string ProcessingMessage, IList<IOnlineDuration> Durationtype, IList<IOnlinePlatform> Onlineplatform);



        /// <summary>
        /// Creates the online platform view.
        /// </summary>
        /// <returns></returns>
        IOnlinePlatformView CreateOnlinePlatformView();

        /// <summary>
        /// Creates the online platform view.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlinePlatformView CreateOnlinePlatformView(IOnlinePlatformView onlinePlatformView, string message);


        /// <summary>
        /// Creates the online purpose view.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlinePurposeView CreateOnlinePurposeView(IOnlinePurposeView onlinePurposeView, string message);


        /// <summary>
        /// Creates the online extra service view.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineExtraServiceView CreateOnlineExtraServiceView(IOnlineExtraServiceView onlineExtraServiceView, string message);


        /// <summary>
        /// Creates the online extra service view.
        /// </summary>
        /// <returns></returns>
        IOnlineExtraServiceView CreateOnlineExtraServiceView();


        /// <summary>
        /// Creates the online purpose view.
        /// </summary>
        /// <returns></returns>
        IOnlinePurposeView CreateOnlinePurposeView();


        /// <summary>
        /// Creates the online platform view.
        /// </summary>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <returns></returns>
        IOnlinePlatformView CreateOnlinePlatformView(IOnlinePlatform onlinePlatform);

        /// <summary>
        /// Creates the online purpose view.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        IOnlinePurposeView CreateOnlinePurposeView(IOnlinePurpose onlinePurposeView);

        /// <summary>
        /// Creates the online extra service view.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        IOnlineExtraServiceView CreateOnlineExtraServiceView(IOnlineExtraService onlineExtraServiceView);




        /// <summary>
        /// Gets the edit platfrom package price view.
        /// </summary>
        /// <param name="pricingView">The pricing view.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView GetEditPlatfromPackagePriceView(IOnlinePlatformPrice pricingView);


        /// <summary>
        /// Creates the online platform package price.
        /// </summary>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView CreateOnlinePlatformPackagePrice(IList<IOnlineDuration> durationType, IList<IOnlinePlatform> onlinePlatform);


        /// <summary>
        /// Gets the edit online extra service price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView GetEditOnlineExtraServicePriceView(IOnlineExtraServicePrice onlineExtraServicePriceView);

        /// <summary>
        /// Edits the online platform package price.
        /// </summary>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="onlinePlatformPrice">The online platform price.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView EditOnlinePlatformPackagePrice(IList<IOnlineDuration> durationType, IList<IOnlinePlatform> onlinePlatform, IOnlinePlatformPrice onlinePlatformPrice);

        /// <summary>
        /// Edits the online extra service price.
        /// </summary>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <param name="onlineExtraServicePrice">The online extra service price.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView EditOnlineExtraServicePrice(IList<IOnlineExtraService> onlineExtraService, IOnlineExtraServicePrice onlineExtraServicePrice);

        /// <summary>
        /// Creates the delete online extra servicet price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView CreateDeleteOnlineExtraServicetPriceView(IOnlineExtraServicePrice onlineExtraServicePriceView);

        /// <summary>
        /// Creates the delete platform package price view.
        /// </summary>
        /// <param name="platformPackagePriceView">The platform package price view.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView CreateDeletePlatformPackagePriceView(IOnlinePlatformPrice platformPackagePriceView);
        /// <summary>
        /// Gets the online extra service price.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        IOnlineView GetOnlineExtraServicePrice(IOnlineExtraServicePrice price);

        /// <summary>
        /// Gets the online artwork price.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        IOnlineView GetOnlineArtworkPrice(IOnlineArtworkPrice price);


        /// <summary>
        /// Gets the online view.
        /// </summary>
        /// <param name="onlinePurpose">The online purpose.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <param name="onlineArtWorkList">The online art work list.</param>
        /// <param name="onlineDurations">The online durations.</param>
        /// <returns></returns>
        IOnlineTransactionUIView GetOnlineView(IList<IOnlinePurpose> onlinePurpose, IList<IOnlinePlatform> onlinePlatform,
            IList<IOnlineExtraService> onlineExtraService, IEnumerable<IOnlineArtworkPrice> onlineArtWorkList,
            IList<IOnlineDuration> onlineDurations);

        /// <summary>
        /// Gets the online view.
        /// </summary>
        /// <param name="onlinePurpose">The online purpose.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <param name="onlineArtWorkList">The online art work list.</param>
        /// <param name="onlineDuration">Duration of the online.</param>
        /// <param name="onlineMainTransaction">The online main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedOnlinePlatformIds">The selected online platform ids.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IOnlineTransactionUIView GetOnlineView(IList<IOnlinePurpose> onlinePurpose, IList<IOnlinePlatform> onlinePlatform,
           IList<IOnlineExtraService> onlineExtraService,
           IEnumerable<IOnlineArtworkPrice> onlineArtWorkList,
           IList<IOnlineDuration> onlineDuration, IOnlineTransactionUI onlineMainTransaction, IEnumerable<IOnlineTransactionAiringUI> transactionAiring,
           List<int> selectedOnlinePlatformIds, string processingMessage);



        /// <summary>
        /// Creates the online duration view.
        /// </summary>
        /// <returns></returns>
        IOnlineDurationView CreateOnlineDurationView();

        /// <summary>
        /// Creates the update online duration view.
        /// </summary>
        /// <param name="onlineDurationInfo">The online duration information.</param>
        /// <param name="processMessage">The process message.</param>
        /// <returns></returns>
        IOnlineDurationView CreateUpdateOnlineDurationView(IOnlineDurationView onlineDurationInfo, string processMessage);

        /// <summary>
        /// Creates the online duration ListView.
        /// </summary>
        /// <param name="onlineDurationListCollection">The online duration list collection.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineDurationList CreateOnlineDurationListView(IList<IOnlineDuration> onlineDurationListCollection,
            string selectedDescription, string message);


        /// <summary>
        /// Gets the tv transaction edit view.
        /// </summary>
        /// <param name="onlineTransaction">The online transaction.</param>
        /// <param name="onlineExtra">The online extra.</param>
        /// <param name="onlineTransactionAiring">The online transaction airing.</param>
        /// <param name="onlinePurpose">The online purpose.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <param name="onlineArtWorkList">The online art work list.</param>
        /// <param name="onlineDurations">The online durations.</param>
        /// <param name="Processingmessage">The processingmessage.</param>
        /// <returns></returns> 
        IOnlineTransactionUIView GetOnlineTransactionEditView(IList<IOnlinePurpose> onlinePurpose, IList<IOnlinePlatform> onlinePlatform,
             IOnlineTransactionExtraService onlineExtra, IEnumerable<IOnlineArtworkPrice> onlineArtWorkList, IList<IOnlineDuration> onlineDurations,
             IList<IOnlineExtraService> onlineExtraService, IOnlineTransactionUI onlineTransaction, IList<IOnlineTransactionAiringUI> onlineTransactionAiring,
             List<int> selectedPlatformIds, string processingMessage);

        /// <summary>
        /// Gets the online artwork transaction ListView.
        /// </summary>
        /// <param name="onlineTransaction">The online transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        IOnlineArtworkTransactionListView GetOnlineArtworkTransactionListView(IOnlineTransaction onlineTransaction, IDigitalFile digitalFile, int? Id, int RepliesId);


        /// <summary>
        /// Gets the online artwork message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetOnlineArtworkMessageRepliesListView(IList<IReplies> replies, IMessage message, int transactionId, int OrderId);

       /// <summary>
        /// Creates the online artworkt price view.
        /// </summary>
        /// <param name="onlineArtworkPrice">The online artwork price.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        IOnlineArtworkPriceView CreateOnlineArtworktPriceView(IOnlineArtworkPrice onlineArtworkPrice, IList<IServiceType> serviceType);  
        /// <summary>
        /// Creates the artwork ListView.
        /// </summary>
        /// <param name="SelectedArtWorkId">The selected art work identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="artWorklCollection">The art workl collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineArtworkPriceListView CreateArtworkListView(int SelectedArtWorkId, string SelectedDescription, IList<IOnlineArtworkPrice> artWorklCollection, string message);
        /// <summary>
        /// Creates the artwork price view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="ArtWork">The art work.</param>
        /// <returns></returns>
        IOnlineArtworkPriceView CreateOnliineArtworkPriceView(IList<IServiceType> ServiceType);
        /// <summary>
        /// Creates the artwork price view.
        /// </summary>
        /// <param name="artworkInfo">The artwork information.</param>
        /// <param name="ProcessingMessages">The processing messages.</param>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="ArtWork">The art work.</param>
        /// <returns></returns>
        IOnlineArtworkPriceView CreateArtworkPriceView(IOnlineArtworkPriceView artworkInfo, string ProcessingMessages,  IList<IServiceType> ServiceType, IList<IOnlineArtworkPrice> ArtWork);
        /// <summary>
        /// Edits the artwork price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="artWork">The art work.</param>
        /// <param name="artWorkPrice">The art work price.</param>
        /// <returns></returns>
        IOnlineArtworkPriceView EditArtworkPriceView(IList<IServiceType> serviceType, IList<IOnlineArtworkPrice> artWork, IOnlineArtworkPrice artWorkPrice);
        /// <summary>
        /// Creates the artwork price ListView.
        /// </summary>
        /// <param name="artwork">The artwork.</param>
        /// <param name="message">The message.</param>
        /// <param name="SelectedArtWorkPriceId">The selected art work price identifier.</param>
        /// <param name="SelectedServiceTypeCode">The selected service type code.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <returns></returns>
        IOnlineArtworkPriceListView CreateArtworkPriceListView(IList<IOnlineArtworkPrice> artwork, string message, int SelectedArtWorkPriceId, string SelectedServiceTypeCode, string SelectedDescription);
        /// <summary>
        /// Creates the delete artwork price view.
        /// </summary>
        /// <param name="artWorkPriceView">The art work price view.</param>
        /// <returns></returns>
        IOnlineArtworkPriceView CreateDeleteArtworkPriceView(IOnlineArtworkPrice artWorkPriceView);
        /// <summary>
        /// Creates the updated online artwork price view.
        /// </summary>
        /// <param name="onlineArtworkPrice">The online artwork price.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        IOnlineArtworkPriceView CreateUpdatedOnlineArtworkPriceView(IOnlineArtworkPriceView onlineArtworkPrice, IList<IServiceType> serviceType);
        //
        IOnlineArtworkPriceView CreateDeleteOnlineArtworkPrice(IOnlineArtworkPrice onlineArtworkPrice, IList<IServiceType> serviceType);
    }
}
