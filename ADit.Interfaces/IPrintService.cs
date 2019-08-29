using System.Collections.Generic;
using System.Web;

namespace ADit.Interfaces
{
    /// <summary>
    ///  
    /// </summary>
    public interface IPrintService
   {

        /// <summary>
        /// Gets the type of the delete print media.
        /// </summary>
        /// <param name="printMediaTypeId">The print media type identifier.</param>
        /// <returns></returns>
        string GetDeletePrintMediaType(int printMediaTypeId);
        /// <summary>
        /// Gets the delete news paper.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <param name="printMediaTypeId">The print media type identifier.</param>
        /// <returns></returns>
        IPrintMediaType GetDeletePrintMediaType(IPrintMediaType printMediaType, int printMediaTypeId);

        /// <summary>
        /// Gets the print media type ListView model.
        /// </summary>
        /// <param name="SelectedPrintMediaTypeIds">The selected print media type ids.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintMediaTypeListView GetPrintMediaTypeListViewModel(int SelectedPrintMediaTypeIds,
           string SelectedDescription, string message);

        /// <summary>
        /// Processes the update print media information.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <returns></returns>
        string ProcessUpdatePrintMediaInfo(IPrintMediaType printMediaType);
        /// <summary>
        /// Gets the type of the edit print media.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <param name="printTypeId">The print type identifier.</param>
        /// <returns></returns>
        IPrintMediaType GetEditPrintMediaType(IPrintMediaType printMediaType, int printTypeId);
        /// <summary>
        /// Processes the print media information.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <returns></returns>
        string ProcessPrintMediaInfo(IPrintMediaType printMediaType);

        // <summary>        
        /// <summary>
        /// Gets the type of the updated print media.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintMediaType getUpdatedPrintMediaType(IPrintMediaType printMediaType, string message);



        /// 
        /// </summary>
        /// <returns></returns>
        IPrintMediaType GetPrintMediaViewModel();
        /// <summary>
       /// <summary>
        /// Gets the print transaction view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <param name="OrderTitle">The order title.</param>
      /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string DeletePrintOrder(int transactionId);
        /// <summary>
        /// Gets the user print transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IPrintMediaModelView GetUserPrintTransaction(int transactionId);
        /// <summary>
        /// Processes the print view.
        /// </summary>
        /// <param name="printTransactionUI">The print transaction UI.</param>
        /// <param name="printTransactionAiringUI">The print transaction airing UI.</param>
        /// <param name="printImageFile">The print image file.</param>
        /// <param name="printTransactionId">The print transaction identifier.</param>
        /// <param name="SelectedNewsPapersId">The selected news papers identifier.</param>
        /// <returns></returns>
        string ProcessPrintView(IPrintTransactionUI printTransactionUI, IEnumerable<IPrintTransactionAiringUI> printTransactionAiringUI, HttpPostedFileBase printImageFile,
             out int printTransactionId, IList<int> SelectedNewsPapersId);
        /// <summary>
        /// Gets the print news paper ListView model.
        /// </summary>
        /// <param name="SelectedPrintNewsPaperId">The selected print news paper identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintNewsPaperListView GetPrintNewsPaperListViewModel(int SelectedPrintNewsPaperId, string SelectedDescription, string message);
        /// <summary>
        /// Gets the print category ListView model.
        /// </summary>
        /// <param name="SelectedPrintCategoryId">The selected print category identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintCategoryListView GetPrintCategoryListViewModel(int SelectedPrintCategoryId, string SelectedDescription, string message);
        /// <summary>
        /// Gets the print service type ListView model.
        /// </summary>
        /// <param name="SelectedPrintServiceTypeId">The selected print service type identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintServiceTypeListView GetPrintServiceTypeListViewModel(int SelectedPrintServiceTypeId, string SelectedDescription, string message);
        /// <summary>
        /// Gets the print service type price view model.
        /// </summary>
        /// <param name="SelectedPrintServiceTypePriceId">The selected print service type price identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintServiceTypePriceListView GetPrintServiceTypePriceViewModel( int SelectedPrintServiceTypePriceId, string SelectedDescription, string message);

        /// <summary>
        /// Gets the updated print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView GetUpdatedPrintServiceTypePriceView(IPrintServiceTypePriceView printServiceTypePriceView);
        /// <summary>
        /// Gets the print service type view model.
        /// </summary>
        /// <returns></returns>
        IPrintServiceTypeView GetPrintServiceTypeViewModel();

