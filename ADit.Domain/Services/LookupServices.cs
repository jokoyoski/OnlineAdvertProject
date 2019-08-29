using AA.Infrastructure.Interfaces;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ADit.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ILookupService" />
    public class LookupServices : ILookupService
    {
        private readonly IEnvironment environment;
        private readonly IEmailFactory emailFactory;
        private readonly IEmail emailService;
        private readonly ILookupRepository lookupRepository;
        private readonly IGeneralFactory generalFactory;
        private readonly IDigitalFileRepository digitalRepository;
        private readonly IScriptingFactory scriptingFactory;
        private static readonly Random random = new Random();

      
        public LookupServices(ILookupRepository lookupRepository, IEnvironment environment, IEmail emailService,
            IEmailFactory emailFactory, IGeneralFactory generalFactory,
            IDigitalFileRepository digitalRepository, IScriptingFactory scriptingFactory)
        {
            this.generalFactory = generalFactory;
            this.lookupRepository = lookupRepository;
            this.digitalRepository = digitalRepository;
            this.scriptingFactory = scriptingFactory;

            this.emailFactory = emailFactory;
            this.emailService = emailService;
            this.environment = environment;
        }

        /// <summary>
        /// Ges the design element price view model.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="selectedDesignElementPriceId">The selected design element price identifier.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        public IDesignElementPriceListView GeDesignElementPriceViewModel(string message,
            int selectedDesignElementPriceId, string selectedServiceTypeCode, string selectedDescription)
        {
            var theCollection = this.lookupRepository.GetDesignElementPrice();
            var viewModel = this.generalFactory.CreateDesignElementPriceListView(theCollection, message,
                selectedDesignElementPriceId, selectedServiceTypeCode, selectedDescription);
            return viewModel;
        }

        /// <summary>
        /// Gets the apcon approval by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">apconById</exception>
        public IApconApprovalView GetApconApprovalById(int Id, string message)
        {
            var apconById = this.lookupRepository.GetApconApprovalById(Id);
            if (apconById == null)
            {
                throw new ApplicationException(nameof(apconById));
            }

            var viewModel = this.generalFactory.GetEditApconView(apconById, message);
            return viewModel;
        }


        /// <summary>
        /// Gets the time belt by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">timeBeltId</exception>
        public ITimeBeltView GetTimeBeltById(int Id, string message)
        {
            var timeBeltId = this.lookupRepository.GetTimeBeltById(Id);
            if (timeBeltId == null)
            {
                throw new ApplicationException(nameof(timeBeltId));
            }

            var viewModel = this.generalFactory.GetEditTimeBeltView(timeBeltId, message);
            return viewModel;
        }

        /// <summary>
        /// Gets the apcon approval type ListView.
        /// </summary>
        /// <param name="selectedApconApprovalTypeId">The selected apcon approval type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IApconApprovalTypeListView GetApconApprovalTypeListView(int selectedApconApprovalTypeId,
            string selectedDescription, string message)
        {
            var ApprovalCollection = this.lookupRepository.GetApconApprovalTypeList().ToList();

            return this.generalFactory.apconApprovalTypeListView(ApprovalCollection, message,
                selectedApconApprovalTypeId, selectedDescription);
        }

        /// <summary>
        /// Gets the apcon approval type price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IApconApprovalTypePriceView GetApconApprovalTypePriceById(int Id)
        {
            var apconById = this.lookupRepository.GetApconApprovalTypePriceById(Id);


            var apconType = this.lookupRepository.GetApconApprovalTypeList();

            return this.generalFactory.EditApconApprovalTypePriceView(apconType, apconById);
        }


        /// <summary>
        /// Gets the radio service price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IRadioServicePriceList GetRadioServicePriceById(int Id)
        {
            var radioService = this.lookupRepository.GetRadioServicePriceById(Id);


            var radioStation = this.lookupRepository.GetRadioStationList();
            var timing = this.lookupRepository.GetTiming();
            var materialType = this.lookupRepository.GetMaterialType();
            var timingBelt = this.lookupRepository.GetTimeBelts();

            return this.generalFactory.EditRadioServicePriceView(radioService, radioStation, timing, materialType,
                timingBelt);
        }


        /// <summary>
        /// Gets the apcon approval type price view.
        /// </summary>
        /// <returns></returns>
        public IApconApprovalTypePriceView GetApconApprovalTypePriceView()
        {
            var apconType = this.lookupRepository.GetApconApprovalTypeList();
            var viewModel = this.generalFactory.CreateApconApprovalTypePriceView(apconType);
            return viewModel;
        }


        /// <summary>
        /// Gets the radio service type price view.
        /// </summary>
        /// <returns></returns>
        public IRadioServicePriceList GetRadioServiceTypePriceView()
        {
            var radioStation = this.lookupRepository.GetRadioStationList();
            var timing = this.lookupRepository.GetTiming();
            var materialType = this.lookupRepository.GetMaterialType();
            var timingbelt = this.lookupRepository.GetTimeBelts();
            var viewModel =
                this.generalFactory.CreateRadioServicePriceView(radioStation, timing, materialType, timingbelt);
            return viewModel;
        }


        /// <summary>
        /// Gets the radio service type price view.
        /// </summary>
        /// <param name="priceView">The price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IRadioServicePriceList GetRadioServiceTypePriceView(IRadioServicePriceList priceView, string message)
        {
            var radioStation = this.lookupRepository.GetRadioStationList();
            var timing = this.lookupRepository.GetTiming();
            var materialType = this.lookupRepository.GetMaterialTypeForRadio();

            var viewModel = this.generalFactory.CreateRadioServicePriceView(priceView, radioStation, timing,
                materialType, message);
            return viewModel;
        }

        /// <summary>
        /// Gets the apcon approval type price view.
        /// </summary>
        /// <param name="priceView">The price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IApconApprovalTypePriceView GetApconApprovalTypePriceView(IApconApprovalTypePriceView priceView,
            string message)
        {
            var apconType = this.lookupRepository.GetApconApprovalTypeList();

            var viewModel = this.generalFactory.CreateApconApprovalTypePriceView(apconType, priceView, message);
            return viewModel;
        }


        /// <summary>
        /// Gets the apcon approval type price view model.
        /// </summary>
        /// <param name="selectedApconApprovalTypePriceId">The selected apcon approval type price identifier.</param>
        /// <param name="selectedApconApprovalId">The selected apcon approval identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IApconApprovalTypePriceListView GetApconApprovalTypePriceViewModel(int selectedApconApprovalTypePriceId,
            int selectedApconApprovalId, string message)
        {
            var theCollection = this.lookupRepository.GetApconApprovalTypePrice();
            var viewModel = this.generalFactory.CreateApconApprovalTypePriceViewModel(theCollection, message,
                selectedApconApprovalTypePriceId, selectedApconApprovalId);
            return viewModel;
        }

        /// <summary>
        /// Gets the radio service price view model.
        /// </summary>
        /// <param name="selectedRadioServiceId">The selected radio service identifier.</param>
        /// <param name="selectedRadioId">The selected radio identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedMaterialTypeId">The selected material type identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IRadioServicePriceListView GetRadioServicePriceViewModel(int selectedRadioServiceId, int selectedRadioId,
            int selectedTimingId, int selectedMaterialTypeId, string message)
        {
            var theCollection = this.lookupRepository.GetRadioServicePrice();
            var viewModel = this.generalFactory.CreateRadioServicePriceViewModel(theCollection, message,
                selectedRadioServiceId, selectedRadioId, selectedTimingId, selectedMaterialTypeId);
            return viewModel;
        }


        /// <summary>
        /// Gets the apcon view.
        /// </summary>
        /// <returns></returns>
        public IApconApprovalView GetApconView()
        {
            return this.generalFactory.CreateApconView();
        }

        /// <summary>
        /// Gets the apcon view.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IApconApprovalView GetApconView(IApconApprovalView apconInfo, string processingMessage)
        {
            return this.generalFactory.CreateApconView(apconInfo, processingMessage);
        }

        /// <summary>
        /// Gets the color ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IColorListView GetColorListViewModel(int selectedId, string selectedDescription, string message)
        {
            var colorCollection = this.lookupRepository.GetColor().ToList();
            return this.generalFactory.CreateColorListView(selectedId, selectedDescription, colorCollection, message);
        }

        /// <summary>
        /// Admins the save timing.
        /// </summary>
        /// <param name="colorView"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IColorView GetColorView(IColorView colorView, string message)
        {
            return this.generalFactory.CreateColorView(colorView, message);
        }

        /// <summary>
        /// Gets the color view.
        /// </summary>
        /// <returns></returns>
        public IColorView GetColorView()
        {
            return this.generalFactory.CreateColorView();
        }

        /// <summary>
        /// Gets the time belt view.
        /// </summary>
        /// <returns></returns>
        public ITimeBeltView GetTimeBeltView()
        {
            return this.generalFactory.CreateTimeBeltView();
        }

        /// <summary>
        /// Gets the delete apcon approval type price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IApconApprovalTypePriceView GetDeleteApconApprovalTypePriceById(int Id)
        {
            var getApconPrice = this.lookupRepository.GetApconApprovalTypePriceById(Id);

            var materialType = this.lookupRepository.GetMaterialType();
            var serviceType = this.lookupRepository.GetServiceType();
            return this.generalFactory.CreateDeleteApconApprovalTypePriceView(getApconPrice);
        }

        /// <summary>
        /// Gets the delete radio service price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IRadioServicePriceList GetDeleteRadioServicePriceById(int Id)
        {
            var radioService = this.lookupRepository.GetRadioServicePriceById(Id);

            return this.generalFactory.CreateDeleteRadioServicePriceView(radioService);
        }


        /// <summary>
        /// Gets the delete design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        public IDesignElementView GetDeleteDesignElement(IDesignElementView designElementView, int designElementId)
        {
            var description = this.lookupRepository.GetDesignElementDescriptionByID(designElementId);

            return this.generalFactory.CreateEditDesignElementView(designElementView, description);
        }

        /// <summary>
        /// Gets the delete design element price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IDesignElementPriceView GetDeleteDesignElementPriceById(int Id)
        {
            var getDesignElementPrice = this.lookupRepository.GetDesignElementPriceById(Id);

            var designElement = this.lookupRepository.GetDesignElement();
            var serviceType = this.lookupRepository.GetServiceType();
            return this.generalFactory.CreateDeleteDesignElementPriceView(getDesignElementPrice, designElement,
                serviceType);
        }

        /// <summary>
        /// Gets the delete material type timing by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">getMaterialType</exception>
        public IMaterialTypeTimingView GetDeleteMaterialTypeTimingById(int Id, string message)
        {
            var getMaterialType = this.lookupRepository.GetEditMaterialTypeTimingById(Id);
            if (getMaterialType == null)
            {
                throw new ApplicationException(nameof(getMaterialType));
            }

            var materialType = this.lookupRepository.GetMaterialType();
            var serviceType = this.lookupRepository.GetServiceType();
            var timingType = this.lookupRepository.GetTiming();
            return this.generalFactory.CreateDeleteMaterialTypeTimingView(getMaterialType);
        }

        /// <summary>
        /// Gets the design element ListView.
        /// </summary>
        /// <param name="SelectedDesignElementId">The selected design element identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IDesignElementListView GetDesignElementListView(int SelectedDesignElementId, string SelectedDescription,
            string message)
        {
            var designElementCollection = this.lookupRepository.GetDesignElement().ToList();
            return this.generalFactory.CreateDesignElementListView(SelectedDesignElementId, SelectedDescription,
                designElementCollection, message);
        }

        /// <summary>
        /// Gets the design element price view.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IDesignElementPriceView GetDesignElementPriceView(IDesignElementPriceView designElementPriceView,
            string message)
        {
            var designelement = this.lookupRepository.GetDesignElement();
            var serviceType = this.lookupRepository.GetServiceType();

            var viewModel = this.generalFactory.CreateDesignElementPriceView(serviceType, designelement);

            return viewModel;
        }

        /// <summary>
        /// Gets the design element price view.
        /// </summary>
        /// <returns></returns>
        public IDesignElementPriceView GetDesignElementPriceView()
        {
            var designelement = this.lookupRepository.GetDesignElement();
            var serviceType = this.lookupRepository.GetServiceType();

            var viewModel = this.generalFactory.CreateDesignElementPriceView(serviceType, designelement);

            return viewModel;
        }

        /// <summary>
        /// Gets the design element view model.
        /// </summary>
        /// <returns></returns>
        public IDesignElementView GetDesignElementViewModel()
        {
            return this.generalFactory.CreateDesignElementView();
        }


        /// <summary>
        /// Gets the duration type ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDurationTypeId">The selected duration type identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IDurationTypeListView GetDurationTypeListView(string selectedId, string selectedDurationTypeId,
            string message)
        {
            var getDurationTypeCollection = this.lookupRepository.GetDurationList().ToList();
            return this.generalFactory.durationTypeListView(selectedId, selectedDurationTypeId,
                getDurationTypeCollection, message);
        }

        /// <summary>
        /// Gets the duration type view.
        /// </summary>
        /// <returns></returns>
        public IDurationTypeView GetDurationTypeView()
        {
            return this.generalFactory.CreateDurationTypeView();
        }

        /// <summary>
        /// Gets the duration type view.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IDurationTypeView GetDurationTypeView(IDurationTypeView durationTypeView, string message)
        {
            return this.generalFactory.CreateDurationTypeView(durationTypeView, message);
        }

        /// <summary>
        /// Gets the edit design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        public IDesignElementView GetEditDesignElement(IDesignElementView designElementView, int designElementId)
        {
            var description = this.lookupRepository.GetDesignElementDescriptionByID(designElementId);

            return this.generalFactory.CreateEditDesignElementView(designElementView, description);
        }


        /// <summary>
        /// Gets the edit material type timing by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IMaterialTypeTimingView GetEditMaterialTypeTimingById(int Id, string message)
        {
            var getmaterialtiming = this.lookupRepository.GetEditMaterialTypeTimingById(Id);
            var materialType = this.lookupRepository.GetMaterialType().ToList();
            var serviceType = this.lookupRepository.GetServiceType().ToList();
            var timing = this.lookupRepository.GetTiming().ToList();
            return this.generalFactory.EditMaterialTypeTimingView(serviceType, materialType, getmaterialtiming, timing,
                message);
        }

        /// <summary>
        /// Gets the material type ListView model.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IMaterialTypeListView GetMaterialTypeListViewModel(int materialTypeId, string selectedDescription,
            string message)
        {
            var MtaerialTypecollection = this.lookupRepository.GetMaterialType().ToList();
            return this.generalFactory.CreateMaterialTypeListView(materialTypeId, selectedDescription,
                MtaerialTypecollection, message);
        }

        /// <summary>
        /// Gets the material type selected information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IMaterialTypeView GetMaterialTypeSelectedInfo(int Id)
        {
            var materialTypeById = this.lookupRepository.GetMaterialTypeById(Id);
            return this.generalFactory.GetEditMaterialTypeView(materialTypeById);
        }

        /// <summary>
        /// Gets the material type timing ListView.
        /// </summary>
        /// <param name="selectedMaterialTypeTimingId">The selected material type timing identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IMaterialTypeTimingListView GetMaterialTypeTimingListView(int selectedMaterialTypeTimingId,
            int selectedTimingId, string selectedDescription, string message)
        {
            var Timingcollection = this.lookupRepository.GetMaterialTypeTimingList().ToList();
            return this.generalFactory.CreateMaterialTypeTimingListVew(Timingcollection, message,
                selectedMaterialTypeTimingId, selectedTimingId, selectedDescription);
        }

        /// <summary>
        /// Gets the material type timing view.
        /// </summary>
        /// <returns></returns>
        public IMaterialTypeTimingView GetMaterialTypeTimingView()
        {
            var materialType = this.lookupRepository.GetMaterialType();
            var serviceType = this.lookupRepository.GetServiceType();
            var timingtype = this.lookupRepository.GetTiming();
            var viewModel = this.generalFactory.CreateMaterialTypeTimingView(serviceType, materialType, timingtype);
            return viewModel;
        }

        /// <summary>
        /// Gets the material type timing view.
        /// </summary>
        /// <param name="materialView">The material view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IMaterialTypeTimingView GetMaterialTypeTimingView(IMaterialTypeTimingView materialView, string message)
        {
            var materialType = this.lookupRepository.GetMaterialType();
            var serviceType = this.lookupRepository.GetServiceType();
            var timingtype = this.lookupRepository.GetTiming();

            var viewModel = this.generalFactory.CreateMaterialTypeTimingView(serviceType, materialType, timingtype);

            return viewModel;
        }

        /// <summary>
        /// Gets the material type view.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IMaterialTypeView GetMaterialTypeView(IMaterialTypeView materialTypeView, string message)
        {
            return this.generalFactory.CreateMaterialTypeView(materialTypeView, message);
        }

        /// <summary>
        /// Gets the material type view.
        /// </summary>
        /// <returns></returns>
        public IMaterialTypeView GetMaterialTypeView()
        {
            return this.generalFactory.CreateMaterialTypeView();
        }

        /// <summary>
        /// Gets the selected color by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IColorView GetSelectedColorByInfo(int Id)
        {
            var colorById = this.lookupRepository.GetColorById(Id);
            return this.generalFactory.CreateColorView(colorById);
        }


        /// <summary>
        /// Gets the selected time belt by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public ITimeBeltView GetSelectedTimeBeltByInfo(int Id)
        {
            var timeBelt = this.lookupRepository.GetTimeBeltById(Id);
            return this.generalFactory.CreateTimeBeltView(timeBelt);
        }

        /// <summary>
        /// Gets the selected design element price information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IDesignElementPriceView GetSelectedDesignElementPriceInfo(int Id)
        {
            var getDesignElement = this.lookupRepository.GetDesignElementPriceById(Id);
            var designElement = this.lookupRepository.GetDesignElement();
            var serviceType = this.lookupRepository.GetServiceType();
            return this.generalFactory.EditDesignElementPriceView(serviceType, designElement, getDesignElement);
        }

        /// <summary>
        /// Gets the selected duration type information.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public IDurationTypeView GetSelectedDurationTypeInfo(string code)
        {
            var durationTypeById = this.lookupRepository.GetDurationTypeById(code);
            return this.generalFactory.CreateDurationTypeView(durationTypeById);
        }

        /// <summary>
        /// Gets the selected timing by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public ITimingView GetSelectedTimingByInfo(int Id)
        {
            var timingById = this.lookupRepository.GetTimingById(Id);
            return this.generalFactory.GetEditTimingView(timingById);
        }

        /// <summary>
        /// Gets the timing ListView.
        /// </summary>
        /// <param name="SelectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ITimingListView GetTimingListView(int SelectedId, string selectedDescription, string message)
        {
            var Timingcollection = this.lookupRepository.GetTiming().ToList();
            return this.generalFactory.CreateTimingListVew(SelectedId, selectedDescription, Timingcollection, message);
        }

        /// <summary>
        /// Creates the timing view.
        /// </summary>
        /// <param name="timingView"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ITimingView GetTimingView(ITimingView timingView, string message)
        {
            return this.generalFactory.CreateTimingView(timingView, message);
        }


        /// <summary>
        /// Gets the timing view.
        /// </summary>
        /// <returns></returns>
        public ITimingView GetTimingView()
        {
            return this.generalFactory.CreateTimingView();
        }

        /// <summary>
        /// Gets the design element price view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IRadioMainView GetDesignElementPriceView(int Id)
        {
            var ScriptingPrice = this.lookupRepository.GetScriptingPriceById(Id);

            return this.generalFactory.GetMaterialScripting(ScriptingPrice);
        }


        /// <summary>
        /// Gets the user message.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public IScriptingViewList GetUserMessage(int userId, string message)
        {
            if (userId <= 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            //Get transaction from database by Id 
            var transactionInfo = this.lookupRepository.GetScriptTransactionById(userId);

            if (transactionInfo == null)
            {
                return null;
            }

            //Get Document from database


            var returnViewModel = this.scriptingFactory.CreateScriptingMessageView(transactionInfo, message);

            return returnViewModel;
        }


        /// <summary>
        /// Gets the tv transaction view model.
        /// </summary>
        /// <param name="selectedTvTransactionId">The selected tv transaction identifier.</param>
        /// <param name="selectedUserId">The selected user identifier.</param>
        /// <param name="message">The message.</param>
       
     
       

        /// <summary>
        /// Saves the uploaded script.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvScriptView</exception>
        public IDigitalFile GetScriptFileForDownload(int Id)
        {
            var digitalFile = this.digitalRepository.GetDigitalFileDetail(Id);
            return digitalFile;
        }


       


        /// <summary>
        /// Gets the tv script message replies ListView.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
      
        /// <summary>
        /// Gets the print script message replies ListView.
        /// </summary>
        /// <param name="SentToId">The sent to identifier.</param>
       

       


        /// <summary>
        /// Gets the material message replies ListView.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
       

        /// <summary>
       

        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var a = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return a;
        }

        /// <summary>
        /// Generates the coupon.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public string GenerateCoupon(int length)
        {
            string result = string.Empty;
            Random random = new Random((int) DateTime.Now.Ticks);
            List<string> characters = new List<string>() { };
            for (int i = 48; i < 58; i++)
            {
                characters.Add(((char) i).ToString());
            }

            for (int i = 65; i < 91; i++)
            {
                characters.Add(((char) i).ToString());
            }

            for (int i = 97; i < 123; i++)
            {
              
                characters.Add(((char) i).ToString());
            }

            for (int i = 0; i < length; i++)
            {
                result += characters[random.Next(0, characters.Count)];
                Thread.Sleep(1);
            }

            return result;
        }

        /// <summary>
        /// Sends the contact mmail.
        /// </summary>
        /// <param name="contactView">The contact view.</param>
        public void SendContactMail(IContactView contactView)
        {
            var contactEmail = this.lookupRepository.GetContactById(contactView.ContactId);

            var emailDetail = this.emailFactory.CreateSendContactUsMail(contactEmail.Email, contactView.customerEmail,
                contactView.Name, contactView.PhoneNumber, contactView.Message);
            var emailKey = this.environment[EnvironmentValues.EmailKey];

            //Send Message to ADit Administrator i.e The Approved Receipient
            this.emailService.Send(emailKey, "team@aditng.com", "ADit Contact", emailDetail.Subject,
                emailDetail.Recipients, emailDetail.Recipients, "", emailDetail.Body);

            //Send Message to the Customer that Initiate the Contact Message
            var subject = "We have received your message";
            var message = string.Empty;

            var customerMail =this.emailFactory.CreateCustomerMessage(contactView.Email, subject, message);
            this.emailService.Send(emailKey, "team@aditng.com", "ADit Team", subject, contactView.Email, contactView.Name, "",
                customerMail.Body);
        }

        /// <summary>
        /// Gets the contact view.
        /// </summary>
        /// <returns></returns>
        public IContactView GetContactView()
        {
            var contactList = this.lookupRepository.GetContactList();
            return this.generalFactory.GetContactView(contactList);
        }


        /// <summary>
        /// Gets the time belt ListView.
        /// </summary>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        public ITimeBeltListView GetTimeBeltListView(string selectedDescription)
        {
            var timeBelt = this.lookupRepository.GetTimeBelts();
            return this.generalFactory.GetTimeBeltListView(timeBelt, selectedDescription);
        }

       
    }
}