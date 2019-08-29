using System.Collections.Generic;

namespace ADit.Interfaces
{


    /// <summary>
    /// 
    /// </summary>
    public interface IOnlineRepository
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="onlineDurationId"></param>
     /// <returns></returns>
        string DeleteOnlineDurationInfo(int onlineDurationId);
        /// <summary>
        /// Edits the duration of the online.
        /// </summary>
        /// <param name="onlineDurationView">The online duration view.</param>
        /// <returns></returns>
        string EditOnlineDuration(IOnlineDurationView onlineDurationView);
        /// <summary>
        /// Saves the online transaction airing.
        /// </summary>
        /// <param name="onlineTransactionId">The online transaction identifier.</param>
        /// <param name="transactionAiringList">The transaction airing list.</param>
        /// <returns></returns>
        string SaveOnlineTransactionAiring(int onlineTransactionId, IList<IOnlineTransactionAiringUI> transactionAiringList);

        /// <summary>
        /// Gets the art work price.
        /// </summary>
        /// <returns></returns>
        IList<IOnlineArtworkPrice> GetArtWorkPrice();

        /// <summary>
        /// Gets the online attachment transaction by identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IOnlineTransactionAttachment GetOnlineAttachmentTransactionById(int UserId, int transactionId);

        /// <summary>
        /// Gets the online transaction.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IOnlineTransaction GetOnlineTransaction(int transactionId);
        /// <summary>
        /// Gets the online artwork transactons.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<IOnlineArtworkTransacton> GetOnlineArtworkTransactons(int UserId, int transactionId);
        /// <summary>
        /// Gets all online transaction.
        /// </summary>
        /// <returns></returns>
        IList<IOnlineTransaction> GetAllOnlineTransaction();

        /// <summary>
        /// Saves the online transaction information.
        /// </summary>
        /// <param name="onlineOrder">The online order.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string SaveOnlineTransactionInfo(IOnlineTransactionUIView onlineOrder, out int transactionId);

        /// <summary>
        /// Saves the online artwork price.
        /// </summary>
        /// <param name="onlineartWorkPriceView">The onlineart work price view.</param>
        /// <returns></returns>
        string SaveOnlineArtworkPrice(IOnlineArtworkPriceView onlineArtWork);  


        /// <summary>
        /// Saves the online transaction attachment.
        /// </summary>
        /// <param name="onlineView">The online view.</param>
        /// <param name="onlineTransactionId">The online transaction identifier.</param>
        /// <returns></returns>
        string SaveOnlineTransactionAttachment(IOnlineView onlineView, int onlineTransactionId);


        /// <summary>
        /// Saves the online transaction extra service.
        /// </summary>
        /// <param name="onlineView">The online view.</param>
        /// <param name="onlineTransactionId">The online transaction identifier.</param>
        /// <returns></returns>
        string saveOnlineTransactionExtraService(IOnlineTransactionUIView onlineView, int onlineTransactionId);


        /// <summary> 
        /// Saves the online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        string SaveOnlineExtraServiceInfo(IOnlineExtraServiceView onlineExtraServiceView);



        /// <summary>
        /// Saves the online platform information.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        string SaveOnlinePlatformInfo(IOnlinePlatformView onlinePlatformView);



        /// <summary>
        /// Saves the online purpose information.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        string SaveOnlinePurposeInfo(IOnlinePurposeView onlinePurposeView);


        /// <summary>
        /// Edits the online extra service.
        /// </summary>
        /// <param name="extraServiceView">The extra service view.</param>
        /// <returns></returns>
        string EditOnlineExtraService(IOnlineExtraServiceView extraServiceView);



        /// <summary>
        /// Edits the online extra service price.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        string EditOnlineExtraServicePrice(IOnlineExtraServicePriceView onlineExtraServicePriceView);



        /// <summary>
        /// Edits the online purpose.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        string EditOnlinePurpose(IOnlinePurposeView onlinePurposeView);



        /// <summary>
        /// Edits the online platform.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        string EditOnlinePlatform(IOnlinePlatformView onlinePlatformView);


        /// <summary>
        /// Deletes the online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceId">The online extra service identifier.</param>
        /// <returns></returns>
        string DeleteOnlineExtraServiceInfo(int onlineExtraServiceId);

        /// <summary>
        /// Deletes the online purpose information.
        /// </summary>
        /// <param name="onlinePurposeId">The online purpose identifier.</param>
        /// <returns></returns>
        string DeleteOnlinePurposeInfo(int onlinePurposeId);


        /// <summary>
        /// Deletes the online platform information.
        /// </summary>
        /// <param name="OnlinePlatformId">The online platform identifier.</param>
        /// <returns></returns>
        string DeleteOnlinePlatformInfo(int OnlinePlatformId);



