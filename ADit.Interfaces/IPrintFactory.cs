using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrintFactory
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="printMediaType"></param>
     /// <param name="description"></param>
     /// <returns></returns>
        IPrintMediaType CreateEditPrintMediaTypeView(IPrintMediaType printMediaType, string description);


        /// <summary>
        /// /
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="printMediaType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        IPrintMediaTypeListView CreatePrintMediaTypeListView(int selectedPrintMediaTypeId,
            string selectedDescription, IList<IPrintMediaType> printMediaTypeCollection, string message);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="printMediaType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        IPrintMediaType getUpdatedPrintMediaType(IPrintMediaType printMediaType, string message);
        /// <summary>
        /// Creates the print media view.
        /// </summary>
        /// <returns></returns>
        IPrintMediaType CreatePrintMediaView();


        /// <summary>
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <returns></returns>
        IPrintTransactionView GetPrintTransactionView(int transactionId, int SentToId, string OrderTitle);
        /// <summary>
        /// Gets the user print transaction.
        /// </summary>
        /// <param name="printTransaction">The print transaction.</param>
        /// <param name="printTransactionAirings">The print transaction airings.</param>
        /// <returns></returns>
        IPrintMediaModelView GetUserPrintTransaction(IPrintTransaction printTransaction, IList<IPrintTransactionAiring> printTransactionAirings);
        /// <summary>
        /// Creates the update print view.
        /// </summary>
        /// <param name="printView">The print view.</param>
        /// <param name="printCategoryList">The print category list.</param>
        /// <param name="printServiceTypesList">The print service types list.</param>
        /// <param name="newspaperList">The newspaper list.</param>
        /// <param name="color">The color.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        IPrintView CreateUpdatePrintView(IPrintView printView, IList<IPrintCategory> printCategoryList,
           IList<IPrintServiceType> printServiceTypesList, IList<INewsPaper> newspaperList, IList<IColor> color,
           IList<IDesignElement> designElement, IList<IDurationType> durationType,
           IList<IApconApprovalType> apconApprovalType, string processingMesage);

        /// <summary>
        /// Gets the print view factory.
        /// </summary>
        /// <param name="apconApprovalTypePrice">The price.</param>
        /// <param name="designelement">The designelement.</param>
        /// <param name="printcategory">The printcategory.</param>
        /// <param name="newspaper">The newspaper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <param name="processingMessage">The message.</param>
        /// <param name="printTransactionAiringUIs">The print transaction airing u is.</param>
        /// <param name="printTransactionUI">The print transaction UI.</param>
        /// <param name="SelectedNewspapersId">The selected newspapers identifier.</param>
        /// <returns></returns>
        IPrintMediaModelView GetPrintViewFactory(IList<IApconApprovalTypePrice> apconApprovalTypePrice, IList<IDesignElement> designelement,
           IList<IPrintCategory> printcategory, IList<INewsPaper> newspaper, IList<IPrintServiceType> serviceType,
           IList<IDurationType> durationType, IList<IApconApprovalType> apconApprovalType, string processingMessage, IEnumerable<IPrintTransactionAiringUI> printTransactionAiringUIs, IPrintTransactionUI printTransactionUI, IList<int> SelectedNewspapersId, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes);


        /// <summary>
        /// Gets the print view factory.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="designelement">The designelement.</param>
        /// <param name="printcategory">The printcategory.</param>
        /// <param name="newspaper">The newspaper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <returns></returns>
        IPrintMediaModelView GetPrintViewFactory(IList<IApconApprovalTypePrice> price, IList<IDesignElementPrice> designelement,
            IList<IPrintCategory> printcategory, IList<INewsPaper> newspaper, IList<IPrintServiceType> serviceType,
            IList<IDurationType> durationType, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes);

        /// <summary>
        /// Creates the print news paper ListView.
        /// </summary>
        /// <param name="selectedPrintNewsPaperId">The selected print news paper identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="printNewsPaperCollection">The print news paper collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintNewsPaperListView CreatePrintNewsPaperListView(int selectedPrintNewsPaperId, string selectedDescription, IList<INewsPaper> printNewsPaperCollection, string message);


        /// <summary>
        /// Creates the print category ListView.
        /// </summary>
        /// <param name="selectedPrintCategoryId">The selected print category identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="printCategoryCollection">The print category collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintCategoryListView CreatePrintCategoryListView(int selectedPrintCategoryId, string selectedDescription, IList<IPrintCategory> printCategoryCollection,
            string message);


        /// <summary>
        /// Creates the print service type price ListView.
        /// </summary>
        /// <param name="selectedPrintServiceTypePriceId">The selected print service type price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="printServiceTypePriceCollection">The print service type price collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintServiceTypePriceListView CreatePrintServiceTypePriceListView(int selectedPrintServiceTypePriceId, string selectedDescription, IList<IPrintServiceTypePrice> printServiceTypePriceCollection, string message);

        /// <summary>
        /// Creates the print serice type view.
        /// </summary>
        /// <returns></returns>
        IPrintServiceTypeView CreatePrintSericeTypeView();
        /// <summary>
        /// Gets the updated print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="newsPaper">The news paper.</param>
        /// <param name="printServiceType">Type of the print service.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView GetUpdatedPrintServiceTypePriceView(IPrintServiceTypePriceView printServiceTypePriceView, IList<INewsPaper> newsPaper, IList<IPrintServiceType> printServiceType, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes);

        /// <summary>
        /// Creates the print service type view.
        /// </summary>
        /// <param name="printServiceTypeInfo">The print service type information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IPrintServiceTypeView CreatePrintServiceTypeView(IPrintServiceTypeView printServiceTypeInfo, string processingMessage);

        /// <summary>
        /// Creates the edit print serice type view.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IPrintServiceTypeView CreateEditPrintSericeTypeView(IPrintServiceTypeView printServiceTypeView,
            string description);

        /// <summary>
        /// Creates the news paper view.
        /// </summary>
        /// <returns></returns>
        INewsPaperView CreateNewsPaperView();

        /// <summary>
        /// Creates the news paper view.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        INewsPaperView CreateNewsPaperView(INewsPaperView newsPaperInfo, string processingMessage);

        /// <summary>
        /// Creates the edit news paper view.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        INewsPaperView CreateEditNewsPaperView(INewsPaperView newsPaperView, string description);

        /// <summary>
        /// Creates the print service type ListView.
        /// </summary>
        /// <param name="selectedPrintServiceTypeId">The selected print service type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="printServiceTypeCollection">The print service type collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintServiceTypeListView CreatePrintServiceTypeListView(int selectedPrintServiceTypeId, string selectedDescription, IList<IPrintServiceType> printServiceTypeCollection, string message);

        /// <summary>
        /// Creates the print category view.
        /// </summary>
        /// <returns></returns>
        IPrintCategoryView CreatePrintCategoryView();

        /// <summary>
        /// Creates the print category view.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IPrintCategoryView CreatePrintCategoryView(IPrintCategoryView printCategoryInfo, string processingMessage);

        /// <summary>
        /// Creates the edit print category view.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IPrintCategoryView CreateEditPrintCategoryView(IPrintCategoryView printCategoryView, string description);

        /// <summary>
        /// Creates the add print serice type price view.
        /// </summary>
        /// <param name="printServiceTypeList">The print service type list.</param>
        /// <param name="newspaperList">The newspaper list.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView CreateAddPrintSericeTypePriceView(IList<IPrintServiceType> printServiceTypeList,
            IList<INewsPaper> newspaperList, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes);

        /// <summary>
        /// Creates the update add print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceInfo">The print service type price information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView CreateUpdateAddPrintServiceTypePriceView(IPrintServiceTypePriceView printServiceTypePriceInfo, string processingMessage);


        /// <summary>
        /// Creates the edit print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="printServiceTypeList">The print service type list.</param>
        /// <param name="newspaperList">The newspaper list.</param>
        /// <param name="printServiceTypePrice">The print service type price.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView CreateEditPrintServiceTypePriceView(IPrintServiceTypePriceView printServiceTypePriceView, IList<IPrintServiceType> printServiceTypeList, IList<INewsPaper> newspaperList, IPrintServiceTypePrice printServiceTypePrice, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes);

        /// <summary>
        /// Creates the delete print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView CreateDeletePrintServiceTypePriceView(IPrintServiceTypePriceView printServiceTypePriceView, IPrintServiceTypePrice description);
        /// <summary>
        /// Gets the apcon price views.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        IPrintMediaModelView GetApconPriceViews(IApconApprovalTypePrice price);
        /// <summary>
        /// Gets the design element views.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        IPrintMediaModelView GetDesignElementViews(IDesignElementPrice price);
        /// <summary>
        /// Creates the print transaction view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="selectedPrintTransactionId">The selected print transaction identifier.</param>
        /// <returns></returns>
        IPrintMediaModelViewList CreatePrintTransactionView(IList<IPrintTransaction> view, int selectedPrintTransactionId);

        /// <summary>
        /// Edits the print view.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="designelement">The designelement.</param>
        /// <param name="printcategory">The printcategory.</param>
        /// <param name="color">The color.</param>
        /// <param name="newspaper">The newspaper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="productionPrice">The production price.</param>
        /// <param name="printTransactionAiring">The print transaction airing.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintMediaModelView EditPrintView(IList<IApconApprovalTypePrice> price, IList<IApconApprovalType> apconApprovalTypes, IList<IDesignElementPrice> designelement,
            IList<IPrintCategory> printcategory, IList<IColor> color, IList<INewsPaper> newspaper, IList<IPrintServiceType> serviceType,
            IList<IDurationType> durationType, IPrintTransaction printTransaction,
            IEnumerable<IPrintTransactionAiringUI> transactionAiring, List<int> selectedPrintNewsPapersIds, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes);

        /// <summary>
        /// Gets the updated news paper view.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        INewsPaperView getUpdatedNewsPaperView(INewsPaperView newsPaperView, string message);
        /// <summary>
        /// Gets the updated print category view.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintCategoryView getUpdatedPrintCategoryView(IPrintCategoryView printCategoryView, string message);
        /// <summary>
        /// Gets the updated print service type view.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintServiceTypeView getUpdatedPrintServiceTypeView(IPrintServiceTypeView printServiceTypeView, string message);
        /// <summary>
        /// Generates the airing view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="newsPaper">The news paper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintTransactionAiringView GenerateAiringView(int Id, IList<INewsPaper> newsPaper, IList<IPrintServiceType> serviceType, string message);

        /// <summary>

        /// <summary>
        /// Creates the print Service Color view.
        /// </summary>
        /// <returns></returns>
        IPrintServiceColor CreatePrintServiceColorView();

        /// <summary>
        /// Gets the color of the updated print service.
        /// </summary>
        /// <param name="printServiceColorView">The print service color view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintServiceColor GetUpdatedPrintServiceColor(IPrintServiceColor printServiceColorView, string message);


        /// <summary>
        /// Creates the print service color ListView.
        /// </summary>
        /// <param name="SelectedPrintServiceTypeColorId">The selected print service type color identifier.</param>
        /// <param name="SelectedPrintServiceTypeColor">Color of the selected print service type.</param>
        /// <param name="printServiceColorCollection">The print service color collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintServiceColorListView CreatePrintServiceColorListView(int? SelectedPrintServiceTypeColorId,
           string SelectedPrintServiceTypeColor, IList<IPrintServiceColor> printServiceColorCollection, string message);

        /// <summary>
        /// Creates the edit print service color view.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <returns></returns>
        IPrintServiceColor CreateEditPrintServiceColorView(IPrintServiceColor printServiceColor);


        /// <summary>
        /// Creates the delete print service type color view.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <returns></returns>
        IPrintServiceColor CreateDeletePrintServiceTypeColorView(IPrintServiceColor printServiceColor);


    }
}