        /// <summary>
        /// Gets the updated newspaper view.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        INewsPaperView GetUpdatedNewspaperView(INewsPaperView newsPaperView,string message);
        /// <summary>
        /// Gets the type of the updated print serrvice.
        /// </summary>
        /// <param name="printServiceType">Type of the print service.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintServiceTypeView GetUpdatedPrintSerrviceType(IPrintServiceTypeView printServiceType,string message);

        /// <summary>
        /// Gets the updated print category view.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintCategoryView GetUpdatedPrintCategoryView(IPrintCategoryView printCategoryView,string message);
        /// <summary>
        /// Processes the print service type information.
        /// </summary>
        /// <param name="printServiceTypeInfo">The print service type information.</param>
        /// <returns></returns>
        string ProcessPrintServiceTypeInfo(IPrintServiceTypeView printServiceTypeInfo);


        /// <summary>
        /// Gets the type of the edit print service.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        IPrintServiceTypeView GetEditPrintServiceType(IPrintServiceTypeView printServiceTypeView, int printServiceTypeId);
        /// <summary>
        /// Processes the type of the update print service.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <returns></returns>
        string ProcessUpdatePrintServiceType(IPrintServiceTypeView printServiceTypeView);


        /// <summary>
        /// Gets the type of the delete print service.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        IPrintServiceTypeView GetDeletePrintServiceType(IPrintServiceTypeView printServiceTypeView,
           int printServiceTypeId);

        /// <summary>
        /// Gets the type of the delete print service.
        /// </summary>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        string GetDeletePrintServiceType(int printServiceTypeId);


        /// <summary>
        /// Gets the news paper view model.
        /// </summary>
        /// <returns></returns>
        INewsPaperView GetNewsPaperViewModel();

        /// <summary>
        /// Processes the news paper information.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        string ProcessNewsPaperInfo(INewsPaperView newsPaperInfo);

        /// <summary>
        /// Gets the edit news paper.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        INewsPaperView GetEditNewsPaper(INewsPaperView newsPaperView, int newsPaperId);
        /// <summary>
        /// Processes the update news paper information.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <returns></returns>
        string ProcessUpdateNewsPaperInfo(INewsPaperView newsPaperView);



        /// <summary>
        /// Gets the delete news paper.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        INewsPaperView GetDeleteNewsPaper(INewsPaperView newsPaperView, int newsPaperId);

        /// <summary>
        /// Gets the delete news paper.
        /// </summary>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        string GetDeleteNewsPaper(int newsPaperId);


        /// <summary>
        /// Gets the print category view model.
        /// </summary>
        /// <returns></returns>
        IPrintCategoryView GetPrintCategoryViewModel();

        /// <summary>
        /// Processes the print category information.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <returns></returns>
        string ProcessPrintCategoryInfo(IPrintCategoryView printCategoryInfo);

        /// <summary>
        /// Gets the edit print category.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        IPrintCategoryView GetEditPrintCategory(IPrintCategoryView printCategoryView, int printCategoryId);

        /// <summary>
        /// Processes the update print category.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <returns></returns>
        string ProcessUpdatePrintCategory(IPrintCategoryView printCategoryInfo);

        /// <summary>
        /// Gets the delete print category.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        IPrintCategoryView GetDeletePrintCategory(IPrintCategoryView printCategoryView, int printCategoryId);


        /// <summary>
        /// Gets the delete print category.
        /// </summary>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        string GetDeletePrintCategory(int printCategoryId);


        /// <summary>
        /// Gets the print service type price view model.
        /// </summary>
        /// <returns></returns>
        IPrintServiceTypePriceView GetPrintServiceTypePriceViewModel();

        /// <summary>
        /// Processes the add print service type price view model.
        /// </summary>
        /// <param name="printServiceTypePriceInfo">The print service type price information.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView ProcessAddPrintServiceTypePriceViewModel(IPrintServiceTypePriceView printServiceTypePriceInfo);



        /// <summary>
        /// Gets the edit print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView GetEditPrintServiceTypePrice(IPrintServiceTypePriceView printServiceTypePriceView,
           int printServiceTypePriceId);


        /// <summary>
        /// Gets the edit print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView GetEditPrintServiceTypePrice(IPrintServiceTypePriceView printServiceTypePriceView);

        /// <summary>
        /// Gets the delete print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView GetDeletePrintServiceTypePrice(IPrintServiceTypePriceView printServiceTypePriceView, int printServiceTypePriceId);

        /// <summary>
        /// Gets the delete print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        string GetDeletePrintServiceTypePrice(int printServiceTypePriceId);


        /// <summary>
        /// Gets the print view.
        /// </summary>
        /// <param name="printTransactionUI">The print transaction UI.</param>
        /// <param name="printTransactionAiringUIs">The print transaction airing u is.</param>
        /// <param name="selectedNewsPapersId">The selected news papers identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintMediaModelView GetPrintView(IPrintTransactionUI printTransactionUI, IEnumerable<IPrintTransactionAiringUI> printTransactionAiringUIs,List<int>selectedNewsPapersId,string message);

        /// <summary>
        /// Gets the print view.
        /// </summary>
        /// <returns></returns>
        IPrintMediaModelView GetPrintView();

        /// <summary>
        /// Gets the apcon approval view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IPrintMediaModelView GetApconApprovalView(int Id);
        /// <summary>
        /// Gets the design element price view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IPrintMediaModelView GetDesignElementPriceView(int Id);
        /// <summary>
        /// Updates the cart.
        /// </summary>
        void UpdateCart();
        /// <summary>
        /// Gets the print history page.
        /// </summary>
        /// <param name="selectedPrintTransactionId">The selected print transaction identifier.</param>
        /// <returns></returns>
        IPrintMediaModelViewList GetPrintHistoryPage(int selectedPrintTransactionId);
        /// <summary>
        /// Gets the print.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintMediaModelView GetPrint(int Id, int userId, string message);
        /// <summary>
        /// Processes the edit print.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="artwork">The artwork.</param>
        /// <returns></returns>
        string ProcessEditPrint(IPrintTransactionUI printTransactionUi, IEnumerable<IPrintTransactionAiringUI> printTransactionAiringUi, HttpPostedFileBase printImageFile
            , out int orderId, IList<int> selectedNewsPapersId);
       
        /// <summary>
        /// Gets the print airing.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintTransactionAiringView GetPrintAiring(int Id, string message);
        /// <summary>
        /// Processes the print airing view.
        /// </summary>
        /// <param name="airingInfo">The airing information.</param>
        /// <returns></returns>
        string ProcessPrintAiringView(IPrintTransactionAiringView airingInfo);


        /// <summary>
        /// Gets the news paper price.
        /// </summary>
        /// <param name="newspaper">The newspaper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        decimal GetNewsPaperPrice(int newspaper, int serviceType,int serviceColorId,int PrintMediaTypeId);

        /// <summary>
        /// Gets the print service color view model.
        /// </summary>
        /// <returns></returns>
        IPrintServiceColor GetPrintServiceColorViewModel();

        /// <summary>
        /// Gets the color of the updated print service.
        /// </summary>
        /// <param name="printServiceColorView">The print service color view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
       IPrintServiceColor GetUpdatedPrintServiceColor (IPrintServiceColor printServiceColorView, string message);

        /// <summary>
        /// Processes the print service information.
        /// </summary>
        /// <param name="printServiceColorView">The print service color view.</param>
        /// <returns></returns>
        string ProcessPrintServiceInfo(IPrintServiceColor printServiceColorView);

        /// <summary>
        /// Gets the print service color ListView model.
        /// </summary>
        /// <param name="SelectedPrintServiceTypeColorId">The selected print service type color identifier.</param>
        /// <param name="SelectedPrintServiceTypeColor">Color of the selected print service type.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IPrintServiceColorListView GetPrintServiceColorListViewModel(int SelectedPrintServiceTypeColorId,
          string SelectedPrintServiceTypeColor, string message);

        /// <summary>
        /// Gets the color of the edit print service.
        /// </summary>
        /// <param name="PrintServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        IPrintServiceColor GetEditPrintServiceColor(int PrintServiceTypeColorId);

        /// <summary>
        /// Processes the update print service information.
        /// </summary>
        /// <param name="printServiceColorView">The print service color view.</param>
        /// <returns></returns>
        string ProcessUpdatePrintServiceInfo(IPrintServiceColor printServiceColorView);

        /// <summary>
        /// Processes the color of the delete print service.
        /// </summary>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        string ProcessDeletePrintServiceColor(int printServiceTypeColorId);

       
       


        /// <summary>
        /// Gets the color of the delete print service.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        IPrintServiceColor GetDeletePrintServiceColor(IPrintServiceColor printServiceColor,int printServiceTypeColorId);
        /// <summary>
        /// Gets the color of the delete print service.
        /// </summary>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        string GetDeletePrintServiceColor(int printServiceTypeColorId); 
    }
}