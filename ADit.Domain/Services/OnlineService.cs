using System;
using System.Collections.Generic;
using System.Linq;
using ADit.Interfaces;
using AA.Infrastructure.Interfaces;
using System.Web;
using ADit.Domain.Resources;
using ADit.Interfaces.ValueTypes;

namespace ADit.Domain.Services
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineServices" />
    public class OnlineService : IOnlineServices
    {
        /// <summary>
        /// The branding repository
        /// </summary>
        private readonly IBrandingRepository brandingRepository;

        private readonly IEnvironment environment;

        private readonly IOrderRepository orderRepository;

        private readonly IEmailFactory emailFactory;

        private readonly IEmail emailService;

        private readonly IOnlineRepository onlineRepository;

        private readonly IOnlineFactory onlineFactory;

        private readonly ILookupRepository lookupRepository;

        private readonly IFormsAuthenticationService formAuthenticationService;

        private readonly ISessionStateService session;

        private readonly IDigitalFileServices digitalFileServices;


        private readonly IDigitalFileRepository digitalFileRepository;

        private readonly ILookupService lookUpServices;

        private readonly IOrderServices orderServices;

        private readonly ITransactionService transactionService;


        public OnlineService(IOnlineRepository onlineRepository,
            IDigitalFileRepository digitalFileRepository, IEmail emailService, IEmailFactory emailFactory, IEnvironment environment,
            IDigitalFileServices digitalFileServices, IOnlineFactory onlineFactory,
            ILookupRepository lookupRepository, IFormsAuthenticationService formsAuthentication,
            ISessionStateService session, ILookupService lookUpServices, IOrderRepository orderRepository, IOrderServices orderServices, IBrandingRepository brandingRepository, ITransactionService transactionService)
        {
            this.digitalFileServices = digitalFileServices;
            this.onlineFactory = onlineFactory;
            this.onlineRepository = onlineRepository;
            this.lookupRepository = lookupRepository;
            this.formAuthenticationService = formsAuthentication;
            this.session = session;

            this.digitalFileRepository = digitalFileRepository;
            this.lookUpServices = lookUpServices;
            this.environment = environment;
            this.emailFactory = emailFactory;
            this.emailService = emailService;
            this.transactionService = transactionService;
            this.orderServices = orderServices;
            this.brandingRepository = brandingRepository;
            this.orderRepository = orderRepository;
        }

        /// <summary>
        /// Processes the online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        public string ProcessOnlineExtraServiceInfo(IOnlineExtraServiceView onlineExtraServiceView)
        {
            var OnlineExtraServiceInfo = this.onlineRepository.SaveOnlineExtraServiceInfo(onlineExtraServiceView);

            return OnlineExtraServiceInfo;
        }

        /// <summary>
        /// Processes the online platform information.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlinePlatformView</exception>
        public string ProcessOnlinePlatformInfo(IOnlinePlatformView onlinePlatformView)
        {
            if (onlinePlatformView == null)
            {
                throw new ArgumentNullException(nameof(onlinePlatformView));
            }

            var processingMessage = string.Empty;

            //Check For The Exitence of the Value

            var onlinePlatform = this.onlineRepository.GetOnlinePlatformByName(onlinePlatformView.Description);

            if (onlinePlatform != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.onlineRepository.SaveOnlinePlatformInfo(onlinePlatformView);
            }


            return processingMessage;

        }

        /// <summary>
        /// Processes the online purpose information.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        public string ProcessOnlinePurposeInfo(IOnlinePurposeView onlinePurposeView)
        {
            var OnlinePurposeInfo = this.onlineRepository.SaveOnlinePurposeInfo(onlinePurposeView);
            return OnlinePurposeInfo;
        }
        /// <summary>
        /// Creates the online extra service view.
        /// </summary>
        /// <returns></returns>
        public IOnlineExtraServiceView CreateOnlineExtraServiceView()
        {
            return this.onlineFactory.CreateOnlineExtraServiceView();
        }

        /// <summary>
        /// Gets the online platform view.
        /// </summary>
        /// <returns></returns>
        public IOnlinePlatformView GetOnlinePlatformView()
        {
            return this.onlineFactory.CreateOnlinePlatformView();
        }
        /// <summary>
        /// Creates the online purpose view.
        /// </summary>
        /// <returns></returns>
        public IOnlinePurposeView CreateOnlinePurposeView()
        {
            return this.onlineFactory.CreateOnlinePurposeView();

        }

        /// <summary>
        /// Gets the selected online extra service information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlineExtraServiceView GetSelectedOnlineExtraServiceInfo(int Id)
        {
            var onlineExtraServiceById = this.lookupRepository.GetOnlineExtraServiceById(Id);
            return this.onlineFactory.CreateOnlineExtraServiceView(onlineExtraServiceById);


        }

        /// <summary>
        /// Gets the selected online duration information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlineDurationView GetSelectedOnlineDurationInfo(int Id)
        {
            var onlineDurationById = this.lookupRepository.GetOnlineDurationById(Id);
            return this.onlineFactory.CreateOnlineDurationView(onlineDurationById);


        }


        /// <summary>
        /// Gets the online extra service ListView model.
        /// </summary>
        /// <param name="selectedOnlineExtraServiceId">The selected online extra service identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlineExtraServiceListView GetOnlineExtraServiceListViewModel(int selectedOnlineExtraServiceId, string selectedDescription, string message)
        {
            var OnlineExtraServiceList = this.lookupRepository.GetOnlineExtraServiceList().ToList();
            var viewModel = onlineFactory.CreateOnlineExtraServiceListView(OnlineExtraServiceList, selectedOnlineExtraServiceId, selectedDescription, message);
            return viewModel;
        }

        /// <summary>
        /// Gets the selected online platform information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlinePlatformView GetSelectedOnlinePlatformInfo(int Id)
        {
            var OnlinePlatformById = this.lookupRepository.GetOnlinePlatformById(Id);
            return this.onlineFactory.CreateOnlinePlatformView(OnlinePlatformById);

        }

        /// <summary>
        /// Gets the online platform ListView model.
        /// </summary>
        /// <param name="selectedOnlinePlatformId">The selected online platform identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlinePlatformListView GetOnlinePlatformListViewModel(int selectedOnlinePlatformId, string selectedDescription, string message)
        {
            var OnlinePlatformList = this.lookupRepository.GetOnlinePlatformList().ToList();
            var viewModel = this.onlineFactory.CreateOnlinePlatformListView(OnlinePlatformList, selectedOnlinePlatformId, selectedDescription, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the selected online purpose information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlinePurposeView GetSelectedOnlinePurposeInfo(int Id)
        {
            var onlinePurposeById = this.lookupRepository.GetOnlinePurposeById(Id);
            return this.onlineFactory.CreateOnlinePurposeView(onlinePurposeById);
        }

        /// <summary>
        /// Gets the online purpose ListView model.
        /// </summary>
        /// <param name="selectedOnlinePurposeId">The selected online purpose identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlinePurposeListView GetOnlinePurposeListViewModel(int selectedOnlinePurposeId, string selectedDescription, string message)
        {
            var OnlinePurposeList = this.lookupRepository.GetOnlinePurposesList().ToList();
            var viewModel = this.onlineFactory.CreateOnlinePurposeListView(OnlinePurposeList, selectedOnlinePurposeId, selectedDescription, message);

            return viewModel;
        }


        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <returns></returns>
        public IOnlineTransactionUIView GetView()
        {
            //Get platform List
            var onlinePlatformList = this.lookupRepository.GetOnlinePlatformList();

            //Get Extra service
            var onlineExtraServiceList = this.lookupRepository.GetActiveOnlineExtraServiceList();

            //Get Purpose List
            var onlinePurposeList = this.lookupRepository.GetOnlinePurposesList();

            //Get Artwork List
            var onlineArtWorkList = this.lookupRepository.GetOnlineArtworkPriceList();

            //Get Duration
            var onlineDuration = this.lookupRepository.GetOnlineDurationList();

            //Build view model from factory
            return this.onlineFactory.GetOnlineView(onlinePurposeList, onlinePlatformList,
                onlineExtraServiceList, onlineArtWorkList, onlineDuration);
        }



        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="onlineMainTransaction">The online main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedOnlinePlatformIds">The selected online platform ids.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineMainTransaction
        /// or
        /// transactionAiring
        /// or
        /// selectedOnlinePlatformIds</exception>
        public IOnlineTransactionUIView GetUpdatedView(IOnlineTransactionUI onlineMainTransaction, IEnumerable<IOnlineTransactionAiringUI> transactionAiring,
            List<int> selectedOnlinePlatformIds, string processingMessage)
        {
            if (onlineMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(onlineMainTransaction));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedOnlinePlatformIds == null)
            {
                throw new ArgumentNullException(nameof(selectedOnlinePlatformIds));
            }


            var onlinePurposeList = this.lookupRepository.GetOnlinePurposesList();
            var onlinePlatformList = this.lookupRepository.GetOnlinePlatformList();
            var onlineExtraServiceList = this.lookupRepository.GetOnlineExtraServiceList();
            var onlineArtWorkList = this.lookupRepository.GetOnlineArtworkPriceList();
            var onlineDuration = this.lookupRepository.GetOnlineDurationList();

            var returnModel = this.onlineFactory.GetOnlineView(onlinePurposeList, onlinePlatformList, onlineExtraServiceList, onlineArtWorkList, onlineDuration,
               onlineMainTransaction, transactionAiring, selectedOnlinePlatformIds, processingMessage);

            return returnModel;
        }

        /// <summary>
        /// Gets the edit online cart view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IOnlineTransactionUIView GetEditOnlineCartView(int transactionId)
        {
            //Get active online purpose list
            var OnlinePurposeList = this.lookupRepository.GetOnlinePurposesList();

            //Get active online platform list
            var OnlinePlatformList = this.lookupRepository.GetOnlinePlatformList();

            //Get active online extra service list
            var OnlineExtraServiceList = this.lookupRepository.GetActiveOnlineExtraServiceList();

            //Get active artwork price list
            var onlineArtWorkList = this.lookupRepository.GetOnlineArtworkPriceList();

            //Get active online duration list
            var onlineDuration = this.lookupRepository.GetOnlineDurationList();

            //Get userID
            var userId = (int)session.GetSessionValue(SessionKey.UserId);


            //Get active online extra service by Id
            var onlineExtraService = this.onlineRepository.GetOnlineExtraServiceTransactionById(transactionId);


            //Get active online airing transaction by the Id
            var onlineMainTransaction = this.onlineRepository.GetOnlineMainTransaction(transactionId);

            // get files description
            if (onlineMainTransaction.ArtworkDigitalFileId > 0)
            {
                var materialFileDetail =
                    this.digitalFileRepository.GetDigitalFileDetail(onlineMainTransaction.ArtworkDigitalFileId);

                onlineMainTransaction.MaterialFileDescription = materialFileDetail == null ? "" : materialFileDetail.Filename;
            }


            //Get Online Transaction by Id
            var airingTransaction = this.onlineRepository.GetOnlineTransactionAiring(transactionId);

            //Get selected menus
            var selectedPlatformIds = airingTransaction.Select(x => x.OnlinePlatformId).ToList();

            //Generate the viewmodel
            var viewModel = this.onlineFactory.GetOnlineTransactionEditView(OnlinePurposeList, OnlinePlatformList,
                onlineExtraService, onlineArtWorkList, onlineDuration, OnlineExtraServiceList, onlineMainTransaction,
                airingTransaction, selectedPlatformIds, "");

            return viewModel;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string DeleteOrder(int transactionId)
        {
            if (transactionId < 0)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }
            return this.onlineRepository.DeleteOnlineOrder(transactionId);
        }


        /// <summary>
        /// Updates the online platform information.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">onlinePlatformView</exception>
        public string UpdateOnlinePlatformInfo(IOnlinePlatformView onlinePlatformView)
        {
            if (onlinePlatformView == null)
            {
                throw new ArgumentException(nameof(onlinePlatformView));
            }


            var processingMessage = string.Empty;

            //Check For The Exitence of the Value

            var onlinePlatform = this.onlineRepository.GetOnlinePlatformByName(onlinePlatformView.Description);

            if (onlinePlatform != null)
            {
                processingMessage = Messages.DescriptionExist;
            }
            else
            {
                processingMessage = this.onlineRepository.EditOnlinePlatform(onlinePlatformView);
            }




            return processingMessage;
        }

        /// <summary>
        /// Updates the online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">onlineExtraServiceView</exception>
        public string UpdateOnlineExtraServiceInfo(IOnlineExtraServiceView onlineExtraServiceView)
        {
            if (onlineExtraServiceView == null)
            {
                throw new ArgumentException(nameof(onlineExtraServiceView));
            }

            var processingMessage = this.onlineRepository.EditOnlineExtraService(onlineExtraServiceView);
            return processingMessage;
        }

        /// <summary>
        /// Updates the online duration information.
        /// </summary>
        /// <param name="onlineDurationView">The online duration view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">onlineDurationView</exception>
        public string UpdateOnlineDurationInfo(IOnlineDurationView onlineDurationView)
        {
            if (onlineDurationView == null)
            {
                throw new ArgumentException(nameof(onlineDurationView));
            }

            var processingMessage = this.onlineRepository.EditOnlineDuration(onlineDurationView);
            return processingMessage;
        }


        /// <summary>
        /// Updates the online purpose information.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">onlinePurposeView</exception>
        public string UpdateOnlinePurposeInfo(IOnlinePurposeView onlinePurposeView)
        {
            if (onlinePurposeView == null)
            {
                throw new ArgumentException(nameof(onlinePurposeView));
            }
            var processingMessage = this.onlineRepository.EditOnlinePurpose(onlinePurposeView);
            return processingMessage;
        }




        /// <summary>
        /// Processes the delete online extra service information.
        /// </summary>
        /// <param name="onlineExtraServiceId">The online extra service identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteOnlineExtraServiceInfo(int onlineExtraServiceId)
        {
            var ExtraServiceDeleting = this.onlineRepository.DeleteOnlineExtraServiceInfo(onlineExtraServiceId);
            return ExtraServiceDeleting;
        }

        public string ProcessDeleteOnlineDurationInfo(int onlineDurationId)
        {
            var onlineDuration = this.onlineRepository.DeleteOnlineDurationInfo(onlineDurationId);
            return onlineDuration;
        }

        /// <summary>
        /// Processes the delete online platform information.
        /// </summary>
        /// <param name="onlinePlatformId">The online platform identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteOnlinePlatformInfo(int onlinePlatformId)
        {
            var PlatformDeleting = this.onlineRepository.DeleteOnlinePlatformInfo(onlinePlatformId);
            return PlatformDeleting;
        }

        /// <summary>
        /// Processes the delete online purpose information.
        /// </summary>
        /// <param name="onlinePurposeId">The online purpose identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteOnlinePurposeInfo(int onlinePurposeId)
        {
            var PurposeDeleting = this.onlineRepository.DeleteOnlinePurposeInfo(onlinePurposeId);
            return PurposeDeleting;
        }



        /// <summary>
        /// Processviews the specified online view.
        /// </summary>
        /// <param name="onlineMainTransaction">The online main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedOnlinePlatformIds">The selected online platform ids.</param>
        /// <param name="artwork">The artwork.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineView</exception>
        public string Processview(IOnlineTransactionUIView onlineMainTransaction,
            IEnumerable<IOnlineTransactionAiringUI> transactionAiring, List<int> selectedOnlinePlatformIds,
             HttpPostedFileBase artwork, out int orderId)
        {
            if (onlineMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(onlineMainTransaction));
            }
            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }
            if (selectedOnlinePlatformIds == null)
            {
                throw new ArgumentNullException(nameof(selectedOnlinePlatformIds));
            }

            var result = string.Empty;
            orderId = -1;

            // save files uploaded by calling digital file services, the id returned will be zero if no files are uploaded - no need to check anything here


            var processingArtworkMessage = this.digitalFileServices.SaveFile(FileType.Image, artwork, out var digitalArtworkFileId);

            //User may not upload an artwork


            //Get The Currently Logged User Id
            var userId = (int)session.GetSessionValue(SessionKey.UserId);

            // Get order number
            orderId = this.orderServices.GetOrderIdentifier(userId);



            //save Online Transaction to database
            var selectedTransactionAiringList = transactionAiring.Where(x => selectedOnlinePlatformIds.Contains(x.OnlinePlatformId)).ToList();

            onlineMainTransaction.OrderId = orderId;
            onlineMainTransaction.UserId = userId;
            onlineMainTransaction.ArtworkDigitalFileId = digitalArtworkFileId;


            var onlineTransactionId = -1;
            result = this.onlineRepository.SaveOnlineTransactionInfo(onlineMainTransaction, out onlineTransactionId);


            //Save to Extra Service Transaction table
            var save = this.onlineRepository.saveOnlineTransactionExtraService(onlineMainTransaction, onlineTransactionId);


            if (string.IsNullOrEmpty(result) && (onlineTransactionId > 0))
            {
                // save transaction airing info also
                result = this.onlineRepository.SaveOnlineTransactionAiring(onlineTransactionId, selectedTransactionAiringList);



            }

            //Update The Cart For The User
            transactionService.UpdateCart(orderId);

            return result;


        }

        /// <summary>
        /// Updates the online transaction.
        /// </summary>
        /// <param name="onlineView">The online view.</param>
        /// <param name="artwork">The artwork.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineView</exception>
        public string UpdateOnlineTransaction(IOnlineTransactionUI onlineView, IEnumerable<IOnlineTransactionAiringUI> transactionAiring,
            List<int> selectedOnlinePlatformIds, HttpPostedFileBase artWorks, out int orderId)
        {
            if (onlineView == null)
            {
                throw new ArgumentNullException(nameof(onlineView));
            }

            if (transactionAiring == null)
            {
                throw new ArgumentNullException(nameof(transactionAiring));
            }

            if (selectedOnlinePlatformIds == null)
            {
                throw new ArgumentNullException(nameof(selectedOnlinePlatformIds));
            }

            orderId = -1;

            var processingMessage = this.digitalFileServices.SaveFile(FileType.Image, artWorks, out var digitalFileId);

            if (digitalFileId > 0)
            {
                onlineView.ArtworkDigitalFileId = digitalFileId;
                onlineView.IsHaveArtWork = true;
            }


            // check that both files saved correctly
            if (!string.IsNullOrEmpty(processingMessage))
            {
                var message = string.Format("{0}", processingMessage);
                return message;
            }

            //Get The Currently Logged User Id
            var userId = (int)session.GetSessionValue(SessionKey.UserId);

            // Get order id
            orderId = orderServices.GetOrderIdentifier(userId);


            // save radio transaction to database
            var selectedTransactionAiringList = transactionAiring.Where(x => selectedOnlinePlatformIds.Contains(x.OnlinePlatformId)).ToList();

            onlineView.OrderId = orderId;
            onlineView.UserId = userId;
            onlineView.ArtworkDigitalFileId = digitalFileId;


            var result = onlineRepository.UpdateOnlineTransactionInfo(onlineView);


            if (string.IsNullOrEmpty(result))
            {
                // delete previously saved radio airing transactions
                var deleteResult = this.onlineRepository.DeleteOnlineTransactionAiring(onlineView.OnlineTransactionId);


                // save transaction airing info also
                result = onlineRepository.SaveOnlineTransactionAiring(onlineView.OnlineTransactionId, selectedTransactionAiringList);

            }

            //Update The Cart For The User
            transactionService.UpdateCart(onlineView.OrderId);

            return result;
        }



        /// <summary>
        /// Gets the platform package price view model.
        /// </summary>
        /// <param name="SelectedOnlinePlatformPriceId">The selected online platform price identifier.</param>
        /// <param name="SelectedOnlinePlatformId">The selected online platform identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPlatformPackagePriceListView GetPlatformPackagePriceViewModel(int SelectedOnlinePlatformPriceId, int SelectedOnlinePlatformId, string message)
        {
            var theCollection = this.lookupRepository.GetOnlinePlatformPriceList();
            var viewModel = this.onlineFactory.CreatePlatformPackagePriceListView(theCollection, SelectedOnlinePlatformPriceId, SelectedOnlinePlatformId, message);
            return viewModel;
        }

        /// <summary>
        /// Gets the platform package price view.
        /// </summary>
        /// <returns></returns>
        public IOnlinePlatformPackagePriceView GetPlatformPackagePriceView()
        {
            var OnlinePlatform = this.lookupRepository.GetOnlinePlatformList();
            var DurationType = this.lookupRepository.GetDurationList();
            var OnlineDurationType = this.lookupRepository.GetOnlineDurationList();

            var viewModel = this.onlineFactory.CreatePlatfromPackagePriceView(OnlinePlatform, OnlineDurationType, DurationType);

            return viewModel;
        }

        /// <summary>
        /// Gets the platform package price view.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlinePlatformPackagePriceView GetPlatformPackagePriceView(IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView, string message)
        {
            var OnlinePlatform = this.lookupRepository.GetOnlinePlatformList();
            var DurationType = this.lookupRepository.GetDurationList();
            var OnlineDurationType = this.lookupRepository.GetOnlineDurationList();

            var viewModel = this.onlineFactory.CreatePlatfromPackagePriceView(OnlinePlatform, onlinePlatformPackagePriceView, message, OnlineDurationType, DurationType);

            return viewModel;
        }


        /// <summary>
        /// Gets the online artwork price ListView.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlineArtworkPriceListView GetOnlineArtworkPriceListView(string message)
        {
            var OnlineArtwork = this.lookupRepository.GetOnlineArtworkPriceList();
            var viewModel = this.onlineFactory.CreateArtworkPriceView(OnlineArtwork, message);

            return viewModel;
        }


        /// <summary>
        /// Processes the platform package price information.
        /// </summary>
        /// <param name="platformInfo">The platform information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">platformInfo</exception>
        public string ProcessPlatformPackagePriceInfo(IOnlinePlatformPackagePriceView platformInfo)
        {
            if (platformInfo == null)
            {
                throw new ArgumentNullException(nameof(platformInfo));
            }


            var saveData = this.onlineRepository.SavePlatfromPackagePrice(platformInfo);



            return saveData;
        }

        /// <summary>
        /// Gets the selected platform package price information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlinePlatformPackagePriceView GetSelectedPlatformPackagePriceInfo(int Id)
        {
            var onlinePlatfromPrice = this.lookupRepository.GetOlinePlatformPriceById(Id);
            var OnlinePlatform = this.lookupRepository.GetOnlinePlatformList();
            var DurationType = this.lookupRepository.GetOnlineDurationList();

            return this.onlineFactory.EditOnlinePlatformPackagePrice(DurationType, OnlinePlatform, onlinePlatfromPrice);

        }

        /// <summary>
        /// Processes the edit online platform package price information.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">onlinePlatformPackagePriceView</exception>
        public string ProcessEditOnlinePlatformPackagePriceInfo(IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView)
        {
            if (onlinePlatformPackagePriceView == null) throw new ArgumentException(nameof(onlinePlatformPackagePriceView));

            string processingMessage = string.Empty;
            //bool isDataOkay = true;



            processingMessage = this.onlineRepository.EditOnlinePlatformPrice(onlinePlatformPackagePriceView);
            return processingMessage;

        }

        /// <summary>
        /// Processes the delete online platform package price information.
        /// </summary>
        /// <param name="OnlinePlatformPriceId">The online platform price identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteOnlinePlatformPackagePriceInfo(int OnlinePlatformPriceId)
        {
            var delete = this.onlineRepository.DeleteOnlinePlatformPrice(OnlinePlatformPriceId);

            return delete;
        }



        /// <summary>
        /// Gets the online extra service price ListView model.
        /// </summary>
        /// <param name="SelectOnlineExtraServicePriceId">The select online extra service price identifier.</param>
        /// <param name="SelectOnlineExtraServiceId">The select online extra service identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlineExtraServicePriceListView GetOnlineExtraServicePriceListViewModel(int SelectOnlineExtraServicePriceId, int SelectOnlineExtraServiceId, string message)
        {

            var theCollection = this.lookupRepository.GetOnlineExtraServicePriceList();
            var viewModel = this.onlineFactory.CreateOnlineExtraServiceListPriceView(theCollection, SelectOnlineExtraServicePriceId, SelectOnlineExtraServiceId, message);
            return viewModel;


        }

        /// <summary>
        /// Gets the online extra service price view.
        /// </summary>
        /// <returns></returns>
        public IOnlineExtraServicePriceView GetOnlineExtraServicePriceView()
        {
            var OnlineExtraService = this.lookupRepository.GetOnlineExtraServiceList();

            var viewModel = this.onlineFactory.CreateOnlineExtraServicePriceView(OnlineExtraService);

            return viewModel;
        }

        /// <summary>
        /// Processes the online extra service price information.
        /// </summary>
        /// <param name="extraServicePriceInfo">The extra service price information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">extraServicePriceInfo</exception>
        public string ProcessOnlineExtraServicePriceInfo(IOnlineExtraServicePriceView extraServicePriceInfo)
        {
            if (extraServicePriceInfo == null)
            {
                throw new ArgumentNullException(nameof(extraServicePriceInfo));
            }

            //save to database
            var returnViewModel = this.onlineRepository.SaveOnlineExtraServicePrice(extraServicePriceInfo);


            return returnViewModel;
        }

        /// <summary>
        /// Gets the selected online extra service price information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlineExtraServicePriceView GetSelectedOnlineExtraServicePriceInfo(int Id)
        {
            var onlineExtraServicePrice = this.lookupRepository.GetOnlineExtraServicePriceById(Id);

            var OnlineExtraService = this.lookupRepository.GetOnlineExtraServiceList();

            return this.onlineFactory.EditOnlineExtraServicePrice(OnlineExtraService, onlineExtraServicePrice);
        }


        /// <summary>
        /// Processes the edit online extra service price information.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">onlineExtraServicePriceView</exception>
        public IOnlineExtraServicePriceView ProcessEditOnlineExtraServicePriceInfo(IOnlineExtraServicePriceView onlineExtraServicePriceView)
        {
            if (onlineExtraServicePriceView == null) throw new ArgumentException(nameof(onlineExtraServicePriceView));
            string processingMessage = string.Empty;
            bool isDataOkay = true;

            var OnlineExtraService = this.lookupRepository.GetOnlineExtraServiceList();

            var returnViewModel = onlineFactory.CreateOnlineExtraServicePriceView(onlineExtraServicePriceView, processingMessage, OnlineExtraService);

            if (!isDataOkay)
            {
                return returnViewModel;
            }
            var onlineExtraServiceView = this.onlineRepository.EditOnlineExtraServicePrice(onlineExtraServicePriceView);
            return returnViewModel;
        }


        /// <summary>
        /// Processes the delete online extra service price information.
        /// </summary>
        /// <param name="OnlineExtraServicePriceId">The online extra service price identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteOnlineExtraServicePriceInfo(int OnlineExtraServicePriceId)
        {
            var ExtraServicePrice = this.onlineRepository.DeleteOnlineExtraServicePrice(OnlineExtraServicePriceId);

            return ExtraServicePrice;

        }

        /// <summary>
        /// Gets the online extra service price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlineExtraServicePriceView GetOnlineExtraServicePriceView(IOnlineExtraServicePriceView onlineExtraServicePriceView, string message)
        {
            var OnlineExtraService = this.lookupRepository.GetOnlineExtraServiceList();

            return this.onlineFactory.CreateOnlineExtraServicePriceView(onlineExtraServicePriceView, message, OnlineExtraService);
        }

        /// <summary>
        /// Gets the online platform view.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlinePlatformView GetOnlinePlatformView(IOnlinePlatformView onlinePlatformView, string message)
        {
            return this.onlineFactory.CreateOnlinePlatformView(onlinePlatformView, message);
        }

        /// <summary>
        /// Gets the online purpose view.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlinePurposeView GetOnlinePurposeView(IOnlinePurposeView onlinePurposeView, string message)
        {
            return this.onlineFactory.CreateOnlinePurposeView(onlinePurposeView, message);
        }

        /// <summary>
        /// Gets the online extra service view.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlineExtraServiceView GetOnlineExtraServiceView(IOnlineExtraServiceView onlineExtraServiceView, string message)
        {
            return this.onlineFactory.CreateOnlineExtraServiceView(onlineExtraServiceView, message);
        }


        /// <summary>
        /// Gets the delete online extra service price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlineExtraServicePriceView GetDeleteOnlineExtraServicePriceById(int Id)
        {
            var OnlineExtraServicePrice = this.lookupRepository.GetOnlineExtraServicePriceById(Id);

            var OnlineExtraService = this.lookupRepository.GetOnlineExtraServiceList();

            return this.onlineFactory.CreateDeleteOnlineExtraServicetPriceView(OnlineExtraServicePrice);

        }

        /// <summary>
        /// Gets the delete platform package price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlinePlatformPackagePriceView GetDeletePlatformPackagePriceById(int Id)
        {
            var OnlinePlatformPackagePrice = this.lookupRepository.GetOnlinePlatformPriceById(Id);

            var onlinePlatform = this.lookupRepository.GetOnlinePlatformPriceList();
            var durationType = this.lookupRepository.GetDurationList();

            return this.onlineFactory.CreateDeletePlatformPackagePriceView(OnlinePlatformPackagePrice);
        }


        /// <summary>
        /// Gets the online extra price view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlineView GetOnlineExtraPriceView(int Id)
        {
            var OnlineExtraService = this.lookupRepository.GetOnlineExtraServiceAmountById(Id);

            return this.onlineFactory.GetOnlineExtraServicePrice(OnlineExtraService);

        }

        /// <summary>
        /// Gets the artwork price view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlineView GetArtworkPriceView(int Id)
        {
            var OnlineArtwork = this.lookupRepository.GetOnlineArtworAmountById(Id);

            var prices = this.onlineFactory.GetOnlineArtworkPrice(OnlineArtwork);
            return prices;
        }


        /// <summary>
        /// Gets the updated online extra service price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        public IOnlineExtraServicePriceView GetUpdatedOnlineExtraServicePriceView(IOnlineExtraServicePriceView onlineExtraServicePriceView)
        {
            var onlineExtraService = this.lookupRepository.GetOnlineExtraServiceList();
            return this.onlineFactory.getUpdatedOnlineExtraServicePriceView(onlineExtraServicePriceView, onlineExtraService);
        }

        /// <summary>
        /// Gets the updated online platform package price view.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <returns></returns>
        public IOnlinePlatformPackagePriceView GetUpdatedOnlinePlatformPackagePriceView(IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView)
        {
            var onlinePlatform = this.lookupRepository.GetOnlinePlatformList();
            var durationType = this.lookupRepository.GetOnlineDurationList();
            return this.onlineFactory.getUpdatedOnlinePlatformPackagePriceView(onlinePlatformPackagePriceView, onlinePlatform, durationType);
        }

        /// <summary>
        /// Gets the duration list.
        /// </summary>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlineDurationList GetDurationList(string selectedDescription, string message)
        {

            var onlineDurationListCollection = this.lookupRepository.GetOnlineDurationList();

            var model = this.onlineFactory.CreateOnlineDurationListView(onlineDurationListCollection,
                selectedDescription, message);

            return model;
        }

        /// <summary>
        /// Gets the online duration view.
        /// </summary>
        /// <returns></returns>
        public IOnlineDurationView GetOnlineDurationView()
        {
            return this.onlineFactory.CreateOnlineDurationView();
        }

        /// <summary>
        /// Gets the online duration view.
        /// </summary>
        /// <param name="onlineDuration">Duration of the online.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineDuration</exception>
        public IOnlineDurationView GetOnlineDurationView(IOnlineDurationView onlineDuration, string processingMessage)
        {
            if (onlineDuration == null)
            {
                throw new ArgumentNullException(nameof(onlineDuration));
            }

            return this.onlineFactory.CreateUpdateOnlineDurationView(onlineDuration, processingMessage);

        }

        /// <summary>
        /// Processes the duration of the online.
        /// </summary>
        /// <param name="onlineDuration">Duration of the online.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineDuration</exception>
        public string ProcessOnlineDuration(IOnlineDurationView onlineDuration)
        {
            if (onlineDuration == null)
            {
                throw new ArgumentNullException(nameof(onlineDuration));
            }

            var processingMessage = string.Empty;

            bool IsDataOaky = true;


            processingMessage = this.onlineRepository.SaveOnlineDurationInfo(onlineDuration);

            return processingMessage;

        }

        /// <summary>
        /// Gets the online duration package price.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <param name="durationId">The duration identifier.</param>
        /// <returns></returns>
        public IOnlinePlatformPrice GetOnlineDurationPackagePrice(int packageId, int durationId)
        {
            var onlinePrice = onlineRepository.GetPlatformPackagePrice(packageId, durationId);


            return onlinePrice;
        }

        /// <summary>
        /// Gets the online artwork transaction ListView.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <returns></returns>
        public IOnlineArtworkTransactionListView GetOnlineArtworkTransactionListView(int transactionId)
        {
            return this.onlineFactory.GetOnlineArtworkTransactionListView(transactionId);
        }




        /// <summary>
        /// Gets the online user transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IOnlineView GetOnlineUserTransaction(int transactionId)
        {
            //Get Online Order
            var onlineOrder =
                this.onlineRepository.GetUserOnlineOrderById(transactionId);
            // var onlineAttachmentTransaction = this.onlineRepository.GetOnlineAttachmentTransactionById(userId, transactionId);
            var onlneAiringTransaction = this.onlineRepository.GetOnlineTransactionAiring(transactionId);
            var onlineTransactionExtraService = this.onlineRepository.GetOnlineExtraServiceTransactionById(transactionId);


            return this.onlineFactory.GetUserOnlineTransaction(onlineOrder, onlneAiringTransaction, onlineTransactionExtraService);


        }
        /// <summary>
        /// Processes the delete art work price information.
        /// </summary>
        /// <param name="artWorkPriceId">The art work price identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteOnlineArtworkPriceInfo(int onlineArtWorkPriceId) 
        {
            var artWork = this.onlineRepository.DeleteOnlineArtWorkPrice(onlineArtWorkPriceId);


            return artWork;
        }


        /// <summary>
        /// Gets the artwork price view model.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="SelectedArtworkPriceId">The selected artwork price identifier.</param>
        /// <param name="SelectedServiceTypeCode">The selected service type code.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <returns></returns>
        public IOnlineArtworkPriceListView GetArtworkPriceViewModel(string message, int SelectedArtworkPriceId, string SelectedServiceTypeCode, string SelectedDescription)
        {
            var theCollection = this.onlineRepository.GetArtWorkPrice();
            var viewModel = this.onlineFactory.CreateArtworkPriceListView(theCollection, message,
                SelectedArtworkPriceId, SelectedServiceTypeCode, SelectedDescription);
            return viewModel;
        }


        /// <summary>
        /// Processes the artwork price information.
        /// </summary>
        /// <param name="onlineartWorkInfo">The onlineart work information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">onlineartWorkInfo</exception>
        public string ProcessOnlineArtWorkPriceInfo(IOnlineArtworkPriceView onlineArtWorkInfo) 
        {
            if (onlineArtWorkInfo == null)
            {
                throw new System.ArgumentNullException(nameof(onlineArtWorkInfo));
            }

            var artWorkPriceInfo = this.onlineRepository.SaveOnlineArtworkPrice(onlineArtWorkInfo);

            return artWorkPriceInfo;
        }


        /// <summary>
        /// Gets the updated artwork view.
        /// </summary>
        /// <param name="onlineartworkPriceView">The onlineartwork price view.</param>
        /// <returns></returns>
        public IOnlineArtworkPriceView GetUpdatedOnlineArtworkView(IOnlineArtworkPriceView onlineartworkPriceView) 
        {
            var serviceType = this.lookupRepository.GetServiceType();
         
            return this.onlineFactory.CreateUpdatedOnlineArtworkPriceView(onlineartworkPriceView, serviceType);
        }

        /// <summary>
        /// Gets the delete artwork price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IOnlineArtworkPriceView GetOnlineArtworkPriceById(int Id)  
        {
            var getOnlineArtWorkPrice = this.onlineRepository.GetOnlineArtWorkPriceById(Id); 

            var serviceType = this.lookupRepository.GetServiceType();
            return this.onlineFactory.CreateOnlineArtworktPriceView(getOnlineArtWorkPrice,
                serviceType);
        }
        /// <summary>
        /// Gets the online art work price view.
        /// </summary>
        /// <param name="onlineArtworkPriceView">The online artwork price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlineArtworkPriceView GetOnlineArtWorkPriceView(IOnlineArtworkPriceView onlineArtworkPriceView, 
            string message)
        {
          
            var serviceType = this.lookupRepository.GetServiceType();

            var viewModel = this.onlineFactory.CreateOnliineArtworkPriceView(serviceType);

            return viewModel;
        }
        /// <summary>
        /// Gets the online art work price view.
        /// </summary>
        /// <returns></returns>
        public IOnlineArtworkPriceView GetOnlineArtWorkPriceView()
        {
           
            var serviceType = this.lookupRepository.GetServiceType();

            var viewModel = this.onlineFactory.CreateOnliineArtworkPriceView(serviceType);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit art work price information.
        /// </summary>
        /// <param name="onlineArtworkInfo">The online artwork information.</param>
        /// <returns></returns>
        public string ProcessEditArtWorkPriceInfo(IOnlineArtworkPriceView onlineArtworkInfo)
        {
            var editArtWork = this.onlineRepository.EditOnlineArtWorkTypePrice(onlineArtworkInfo);


            return editArtWork;
        }

        public string ProcessArtWorkPriceInfo(IOnlineArtworkPriceView onlineArtworkInfo)
        {
            if (onlineArtworkInfo == null)
            {
                throw new System.ArgumentNullException(nameof(onlineArtworkInfo));
            }

            var onlineArtworkPriceInfo = this.onlineRepository.SaveOnlineArtworkPrice(onlineArtworkInfo);

            return onlineArtworkPriceInfo;
        }
    }
}
