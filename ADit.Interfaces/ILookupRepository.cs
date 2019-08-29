using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILookupRepository
    {
        /// <summary>
        /// Gets the online duration by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineDuration GetOnlineDurationById(int Id);
        
           

        /// <summary>
        /// Gets the print media type list.
        /// </summary>
        /// <returns></returns>
        IList<IPrintMediaType> GetPrintMediaTypeList();

        /// <summary>
        /// Gets the print media type description by identifier.
        /// </summary>
        /// <param name="printMediaTypeId">The print media type identifier.</param>
        /// <returns></returns>
        string GetPrintMediaTypeDescriptionById(int printMediaTypeId);

        /// <summary>
        /// Gets the order number by order identifier.
        /// </summary>
        /// <param name="OrderId">The order identifier.</param>
        /// <returns></returns>
        IOrder GetOrderNumberByOrderId(int OrderId);
        /// <summary>
        /// Gets the contact by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IContact GetContactById(int Id);
        /// <summary>
        /// Gets the contact list.
        /// </summary>
        /// <returns></returns>
        IList<IContact> GetContactList();
        
        /// <summary>
        /// Gets the user details for email.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="Details">The details.</param>
        /// <returns></returns>
        ISendMailScript GetUserDetails(int SentToId);
        /// <summary>
        /// Gets the time belt by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        ITimeBelt GetTimeBeltById(int Id);
        /// <summary>
        /// Gets the time belt description by value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        ITimeBelt GetTimeBeltDescriptionByValue(string name);
        /// <summary>
        /// Gets the tv timing.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialTypeTimingModel> GetTVTiming();

        /// <summary>
        /// Gets the apcon approval type list.
        /// </summary>
        /// <returns></returns>
        IList<IApconApprovalType> GetApconApprovalTypeList();


        /// <summary>
        /// Gets the apcon approval by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IApconApprovalType GetApconApprovalById(int Id);


        /// <summary>
        /// Gets the apcon approval type price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IApconApprovalTypePrice GetApconApprovalTypePriceById(int Id);

        /// <summary>
        /// Gets the timing collection.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IList<ITiming> GetTimingCollection(int Id);


        /// <summary>
        /// Gets the apcon approval type price.
        /// </summary>
        /// <returns></returns>
        IList<IApconApprovalTypePrice> GetApconApprovalTypePrice();


        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        /// <returns></returns>
        IList<IServiceType> GetServiceType();

        /// <summary>
        /// Gets the type of the material.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialType> GetMaterialType();
        /// <summary>
        /// Gets the material type for radio.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialType> GetMaterialTypeForRadio();
        /// <summary>
        /// Gets the material type for tv.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialType> GetMaterialTypeForTv();


        /// <summary>
        /// Gets the material production price list.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialProductionPrice> GetMaterialProductionPriceList();

        /// <summary>
        /// Gets the material scripting price list.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialScriptingPrice> GetMaterialScriptingPriceList();


        /// <summary>
        /// Gets the duration list.
        /// </summary>
        /// <returns></returns>
        IList<IDurationType> GetDurationList();

        /// <summary>
        /// Gets the timing.
        /// </summary>
        /// <returns></returns>
        IList<ITiming> GetTiming();


        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <returns></returns>
        IList<IColor> GetColor();
        /// <summary>
        /// Deletes the design element price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string DeleteDesignElementPrice(int Id);

        /// <summary>
        /// Gets the design element.
        /// </summary>
        /// <returns></returns>
        IList<IDesignElement> GetDesignElement();


        /// <summary>
        /// Gets the design element price.
        /// </summary>
        /// <returns></returns>
        IList<IDesignElementPrice> GetDesignElementPrice();


        /// <summary>
        /// Gets the timing by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        ITiming GetTimingById(int Id);

        /// <summary>
        /// Gets the material type by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialType GetMaterialTypeById(int Id);

        /// <summary>
        /// Gets the design element price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IDesignElementPrice GetDesignElementPriceById(int Id);

        /// <summary>
        /// Gets the color by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IColor GetColorById(int Id);

        /// <summary>
        /// Gets the design element description by identifier.
        /// </summary>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        string GetDesignElementDescriptionByID(int designElementId);
        /// <summary>
        /// Gets the duration type by identifier.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IDurationType GetDurationTypeById(string code);

        /// <summary>
        /// Gets the material scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialScriptingPrice GetMaterialScriptingPriceById(int Id);

        /// <summary>
        /// Gets the material production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialProductionPrice GetMaterialProductionPriceById(int Id);

        /// <summary>
        /// Gets the material type timing collection.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IList<IMaterialTypeTimingModel> GetMaterialTypeTimingCollection(int Id);
        /// <summary>
        /// Gets the material type timing list.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialTypeTimingDetail> GetMaterialTypeTimingList();
        /// <summary>
        /// Gets the edit material type timing by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialTypeTimingModel GetEditMaterialTypeTimingById(int Id);


        /// <summary>
        /// Gets the branding material price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IBrandingMaterialPrice GetBrandingMaterialPriceById(int Id);
        /// <summary>
        /// Gets the branding material by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IBrandingMaterial GetBrandingMaterialById(int Id);
        /// <summary>
        /// Gets the material list.
        /// </summary>
        /// <returns></returns>
        IList<IBrandingMaterial> GetMaterialList();
        /// <summary>
        /// Gets the branding material price list.
        /// </summary>
        /// <returns></returns>
        IList<IBrandingMaterialPrice> GetBrandingMaterialPriceList();
        /// <summary>
        /// Gets the online extra service list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlineExtraService> GetOnlineExtraServiceList();
        /// <summary>
        /// Gets the online extra service by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineExtraService GetOnlineExtraServiceById(int Id);
        /// <summary>
        /// Gets the online platform list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlinePlatform> GetOnlinePlatformList();
        /// <summary>
        /// Gets the online platform by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlinePlatform GetOnlinePlatformById(int Id);
        /// <summary>
        /// Gets the online purposes list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlinePurpose> GetOnlinePurposesList();
        /// <summary>
        /// Gets the online purpose by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlinePurpose GetOnlinePurposeById(int Id);
        /// <summary>
        /// Gets the online platform price list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlinePlatformPrice> GetOnlinePlatformPriceList();
        /// <summary>
        /// Gets the online platform price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlinePlatformPrice GetOnlinePlatformPriceById(int Id);
        /// <summary>
        /// Gets the oline platform price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlinePlatformPrice GetOlinePlatformPriceById(int Id);
        /// <summary>
        /// Gets the online extra service price list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlineExtraServicePrice> GetOnlineExtraServicePriceList();
        /// <summary>
        /// Gets the online extra service price by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IOnlineExtraServicePrice GetOnlineExtraServicePriceById(int id);
        /// <summary>
        /// Gets the script material question list.
        /// </summary>
        /// <returns></returns>
        IList<IScriptMaterialQuestion> GetScriptMaterialQuestionList();
        /// <summary>
        /// Gets the radio station list.
        /// </summary>
        /// <returns></returns>
        IList<IRadioStationModel> GetRadioStationList();
        /// <summary>
        /// Gets the radio station by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IRadioStationModel GetRadioStationById(int Id);
        /// <summary>
        /// Gets the print categories list.
        /// </summary>
        /// <returns></returns>
        IList<IPrintCategory> GetPrintCategoriesList();
        /// <summary>
        /// Gets the service type list.
        /// </summary>
        /// <returns></returns>
        IList<IPrintServiceType> GetServiceTypeList();
        /// <summary>
        /// Gets the apcon approval price by type identifier.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns></returns>
        IApconApprovalTypePrice GetApconApprovalPriceByTypeId(int typeId);
        /// <summary>
        /// Gets the news paper list.
        /// </summary>
        /// <returns></returns>
        IList<INewsPaper> GetNewsPaperList();
        /// <summary>
        /// Gets the print service type list.
        /// </summary>
        /// <returns></returns>
        IList<IPrintServiceType> GetPrintServiceTypeList();
        /// <summary>
        /// Gets the print category list.
        /// </summary>
        /// <returns></returns>
        IList<IPrintCategory> GetPrintCategoryList();
        /// <summary>
        /// Gets the print service type price list.
        /// </summary>
        /// <returns></returns>
        IList<IPrintServiceTypePrice> GetPrintServiceTypePriceList();
        /// <summary>
        /// Gets the print service type description by identifier.
        /// </summary>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        string GetPrintServiceTypeDescriptionByID(int printServiceTypeId);
        /// <summary>
        /// Gets the news paper description by identifier.
        /// </summary>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        string GetNewsPaperDescriptionById(int newsPaperId);
        /// <summary>
        /// Gets the print category description by identifier.
        /// </summary>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        string GetPrintCategoryDescriptionByID(int printCategoryId);
        /// <summary>
        /// Gets the print service type price description by identifier.
        /// </summary>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        IPrintServiceTypePrice GetPrintServiceTypePriceDescriptionByID(int printServiceTypePriceId);
        /// <summary>
        /// Gets the tv station by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        ITvStation GetTvStationById(int Id);
        /// <summary>
        /// Gets the tv station list.
        /// </summary>
        /// <returns></returns>
        IList<ITvStation> GetTvStationList();
        //IList<ITiming> GetTiming();
        /// <summary>
        /// Gets the print media.
        /// </summary>
        /// <returns></returns>
        IList<IApconApprovalTypePrice> GetPrintMedia();
        /// <summary>
        /// Gets the apcon approval price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IApconApprovalTypePrice GetApconApprovalPriceById(int Id);
        /// <summary>
        /// Gets the design element price amount by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IDesignElementPrice GetDesignElementPriceAmountById(int Id);
        /// <summary>
        /// Gets the design element price list.
        /// </summary>
        /// <returns></returns>
        IList<IDesignElementPrice> GetDesignElementPriceList();


        /// <summary>
        /// Gets the scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialScriptingPrice GetScriptingPriceById(int Id);
        /// <summary>
        /// Gets the production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialProductionPrice GetProductionPriceById(int Id);

        /// <summary>
        /// Gets the radio scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialScriptingPrice GetRadioScriptingPriceById(int Id);
        /// <summary>
        /// Gets the radio production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialProductionPrice GetRadioProductionPriceById(int Id);

        /// <summary>
        /// Gets the tv scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialScriptingPrice GetTvScriptingPrice(int Id);

        /// <summary>
        /// Gets the tv production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialProductionPrice GetTvProductionPrice(int Id);


        /// <summary>
        /// Gets the online extra service amount by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IOnlineExtraServicePrice GetOnlineExtraServiceAmountById(int Id);
        /// <summary>
        /// Gets the branding material amount by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IBrandingMaterialPrice GetBrandingMaterialAmountById(int Id);
        /// <summary>
        /// Gets the material price list.
        /// </summary>
        /// <returns></returns>
        IList<IBrandingMaterialPrice> GetMaterialPriceList();

        /// <summary>
        /// Gets the online artwork price list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlineArtworkPrice> GetOnlineArtworkPriceList();
        /// <summary>
        /// Gets the online artwor amount by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IOnlineArtworkPrice GetOnlineArtworAmountById(int id);
        /// <summary>
        /// Gets the print transaction.
        /// </summary>
        /// <returns></returns>
        IList<IPrintTransaction> GetPrintTransaction();
        /// <summary>
        /// Gets the print transaction by identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactonId">The transacton identifier.</param>
        /// <returns></returns>
        IPrintTransaction GetPrintTransactionById(int UserId, int transactonId);


        /// <summary>
        /// Gets the radio timing.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialTypeTimingModel> GetRadioTiming();
        /// <summary>
        /// Gets the script transaction by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IList<IScriptingDetailModel> GetScriptTransactionById(int Id);
        /// <summary>
        /// Gets the apcon description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IApconApprovalType GetApconDescriptionByValue(string description);
        /// <summary>
        /// Gets the color description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IColor GetColorDescriptionByValue(string description);
        /// <summary>
        /// Gets the material type description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IMaterialType GetMaterialTypeDescriptionByValue(string description);
        /// <summary>
        /// Gets the design description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IDesignElement GetDesignDescriptionByValue(string description);
        /// <summary>
        /// Gets the timing description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        ITiming GetTimingDescriptionByValue(string description);
        /// <summary>
        /// Gets the duration type description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IDurationType GetDurationTypeDescriptionByValue(string description);

        /// <summary>
        /// Gets the active apcon approval type list.
        /// </summary>
        /// <returns></returns>
        IList<IApconApprovalType> GetActiveAPCONApprovalTypeList();


        /// <summary>
        /// Gets the active material type for tv.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialType> GetActiveMaterialTypeForTv();

        /// <summary>
        /// Gets the radio service price.
        /// </summary>
        /// <returns></returns>
        IList<IRadioServicePriceListModel> GetRadioServicePrice();

        /// <summary>
        /// Gets the radio service price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IRadioServicePriceListModel GetRadioServicePriceById(int Id);


        /// <summary>
        /// Gets the active material type for radio.
        /// </summary>
        /// <returns></returns>
        IList<IMaterialType> GetActiveMaterialTypeForRadio();

        /// <summary>
        /// Gets the print design element price list.
        /// </summary>
        /// <returns></returns>
        IList<IDesignElementPrice> GetPrintDesignElementPriceList();

        /// <summary>
        /// Gets the active online extra service list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlineExtraService> GetActiveOnlineExtraServiceList();
        /// <summary>
        /// Gets the online duration list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlineDuration> GetOnlineDurationList();

        /// <summary>
        /// Gets the tv transaction list.
        /// </summary>
        /// <returns></returns>
        IList<ITvTransaction> GetTvTransactionList();
        /// <summary>
        /// Gets the tv transaction by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        ITvTransaction GetTvTransactionById(int Id, int userId);
        /// <summary>
        /// Gets the tv script transaction.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<ITvScriptingTransactionModelView> GetTvScriptTransaction(int Id, int userId);
        /// <summary>
        /// Gets the tv material transaction.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<ITvMaterialTransactionModel> GetTvMaterialTransaction(int UserId, int transactionId);
        /// <summary>
        /// Gets the print transaction list.
        /// </summary>
        /// <returns></returns>
        IList<IPrintTransaction> GetPrintTransactionList();
       

        /// <summary>
        /// Gets the order type by identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        IOrder GetPendingOrderByUserId(int UserId);

        /// <summary>
        /// Gets the order numbe status.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="orderNumber">The order number.</param>
        /// <returns></returns>
        IOrder GetOrderNumbeStatus(int userId, int orderNumber);


        /// <summary>
        /// Gets the time belts.
        /// </summary>
        /// <returns></returns>
        IList<ITimeBelt> GetTimeBelts();


        /// <summary>
        /// Gets the print service color list.
        /// </summary>
        /// <returns></returns>
        IList<IPrintServiceColor> GetPrintServiceColorList();

        /// <summary>
        /// Gets the print servie color by identifier.
        /// </summary>
        /// <param name="printServiceColorId">The print service color identifier.</param>
        /// <returns></returns>
        IPrintServiceColor GetPrintServieColorById(int printServiceColorId);

        /// <summary>
        /// Gets the art work price list.
        /// </summary>
        /// <returns></returns>
        IList<IOnlineArtworkPrice> GetArtWorkPriceList();

        /// <summary>
        /// Gets the art work price by identifier.
        /// </summary>
        /// <param name="ArtWorkPriceId">The art work price identifier.</param>
        /// <returns></returns>
        IOnlineArtworkPrice GetArtWorkPriceById(int ArtWorkPriceId);
        /// <summary>
        /// Gets the print service color description by identifier.
        /// </summary>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        string GetPrintServiceColorDescriptionById(int printServiceTypeColorId);

     

    }



}