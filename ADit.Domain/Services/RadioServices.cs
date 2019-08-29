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
    /// <seealso cref="ADit.Interfaces.IRadioServices" />
    public class RadioServices : IRadioServices
    {
        private readonly IEnvironment environment;
        private readonly IEmailFactory emailFactory;
        private readonly IEmail emailService;
        private readonly IRadioViewsModelFactory radioViewsModelFactory;
        private readonly ISessionStateService session;
        private readonly IGeneralFactory lookupFactory;
        private readonly ILookupRepository lookupRepository;
        private readonly IRadioRepository radioRepository;
        private readonly IDigitalFileServices digitalFileServices;
        private readonly IGeneralRepository generalRepository;

        private readonly IDigitalFileRepository digitalFileRepository;
        private readonly ILookupService lookUpServices;
        private readonly IOrderServices orderServices;
        private readonly ITransactionService transactionService;

        private readonly IOrderRepository orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioServices" /> class.
        /// </summary>
        /// <param name="radioViewsModelFactory">The radio views model factory.</param>
        /// <param name="emailService">The email service.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="emailFactory">The email factory.</param>
        /// <param name="session">The session.</param>
        /// <param name="lookupRepository">The lookup repository.</param>
        /// <param name="radioRepository">The radio repository.</param>
        /// <param name="lookupFactory">The lookup factory.</param>
        /// <param name="digitalFileServices">The digital file services.</param>
        /// <param name="generalRepository">The general repository.</param>
        /// <param name="digitalFileRepository">The digital file repository.</param>
        /// <param name="messageRepository">The message repository.</param>
        /// <param name="lookUpServices">The look up services.</param>
        /// <param name="orderServices">The order services.</param>
        /// <param name="transactionService">The transaction service.</param>
        public RadioServices(IRadioViewsModelFactory radioViewsModelFactory, IEmail emailService,
            IOrderRepository orderRepository, IEnvironment environment, IEmailFactory emailFactory,
            ISessionStateService session, ILookupRepository lookupRepository, IRadioRepository radioRepository,
            IGeneralFactory lookupFactory, IDigitalFileServices digitalFileServices,
            IGeneralRepository generalRepository, IDigitalFileRepository digitalFileRepository,
            ILookupService lookUpServices, IOrderServices orderServices, ITransactionService transactionService)
        {
            this.radioRepository = radioRepository;
            this.radioViewsModelFactory = radioViewsModelFactory;
            this.session = session;
            this.lookupRepository = lookupRepository;
            this.lookupFactory = lookupFactory;
            this.digitalFileServices = digitalFileServices;
            this.generalRepository = generalRepository;
            this.digitalFileRepository = digitalFileRepository;
            this.orderRepository = orderRepository;
            this.lookUpServices = lookUpServices;
            this.environment = environment;
            this.emailFactory = emailFactory;
            this.emailService = emailService;
            this.orderServices = orderServices;
            this.transactionService = transactionService;
        }

        /// <summary>
        /// Gets the radio main view.
        /// </summary>
        /// <returns>
        /// IRadioTransactionUIView.
        /// </returns>
        public IRadioTransactionUIView GetRadioMainView()
        {
            //Get Active Apcon Approval List
            var approvalList = lookupRepository.GetActiveAPCONApprovalTypeList();

            //Get Only Active Material Type For Radio
            var activeMaterialType = lookupRepository.GetActiveMaterialTypeForRadio();

            // Get Radio Station Lists
            var radioStationList = lookupRepository.GetRadioStationList();

            // Get Timing
            var timing = this.lookupRepository.GetTiming();

            // var timing = lookupRepository.GetRadioTiming();

            //Get Scripting Questions from the Database
            var scriptMaterialQuestion = lookupRepository.GetScriptMaterialQuestionList();

            //Time Belt
            var timeBeltList = lookupRepository.GetTimeBelts();

            // build view model from factory
            var viewModel = radioViewsModelFactory.CreateRadioMainView(approvalList, radioStationList,
                timing, scriptMaterialQuestion, activeMaterialType, timeBeltList);


            return viewModel;
        }

        /// <summary>
        /// Gets the radio main view.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns>
        /// IRadioTransactionUIView.
        /// </returns>
        public IRadioTransactionUIView GetRadioMainView(IRadioTransactionUI radioMainTransaction,
            IEnumerable<IRadioTransactionAiringUI> transactionAiring,
            List<int> selectedRadioStationIds, string processingMessage)
        {
            //Get Active Apcon Approval List
            var approvalList = lookupRepository.GetActiveAPCONApprovalTypeList();

            //Get Only Active Material Type For Radio
            var activeMaterialType = lookupRepository.GetActiveMaterialTypeForRadio();

            // Get Radio Station Lists
            var radioStationList = lookupRepository.GetRadioStationList();

            // Get Timing 
            var timing = lookupRepository.GetTiming();

            //Get Scripting Questions from the Database
            var scriptMaterialQuestion = lookupRepository.GetScriptMaterialQuestionList();

            //Time Belt
            var timeBeltList = lookupRepository.GetTimeBelts();

            // build view model from factory
            var viewModel = radioViewsModelFactory.CreateRadioMainView(approvalList, radioStationList, timing,
                scriptMaterialQuestion,
                activeMaterialType, timeBeltList, radioMainTransaction, transactionAiring, selectedRadioStationIds,
                processingMessage);

            return viewModel;
        }


        /// <summary>
        /// Gets the radio main view by transaction identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>IRadioMainView.</returns>
        public IRadioTransactionUIView GetRadioMainViewByTransactionId(int transactionId)
        {
            //Get Active Apcon Approval List
            var approvalList = lookupRepository.GetActiveAPCONApprovalTypeList();

            //Get Only Active Material Type For Radio
            var activeMaterialType = lookupRepository.GetActiveMaterialTypeForRadio();

            // Get Radio Station Lists
            var radioStationList = lookupRepository.GetRadioStationList();


            // Get Timing
            var timing = this.lookupRepository.GetTiming();

            //Get Scripting Questions from the Database
            var scriptMaterialQuestion = lookupRepository.GetScriptMaterialQuestionList();

            //Time Belt
            var timeBeltList = lookupRepository.GetTimeBelts();

            // Get the radio transaction from repository
            var radioMainTransaction = this.radioRepository.GetRadioMainTransactionById(transactionId);

            // Get radio transaction airing from repository
            var transactionAiring = this.radioRepository.GetRadioTransactionAiringById(transactionId).ToList();

            // compute selectedIds
            var selectedRadioStationIds = transactionAiring.Select(x => x.RadioStationId).ToList();

            // get files description
            if (radioMainTransaction.MaterialDigitalFileId > 0)
            {
                var materialFileDetail =
                    this.digitalFileRepository.GetDigitalFileDetail(radioMainTransaction.MaterialDigitalFileId);

                radioMainTransaction.MaterialFileDescription =
                    materialFileDetail == null ? "" : materialFileDetail.Filename;
            }

            if (radioMainTransaction.ScriptDigitalFileId > 0)
            {
                var scriptFileDetail =
                    this.digitalFileRepository.GetDigitalFileDetail(radioMainTransaction.ScriptDigitalFileId);

                radioMainTransaction.ScriptFileDescription = scriptFileDetail == null ? "" : scriptFileDetail.Filename;
            }

            // build view model from factory
            var viewModel = radioViewsModelFactory.CreateRadioMainView(approvalList, radioStationList, timing,
                scriptMaterialQuestion,
                activeMaterialType, timeBeltList, radioMainTransaction, transactionAiring, selectedRadioStationIds, "");

            return viewModel;
        }


        /// <summary>
        /// Processes the radio main information.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>System.String.</returns>
        public string ProcessRadioMainInfo(IRadioTransactionUI radioMainTransaction,
            IEnumerable<IRadioTransactionAiringUI> transactionAiring, List<int> selectedRadioStationIds,
            HttpPostedFileBase scriptingMaterial, HttpPostedFileBase productionMaterial, out int orderId)
        {
            if (radioMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioMainTransaction));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedRadioStationIds == null)
            {
                throw new ArgumentNullException(nameof(selectedRadioStationIds));
            }

            orderId = -1;

            // save files uploaded by calling digital file services, the id returned will be zero if no files are uploaded - no need to check anything here
            var processingScriptMessage =
                digitalFileServices.SaveFile(FileType.Image, scriptingMaterial, out var digitalScriptFileId);
            var processingProductionMessage =
                digitalFileServices.SaveFile(FileType.Image, productionMaterial, out var digitalProductionFileId);

            // check that both files saved correctly
            if (!string.IsNullOrEmpty(processingScriptMessage) && !string.IsNullOrEmpty(processingProductionMessage))
            {
                var message = string.Format("{0}-{1}", processingProductionMessage, processingScriptMessage);
                return message;
            }

            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);

            // Get order id
            orderId = orderServices.GetOrderIdentifier(userId);

            // save radio transaction to database
            var selectedTransactionAiringList =
                transactionAiring.Where(x => selectedRadioStationIds.Contains(x.RadioStationId)).ToList();

            radioMainTransaction.OrderId = orderId;
            radioMainTransaction.UserId = userId;
            radioMainTransaction.ScriptDigitalFileId = digitalScriptFileId;
            radioMainTransaction.MaterialDigitalFileId = digitalProductionFileId;

            var result = radioRepository.SaveRadioTransactionInfo(radioMainTransaction, out var radioTransactionId);
            if (string.IsNullOrEmpty(result) && (radioTransactionId > 0))
            {
                // save transaction airing info also
                result = radioRepository.SaveRadioTransactionAiring(radioTransactionId, selectedTransactionAiringList);
            }

            //Update The Cart For The User
            transactionService.UpdateCart(orderId);

            return result;
        }

        /// <summary>
        /// Updates the radio main information.
        /// </summary>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns>System.String.</returns>
        public string UpdateRadioMainInfo(IRadioTransactionUI radioMainTransaction,
            IEnumerable<IRadioTransactionAiringUI> transactionAiring,
            List<int> selectedRadioStationIds, HttpPostedFileBase scriptingMaterial,
            HttpPostedFileBase productionMaterial)
        {
            if (radioMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioMainTransaction));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedRadioStationIds == null)
            {
                throw new ArgumentNullException(nameof(selectedRadioStationIds));
            }

            // save files uploaded by calling digital file services, the id returned will be zero if no files are uploaded - no need to check anything here
            var processingScriptMessage =
                digitalFileServices.SaveFile(FileType.Image, scriptingMaterial, out var digitalScriptFileId);
            var processingProductionMessage =
                digitalFileServices.SaveFile(FileType.Image, productionMaterial, out var digitalProductionFileId);

            // check that both files saved correctly
            if (!string.IsNullOrEmpty(processingScriptMessage) && !string.IsNullOrEmpty(processingProductionMessage))
            {
                var message = string.Format("{0}-{1}", processingProductionMessage, processingScriptMessage);
                return message;
            }

            //Get The Currently Logged User Id
            var userId = (int) session.GetSessionValue(SessionKey.UserId);

            // save radio transaction to database
            var selectedTransactionAiringList =
                transactionAiring.Where(x => selectedRadioStationIds.Contains(x.RadioStationId)).ToList();

            radioMainTransaction.UserId = userId;
            radioMainTransaction.ScriptDigitalFileId = digitalScriptFileId < 1
                ? radioMainTransaction.ScriptDigitalFileId
                : digitalScriptFileId;
            radioMainTransaction.MaterialDigitalFileId = digitalProductionFileId < 1
                ? radioMainTransaction.MaterialDigitalFileId
                : digitalProductionFileId;

            var result = radioRepository.UpdateRadioTransactionInfo(radioMainTransaction);
            if (string.IsNullOrEmpty(result))
            {
                // delete previously saved radio airing transactions
                var deleteResult =
                    this.radioRepository.DeleteRadioTransactionAiring(radioMainTransaction.RadioTransactionId);


                // save transaction airing info also
                result = radioRepository.SaveRadioTransactionAiring(radioMainTransaction.RadioTransactionId,
                    selectedTransactionAiringList);
            }

            //Update The Cart For The User
            transactionService.UpdateCart(radioMainTransaction.OrderId);

            return result;
        }

        /// <summary>
        /// Deletes the radio order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public string DeleteRadioOrder(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }

            return this.radioRepository.DeleteRadioOrder(transactionId);
        }

        /// <summary>
        /// Gets the radio station effective price.
        /// </summary>
        /// <param name="tvStationId">The tv station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <param name="timeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        public decimal GetRadioStationEffectivePrice(int tvStationId, int timingId, int timeBeltId,int materialTypeId)
        {
            var tvPrices = radioRepository.GetRadioEffectivePrice(tvStationId, timingId, timeBeltId,materialTypeId);
            return tvPrices?.Amount ?? 0;
        }


        /// <summary>
        /// Gets the radio station by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">radioById</exception>
        public IRadioStationView GetRadioStationById(int Id, string message)
        {
            var radioById = lookupRepository.GetRadioStationById(Id);
            if (radioById == null)
            {
                throw new ApplicationException(nameof(radioById));
            }

            return radioViewsModelFactory.GetEditRadioStationTypeView(radioById, message);
        }


        /// <summary>
        /// Processes the delete radio station.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">radio</exception>
        public string ProcessDeleteRadioStation(int radio)
        {
            if (radio < 1)
            {
                throw new ArgumentOutOfRangeException("radio");
            }

            var delete = radioRepository.DeleteRadioStation(radio);
            return delete;
        }

        /// <summary>
        /// Processes the radio main information.
        /// </summary>
        /// <param name="radioInfo">The radio information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">radioInfo</exception>
        public string ProcessRadioStation(IRadioStationView radioInfo)
        {
            if (radioInfo == null)
            {
                throw new System.ArgumentNullException(nameof(radioInfo));
            }


            var processingMessage = string.Empty;

            //check if data already exists in the database
            var valueEntered = radioRepository.GetRadioDescriptionByValue(radioInfo.Description);
            var IsRecordExist = (valueEntered == null) ? false : true;

            if (IsRecordExist)
            {
                processingMessage = Messages.RadioStationExists;
                return processingMessage;
            }


            //TODO: all process must return string to the controller
            //Save to database
            var apconView = radioRepository.SaveRadioStation(radioInfo);


            return apconView;
        }

        /// <summary>
        /// Gets the production price view.
        /// </summary>
        /// <returns></returns>
        public IMaterialProductionPriceView GetProductionPriceView()
        {
            var materialType = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();

            var viewModel = radioViewsModelFactory.CreateMaterialProductionPriceView(serviceType, materialType);

            return viewModel;
        }


        /// <summary>
        /// Gets the production price view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IMaterialProductionPriceView GetProductionPriceView(IMaterialProductionPriceView view, string message)
        {
            var materialType = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();

            var viewModel =
                radioViewsModelFactory.CreateMaterialProductionPriceView(serviceType, materialType, view, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the production price information.
        /// </summary>
        /// <param name="productionInfo">The production information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">productionInfo</exception>
        public string ProcessProductionPriceInfo(IMaterialProductionPriceView productionInfo)
        {
            if (productionInfo == null)
            {
                throw new System.ArgumentNullException(nameof(productionInfo));
            }

            var processingmessage = string.Empty;
            var isDataOkay = true;

            var materialType = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();

            if (productionInfo.MaterialTypeId.Equals(-1) && productionInfo.ServiceTypeCode == "")
            {
                processingmessage = Messages.SelectOption;
                isDataOkay = false;
            }

            if (!isDataOkay)
            {
                return processingmessage;
            }

            var saveData = radioRepository.SaveProductionPrice(productionInfo);


            return saveData;
        }


        /// <summary>
        /// Gets the scripting price view.
        /// </summary>
        /// <returns></returns>
        public IMaterialScriptingPriceView GetScriptingPriceView()
        {
            var materialType = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();

            var viewModel = radioViewsModelFactory.CreateMaterialScriptingPriceView(serviceType, materialType);

            return viewModel;
        }

        /// <summary>
        /// Gets the scripting price view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IMaterialScriptingPriceView GetScriptingPriceView(IMaterialScriptingPriceView view, string message)
        {
            var materialType = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();

            var viewModel =
                radioViewsModelFactory.CreateMaterialScriptingPriceView(serviceType, materialType, view, message);

            return viewModel;
        }

        /// <summary>
        /// Processes the scripting price information.
        /// </summary>
        /// <param name="scriptingInfo">The scripting information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">scriptingInfo</exception>
        public string ProcessScriptingPriceInfo(IMaterialScriptingPriceView scriptingInfo)
        {
            if (scriptingInfo == null)
            {
                throw new System.ArgumentNullException(nameof(scriptingInfo));
            }

            var processingmessage = string.Empty;

            var saveData = radioRepository.SaveScriptingPrice(scriptingInfo);

            var materialType = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();
            return saveData;
        }


        /// <summary>
        /// Processes the edit scripting price.
        /// </summary>
        /// <param name="scriptview">The scriptview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">scriptview</exception>
        public string ProcessEditScriptingPrice(IMaterialScriptingPriceView scriptview)
        {
            if (scriptview == null)
            {
                throw new ArgumentNullException(nameof(scriptview));
            }

            string processingMessage = string.Empty;

            processingMessage = generalRepository.EditMaterialScriptingPrice(scriptview);
            var servicetype = lookupRepository.GetServiceType();
            var materialtype = lookupRepository.GetMaterialType();
            return processingMessage;
        }

        /// <summary>
        /// Processes the edit production price.
        /// </summary>
        /// <param name="productionview">The productionview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">productionview</exception>
        public string ProcessEditProductionPrice(IMaterialProductionPriceView productionview)
        {
            if (productionview == null)
            {
                throw new ArgumentNullException(nameof(productionview));
            }

            string processingMessage = string.Empty;
            var servicetype = lookupRepository.GetServiceType();
            var materialtype = lookupRepository.GetMaterialType();

            processingMessage = generalRepository.EditMaterialProductionPrice(productionview);

            return processingMessage;
        }


        /// <summary>
        /// Processes the delete material scripting price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        public string ProcessDeleteMaterialScriptingPrice(int Id)
        {
            if (Id < 1)
            {
                throw new ArgumentOutOfRangeException("Id");
            }

            var materialtype = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();

            var delete = generalRepository.DeleteMaterialScriptingPrice(Id);


            return delete;
        }


        /// <summary>
        /// Processes the delete material production price.
        /// </summary>
        /// <param name="production">The production.</param>
        /// <returns></returns>
        public string ProcessDeleteMaterialProductionPrice(int production)
        {
            var productionDelete = generalRepository.DeleteMaterialProductionPrice(production);

            var materialtype = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();
            return productionDelete;
        }

        /// <summary>
        /// Gets the radio station ListView model.
        /// </summary>
        /// <param name="selectedRadioStationId">The selected radio station identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IRadioSationListView GetRadioStationListViewModel(int selectedRadioStationId, string selectedDescription,
            string message)
        {
            // get radio station collection
            var theCollection = lookupRepository.GetRadioStationList().ToList();

            //Generate list from radio
            var viewModel = radioViewsModelFactory.CreateRadioStationView(theCollection, message,
                selectedRadioStationId, selectedDescription);

            return viewModel;
        }

        /// <summary>
        /// Gets the radio station view.
        /// </summary>
        /// <returns></returns>
        public IRadioStationView GetRadioStationView()
        {
            return radioViewsModelFactory.CreateRadioStation();
        }

        /// <summary>
        /// Deletes the radio by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public string DeleteRadioById(int Id)
        {
            var processingMessage = string.Empty;
            return processingMessage = radioRepository.deleteRadioById(Id);
        }


        /// <summary>
        /// Gets the radio station view.
        /// </summary>
        /// <param name="radioView">The radio view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IRadioStationView GetRadioStationView(IRadioStationView radioView, string message)
        {
            return radioViewsModelFactory.CreateRadioStation(radioView, message);
        }

        /// <summary>
        /// Processes the edit radio.
        /// </summary>
        /// <param name="radioview">The radioview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioview</exception>
        public string ProcessEditRadio(IRadioStationView radioview)
        {
            if (radioview == null)
            {
                throw new ArgumentNullException(nameof(radioview));
            }


            //check if data already exists in the database
            var valueEntered = radioRepository.GetRadioDescriptionByValue(radioview.Description);
            var IsRecordExist = (valueEntered == null) ? false : true;


            var processingMessage = string.Empty;

            if (IsRecordExist)
            {
                processingMessage = Messages.RadioStationExists;
                return processingMessage;
            }

            var editRadio = radioRepository.EditRadioStation(radioview);
            return editRadio;
        }


        /// <summary>
        /// Gets the scripting price view model.
        /// </summary>
        /// <param name="selectedMaterialScriptingPriceId">The selected material scripting price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IScriptingPriceListView GetScriptingPriceViewModel(int selectedMaterialScriptingPriceId,
            string selectedDescription, string selectedServiceTypeCode, string message)
        {
            var theCollection = lookupRepository.GetMaterialScriptingPriceList();

            var viewModel = radioViewsModelFactory.CreateScriptingPriceView(theCollection, message,
                selectedMaterialScriptingPriceId, selectedDescription, selectedServiceTypeCode);

            return viewModel;
        }


        /// <summary>
        /// Gets the material scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IMaterialScriptingPriceView GetMaterialScriptingPriceById(int Id, string message)
        {
            var radioById = lookupRepository.GetMaterialScriptingPriceById(Id);


            var materialtype = lookupRepository.GetMaterialType();

            var serviceType = lookupRepository.GetServiceType();
            return radioViewsModelFactory.EditMaterialScriptingPriceView(serviceType, materialtype, radioById,
                message);
        }

        /// <summary>
        /// Gets the material production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">priceById</exception>
        public IMaterialProductionPriceView GetMaterialProductionPriceById(int Id, string message)
        {
            var priceById = lookupRepository.GetMaterialProductionPriceById(Id);
            if (priceById == null)
            {
                throw new ApplicationException(nameof(priceById));
            }

            var materialtype = lookupRepository.GetMaterialType();

            var serviceType = lookupRepository.GetServiceType();
            return radioViewsModelFactory.EditMaterialProductionPriceView(serviceType, materialtype, priceById,
                message);
        }


        /// <summary>
        /// Gets the delete design element price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IDesignElementPriceView GetDeleteDesignElementPriceById(int Id)
        {
            var getDesignElement = lookupRepository.GetDesignElementPriceById(Id);

            var designElement = lookupRepository.GetDesignElement();
            var serviceType = lookupRepository.GetServiceType();
            return lookupFactory.CreateDeleteDesignElementPriceView(getDesignElement);
        }


        /// <summary>
        /// Gets the delete material production price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IMaterialProductionPriceView GetDeleteMaterialProductionPriceById(int Id)
        {
            var getMaterialProductionPrice = lookupRepository.GetMaterialProductionPriceById(Id);

            var materialType = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();
            return lookupFactory.CreateDeleteMaterialProductionPriceView(getMaterialProductionPrice);
        }


        /// <summary>
        /// Gets the delete material scripting price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IMaterialScriptingPriceView GetDeleteMaterialScriptingPriceById(int Id)
        {
            var getMaterialScriptingPrice = lookupRepository.GetMaterialScriptingPriceById(Id);

            var materialType = lookupRepository.GetMaterialType();
            var serviceType = lookupRepository.GetServiceType();
            return lookupFactory.CreateDeleteMaterialScriptingPriceView(getMaterialScriptingPrice);
        }


        /// <summary>
        /// Gets the production price view model.
        /// </summary>
        /// <param name="selectedMaterialProductionPriceId">The selected material production price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IProductionPriceListView GetProductionPriceViewModel(int selectedMaterialProductionPriceId,
            string selectedDescription, string selectedServiceTypeCode, string message)
        {
            var theCollection = lookupRepository.GetMaterialProductionPriceList();
            var viewModel = radioViewsModelFactory.CreateProductionPriceView(theCollection, message,
                selectedMaterialProductionPriceId, selectedDescription, selectedServiceTypeCode);
            return viewModel;
        }


        /// <summary>
        /// Gets the material timing registration view.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ITiming GetMaterialTimingRegistrationView(int id)
        {
            var timingCollection = lookupRepository.GetTimingCollection(id);

            var viewModel = radioViewsModelFactory.CreateTimingView(timingCollection, id);

            return viewModel;
        }

        /// <summary>
        /// Gets the radio transaction view.
        /// </summary>
        /// <returns></returns>
        public IRadioTransactionView GetRadioTransactionView()
        {
            var apconApprovalTypePriceList = lookupRepository.GetApconApprovalTypePrice();
            var durationTypeList = lookupRepository.GetDurationList();
            var scriptMaterialQuestionList = lookupRepository.GetScriptMaterialQuestionList();
            var materialTypeTimeList = lookupRepository.GetMaterialTypeTimingList();
            var productionPriceList = lookupRepository.GetMaterialProductionPriceList();
            var scriptingPriceList = lookupRepository.GetMaterialScriptingPriceList();
            var radioStationList = lookupRepository.GetRadioStationList();

            var viewModel = radioViewsModelFactory.CreateRadioTransactionView(apconApprovalTypePriceList,
                durationTypeList, scriptMaterialQuestionList,
                materialTypeTimeList, productionPriceList, scriptingPriceList, radioStationList);

            return viewModel;
        }


        /// <summary>
        /// Gets the scripting price view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IRadioMainView GetScriptingPriceView(int Id)
        {
            var radioDDL = lookupRepository.GetRadioScriptingPriceById(Id);

            return radioViewsModelFactory.GetScriptingPriceForRadio(radioDDL);
        }

        /// <summary>
        /// Gets the production price view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IRadioMainView GetProductionPriceView(int Id)
        {
            var radioDDL = lookupRepository.GetRadioProductionPriceById(Id);

            return radioViewsModelFactory.GetProductionPriceForRadio(radioDDL);
        }

        /// <summary>
        /// Gets the edit radio by identifier.
        /// </summary>
        /// <param name="radioMainView">The radio main view.</param>
        /// <returns></returns>
        public string getEditRadioById(IRadioMainView radioMainView)
        {
            var result = string.Empty;

            var radioModel = radioRepository.EditRadioTransactionInfo(radioMainView, out int radioTransactionId);

            return result;
        }

        
        /// <summary>
        /// Gets the radio airing view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">transactionId</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">transactionId</exception>
        public IRadioTransactionAiringView GetRadioAiringView(int transactionId, string processingMessage)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId));
            }


            var radioStationList = lookupRepository.GetRadioStationList();
            var durationTypeList = lookupRepository.GetDurationList();
            var timingList = lookupRepository.GetTiming();

            //Generate and Parse The View

            var model = radioViewsModelFactory.GetRadioAiringView(transactionId, radioStationList,
                durationTypeList, timingList, processingMessage);

            return model;
        }

        /// <summary>
        /// Processes the add radio airing.
        /// </summary>
        /// <param name="radioAiringInfo">The radio airing information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioAiringInfo</exception>
        /// <exception cref="System.ArgumentNullException">radioAiringInfo</exception>
        public string ProcessAddRadioAiring(IRadioTransactionAiringView radioAiringInfo)
        {
            if (radioAiringInfo == null)
            {
                throw new ArgumentNullException(nameof(radioAiringInfo));
            }


            //Store The Airing Information to the Database

            return radioRepository.SaveRadioTransactionAiring(radioAiringInfo);
        }


        /// <summary>
        /// Gets the radio production ListView.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IRadioProductionListView GetRadioProductionListView(int id)
        {
            var radioModel = radioRepository.GetRadioProductionViewById(id);
            var ProductiondigitalFile =
                digitalFileRepository.GetDigitalFileDetail(radioModel.ProductionDigitalFileId ?? -1);
            var radioProductionList = radioRepository.GetRadioProductionList();
            return radioViewsModelFactory.GetRadioMainListView(radioModel, radioProductionList,
                ProductiondigitalFile);
        }

        /// <summary>
        /// Saveradioes the production.
        /// </summary>
        /// <param name="radioProduction">The radio production.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns></returns>
        public string SaveradioProduction(IRadioProductionView radioProduction, HttpPostedFileBase productionMaterial)
        {
            var processingProductionMessage = "";


            var digitalProductionFileId = -1;


            processingProductionMessage =
                digitalFileServices.SaveFile(FileType.Image, productionMaterial, out digitalProductionFileId);

            if (digitalProductionFileId > 0)
            {
                radioProduction.RadioManagerProductionDigitalId = digitalProductionFileId;
            }


            return radioRepository.SaveradioProduction(radioProduction);
        }


        /// <summary>
        /// Gets the radio transaction.
        /// </summary>
        /// <returns></returns>
        public IRadioMainListView GetRadioTransaction()
        {
            var radioTransactionList = radioRepository.GetRadioTranasction();

            return radioViewsModelFactory.getRadioTransaction(radioTransactionList);
        }


        /// <summary>
        /// Updates the radio transaction.
        /// </summary>
        /// <param name="radioMainView">The radio main view.</param>
        /// <param name="scriptingMaterial">The scripting material.</param>
        /// <param name="productionMaterial">The production material.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">radioMainView</exception>
        public string UpdateRadioTransaction(IRadioMainView radioMainView, HttpPostedFileBase scriptingMaterial,
            HttpPostedFileBase productionMaterial)
        {
            var result = string.Empty;
            if (radioMainView == null)
            {
                throw new System.ArgumentNullException(nameof(radioMainView));
            }

            var processingScriptMessage = string.Empty;
            var processingProductionMessage = "";

            var digitalScriptFileId = -1;
            var digitalProductionFileId = -1;

            processingScriptMessage =
                digitalFileServices.SaveFile(FileType.Image, scriptingMaterial, out digitalScriptFileId);

            if (digitalScriptFileId > 0)
            {
                radioMainView.ScriptDigitalFileId = digitalScriptFileId;
            }


            processingProductionMessage =
                digitalFileServices.SaveFile(FileType.Image, productionMaterial, out digitalProductionFileId);

            if (digitalProductionFileId > 0)
            {
                radioMainView.MaterialDigitalFileId = digitalProductionFileId;
            }

            var channels = new List<Dictionary<string, string>>();
            for (var i = 0; i < radioMainView.RadioStationPrice.Length; i++)
            {
                var channel = new Dictionary<string, string>
                {
                    {"Station", radioMainView.RadioStationId[i].ToString()},
                    {"Timing", radioMainView.TimingId[i].ToString()},

                    {"StartDate", radioMainView.StartDate[i].ToString()},
                    {"EndDate", radioMainView.EndDate[i].ToString()},

                    {"Price", radioMainView.RadioStationPrice[i].ToString()},
                    {"TimeBeltId", radioMainView.TimeBeltId[i].ToString()},
                    {"Slots", radioMainView.Slots[i].ToString()},
                    {"totalSlots", radioMainView.totalSlots[i].ToString()},
                };

                channels.Add(channel);
            }

            radioMainView.RadioChannelList = channels;

            if (radioMainView.ApconApprovalTypeId == 1)
            {
                radioMainView.IsHaveApconApproval = true;
                // radioMainView.ap
            }

            if (radioMainView.MaterialDigitalFileId > 0)
            {
                radioMainView.IsHaveMaterial = true;
            }

            var saveTransaction =
                radioRepository.UpdateRadioTransaction(radioMainView);

            var radioAiring = radioRepository.UpdateRadioTransactionAiring(radioMainView);
            return saveTransaction;
        }

        /// <summary>
        /// Gets the user radio order by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IRadioMainView GetUserRadioOrderById(int transactionId, int UserId, string processingMessage)
        {
            var ApprovalList = lookupRepository.GetActiveAPCONApprovalTypeList();
            var MaterialTypeList = radioRepository.GetActiveMaterialTypeForRadio();

            var radioOrder = radioRepository.GetUserRadioOrderById(transactionId);
            var radioAiringDetails = radioRepository.GetRadioTransactionAiring(radioOrder.RadioTransactionId);
            ///Material Question
            var MaterialQuestion = lookupRepository.GetScriptMaterialQuestionList();

            return radioViewsModelFactory.getRadioTransactionById(radioOrder, ApprovalList, MaterialTypeList,
                processingMessage, radioAiringDetails);
        }


        /// <summary>
        /// Gets the radio price.
        /// </summary>
        /// <param name="radioStationId">The radio station identifier.</param>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns></returns>
        public IRadioServicePriceListModel GetRadioPrice(int radioStationId, int timingId,int materialTypeId)
        {
            var radioStationPrice = radioRepository.GetRadioStationPrice(radioStationId, timingId,materialTypeId);

            return radioStationPrice;
        }


        /// <summary>
        /// Gets the script file for download.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IDigitalFile GetScriptFileForDownload(int id)
        {
            var digitalFile =
                digitalFileRepository.GetDigitalFileDetail(id);
            return digitalFile;
        }


       
       
    }
}