        /// <summary>
        /// Saves the online extra service price.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        string SaveOnlineExtraServicePrice(IOnlineExtraServicePriceView onlineExtraServicePriceView);
        /// <summary>
        /// Saves the platfrom package price.
        /// </summary>
        /// <param name="priceview">The priceview.</param>
        /// <returns></returns>
        string SavePlatfromPackagePrice(IOnlinePlatformPackagePriceView priceview);

        /// <summary>
        /// Edits the online platform price.
        /// </summary>
        /// <param name="onlinePlatformPackagePrice">The online platform package price.</param>
        /// <returns></returns>
        string EditOnlinePlatformPrice(IOnlinePlatformPackagePriceView onlinePlatformPackagePrice);


        /// <summary>
        /// Deletes the online platform price.
        /// </summary>
        /// <param name="onlinePlatformPackagePrice">The online platform package price.</param>
        /// <returns></returns>
        string DeleteOnlinePlatformPrice(int onlinePlatformPackagePrice);

        /// <summary>
        /// Deletes the online extra service price.
        /// </summary>
        /// <param name="OnlineExtraServicePriceId">The online extra service price identifier.</param>
        /// <returns></returns>
        string DeleteOnlineExtraServicePrice(int OnlineExtraServicePriceId);


        /// <summary>
        /// Gets the name of the online platform by.
        /// </summary>
        /// <param name="onlineName">Name of the online.</param>
        /// <returns></returns>
        IOnlinePlatform GetOnlinePlatformByName(string onlineName);

        /// <summary>
        /// Gets the name of the online purpose.
        /// </summary>
        /// <param name="purposeName">Name of the purpose.</param>
        /// <returns></returns>
        IOnlinePurpose GetOnlinePurposeName(string purposeName);

        /// <summary>
        /// Gets the online duration by description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IOnlineDuration GetOnlineDurationByDescription(string description);

        /// <summary>
        /// Saves the online duration information.
        /// </summary>
        /// <param name="onlineDurationInfo">The online duration information.</param>
        /// <returns></returns>
        string SaveOnlineDurationInfo(IOnlineDurationView onlineDurationInfo);

        /// <summary>
        /// Gets the platform package price.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="durationId">The duration identifier.</param>
        /// <returns></returns>
        IOnlinePlatformPrice GetPlatformPackagePrice(int packageId, int durationId);

        /// <summary>
        /// Gets the active online transaction.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IList<IOnlineTransaction> getActiveOnlineTransaction(int Id);
        /// <summary>
        /// Saves the online transation airing.
        /// </summary>
        /// <param name="onlineOrder">The online order.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string SaveOnlineTransationAiring(IOnlineView onlineOrder, int transactionId);
        /// <summary>
        /// Gets the online transaction airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<IOnlineTransactionAiringUI> GetOnlineTransactionAiring(int transactionId);
        /// <summary>
        /// Gets the user online order by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IOnlineTransaction GetUserOnlineOrderById(int transactionId);

        /// <summary>
        /// Gets the online extra service transaction by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IOnlineTransactionExtraService GetOnlineExtraServiceTransactionById(int transactionId);
        /// <summary>
        /// Updates the online transation airing.
        /// </summary>
        /// <param name="onlineOrder">The online order.</param>
        /// <returns></returns>
        string UpdateOnlineTransationAiring(IOnlineView onlineOrder);
        /// <summary>
        /// Updates the online transaction information.
        /// </summary>
        /// <param name="onlineOrder">The online order.</param>
        /// <returns></returns>
        string UpdateOnlineTransactionInfo(IOnlineTransactionUI onlineOrder);
        //string saveUploadedArtwork(IOnlineArtworkTransactionListView onlineArtworkTransactionListView);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        IOnlineTransactionUI GetOnlineMainTransaction(int transactionId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onlineTransactionId"></param>
        /// <returns></returns>
        string DeleteOnlineTransactionAiring(int onlineTransactionId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        string DeleteOnlineOrder(int transactionId);
        /// <summary>
        /// Deletes the art work price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string DeleteOnlineArtWorkPrice(int Id); 
   
     
        /// <summary>
        /// Gets the art work price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineArtworkPrice GetOnlineArtWorkPriceById(int Id); 
        /// <summary>
        /// Gets the art work price amount by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineArtworkPrice GetArtWorkPriceAmountById(int Id);
      
        /// <summary>
        /// Gets the print art work price list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlineArtworkPrice> GetPrintArtWorkPriceList();
        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        /// <returns></returns>
        IList<IServiceType> GetServiceType();
        /// <summary>
        /// Edits the online art work type price.
        /// </summary>
        /// <param name="onlineArtWorkPriceView">The online art work price view.</param>
        /// <returns></returns>
        string EditOnlineArtWorkTypePrice(IOnlineArtworkPriceView onlineArtWorkPriceView);
    }

}
