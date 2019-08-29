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
    /// <seealso cref="ADit.Interfaces.ITvServices" />
    public class TvServices : ITvServices
    {
        /// <summary>
        /// The environment
        /// </summary>
        private readonly IEnvironment environment;

        private readonly IOrderRepository orderRepository;
       
        private readonly IEmailFactory emailFactory;

        private readonly IEmail emailService;

     
        private readonly ITvRepository tvRepository;
    
        private readonly ITvFactory tvFactory;

        private readonly ILookupRepository lookupRepository;

        private readonly IFormsAuthenticationService formsAuthentication;
      
        private readonly ISessionStateService session;

        private readonly IDigitalFileServices digitalFileServices;

        private readonly ILookupService lookUpServices;

        private readonly IDigitalFileRepository digitalFileRepository;

       
        private readonly IOrderServices orderServices;
       
        private readonly ITransactionService transactionService;

       

      
        public TvServices(ITvRepository tvRepository, IOrderServices orderServices, IEnvironment environment,
            ITransactionService transactionService, IEmailFactory emailFactory, IEmail emailService,
            ITvFactory tvFactory, IDigitalFileServices digitalFileServices,
            ILookupRepository lookupRepository, IFormsAuthenticationService formsAuthentication,
            ISessionStateService session, ILookupService lookUpServices, IOrderRepository orderRepository,
            IDigitalFileRepository digitalFileRepository)
        {
            this.transactionService = transactionService;
            this.orderServices = orderServices;
            this.tvFactory = tvFactory;
            this.tvRepository = tvRepository;
            this.lookupRepository = lookupRepository;
            this.formsAuthentication = formsAuthentication;
            this.digitalFileServices = digitalFileServices;
            this.session = session;
            this.lookUpServices = lookUpServices;
            this.orderRepository = orderRepository;
            this.digitalFileRepository = digitalFileRepository;
            this.emailFactory = emailFactory;
            this.environment = environment;
            this.emailService = emailService;
        }

        /// <summary>
        /// Processes the tv station information.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">tvStationView</exception>
        public string ProcessTvStationInfo(ITvStationView tvStationView)
        {
            if (tvStationView == null)
            {
                throw new ArgumentException("tvStationView");
            }


            var processingMessage = string.Empty;


            //check if data already exists in the database
            var valueEntered = this.tvRepository.GetTvDescriptionByValue(tvStationView.Description);
            var isRecordExist = (valueEntered == null) ? false : true;

            if (isRecordExist)
            {
                processingMessage = Messages.TvStationExist;
                return processingMessage;
            }


            processingMessage = this.tvRepository.SaveTvStationInfo(tvStationView);
            return processingMessage;
        }


        /// <summary>
        /// Gets the tv station view.
        /// </summary>
        /// <returns></returns>
        public ITvStationView GetTvStationView()
        {
            return this.tvFactory.CreateTvStationView();
        }


        /// <summary>
        /// Gets the selected tv station information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ITvStationView GetSelectedTvStationInfo(int id)
        {
            var tvStationById = this.lookupRepository.GetTvStationById(id);
            return this.tvFactory.GetEditTvStationView(tvStationById);
        }


        /// <summary>
        /// Gets the tv station view model.
        /// </summary>
        /// <param name="selectedTvStationId">The selected tv station identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ITvStationListView GetTvStationViewModel(int selectedTvStationId, string selectedDescription,
            string message)
        {
            var theCollection = this.lookupRepository.GetTvStationList().ToList();

            var viewModel = this.tvFactory.CreateTvStationListView(theCollection, message, selectedTvStationId,
                selectedDescription);
            return viewModel;
        }

        /// <summary>
        /// Gets the tvview.
        /// </summary>
        /// <returns></returns>
        public ITVTransactionUIView GetTvview()
        {
            //Get Active Apcon Approval List
            var approvalList = this.lookupRepository.GetActiveAPCONApprovalTypeList();

            //Get Active Material Types
            var materialTypeList = this.lookupRepository.GetActiveMaterialTypeForTv();

            //Material Question
            var materialQuestion = this.lookupRepository.GetScriptMaterialQuestionList();

            //TV Stations
            var tvStationList = this.lookupRepository.GetTvStationList();

            var timingtype = this.lookupRepository.GetTiming();


            //Duration List
            var durationList = this.lookupRepository.GetDurationList();


            //Time Belt
            var timeBeltList = this.lookupRepository.GetTimeBelts();


            //Build view model from factory
            return this.tvFactory.GetTvView(approvalList, materialTypeList, tvStationList, durationList, timingtype,
                materialQuestion, timeBeltList);
        }


        /// <summary>
        /// Processes the delete tv station information.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteTvStationInfo(int tvStationId)
        {
            var tvStation = this.tvRepository.DeleteTvStationInfo(tvStationId);
            return tvStation;
        }


        /// <summary>
        /// Updates the tv station information.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">tvSattionView</exception>
        public string UpdateTvStationInfo(ITvStationView tvStationView)
        {
            if (tvStationView == null)
            {
                throw new ArgumentException("tvSattionView");
            }


            var processingMessage = string.Empty;

            //check if data already exists in the database
            var valueEntered = this.tvRepository.GetTvDescriptionByValue(tvStationView.Description);
            var isRecordExist = (valueEntered == null) ? false : true;

            if (isRecordExist)
            {
                processingMessage = Messages.TvStationExist;
                return processingMessage;
            }


            var tvStation = this.tvRepository.EditTvStation(tvStationView);
            return tvStation;
        }


        /// <summary>
        /// Processes the tv main information.
        /// </summary>
        /// <param name="tvMainTransaction">The tv main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedTvStationIds">The selected tv station ids.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// tvMainTransaction
        /// or
        /// transactionAiring
        /// or
        /// selectedTvStationIds
        /// </exception>
        ///// <param name="tvView"></param> 
        ///// <returns></returns>
        public string processTVMainInfo(ITvTransactionUI tvMainTransaction,
            IEnumerable<ITvTransactionAiringUI> transactionAiring, List<int> selectedTvStationIds,
            HttpPostedFileBase scriptingMaterial, HttpPostedFileBase productionMaterial, out int orderId)
        {
            if (tvMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(tvMainTransaction));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedTvStationIds == null)
            {
                throw new ArgumentNullException(nameof(selectedTvStationIds));
            }


            // save files uploaded by calling digital file services, the id returned will be zero if no files are uploaded - no need to check anything here

            var processingScriptMessage =
                this.digitalFileServices.SaveFile(FileType.Image, scriptingMaterial, out var digitalScriptingFileId);
            var processingProductionMessage = this.digitalFileServices.SaveFile(FileType.Image, productionMaterial,
                out var digitalProductionFileId);

            //User May not have a scripting and/or production material


            //Get The Currently Logged User Id
            var userId = (int) this.session.GetSessionValue(SessionKey.UserId);

            // Get order number
            orderId = this.orderServices.GetOrderIdentifier(userId);


            var selectedTransactionAiringList =
                transactionAiring.Where(x => selectedTvStationIds.Contains(x.TvStationId)).ToList();


            tvMainTransaction.OrderId = orderId; //Assign the order ID
            tvMainTransaction.UserId = userId; // Assign the user ID
            tvMainTransaction.ScriptDigitalFileId = digitalScriptingFileId; //Assign the ScriptingFileID
            tvMainTransaction.MaterialDigitalFileId = digitalProductionFileId; // Assign the production file ID


            //Save the transactio tot databse
            var result = this.tvRepository.SaveTvTransactionInfo(tvMainTransaction, out var tvTransactionId);
            if (string.IsNullOrEmpty(result) && (tvTransactionId > 0))
            {
                // save transaction airing info also
                result = this.tvRepository.SaveTvTransactionAiring(selectedTransactionAiringList, tvTransactionId);
            }

            //Update The Cart For The User
            this.transactionService.UpdateCart(orderId);

            return result;
        }



        /// <summary>
        /// Checks the tv service.
        /// </summary>
        /// <param name="tVServicePricesList">The t v service prices list.</param>
        /// <returns></returns>
        public bool CheckTvService(ITVServicePricesListView tVServicePricesList)
        {
            return this.tvRepository.CheckTvServiceprice(tVServicePricesList);
        }
        /// <summary>
        /// Deletes the tv order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public string DeleteTvOrder(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }
            return this.tvRepository.DeleteTvOrder(transactionId);
        }

        /// <summary>
        /// Creates the tv transaction updated view.
        /// </summary>
        /// <param name="tvMainTransaction"></param>
        /// <param name="transactionAiring"></param>
        /// <param name="selectedTvStationIds"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public ITVTransactionUIView CreateTvTransactionUpdatedView(ITvTransactionUI tvMainTransaction,
            IEnumerable<ITvTransactionAiringUI> transactionAiring,
            List<int> selectedTvStationIds, string processingMessage)
        {
            //Get Active Apcon Approval List
            var approvalList = this.lookupRepository.GetActiveAPCONApprovalTypeList();

            //Get Active Material Types
            var materialTypeList = this.lookupRepository.GetActiveMaterialTypeForTv();

            //Material Question
            var materialQuestion = this.lookupRepository.GetScriptMaterialQuestionList();

            //TV Stations
            var tvStationList = this.lookupRepository.GetTvStationList();

            //Duration List
            var durationList = this.lookupRepository.GetDurationList();


            //Timing Lists
            var timingList = this.lookupRepository.GetTVTiming();

            //Time Belt
            var timeBeltList = this.lookupRepository.GetTimeBelts();

            var returnViewModel = this.tvFactory.CreateUpdatedView(approvalList, materialTypeList,
                tvStationList, durationList, timingList, materialQuestion,
                timeBeltList, processingMessage, tvMainTransaction, transactionAiring, selectedTvStationIds);


            return returnViewModel;
        }


        /// <summary>
        /// Gets the edit tv cart view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ITVTransactionUIView GetEditTvCartView(int transactionId)
        {
            //Approval Lists
            var approvalList = this.lookupRepository.GetActiveAPCONApprovalTypeList();

            //Material Lists
            var materialTypeList = this.lookupRepository.GetActiveMaterialTypeForTv();


            //Material Question
            var materialQuestion = this.lookupRepository.GetScriptMaterialQuestionList();


            //TV Stations
            var tvStationList = this.lookupRepository.GetTvStationList();

            //Duration List
            var durationList = this.lookupRepository.GetDurationList();


            //Timing Lists

            var timingtype = this.lookupRepository.GetTiming();


            //Get TV timeing belt
            var timeBeltCollection = this.lookupRepository.GetTimeBelts();


            //The Tv Order
            var tvOrder =
                this.tvRepository.GetUserTvOrderById(transactionId); // The the Selected Transaction from the Database

            // get files description
            if (tvOrder.MaterialDigitalFileId > 0)
            {
                var materialFileDetail =
                    this.digitalFileRepository.GetDigitalFileDetail(tvOrder.MaterialDigitalFileId??0);

                tvOrder.MaterialFileDescription = materialFileDetail == null ? "" : materialFileDetail.Filename;
            }

            if (tvOrder.ScriptingDigitalFileId> 0)
            {
                var scriptFileDetail =
                    this.digitalFileRepository.GetDigitalFileDetail(tvOrder.ScriptingDigitalFileId);

                tvOrder.ScriptFileDescription = scriptFileDetail == null ? "" : scriptFileDetail.Filename;
            }
            //Get TV Airing Details
            var tvAiringDetails = this.tvRepository.GetTvTransactionAiringList(tvOrder.TvTransactionId);



            //Selected TVs
            var selectedTvIds = tvAiringDetails.Select(x => x.TvStationId).ToList();


            var model = this.tvFactory.GetTvTransactionEditView(tvOrder, tvAiringDetails, selectedTvIds, approvalList,
                materialTypeList, materialQuestion, tvStationList, durationList,timingtype, timeBeltCollection,
                "");


            return model;
        }


        /// <summary>
        /// Gets the tv airing view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">transactionId</exception>
        public ITVTransactionAiringView GetTvAiringView(int transactionId, string processingMessage)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }


            var tvStationList = this.lookupRepository.GetTvStationList();
            var durationTypeList = this.lookupRepository.GetDurationList();
            var timingList = this.lookupRepository.GetTiming();

            //Generate and Parse The View

            var model = this.tvFactory.GetTvAiringView(transactionId, tvStationList,
                durationTypeList, timingList, processingMessage);

            return model;
        }


        /// <summary>
        /// Processes the add radio airing.
        /// </summary>
        /// <param name="tvAiringInfo">The radio airing information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvAiringInfo</exception>
        /// <exception cref="System.ArgumentNullException">radioAiringInfo</exception>
        public string ProcessAddTVAiring(ITVTransactionAiringView tvAiringInfo)
        {
            if (tvAiringInfo == null)
            {
                throw new ArgumentNullException(nameof(tvAiringInfo));
            }


            //Store The Airing Information to the Database

            return "";
        }


        /// <summary>
        /// Updates the tv transaction.
        /// </summary>
        /// <param name="tvInfo">The tv information.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvInfo</exception>
        /// <exception cref="System.ArgumentNullException">tvInfo</exception>
        public string UpdateTvTransaction(ITvTransactionUI tvMainTransaction,
            IEnumerable<ITvTransactionAiringUI> transactionAiring, List<int> selectedTvStationIds,
            HttpPostedFileBase scriptingMaterial, HttpPostedFileBase productionMaterial, out int orderId)
        {
            if (tvMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(tvMainTransaction));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedTvStationIds == null)
            {
                throw new ArgumentNullException(nameof(selectedTvStationIds));
            }


            // save files uploaded by calling digital file services, the id returned will be zero if no files are uploaded - no need to check anything here

            var processingScriptMessage =
                this.digitalFileServices.SaveFile(FileType.Image, scriptingMaterial, out var digitalScriptingFileId);
            var processingProductionMessage = this.digitalFileServices.SaveFile(FileType.Image, productionMaterial,
                out var digitalProductionFileId);

            //User May not have a scripting and/or production material


            //Get The Currently Logged User Id
            var userId = (int)this.session.GetSessionValue(SessionKey.UserId);

            // Get order number
            orderId = this.orderServices.GetOrderIdentifier(userId);


            var selectedTransactionAiringList =
                transactionAiring.Where(x => selectedTvStationIds.Contains(x.TvStationId)).ToList();


            tvMainTransaction.OrderId = orderId; //Assign the order ID
            tvMainTransaction.UserId = userId; // Assign the user ID
            tvMainTransaction.ScriptDigitalFileId = digitalScriptingFileId; //Assign the ScriptingFileID
            tvMainTransaction.MaterialDigitalFileId = digitalProductionFileId; // Assign the production file ID


            //Save the transactio tot databse
            var result = this.tvRepository.UpdateTvTransaction(tvMainTransaction);
            if (string.IsNullOrEmpty(result))
            {
                // delete previously saved tv airing transactions
                var deleteResult = this.tvRepository.DeleteTvTransactionAiring(tvMainTransaction.TvTransactionId);


                // save transaction airing info also
                result = tvRepository.SaveTvTransactionAiring( selectedTransactionAiringList, tvMainTransaction.TvTransactionId);

            }

            //Update The Cart For The User
            this.transactionService.UpdateCart(orderId);

            return result;
        }

        /// <summary>
        /// Gets the tv station view.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ITvStationView GetTvStationView(ITvStationView tvStationView, string message)
        {
            return this.tvFactory.CreateTvStationView(tvStationView, message);
        }

        /// <summary>
        /// Gets the tv scripting price view.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ITvView GetTvScriptingPriceView(int id)
        {
            var tvDDL = this.lookupRepository.GetTvScriptingPrice(id);

            return this.tvFactory.GetScriptingPriceForTv(tvDDL);
        }


        /// <summary>
        /// Gets the tv production price view.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ITvView GetTvProductionPriceView(int id)
        {
            var tvDDL = this.lookupRepository.GetTvProductionPrice(id);

            return this.tvFactory.GetProductionPriceForTv(tvDDL);
        }

        /// <summary>
        /// Gets the itv service prices list.
        /// </summary>
        /// <param name="selectedTvServicesPriceId">The selected tv services price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ITVServicePricesListMainView GetITVServicePricesList(int selectedTvServicesPriceId,
            string selectedDescription, string message)
        {
            var tvList = this.tvRepository.GetITVServicePricesList();
            return this.tvFactory.GetITVServicePricesList(selectedTvServicesPriceId, selectedDescription, tvList,
                message);
        }

        /// <summary>
        /// Updates the tv service price list.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <returns></returns>
        public string UpdateTvServicePriceList(ITVServicePricesListView tVServicePricesListView)
        {
            return this.tvRepository.UpdateTvServicePriceList(tVServicePricesListView);
        }

        /// <summary>
        /// Saves the tv service price list.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <returns></returns>
        public string saveTvServicePriceList(ITVServicePricesListView tVServicePricesListView)
        {
            return this.tvRepository.saveTvServicePriceList(tVServicePricesListView);
        }

        /// <summary>
        /// Getedits the tv service price ListView.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ITVServicePricesListView GeteditTvServicePriceListView(int id)
        {
            var tvId = this.tvRepository.GeteditTvServicePriceListView(id);

            var tvList = this.lookupRepository.GetTvStationList().ToList();

            var timing = this.lookupRepository.GetTiming().ToList();
            var timingBelt = this.lookupRepository.GetTimeBelts();
            var materialType = this.lookupRepository.GetMaterialType();

            return this.tvFactory.GeteditTvServicePriceListView(tvId, tvList, timing, timingBelt,materialType);
        }


        /// <summary>
        /// Deletes the service price ListView.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string deleteServicePriceListView(int id)
        {
            return this.tvRepository.deleteServicePriceListView(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public ITVServicePricesListView GetTVServicePricesListView()
        {
            var tvList = this.lookupRepository.GetTvStationList();
            var timingtype = this.lookupRepository.GetTiming();
            var timingBelt = this.lookupRepository.GetTimeBelts();
            var materialType = this.lookupRepository.GetMaterialType();
            return this.tvFactory.GetTVServicePricesListView(tvList, timingtype, timingBelt,materialType);
        }


        /// <summary>
        /// Gets the add tv services ListView.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ITVServicePricesListView GetAddTvServicesListView(ITVServicePricesListView tVServicePricesListView,
            string processingMessage)
        {
            var tvList = this.lookupRepository.GetTvStationList();
            var timingtype = this.lookupRepository.GetTiming();
            var timingBelt = this.lookupRepository.GetTimeBelts();
            var material = this.lookupRepository.GetMaterialType();
            return this.tvFactory.GetTVServicePricesListView(tvList, timingtype, timingBelt,material);
        }


        /// <summary>
        /// </summary>
        /// <param name="tVServicePricesListView"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public ITVServicePricesListView GetUpdatedTvServicesListView(ITVServicePricesListView tVServicePricesListView,
            string processingMessage)
        {
            var tvList = this.lookupRepository.GetTvStationList().ToList();
            var timingList = this.lookupRepository.GetTiming().ToList();
            return this.tvFactory.GetUpdatedTvServicesListView(tVServicePricesListView, processingMessage, tvList,
                timingList);
        }

        /// <summary>
        /// Gets the delete service price ListView.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ITVServicePricesListView GetDeleteServicePriceListView(int id)
        {
            var tvId = this.tvRepository.GeteditTvServicePriceListView(id);
            var tvList = this.lookupRepository.GetTvStationList().ToList();
            var timing = this.lookupRepository.GetTiming().ToList();
            var timingBelt = this.lookupRepository.GetTimeBelts();
            var materialType = this.lookupRepository.GetMaterialType();
            return this.tvFactory.GeteditTvServicePriceListView(tvId, tvList, timing, timingBelt,materialType);
        }


        /// <summary>
        /// Gets the tv station effective price.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId"></param>
        /// <returns></returns>
        public decimal GetTvStationEffectivePrice(int tvStationId, int timingId, int timeBeltId,int materialTypeId)
        {
            var tvPrices = this.tvRepository.GetTvEffectivePrice(tvStationId, timingId, timeBeltId,materialTypeId);
            return tvPrices?.Amount ?? 0;
        }

        /// <summary>
       
        

        /// <summary>
        /// Gets the material message replies ListView.
        /// </summary>
        /// <param name="sentToId">The sent to identifier.</param>
        
        /// <summary>
        /// Gets the script message replies ListView.
        /// </summary>
        /// <param name="sentToId">The sent to identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="materialType">Type of the material.</param>
    


        

        
        //gets the order infromation for admin

        /// <summary>
        /// Gets the tv user transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public ITvView GetTvUserTransaction(int transactionId, int userId)
        {
            //Get Radio Order
            var tvOrder = this.tvRepository.GetUserTvOrderById(transactionId
            ); // The the Selected Transaction from the Repos
            var materialType = this.lookupRepository.GetMaterialType();
            //Get Radio Airing Details
            var radioAiringDetails = this.tvRepository.GetTvTransactionAiring(tvOrder.TvTransactionId);
            return this.tvFactory.GetUserTransaction(tvOrder, radioAiringDetails, materialType);
        }


       



        /// <summary>
        /// Gets the script file for download.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IDigitalFile GetScriptFileForDownload(int Id)
        {
            var digitalFile =
                digitalFileRepository.GetDigitalFileDetail(Id);
            return digitalFile;
        }

       
    }
}