using AA.Infrastructure.Interfaces;
using ADit.Domain.Resources;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADit.Domain.Services
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IPrintService" />
    public class PrintService : IPrintService
    {
        
        private readonly IEmail emailService;
       
        private readonly IEnvironment environment;
       
        private readonly IEmailFactory emailFactory;
     
        private readonly IPrintRepository printRepository;
        
        private readonly IOrderRepository orderRepository;
       
        private readonly IPrintFactory printFactory;
       
        private readonly ILookupRepository lookupRepository;
      
        private readonly IDigitalFileServices digitalFileServices;
       
        private readonly ISessionStateService session;
      
        private readonly IGeneralRepository generalRepository;
      
        private readonly IOrderServices orderServices;
       
        private readonly ITransactionService transactionService;


        private readonly IDigitalFileRepository digitalFileRepository;

      
        public PrintService(IPrintRepository printRepository, IDigitalFileServices digitalFileServices,
            IPrintFactory printFactory, ILookupRepository lookupRepository, IOrderServices orderServices,
            ISessionStateService session,IOrderRepository orderRepository ,IGeneralRepository generalRepository,IEmail emailService ,IEnvironment environment,ITransactionService transactionService,IEmailFactory emailFactory,IDigitalFileRepository digitalFileRepository)
        {
            this.environment = environment;
            this.transactionService = transactionService;
            this.lookupRepository = lookupRepository;
            this.printFactory = printFactory;
            this.printRepository = printRepository;
            this.digitalFileServices = digitalFileServices;
            this.session = session;
            this.generalRepository = generalRepository;
            this.orderServices = orderServices;
            this.digitalFileRepository = digitalFileRepository;
           
            this.emailFactory = emailFactory;
            this.emailService = emailService;
            this.orderRepository = orderRepository;
        }

        /// <summary>
        /// Processes the print view.
        /// </summary>
        /// <param name="printTransactionUi">The print transaction UI.</param>
        /// <param name="printTransactionAiringUi">The print transaction airing UI.</param>
        /// <param name="printImageFile">The print image file.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="selectedNewsPapersId">The selected news papers identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printTransactionUI
        /// or
        /// printTransactionAiringUI</exception>
        public string ProcessPrintView(IPrintTransactionUI printTransactionUi, IEnumerable<IPrintTransactionAiringUI> printTransactionAiringUi, HttpPostedFileBase printImageFile
            , out int orderId, IList<int> selectedNewsPapersId)
        {
            if (printTransactionUi == null)
            {
                throw new ArgumentNullException(nameof(printTransactionUi));
            }

            if (printTransactionAiringUi == null)
            {
                throw new ArgumentNullException(nameof(printTransactionAiringUi));
            }

            if (selectedNewsPapersId == null)
            {
                throw new ArgumentNullException(nameof(selectedNewsPapersId));
            }

            //Get The Currently Logged User Id
            var userId = (int) this.session.GetSessionValue(SessionKey.UserId);


            // Get order number
            orderId = this.orderServices.GetOrderIdentifier(userId);

            // save files uploaded by calling digital file services, the id returned will be zero if no files are uploaded - no need to check anything here
            var artWorkProcessingMessage = this.digitalFileServices.SaveFile(FileType.Image, printImageFile, out var printFileId);


            // save print transaction to database
            var selectedTransactionAiringList = printTransactionAiringUi.Where(x => selectedNewsPapersId.Contains(x.NewsPaperId)).ToList();


            printTransactionUi.OrderId = orderId; // Assign Order ID
            printTransactionUi.UserId = userId; //Assign User ID
            printTransactionUi.MaterialDigitalFileId = printFileId; //Assign PrintID


            var result = this.printRepository.SavePrintTransaction(printTransactionUi, out var printTransactionId);

            if (string.IsNullOrEmpty(result) && (printTransactionId > 0))
            {
                // save transaction airing info also
                result = this.printRepository.SavePrintTransactionAiring(selectedTransactionAiringList, printTransactionId);
            }

            //Update The Cart For The User
            this.transactionService.UpdateCart(orderId);

            return result;
        }


        /// <summary>
        /// Gets the print news paper ListView model.
        /// </summary>
        /// <param name="SelectedPrintNewsPaperId">The selected print news paper identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintNewsPaperListView GetPrintNewsPaperListViewModel(int SelectedPrintNewsPaperId,
            string SelectedDescription, string message)
        {
            var theCollection = this.lookupRepository.GetNewsPaperList().ToList();

            //Generate Vacancy From Factory
            var viewModel = this.printFactory.CreatePrintNewsPaperListView(SelectedPrintNewsPaperId,
                SelectedDescription, theCollection, message);

            return viewModel;
        }



        public IPrintMediaTypeListView GetPrintMediaTypeListViewModel(int SelectedPrintMediaTypeIds,
           string SelectedDescription, string message)
        {
            var theCollection = this.lookupRepository.GetPrintMediaTypeList().ToList();

            //Generate Vacancy From Factory
            var viewModel = this.printFactory.CreatePrintMediaTypeListView(SelectedPrintMediaTypeIds,
                SelectedDescription, theCollection, message);

            return viewModel;
        }





        /// <summary>
        /// Gets the print category ListView model.
        /// </summary>
        /// <param name="SelectedPrintCategoryId">The selected print category identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintCategoryListView GetPrintCategoryListViewModel(int SelectedPrintCategoryId,
            string SelectedDescription, string message)
        {
            var theCollection = this.lookupRepository.GetPrintCategoriesList().ToList();

            //Generate Vacancy From Factory
            var viewModel = this.printFactory.CreatePrintCategoryListView(SelectedPrintCategoryId, SelectedDescription,
                theCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the print service type ListView model.
        /// </summary>
        /// <param name="SelectedPrintServiceTypeId">The selected print service type identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintServiceTypeListView GetPrintServiceTypeListViewModel(int SelectedPrintServiceTypeId,
            string SelectedDescription, string message)
        {
            var theCollection = this.lookupRepository.GetServiceTypeList().ToList();

            //Generate Vacancy From Factory
            var viewModel = this.printFactory.CreatePrintServiceTypeListView(SelectedPrintServiceTypeId,
                SelectedDescription, theCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the print service type price view model.
        /// </summary>
        /// <param name="SelectedPrintServiceTypePriceId">The selected print service type price identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintServiceTypePriceListView GetPrintServiceTypePriceViewModel(int SelectedPrintServiceTypePriceId,
            string SelectedDescription, string message)
        {
            var theCollection = this.lookupRepository.GetPrintServiceTypePriceList().ToList();

            //Generate Vacancy From Factory
            var viewModel = this.printFactory.CreatePrintServiceTypePriceListView(SelectedPrintServiceTypePriceId,
                SelectedDescription, theCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the print service type view model.
        /// </summary>
        /// <returns></returns>
        public IPrintServiceTypeView GetPrintServiceTypeViewModel()
        {
            return this.printFactory.CreatePrintSericeTypeView();
        }

        /// <summary>
        /// Processes the print service type information.
        /// </summary>
        /// <param name="printServiceTypeInfo">The print service type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypeInfo</exception>
        public string ProcessPrintServiceTypeInfo(IPrintServiceTypeView printServiceTypeInfo)
        {
            if (printServiceTypeInfo == null) throw new ArgumentNullException(nameof(printServiceTypeInfo));
            string processingMessage = string.Empty;

            //Check That The Service Types Existed

            var serviceType = this.printRepository.GetPrintServiceTypeByName(printServiceTypeInfo.Description);

            if (serviceType != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.SaveAddPrintServiceType(printServiceTypeInfo);
            }

            return processingMessage;
        }

        /// <summary>
        /// Gets the type of the edit print service.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        public IPrintServiceTypeView GetEditPrintServiceType(IPrintServiceTypeView printServiceTypeView,
            int printServiceTypeId)
        {
            var description = this.lookupRepository.GetPrintServiceTypeDescriptionByID(printServiceTypeId);

            return this.printFactory.CreateEditPrintSericeTypeView(printServiceTypeView, description);
        }

        /// <summary>
        /// Processes the type of the update print service.
        /// </summary>
        /// <param name="printServiceTypeInfo">The print service type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypeInfo</exception>
        public string ProcessUpdatePrintServiceType(IPrintServiceTypeView printServiceTypeInfo)
        {
            if (printServiceTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypeInfo));
            }

            var processingMessage = string.Empty;

            var serviceType = this.printRepository.GetPrintServiceTypeByName(printServiceTypeInfo.Description);

            if (serviceType != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.SavePrintServiceTypeDescription(printServiceTypeInfo);
            }


            return processingMessage;
        }

        /// <summary>
        /// Gets the type of the delete print service.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        public IPrintServiceTypeView GetDeletePrintServiceType(IPrintServiceTypeView printServiceTypeView,
            int printServiceTypeId)
        {
            var description = this.lookupRepository.GetPrintServiceTypeDescriptionByID(printServiceTypeId);

            return this.printFactory.CreateEditPrintSericeTypeView(printServiceTypeView, description);
        }

        /// <summary>
        /// Gets the type of the delete print service.
        /// </summary>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        public string GetDeletePrintServiceType(int printServiceTypeId)
        {
            var returnMessage = this.printRepository.DeletePrintServiceTypeDescription(printServiceTypeId);

            return returnMessage;
        }

        /// <summary>
        /// Gets the news paper view model.
        /// </summary>
        /// <returns></returns>
        public INewsPaperView GetNewsPaperViewModel()
        {
            return this.printFactory.CreateNewsPaperView();
        }
        /// <summary>
        /// Gets the news paper view model.
        /// </summary>
        /// <returns></returns>
        public IPrintMediaType GetPrintMediaViewModel()
        {
            return this.printFactory.CreatePrintMediaView();
        }
        /// <summary>
        /// Processes the news paper information.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperInfo</exception>
        public string ProcessNewsPaperInfo(INewsPaperView newsPaperInfo)
        {
            if (newsPaperInfo == null)
            {
                throw new ArgumentNullException(nameof(newsPaperInfo));
            }

            string processingMessage = string.Empty;

            //Checking If The News paper nGeame already existed

            var newsPaper = this.printRepository.GetNewsPaperDescriptionByName(newsPaperInfo.Description);

            if (newsPaper != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.SaveAddNewsPaper(newsPaperInfo);
            }


            return processingMessage;
        }





        /// <summary>
        /// Processes the print media information.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperInfo</exception>
        public string ProcessPrintMediaInfo(IPrintMediaType printMediaType)
        {
            if (printMediaType == null)
            {
                throw new ArgumentNullException(nameof(printMediaType));
            }

            string processingMessage = string.Empty;

            //Checking If The News paper nGeame already existed

            var newsPaper = this.printRepository.GetNewsPaperDescriptionByName(printMediaType.Description);

            if (newsPaper != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.SaveAddPrintMediaType(printMediaType);
            }


            return processingMessage;
        }

        /// <summary>
        /// Gets the edit news paper.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        public INewsPaperView GetEditNewsPaper(INewsPaperView newsPaperView, int newsPaperId)
        {
            var description = this.lookupRepository.GetNewsPaperDescriptionById(newsPaperId);

            return this.printFactory.CreateEditNewsPaperView(newsPaperView, description);
        }




        /// <summary>
        /// Gets the type of the edit print media.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <param name="printTypeId">The print type identifier.</param>
        /// <returns></returns>
        public IPrintMediaType GetEditPrintMediaType(IPrintMediaType printMediaType, int printTypeId)
        {
            var description = this.lookupRepository.GetPrintMediaTypeDescriptionById(printTypeId);

            return this.printFactory.CreateEditPrintMediaTypeView(printMediaType, description);
        }

        /// <summary>
        /// Processes the update news paper information.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperInfo</exception>
        public string ProcessUpdateNewsPaperInfo(INewsPaperView newsPaperInfo)
        {
            if (newsPaperInfo == null)
            {
                throw new ArgumentNullException(nameof(newsPaperInfo));
            }

            var processingMessage = string.Empty;

            var newsPaper = this.printRepository.GetNewsPaperDescriptionByName(newsPaperInfo.Description);

            if (newsPaper != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.UpdateNewsPaperInfo(newsPaperInfo);
            }


            return processingMessage;
        }






        /// <summary>
        /// Processes the update print media information.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperInfo</exception>
        public string ProcessUpdatePrintMediaInfo(IPrintMediaType printMediaType)
        {
            if (printMediaType == null)
            {
                throw new ArgumentNullException(nameof(printMediaType));
            }

            var processingMessage = string.Empty;

            var newsPaper = this.printRepository.GetNewsPaperDescriptionByName(printMediaType.Description);

            if (newsPaper != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.UpdatePrintMediaTypeInfo(printMediaType);
            }


            return processingMessage;
        }











        /// Processes the update news paper information.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperInfo</exception>
        public string ProcessUpdatePrintMediaTypeInfo(IPrintMediaType printMediaType)
        {
            if (printMediaType == null)
            {
                throw new ArgumentNullException(nameof(printMediaType));
            }

            var processingMessage = string.Empty;

            var newsPaper = this.printRepository.GetPrintMediaTypeByName(printMediaType.Description);

            if (newsPaper != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.UpdatePrintMediaTypeInfo(printMediaType);
            }


            return processingMessage;
        }

        /// <summary>
        /// Gets the delete news paper.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        public IPrintMediaType GetDeletePrintMediaType(IPrintMediaType printMediaType, int printMediaTypeId)
        {
            var description = this.lookupRepository.GetPrintMediaTypeDescriptionById(printMediaTypeId);

            printMediaType.PrintMediaTypeId = printMediaTypeId;
            return this.printFactory.CreateEditPrintMediaTypeView(printMediaType, description);
        }



        /// <summary>
        /// Gets the delete news paper.
        /// </summary>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        public string GetDeleteNewsPaper(int newsPaperId)
        {
            var returnMessage = this.printRepository.DeleteNewsPaperDescription(newsPaperId);

            return returnMessage;
        }
        /// <summary>
        /// Gets the type of the delete print media.
        /// </summary>
        /// <param name="printMediaTypeId">The print media type identifier.</param>
        /// <returns></returns>
        public string GetDeletePrintMediaType(int printMediaTypeId)
        {
            var returnMessage = this.printRepository.DeletePrintMediaTypeDescription(printMediaTypeId);

            return returnMessage;
        }


        /// <summary>
        /// Gets the print category view model.
        /// </summary>
        /// <returns></returns>
        public IPrintCategoryView GetPrintCategoryViewModel()
        {
            return this.printFactory.CreatePrintCategoryView();
        }

        /// <summary>
        /// Processes the print category information.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printCategoryInfo</exception>
        public string ProcessPrintCategoryInfo(IPrintCategoryView printCategoryInfo)
        {
            if (printCategoryInfo == null)
            {
                throw new ArgumentNullException(nameof(printCategoryInfo));
            }

            string processingMessage = string.Empty;

            //Check That The Category does not Already Existed
            var category = this.printRepository.GetPrintCategoryByName(printCategoryInfo.Description);
            if (category != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.SaveAddPrintCategory(printCategoryInfo);
            }


            return processingMessage;
        }

        /// <summary>
        /// Gets the edit print category.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        public IPrintCategoryView GetEditPrintCategory(IPrintCategoryView printCategoryView, int printCategoryId)
        {
            var description = this.lookupRepository.GetPrintCategoryDescriptionByID(printCategoryId);

            return this.printFactory.CreateEditPrintCategoryView(printCategoryView, description);
        }

        /// <summary>
        /// Processes the update print category.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printCategoryInfo</exception>
        public string ProcessUpdatePrintCategory(IPrintCategoryView printCategoryInfo)
        {
            if (printCategoryInfo == null)
            {
                throw new ArgumentNullException(nameof(printCategoryInfo));
            }


            string processingMessage = string.Empty;

            //Check That The Category does not Already Existed
            var category = this.printRepository.GetPrintCategoryByName(printCategoryInfo.Description);
            if (category != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.UpdatePrintCategoryDescription(printCategoryInfo);
            }


            return processingMessage;
        }

        /// <summary>
        /// Gets the delete print category.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        public IPrintCategoryView GetDeletePrintCategory(IPrintCategoryView printCategoryView, int printCategoryId)
        {
            var description = this.lookupRepository.GetPrintCategoryDescriptionByID(printCategoryId);

            return this.printFactory.CreateEditPrintCategoryView(printCategoryView, description);
        }

        /// <summary>
        /// Gets the delete print category.
        /// </summary>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        public string GetDeletePrintCategory(int printCategoryId)
        {
            var returnMessage = this.printRepository.DeletePrintCategoryDescription(printCategoryId);

            return returnMessage;
        }

        /// <summary>
        /// Gets the print service type price view model.
        /// </summary>
        /// <returns></returns>
        public IPrintServiceTypePriceView GetPrintServiceTypePriceViewModel()
        {
            var NewsPaperList = this.lookupRepository.GetNewsPaperList();
            var PrintServiceTypeList = this.lookupRepository.GetServiceTypeList();
            var printServiceTypeColorList = this.printRepository.GetPrintServiceColors();
            var printMediaTypeList = this.printRepository.GetActivePMediaType();

            return this.printFactory.CreateAddPrintSericeTypePriceView(PrintServiceTypeList, NewsPaperList,printServiceTypeColorList,printMediaTypeList);
        }

        /// <summary>
        /// Processes the add print service type price view model.
        /// </summary>
        /// <param name="printServiceTypePriceInfo">The print service type price information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypePriceInfo</exception>
        public IPrintServiceTypePriceView ProcessAddPrintServiceTypePriceViewModel(
            IPrintServiceTypePriceView printServiceTypePriceInfo)
        {
            if (printServiceTypePriceInfo == null) throw new ArgumentNullException(nameof(printServiceTypePriceInfo));
            string processingMessage = string.Empty;


            this.printRepository.SaveAddPrintServiceTypePrice(printServiceTypePriceInfo);
            var returnView = this.printFactory.CreateUpdateAddPrintServiceTypePriceView(printServiceTypePriceInfo,
                    processingMessage);

            return returnView;
        }


        /// <summary>
        /// Gets the edit print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        public IPrintServiceTypePriceView GetEditPrintServiceTypePrice(
            IPrintServiceTypePriceView printServiceTypePriceView, int printServiceTypePriceId)
        {
            var NewsPaperList = this.lookupRepository.GetNewsPaperList();
            var PrintServiceTypeList = this.lookupRepository.GetServiceTypeList();
            var printResult = this.lookupRepository.GetPrintServiceTypePriceDescriptionByID(printServiceTypePriceId);
            var printColor = this.printRepository.GetPrintServiceColors();
            var printmediaList = this.printRepository.GetActivePMediaType();
            return this.printFactory.CreateEditPrintServiceTypePriceView(printServiceTypePriceView,
                PrintServiceTypeList, NewsPaperList, printResult,printColor,printmediaList);
        }

        /// <summary>
        /// Gets the edit print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <returns></returns>
        public IPrintServiceTypePriceView GetEditPrintServiceTypePrice(
            IPrintServiceTypePriceView printServiceTypePriceView)
        {
            var returnView = this.printRepository.savePrintServiceTypePriceDescription(printServiceTypePriceView);

            return returnView;
        }

        /// <summary>
        /// Gets the delete print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        public IPrintServiceTypePriceView GetDeletePrintServiceTypePrice(
            IPrintServiceTypePriceView printServiceTypePriceView, int printServiceTypePriceId)
        {
            var NewsPaperList = this.lookupRepository.GetNewsPaperList();
            var PrintServiceTypeList = this.lookupRepository.GetServiceTypeList();
            var description = this.lookupRepository.GetPrintServiceTypePriceDescriptionByID(printServiceTypePriceId);

            return this.printFactory.CreateDeletePrintServiceTypePriceView(printServiceTypePriceView, description);
        }

        /// <summary>
        /// Gets the delete print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceId">The print service type price identifier.</param>
        /// <returns></returns>
        public string GetDeletePrintServiceTypePrice(int printServiceTypePriceId)
        {
            var returnMessage = this.printRepository.DeletePrintServiceTypePriceDescription(printServiceTypePriceId);

            return returnMessage;
        }



        /// <summary>
        /// Gets the print view.
        /// </summary>
        /// <returns></returns>
        public IPrintMediaModelView GetPrintView()
        {
            //Apcon Prices List
            var ApconPriceList = this.lookupRepository.GetPrintMedia();

            //Get Design Elements
            var DesignElementList = this.lookupRepository.GetPrintDesignElementPriceList();

            var CategoryList = this.lookupRepository.GetPrintCategoriesList();


            //News Papaer Lists
            var NewspaperList = this.lookupRepository.GetNewsPaperList();

            //New Paper Services Types
            var ServiceTypeList = this.lookupRepository.GetPrintServiceTypeList();

            //Duration Lists
            var DurationList = this.lookupRepository.GetDurationList();

            //
            var printColor = this.printRepository.GetPrintServiceColors();

            var printMediaType = this.printRepository.GetActivePMediaType();

            return this.printFactory.GetPrintViewFactory(ApconPriceList, DesignElementList, CategoryList,
                NewspaperList, ServiceTypeList, DurationList,printColor,printMediaType);
        }





        /// <summary>
        /// Gets the upload print script.
        /// </summary>
        

        /// <summary>
        /// Gets the print view.
        /// </summary>
        /// <param name="printTransactionUI">The print transaction UI.</param>
        /// <param name="printTransactionAiringUIs">The print transaction airing u is.</param>
        /// <param name="selectedNewsPapersId">The selected news papers identifier.</param>
        /// <param name="processingMessage">The message.</param>
        /// <returns></returns>
        public IPrintMediaModelView GetPrintView(IPrintTransactionUI printTransactionUI, IEnumerable<IPrintTransactionAiringUI> printTransactionAiringUIs, List<int> selectedNewsPapersId, string processingMessage)
        {
            var ApconPriceList = this.lookupRepository.GetPrintMedia();

            var designElementList = this.lookupRepository.GetDesignElement();
            var categoriesList = this.lookupRepository.GetPrintCategoriesList();
            var apconApprovalTypes = this.lookupRepository.GetActiveAPCONApprovalTypeList();
            var newspaperList = this.lookupRepository.GetNewsPaperList();
            var serviceTypeList = this.lookupRepository.GetPrintServiceTypeList();
            var durationList = this.lookupRepository.GetDurationList();
            var printColor = this.printRepository.GetPrintServiceColors();

            var printMediaType = this.printRepository.GetActivePMediaType();


            return this.printFactory.GetPrintViewFactory(ApconPriceList, designElementList,
                categoriesList, newspaperList, serviceTypeList,
                durationList, apconApprovalTypes, processingMessage, printTransactionAiringUIs, printTransactionUI, selectedNewsPapersId,printColor,printMediaType);
        }

        /// <summary>
        /// Gets the print history page.
        /// </summary>
        /// <param name="selectedPrintTransactionId">The selected print transaction identifier.</param>
        /// <returns></returns>
        public IPrintMediaModelViewList GetPrintHistoryPage(int selectedPrintTransactionId)
        {
            var theCollection = this.lookupRepository.GetPrintTransaction();

            var viewModel = this.printFactory.CreatePrintTransactionView(theCollection, selectedPrintTransactionId);
            return viewModel;
        }





       

      

        /// <summary>
        /// Gets the apcon approval view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IPrintMediaModelView GetApconApprovalView(int Id)
        {
            var ApconList = this.lookupRepository.GetApconApprovalPriceById(Id);

            return this.printFactory.GetApconPriceViews(ApconList);
        }


        /// <summary>
        /// Gets the design element price view.
        /// </summary>
        /// <param name="designElementPriceId">The design element price identifier.</param>
        /// <returns></returns>
        public IPrintMediaModelView GetDesignElementPriceView(int designElementPriceId)
        {
            var DesignPriceList = this.lookupRepository.GetDesignElementPriceAmountById(designElementPriceId);

            return this.printFactory.GetDesignElementViews(DesignPriceList);
        }


        /// <summary>
        /// Updates the cart.
        /// </summary>
        public void UpdateCart()
        {
            //Get Current Cart Value
            var cart = 0;
            var PrintMedia = 0;

            var isTvCartValueExist = this.session.CheckCurrentSessionValueExists(SessionKey.TvCart);
            var isRadioCartValueExist = this.session.CheckCurrentSessionValueExists(SessionKey.RadioCart);
            var isOnlineCartValueExist = this.session.CheckCurrentSessionValueExists(SessionKey.OnlineCart);
            var isBrandingCartValueExist = this.session.CheckCurrentSessionValueExists(SessionKey.BrandingCart);
            var isPrintMediaCartValueExist = this.session.CheckCurrentSessionValueExists(SessionKey.PrintMediaCart);


            if (isPrintMediaCartValueExist)
            {
                var orders = new List<IPrintMediaModelView>();
                orders = (List<IPrintMediaModelView>) this.session.GetSessionValue(SessionKey.PrintMediaCart);
                PrintMedia = orders.Count;
                cart += PrintMedia;
            }


            //TODO: Radio Order, Online Order, Print Media, Brading Order

            this.session.AddValueToSession(SessionKey.CartNumber, cart);
        }

        /// <summary>
        /// Deletes the print order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public string DeletePrintOrder(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }
            return this.printRepository.DeletePrintOrder(transactionId);
        }

        /// <summary>
        /// Gets the print.
        /// </summary>
        /// <param name="transactionId">The identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">priceById</exception>
        public IPrintMediaModelView GetPrint(int transactionId, int userId, string message)
        {
            //Print Transaction
            var printTransaction = this.lookupRepository.GetPrintTransactionById(transactionId, userId);
            // get files description
            if (printTransaction.MaterialDigitalFileId > 0)
            {
                var materialFileDetail =
                    this.digitalFileRepository.GetDigitalFileDetail(printTransaction.MaterialDigitalFileId??0);

                printTransaction.PrintFileDescription = materialFileDetail == null ? "" : materialFileDetail.Filename;
            }

            if (printTransaction == null)
            {
                throw new ApplicationException(nameof(printTransaction));
            }

            //Apcon Approval List
            var ApconPriceList = this.lookupRepository.GetPrintMedia();

            var apconList = this.lookupRepository.GetActiveAPCONApprovalTypeList();
            //Design Element List
            //var DesignElementList = this.lookupRepository.GetDesignElementPriceList();
            var DesignElementList = this.lookupRepository.GetPrintDesignElementPriceList();
            //Print Category List
            var CategoryList = this.lookupRepository.GetPrintCategoriesList();

            //Colors List
            var ColorList = this.lookupRepository.GetColor();

            //NewsPaper List
            var NewspaperList = this.lookupRepository.GetNewsPaperList();

            //Print Service Types List
            var ServiceTypeList = this.lookupRepository.GetPrintServiceTypeList();

            //DurationList 
            var DurationList = this.lookupRepository.GetDurationList();

            //printColor
            var printColor = this.printRepository.GetPrintServiceColors();

            //Get Print Airing List
            var printTransactionAiring = this.printRepository.GetPrintTransactionAiringList(transactionId);


            var printMediaType = this.printRepository.GetActivePMediaType();

            var selectedNewsPaperIds = printTransactionAiring.Select(x => x.NewsPaperId).ToList();
            var viewModel = this.printFactory.EditPrintView(ApconPriceList,apconList, DesignElementList,
                  CategoryList, ColorList, NewspaperList, ServiceTypeList, DurationList, printTransaction,
                  printTransactionAiring,selectedNewsPaperIds,printColor,printMediaType);

            return viewModel;
        }


        /// <summary>
        /// Processes the edit print.
        /// </summary>
        /// <param name="printInfo">The print information.</param>
        /// <param name="artworkFile">The artwork file.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">view</exception>
        public string ProcessEditPrint(IPrintTransactionUI printTransactionUi, IEnumerable<IPrintTransactionAiringUI> printTransactionAiringUi, HttpPostedFileBase printImageFile
            , out int orderId, IList<int> selectedNewsPapersId)
        {

            int printFileId = 0;

            if (printTransactionUi == null)
            {
                throw new ArgumentNullException(nameof(printTransactionUi));
            }

            if (printTransactionAiringUi == null)
            {
                throw new ArgumentNullException(nameof(printTransactionAiringUi));
            }

            if (selectedNewsPapersId == null)
            {
                throw new ArgumentNullException(nameof(selectedNewsPapersId));
            }

            //Get The Currently Logged User Id
            var userId = (int)this.session.GetSessionValue(SessionKey.UserId);


            // Get order number
            orderId = this.orderServices.GetOrderIdentifier(userId);

            if(printImageFile!=null)
            {
                // save files uploaded by calling digital file services, the id returned will be zero if no files are uploaded - no need to check anything here
                var artWorkProcessingMessage = this.digitalFileServices.SaveFile(FileType.Image, printImageFile, out  printFileId);


            }

            // save print transaction to database
            var selectedTransactionAiringList = printTransactionAiringUi.Where(x => selectedNewsPapersId.Contains(x.NewsPaperId)).ToList();


            printTransactionUi.OrderId = orderId; // Assign Order ID
            printTransactionUi.UserId = userId; //Assign User ID
            if(printFileId>0)
            {
                //Assign PrintID
                printTransactionUi.MaterialDigitalFileId = printFileId;
            } 


            var result = this.printRepository.UpdatePrintTransaction(printTransactionUi);

            if (string.IsNullOrEmpty(result))
            {
                // delete previously saved print airing transactions
                var deleteResult = this.printRepository.DeletePrintTransactionAiring(printTransactionUi.PrintTransactionId);


                // save transaction airing info also
                result = printRepository.SavePrintTransactionAiring( selectedTransactionAiringList, printTransactionUi.PrintTransactionId);

            }

            //Update The Cart For The User
            this.transactionService.UpdateCart(orderId);

            return result;
        }

        
        /// <summary>
        /// Gets the updated print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <returns></returns>
        public IPrintServiceTypePriceView GetUpdatedPrintServiceTypePriceView(
            IPrintServiceTypePriceView printServiceTypePriceView)
        {
            var printServiceType = this.lookupRepository.GetPrintServiceTypeList();
            var newsPaper = this.lookupRepository.GetNewsPaperList();
            var printColor = this.printRepository.GetPrintServiceColors();
            var printMediaType = this.printRepository.GetActivePMediaType();
            return this.printFactory.GetUpdatedPrintServiceTypePriceView(printServiceTypePriceView, newsPaper,
                printServiceType,printColor,printMediaType);
        }

        /// <summary>
        /// Gets the updated newspaper view.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public INewsPaperView GetUpdatedNewspaperView(INewsPaperView newsPaperView, string message)
        {
            return this.printFactory.getUpdatedNewsPaperView(newsPaperView, message);
        }




        /// <summary>
        /// Gets the updated newspaper view.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintMediaType getUpdatedPrintMediaType(IPrintMediaType printMediaType, string message)
        {
            return this.printFactory.getUpdatedPrintMediaType(printMediaType, message);
        }
        /// <summary>
        /// Gets the type of the updated print serrvice.
        /// </summary>
        /// <param name="printServiceType">Type of the print service.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintServiceTypeView GetUpdatedPrintSerrviceType(IPrintServiceTypeView printServiceType, string message)
        {
            return this.printFactory.getUpdatedPrintServiceTypeView(printServiceType, message);
        }

        /// <summary>
        /// Gets the updated print category view.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintCategoryView GetUpdatedPrintCategoryView(IPrintCategoryView printCategoryView, string message)
        {
            return this.printFactory.getUpdatedPrintCategoryView(printCategoryView, message);
        }




       

        /// <summary>
        /// Gets the print airing.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        public IPrintTransactionAiringView GetPrintAiring(int Id, string message)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Id));
            }

            //Get all data from database
            var newspaperList = this.lookupRepository.GetNewsPaperList();
            var serviceType = this.lookupRepository.GetPrintServiceTypeList();

            //Pass the items to the factory to generate view

            var model = this.printFactory.GenerateAiringView(Id, newspaperList, serviceType, message);
            return model;
        }


        /// <summary>
        /// Processes the print airing view.
        /// </summary>
        /// <param name="airingInfo">The airing information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">airingInfo</exception>
        public string ProcessPrintAiringView(IPrintTransactionAiringView airingInfo)
        {
            if (airingInfo == null)
            {
                throw new ArgumentNullException(nameof(airingInfo));
            }


            //Store The Airing Information to the Database

            return this.printRepository.SavePrintTransactionAiring(airingInfo);
        }


        /// <summary>
        /// Gets the news paper price.
        /// </summary>
        /// <param name="newspaper">The newspaper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        public decimal GetNewsPaperPrice(int newspaper, int serviceType,int serviceColorId,int PrintMediaTypeId)
        {
            var price = this.printRepository.GetServiceType(newspaper, serviceType,serviceColorId,PrintMediaTypeId);

            return price?.Amount ?? 0;
        }

        /// <summary>
        /// Gets the user print transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public IPrintMediaModelView GetUserPrintTransaction(int transactionId)
        {
            

            var printTransaction = this.printRepository.GetPrintTransactionById(transactionId);
            var printAiringTransaction = this.printRepository.GetPrintTransactionAiringById(transactionId);
            return this.printFactory.GetUserPrintTransaction(printTransaction, printAiringTransaction);
        }


        /// <summary>
       /// Gets the delete news paper.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        public INewsPaperView GetDeleteNewsPaper(INewsPaperView newsPaperView, int newsPaperId)
        {
            var description = this.lookupRepository.GetNewsPaperDescriptionById(newsPaperId);

            return this.printFactory.CreateEditNewsPaperView(newsPaperView, description);
        }


        /// <summary>
        /// Gets the print service color view model.
        /// </summary>
        /// <returns></returns>
        public IPrintServiceColor GetPrintServiceColorViewModel()
        {
            return this.printFactory.CreatePrintServiceColorView();
        }

        /// <summary>
        /// Gets the color of the updated print service.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintServiceColor getUpdatedPrintServiceColor(IPrintServiceColor printServiceColor, string message)
        {
            return this.printFactory.GetUpdatedPrintServiceColor(printServiceColor, message);
        }

      

        /// <summary>
        /// Processes the print service information.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <returns></returns>
        public string ProcessPrintServiceInfo(IPrintServiceColor printServiceColor)
        {
            if (printServiceColor == null)
            {
                throw new ArgumentNullException(nameof(printServiceColor));
            }

            string processingMessage = string.Empty;

            //Checking If The Print Service nGeame already existed

            var PrintService = this.printRepository.GetPrintServiceColorDescriptionByName(printServiceColor.PrintServiceTypeColor);

            if (PrintService != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.SaveAddPrintServiceColor(printServiceColor);
            }


            return processingMessage;
        }

        /// <summary>
        /// Gets the print service color ListView model.
        /// </summary>
        /// <param name="SelectedPrintServiceTypeColorId">The selected print service type color identifier.</param>
        /// <param name="SelectedPrintServiceTypeColor">Color of the selected print service type.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintServiceColorListView GetPrintServiceColorListViewModel(int SelectedPrintServiceTypeColorId,
         string SelectedPrintServiceTypeColor, string message)
        {
            var TheCollection = this.lookupRepository.GetPrintServiceColorList();

      
            var viewModel = this.printFactory.CreatePrintServiceColorListView(SelectedPrintServiceTypeColorId,
                 SelectedPrintServiceTypeColor, TheCollection, message);

            return viewModel;
        }


        /// <summary>
        /// Processes the update print service information.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceColor</exception>
        public string ProcessUpdatePrintServiceInfo(IPrintServiceColor printServiceColor)
        {
            if (printServiceColor == null)
            {
                throw new ArgumentNullException(nameof(printServiceColor));
            }

            var processingMessage = string.Empty;

            var newsPaper = this.printRepository.GetPrintServiceColorDescriptionByName(printServiceColor.PrintServiceTypeColor);

            if (newsPaper != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.printRepository.UpdatePrintServiceColorInfo(printServiceColor);
            }


            return processingMessage;
        }

        /// <summary>
        /// Gets the color of the updated print service.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintServiceColor GetUpdatedPrintServiceColor(IPrintServiceColor printServiceColor, string message) 
        {
            return this.printFactory.GetUpdatedPrintServiceColor(printServiceColor, message);
        }

        /// <summary>
        /// Gets the color of the edit print service.
        /// </summary>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        public IPrintServiceColor GetEditPrintServiceColor(int printServiceTypeColorId)
        {
            var printServiceColor = this.lookupRepository.GetPrintServieColorById(printServiceTypeColorId);

            return this.printFactory.CreateEditPrintServiceColorView(printServiceColor);
        }


        /// <summary>
        /// Processes the color of the delete print service.
        /// </summary>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        public string ProcessDeletePrintServiceColor(int printServiceTypeColorId)
        {

            var printServiceColor = this.printRepository.DeletePrintServiceColorDescription(printServiceTypeColorId);

            return printServiceColor;
        }

       
        

        
       
       

       
      

        public IPrintServiceColor GetDeletePrintServiceColor(IPrintServiceColor printServiceColor,int printServiceTypeColorId)
        {
            
                var PrintServiceTypeColor = this.lookupRepository.GetPrintServiceColorDescriptionById(printServiceTypeColorId);

                printServiceColor.PrintServiceTypeColorId = printServiceTypeColorId;
                return this.printFactory.CreateEditPrintServiceColorView(printServiceColor);
            
        }

        public string GetDeletePrintServiceColor(int printServiceTypeColorId)
        {
            var returnMessage = this.printRepository.DeletePrintServiceColorDescription(printServiceTypeColorId);

            return returnMessage;
        }
    }
}

