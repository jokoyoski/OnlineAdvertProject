using System.Collections.Generic;
using System.Web;

namespace ADit.Interfaces
{
     

    /// <summary>
    /// 
    /// </summaryADitEntities
    public interface IOnlineServices
    {
        /// <summary>
        /// Processes the delete online duration information.
        /// </summary>
        /// <param name="onlineDurationId">The online duration identifier.</param>
        /// <returns></returns>
        string ProcessDeleteOnlineDurationInfo(int onlineDurationId);
        /// <summary>
        /// Updates the online duration information.
        /// </summary>
        /// <param name="onlineDurationView">The online duration view.</param>
        /// <returns></returns>
        string UpdateOnlineDurationInfo(IOnlineDurationView onlineDurationView);
        /// <summary>
        /// Gets the selected online duration information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineDurationView GetSelectedOnlineDurationInfo(int Id);
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onlineView"></param>
        /// <param name="transactionAiring"></param>
        /// <param name="selectedOnlinePlatformIds"></param>
        /// <param name="artWorks"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        string UpdateOnlineTransaction(IOnlineTransactionUI onlineView, IEnumerable<IOnlineTransactionAiringUI> transactionAiring,
            List<int> selectedOnlinePlatformIds, HttpPostedFileBase artWorks, out int orderId);
      
        /// <summary>
        /// Gets the online user transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IOnlineView GetOnlineUserTransaction(int transactionId);
        

