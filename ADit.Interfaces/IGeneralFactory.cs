using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGeneralFactory
    {

        /// <summary>
        /// Gets the contact view.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        /// <returns></returns>
        IContactView GetContactView(IList<IContact> contacts);
        /// <summary>
        /// Gets the edit time belt view.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITimeBeltView GetEditTimeBeltView(ITimeBelt timeBeltView, string message);
        /// <summary>
        /// Creates the time belt view.
        /// </summary>
        /// <param name="timeBelt">The time belt.</param>
        /// <returns></returns>
        ITimeBeltView CreateTimeBeltView(ITimeBelt timeBelt);
        /// <summary>
        /// Creates the time belt view.
        /// </summary>
        /// <returns></returns>
        ITimeBeltView CreateTimeBeltView();
        /// <summary>
        /// Creates the updated design element price view.
        /// </summary>
        /// <param name="designElementPrice">The design element price.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        IDesignElementPriceView CreateUpdatedDesignElementPriceView(IDesignElementPriceView designElementPrice, IList<IDesignElement> designElement, IList<IServiceType> serviceType);

        /// <summary>
        /// Creates the delete design element price view.
        /// </summary>
        /// <param name="designElementPrice">The design element price.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        IDesignElementPriceView CreateDeleteDesignElementPriceView(IDesignElementPrice designElementPrice, IList<IDesignElement> designElement, IList<IServiceType> serviceType);
        /// <summary>
        /// Creates the apcon approval type price view model.
        /// </summary>
        /// <param name="ApconPrice">The apcon price.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedApconApprovalTypePriceId">The selected apcon approval type price identifier.</param>
        /// <param name="selectedApconApprovalId">The selected apcon approval identifier.</param>
        /// <returns></returns>
        IApconApprovalTypePriceListView CreateApconApprovalTypePriceViewModel(IList<IApconApprovalTypePrice> ApconPrice, string message,
            int selectedApconApprovalTypePriceId, int selectedApconApprovalId);
        /// <summary>
        /// Creates the apcon approval type price view.
        /// </summary>
        /// <param name="ApconType">Type of the apcon.</param>
        /// <returns></returns>
        IApconApprovalTypePriceView CreateApconApprovalTypePriceView(IList<IApconApprovalType> ApconType);
        /// <summary>
        /// Creates the apcon approval type price view.
        /// </summary>
        /// <param name="ApconType">Type of the apcon.</param>
        /// <param name="priceView">The price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IApconApprovalTypePriceView CreateApconApprovalTypePriceView(IList<IApconApprovalType> ApconType,
             IApconApprovalTypePriceView priceView, string message);
        /// <summary>
        /// Edits the apcon approval type price view.
        /// </summary>
        /// <param name="apconType">Type of the apcon.</param>
        /// <param name="apconPrice">The apcon price.</param>
        /// <returns></returns>
        IApconApprovalTypePriceView EditApconApprovalTypePriceView(IList<IApconApprovalType> apconType, IApconApprovalTypePrice apconPrice);
        /// <summary>
        /// Creates the delete apcon approval type price view.
        /// </summary>
        /// <param name="apconPrice">The apcon price.</param>
        /// <returns></returns>
        IApconApprovalTypePriceView CreateDeleteApconApprovalTypePriceView(IApconApprovalTypePrice apconPrice);
        /// <summary>
        /// Creates the design element ListView.
        /// </summary>
        /// <param name="SelectedDesignElementId">The selected design element identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="designElementlCollection">The design elementl collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        //IDesignElementListView CreateDesignElementListView(IList<IDesignElement> designElementlCollection, string message);
        IDesignElementListView CreateDesignElementListView(int SelectedDesignElementId, string SelectedDescription, IList<IDesignElement> designElementlCollection, string message);
        /// <summary>
        /// Creates the color ListView.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="colorCollection">The color collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IColorListView CreateColorListView(int Id, string selectedDescription,IList<IColor> colorCollection, string message);

        /// <summary>
        /// Creates the timing list vew.
        /// </summary>
        /// <param name="SelectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="timingCollection">The timing collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITimingListView CreateTimingListVew(int SelectedTimingId, string selectedDescription,IList<ITiming> timingCollection, string message);

        /// <summary>
        /// Creates the material type ListView.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="materialTypeCollection">The material type collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialTypeListView CreateMaterialTypeListView(int materialTypeId, string selectedDescription,IList<IMaterialType> materialTypeCollection, string message);
        /// <summary>
        /// Apcons the approval type ListView.
        /// </summary>
        /// <param name="apconApprovalTypeCollection">The apcon approval type collection.</param>
        /// <param name="message">The message.</param>
        /// <param name="SelectedApconApprovalTypeId">The selected apcon approval type identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <returns></returns>
        IApconApprovalTypeListView apconApprovalTypeListView(IList<IApconApprovalType> apconApprovalTypeCollection, string message, int SelectedApconApprovalTypeId, string SelectedDescription);
        /// <summary>
        /// Durations the type ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="durationTypeCollection">The duration type collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDurationTypeListView durationTypeListView( string selectedId, string selectedDescription,IList<IDurationType> durationTypeCollection, string message);

        /// <summary>
        /// Creates the design element view.
        /// </summary>
        /// <returns></returns>
        IDesignElementView CreateDesignElementView();
        /// <summary>
        /// Creates the design element view.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDesignElementView CreateDesignElementView(IDesignElementView designElementInfo, string processingMessage);

        /// <summary>
        /// Creates the edit design element view.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IDesignElementView CreateEditDesignElementView(IDesignElementView designElementView, string description);
        /// <summary>
        /// Creates the add news paper view.
        /// </summary>
        /// <returns></returns>
        INewsPaperView CreateAddNewsPaperView();

        /// <summary>
        /// Creates the color view.
        /// </summary>
        /// <returns></returns>
        IColorView CreateColorView();




        /// <summary>
        /// Creates the duration type view.
        /// </summary>
        /// <returns></returns>
        IDurationTypeView CreateDurationTypeView();

        /// <summary>
        /// Creates the material type view.
        /// </summary>
        /// <returns></returns>
        IMaterialTypeView CreateMaterialTypeView();

        /// <summary>
        /// Creates the timing view.
        /// </summary>
        /// <returns></returns>
        ITimingView CreateTimingView();

        /// <summary>
        /// Creates the color view.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        IColorView CreateColorView(IColor colorView);

        /// <summary>
        /// Gets the edit timing view.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        ITimingView GetEditTimingView(ITiming timingView);

        /// <summary>
        /// Gets the edit material type view.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        IMaterialTypeView GetEditMaterialTypeView(IMaterialType materialTypeView);

        /// <summary>
        /// Creates the duration type view.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        IDurationTypeView CreateDurationTypeView(IDurationType durationTypeView);



        /// <summary>
        /// Creates the apcon view.
        /// </summary>
        /// <returns></returns>
        IApconApprovalView CreateApconView();


        /// <summary>
        /// Creates the apcon view.
        /// </summary>
        /// <param name="apconview">The apconview.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IApconApprovalView CreateApconView(IApconApprovalView apconview, string processingMessage);

        /// <summary>
        /// Gets the edit apcon view.
        /// </summary>
        /// <param name="apconview">The apconview.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IApconApprovalView GetEditApconView(IApconApprovalType apconview, string message);

        /// <summary>
        /// Creates the design element price view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="DesignElement">The design element.</param>
        /// <returns></returns>
        IDesignElementPriceView CreateDesignElementPriceView(IList<IServiceType> ServiceType, IList<IDesignElement> DesignElement);
        /// <summary>
        /// Creates the design element price view.
        /// </summary>
        /// <param name="designelementInfo">The designelement information.</param>
        /// <param name="ProcessingMessages">The processing messages.</param>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="DesignElement">The design element.</param>
        /// <returns></returns>
        IDesignElementPriceView CreateDesignElementPriceView(IDesignElementPriceView designelementInfo, string ProcessingMessages,
           IList<IServiceType> ServiceType, IList<IDesignElement> DesignElement);
        /// <summary>
        /// Edits the design element price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="designElementPrice">The design element price.</param>
        /// <returns></returns>
        IDesignElementPriceView EditDesignElementPriceView(IList<IServiceType> serviceType, IList<IDesignElement> designElement, IDesignElementPrice designElementPrice);

        /// <summary>
        /// Creates the design element price ListView.
        /// </summary>
        /// <param name="designelement">The designelement.</param>
        /// <param name="message">The message.</param>
        /// <param name="SelectedDesignElementPriceId">The selected design element price identifier.</param>
        /// <param name="SelectedServiceTypeCode">The selected service type code.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <returns></returns>
        IDesignElementPriceListView CreateDesignElementPriceListView(IList<IDesignElementPrice> designelement, string message, int SelectedDesignElementPriceId, string SelectedServiceTypeCode, string SelectedDescription);

        /// <summary>
        /// Creates the delete design element price view.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <returns></returns>
        IDesignElementPriceView CreateDeleteDesignElementPriceView(IDesignElementPrice designElementPriceView);


        /// <summary>
        /// Creates the material type timing list vew.
        /// </summary>
        /// <param name="timingCollection">The timing collection.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedMaterialTypeTimingId">The selected material type timing identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        IMaterialTypeTimingListView CreateMaterialTypeTimingListVew(IList<IMaterialTypeTimingDetail> timingCollection, string message,
            int selectedMaterialTypeTimingId, int selectedTimingId, string selectedDescription);
        /// <summary>
        /// Creates the production ListView.
        /// </summary>
        /// <param name="material">The material.</param>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        IMaterialProductionPriceView CreateProductionListView(IList<IMaterialType> material, IList<IServiceType> service);
        /// <summary>
        /// Creates the scripting ListView.
        /// </summary>
        /// <param name="material">The material.</param>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        IMaterialScriptingPriceView CreateScriptingListView(IList<IMaterialType> material, IList<IServiceType> service);
        /// <summary>
        /// Creates the delete material production price view.
        /// </summary>
        /// <param name="productionPrice">The production price.</param>
        /// <returns></returns>
        IMaterialProductionPriceView CreateDeleteMaterialProductionPriceView(IMaterialProductionPrice productionPrice);
        /// <summary>
        /// Creates the delete material scripting price view.
        /// </summary>
        /// <param name="scriptingPrice">The scripting price.</param>
        /// <returns></returns>
        IMaterialScriptingPriceView CreateDeleteMaterialScriptingPriceView(IMaterialScriptingPrice scriptingPrice);
        /// <summary>
        /// Creates the material type timing view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="TimingType">Type of the timing.</param>
        /// <returns></returns>
        IMaterialTypeTimingView CreateMaterialTypeTimingView(IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType, IList<ITiming> TimingType);


        /// <summary>
        /// Creates the updated material type timing view.
        /// </summary>
        /// <param name="timingInfo">The timing information.</param>
        /// <param name="ProcessingMessages">The processing messages.</param>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="TimingType">Type of the timing.</param>
        /// <returns></returns>
        IMaterialTypeTimingView CreateUpdatedMaterialTypeTimingView(IMaterialTypeTimingView timingInfo, string ProcessingMessages,
            IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType, IList<ITiming> TimingType);

        /// <summary>
        /// Edits the material type timing view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="MaterialTypeTiming">The material type timing.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialTypeTimingView EditMaterialTypeTimingView(IList<IServiceType> serviceType, IList<IMaterialType> MaterialType, IMaterialTypeTimingModel MaterialTypeTiming, IList<ITiming> Timing, string message);
        /// <summary>
        /// Creates the material type timing view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="TimingType">Type of the timing.</param>
        /// <param name="materialView">The material view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialTypeTimingView CreateMaterialTypeTimingView(IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType, IList<ITiming> TimingType, IMaterialTypeTimingView materialView, string message);
        /// <summary>
        /// Creates the edit material type timing view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="Timing">The timing.</param>
        /// <returns></returns>
        IMaterialTypeTimingView CreateEditMaterialTypeTimingView(IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType, IList<ITiming> Timing);
        /// <summary>
        /// Creates the delete material type timing view.
        /// </summary>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        IMaterialTypeTimingView CreateDeleteMaterialTypeTimingView(IMaterialTypeTimingModel MaterialType);
        /// <summary>
        /// Creates the color view.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IColorView CreateColorView(IColorView colorView, string processingMessage);

        /// <summary>
        /// Creates the timing view.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITimingView CreateTimingView(ITimingView timingView, string processingMessage);
        /// <summary>
        /// Creates the duration type view.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDurationTypeView CreateDurationTypeView(IDurationTypeView durationTypeView, string processingMessage);
        /// <summary>
        /// Creates the material type view.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IMaterialTypeView CreateMaterialTypeView(IMaterialTypeView materialTypeView, string processingMessage);
        /// <summary>
        /// Gets the material scripting.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        IRadioMainView GetMaterialScripting(IMaterialScriptingPrice price);
        /// <summary>
        /// Creates the radio service price view model.
        /// </summary>
        /// <param name="RadioService">The radio service.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedRadioServiceId">The selected radio service identifier.</param>
        /// <param name="selectedRadioId">The selected radio identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedMaterialTypeId">The selected material type identifier.</param>
        /// <returns></returns>
        IRadioServicePriceListView CreateRadioServicePriceViewModel(IList<IRadioServicePriceListModel> RadioService, string message,
         int selectedRadioServiceId, int selectedRadioId, int selectedTimingId,
         int selectedMaterialTypeId);
        /// <summary>
        /// Creates the radio service price view.
        /// </summary>
        /// <param name="RadioStation">The radio station.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        IRadioServicePriceList CreateRadioServicePriceView(IList<IRadioStationModel> RadioStation, IList<ITiming> Timing,
           IList<IMaterialType> MaterialType,IList<ITimeBelt>timeBelts);

        /// <summary>
        /// Creates the radio service price view.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <param name="RadioStation">The radio station.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IRadioServicePriceList CreateRadioServicePriceView(IRadioServicePriceList radio, IList<IRadioStationModel> RadioStation, IList<ITiming> Timing,
           IList<IMaterialType> MaterialType, string message);

        /// <summary>
        /// Edits the radio service price view.
        /// </summary>
        /// <param name="radioservice">The radioservice.</param>
        /// <param name="RadioStation">The radio station.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        IRadioServicePriceList EditRadioServicePriceView(IRadioServicePriceListModel radioservice, IList<IRadioStationModel> RadioStation,
            IList<ITiming> Timing, IList<IMaterialType> MaterialType,IList<ITimeBelt>timeBelts);
        /// <summary>
        /// Creates the delete radio service price view.
        /// </summary>
        /// <param name="radioservice">The radioservice.</param>
        /// <returns></returns>
        IRadioServicePriceList CreateDeleteRadioServicePriceView(IRadioServicePriceListModel radioservice);

        /// <summary>
        /// Creates the tv transaction view model.
        /// </summary>
        /// <param name="TvTransaction">The tv transaction.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedTvTransactionId">The selected tv transaction identifier.</param>
        /// <param name="selectedUserId">The selected user identifier.</param>
        /// <returns></returns>
        ITvTransactionListView CreateTvTransactionViewModel(IList<ITvTransaction> TvTransaction, string message,
        int selectedTvTransactionId, int selectedUserId,IList<IMessage>messages,IList<IReplies>replies);
        /// <summary>
        /// Gets the tv material transaction ListView.
        /// </summary>
        /// <param name="tvMaterialTransaction">The tv material transaction.</param>
        /// <param name="tvTransaction">The tv transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        ITvTransactionView GetTvMaterialTransactionListView(IList<ITvMaterialTransactionModel> tvMaterialTransaction, ITvTransaction tvTransaction,
                  IDigitalFile digitalFile, int? Id, int RepliesId);
        /// <summary>
        /// Gets the tv scripting view.
        /// </summary>
        /// <param name="tvScriptingTransaction">The tv scripting transaction.</param>
        /// <param name="tvTransaction">The tv transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        ITvTransactionView GetTvScriptingView(IList<ITvScriptingTransactionModelView> tvScriptingTransaction, ITvTransaction tvTransaction,
             IDigitalFile digitalFile, int? Id, int RepliesId);

        /// <summary>
        /// Creates the print transaction view model.
        /// </summary>
        /// <param name="PrintTransaction">The print transaction.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedPrintTransactionId">The selected print transaction identifier.</param>
        /// <param name="selectedUserId">The selected user identifier.</param>
        /// <returns></returns>
        IPrintTransactionListView CreatePrintTransactionViewModel(IList<IPrintTransaction> PrintTransaction, string message,
        int selectedPrintTransactionId, int selectedUserId,IList<IMessage>messagesList,IList<IReplies>replies);
        /// <summary>
        /// Gets the print scripting view.
        /// </summary>
        /// <param name="printScriptingTransaction">The print scripting transaction.</param>
        /// <param name="printTransaction">The print transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        IPrintTransactionView GetPrintScriptingView(IList<IPrintScriptingTransactionModel> printScriptingTransaction, IPrintTransaction printTransaction,
             IDigitalFile digitalFile, int? Id, int RepliesId);


        /// <summary>
        /// Gets the tv message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetTvMessageRepliesListView(IList<IReplies> replies,
            IMessage message);

        /// <summary>
        /// Gets the print message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetPrintMessageRepliesListView(IList<IReplies> replies,
            IMessage message,int transactionId,int SentToId,int OrderId);

        /// <summary>
        /// Gets the time belt ListView.
        /// </summary>
        /// <param name="timeBelts">The time belts.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        ITimeBeltListView GetTimeBeltListView(IList<ITimeBelt> timeBelts, string selectedDescription);
    }

}