        /// Gets the updated online extra service price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView GetUpdatedOnlineExtraServicePriceView(IOnlineExtraServicePriceView onlineExtraServicePriceView);
        /// <summary>
        /// Gets the updated online platform package price view.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView GetUpdatedOnlinePlatformPackagePriceView(IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView);


        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <returns></returns>
        IOnlineTransactionUIView GetView();

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="onlineMainTransaction">The online main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedOnlinePlatformIds">The selected online platform ids.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IOnlineTransactionUIView GetUpdatedView(IOnlineTransactionUI onlineMainTransaction, IEnumerable<IOnlineTransactionAiringUI> transactionAiring,
            List<int> selectedOnlinePlatformIds, string processingMessage);


        /// <summary>
        /// Processviews the specified online main transaction.
        /// </summary>
        /// <param name="onlineMainTransaction">The online main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedOnlinePlatformIds">The selected online platform ids.</param>
        /// <param name="artwork">The artwork.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        string Processview(IOnlineTransactionUIView onlineMainTransaction,
            IEnumerable<IOnlineTransactionAiringUI> transactionAiring, List<int> selectedOnlinePlatformIds,
             HttpPostedFileBase artwork, out int orderId);



        /// <summary>
        /// Gets the online purpose ListView model.
        /// </summary>
        /// <param name="selectedOnlinePurposeId">The selected online purpose identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlinePurposeListView GetOnlinePurposeListViewModel(int selectedOnlinePurposeId, string selectedDescription, string message);


        /// <summary>
        /// Gets the online platform ListView model.
        /// </summary>
        /// <param name="selectedOnlinePlatformId">The selected online platform identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlinePlatformListView GetOnlinePlatformListViewModel(int selectedOnlinePlatformId, string selectedDescription, string message);

        /// <summary>
        /// Gets the online extra service ListView model.
        /// </summary>
        /// <param name="selectedOnlineExtraServiceId">The selected online extra service identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineExtraServiceListView GetOnlineExtraServiceListViewModel(int selectedOnlineExtraServiceId, string selectedDescription, string message);

        /// <summary>
        /// Gets the online extra service price ListView model.
        /// </summary>
        /// <param name="SelectOnlineExtraServicePriceId">The select online extra service price identifier.</param>
        /// <param name="SelectOnlineExtraServiceId">The select online extra service identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceListView GetOnlineExtraServicePriceListViewModel(int SelectOnlineExtraServicePriceId, int SelectOnlineExtraServiceId, string message);

        /// <summary>
        /// Gets the online platform view.
        /// </summary>
        /// <returns></returns>
        IOnlinePlatformView GetOnlinePlatformView();


        /// <summary>
        /// Gets the online platform view.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlinePlatformView GetOnlinePlatformView(IOnlinePlatformView onlinePlatformView, string message);




        /// <summary>
        /// Gets the online purpose view.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlinePurposeView GetOnlinePurposeView(IOnlinePurposeView onlinePurposeView, string message);



        /// <summary>
        /// Gets the online extra service view.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineExtraServiceView GetOnlineExtraServiceView(IOnlineExtraServiceView onlineExtraServiceView, string message);



        /// <summary>
        /// Creates the online purpose view.
        /// </summary>
        /// <returns></returns>
        IOnlinePurposeView CreateOnlinePurposeView();


        /// <summary>
        /// Creates the online extra service view.
        /// </summary>
        /// <returns></returns>
        IOnlineExtraServiceView CreateOnlineExtraServiceView();




        /// <summary>
        /// Processes the online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        string ProcessOnlineExtraServiceInfo(IOnlineExtraServiceView onlineExtraServiceView);


        /// <summary>
        /// Processes the online platform information.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        string ProcessOnlinePlatformInfo(IOnlinePlatformView onlinePlatformView);


        /// <summary>
        /// Processes the online purpose information.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        string ProcessOnlinePurposeInfo(IOnlinePurposeView onlinePurposeView);


        /// <summary>
        /// Updates the online platform information.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        string UpdateOnlinePlatformInfo(IOnlinePlatformView onlinePlatformView);


        /// <summary>
        /// Updates the online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        string UpdateOnlineExtraServiceInfo(IOnlineExtraServiceView onlineExtraServiceView);





        /// <summary>
        /// Updates the online purpose information.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        string UpdateOnlinePurposeInfo(IOnlinePurposeView onlinePurposeView);




        /// <summary>
        /// Processes the delete online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceId">The online extra service identifier.</param>
        /// <returns></returns>
        string ProcessDeleteOnlineExtraServiceInfo(int onlineExtraServiceId);




        /// <summary>
        /// Processes the delete online purpose information.
        /// </summary>
        /// <param name="onlinePurposeId">The online purpose identifier.</param>
        /// <returns></returns>
        string ProcessDeleteOnlinePurposeInfo(int onlinePurposeId);


        /// <summary>
        /// Processes the delete online platform information.
        /// </summary>
        /// <param name="onlinePlatformId">The online platform identifier.</param>
        /// <returns></returns>
        string ProcessDeleteOnlinePlatformInfo(int onlinePlatformId);



        /// <summary>
        /// Gets the selected online extra service information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineExtraServiceView GetSelectedOnlineExtraServiceInfo(int Id);



        /// <summary>
        /// Gets the delete online extra service price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView GetDeleteOnlineExtraServicePriceById(int Id);


        /// <summary>
        /// Gets the selected online extra service price information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView GetSelectedOnlineExtraServicePriceInfo(int Id);


        /// <summary>
        /// Gets the delete platform package price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView GetDeletePlatformPackagePriceById(int Id);

        /// <summary>
        /// Gets the selected online platform information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlinePlatformView GetSelectedOnlinePlatformInfo(int Id);

        /// <summary>
        /// Gets the selected online purpose information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlinePurposeView GetSelectedOnlinePurposeInfo(int Id);


        /// <summary>
        /// Gets the platform package price view model.
        /// </summary>
        /// <param name="SelectedOnlinePlatformPriceId">The selected online platform price identifier.</param>
        /// <param name="SelectedOnlinePlatformId">The selected online platform identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPlatformPackagePriceListView GetPlatformPackagePriceViewModel(int SelectedOnlinePlatformPriceId, int SelectedOnlinePlatformId, string message);





         /// <summary>
        /// Gets the platform package price view.
        /// </summary>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView GetPlatformPackagePriceView();

       

        /// <summary>
        /// Gets the platform package price view.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView GetPlatformPackagePriceView(IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView, string message);


        /// <summary>
        /// Gets the online extra service price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView GetOnlineExtraServicePriceView(IOnlineExtraServicePriceView onlineExtraServicePriceView, string message);

        /// <summary>
        /// Processes the platform package price information.
        /// </summary>
        /// <param name="platformInfo">The platform information.</param>
        /// <returns></returns>
        string ProcessPlatformPackagePriceInfo(IOnlinePlatformPackagePriceView platformInfo);



        /// <summary>
        /// Gets the online extra service price view.
        /// </summary>
        /// <returns></returns>
        IOnlineExtraServicePriceView GetOnlineExtraServicePriceView();


        /// <summary>
        /// Processes the online extra service price information.
        /// </summary>
        /// <param name="extraServicePriceInfo">The extra service price information.</param>
        /// <returns></returns>
        string ProcessOnlineExtraServicePriceInfo(IOnlineExtraServicePriceView extraServicePriceInfo);

        /// <summary>
        /// Gets the selected platform package price information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlinePlatformPackagePriceView GetSelectedPlatformPackagePriceInfo(int Id);





        /// <summary>
        /// Processes the edit online platform package price information.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <returns></returns>
        string ProcessEditOnlinePlatformPackagePriceInfo(IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView);

        /// <summary>
        /// Processes the delete online platform package price information.
        /// </summary>
        /// <param name="OnlinePlatformPriceId">The online platform price identifier.</param>
        /// <returns></returns>
        string ProcessDeleteOnlinePlatformPackagePriceInfo(int OnlinePlatformPriceId);




        /// <summary>
        /// Processes the edit online extra service price information.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        IOnlineExtraServicePriceView ProcessEditOnlineExtraServicePriceInfo(IOnlineExtraServicePriceView onlineExtraServicePriceView);



        /// <summary>
        /// Processes the delete online extra service price information.
        /// </summary>
        /// <param name="OnlineExtraServicePriceId">The online extra service price identifier.</param>
        /// <returns></returns>
        string ProcessDeleteOnlineExtraServicePriceInfo( int OnlineExtraServicePriceId);

        /// <summary>
        /// Gets the online extra price view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineView GetOnlineExtraPriceView(int Id);

        /// <summary>
        /// Gets the artwork price view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineView GetArtworkPriceView(int Id);

        /// <summary>
        /// Gets the duration list.
        /// </summary>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineDurationList GetDurationList(string selectedDescription, string message);
        /// <summary>
        /// Gets the online duration view.
        /// </summary>
        /// <returns></returns>
        IOnlineDurationView GetOnlineDurationView();
        /// <summary>
        /// Gets the online duration view.
        /// </summary>
        /// <param name="onlineDuration">Duration of the online.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IOnlineDurationView GetOnlineDurationView(IOnlineDurationView onlineDuration, string processingMessage);
        /// <summary>
        /// Processes the duration of the online.
        /// </summary>
        /// <param name="onlineDuration">Duration of the online.</param>
        /// <returns></returns>
        string ProcessOnlineDuration(IOnlineDurationView onlineDuration);

        /// <summary>
        /// Gets the online duration package price.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="durationId">The duration identifier.</param>
        /// <returns></returns>
        IOnlinePlatformPrice GetOnlineDurationPackagePrice(int packageId, int durationId);


        /// <summary>
        /// Gets the edit online cart view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IOnlineTransactionUIView GetEditOnlineCartView(int transactionId);
         


        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        string DeleteOrder(int transactionId);
     
        
        /// <summary>
        /// Gets the delete artwork price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineArtworkPriceView GetOnlineArtworkPriceById(int Id);    
        /// <summary>
        /// Gets the artwork price view model.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="SelectedArtworkPriceId">The selected artwork price identifier.</param>
        /// <param name="SelectedServiceTypeCode">The selected service type code.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <returns></returns>
        IOnlineArtworkPriceListView GetArtworkPriceViewModel(string message, int SelectedArtworkPriceId, string SelectedServiceTypeCode, string SelectedDescription);
        /// <summary>
        /// Gets the updated artwork view.
        /// </summary>
        /// <param name="onlineartworkPriceView">The onlineartwork price view.</param>
        /// <returns></returns>
        IOnlineArtworkPriceView GetUpdatedOnlineArtworkView(IOnlineArtworkPriceView onlineartworkPriceView);
        /// <summary>
        /// Processes the edit art work price information.
        /// </summary>
        /// <param name="onlineArtworkInfo">The online artwork information.</param>
        /// <returns></returns>
        string ProcessEditArtWorkPriceInfo(IOnlineArtworkPriceView onlineArtworkInfo);
        /// <summary>
        /// Processes the delete online artwork price information.
        /// </summary>
        /// <param name="onlineArtWorkPriceId">The online art work price identifier.</param>
        /// <returns></returns>
        string ProcessDeleteOnlineArtworkPriceInfo(int onlineArtWorkPriceId);
        /// <summary>
        /// Gets the online art work price view.
        /// </summary>
        /// <param name="onlineArtworkPriceView">The online artwork price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IOnlineArtworkPriceView GetOnlineArtWorkPriceView(IOnlineArtworkPriceView onlineArtworkPriceView,string message);
        /// <summary>
        /// Processes the online art work price information.
        /// </summary>
        /// <param name="onlineArtWorkInfo">The online art work information.</param>
        /// <returns></returns>
        string ProcessOnlineArtWorkPriceInfo(IOnlineArtworkPriceView onlineArtWorkInfo);

        /// <summary>
        /// Gets the online art work price view.
        /// </summary>
        /// <returns></returns>
        IOnlineArtworkPriceView GetOnlineArtWorkPriceView();
    }
}
