using AA.Infrastructure.Interfaces;
using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using ADit.Domain.Resources;
using System.Web;

namespace ADit.Domain.Services
{


    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IBrandingService" />
    public class BrandingService : IBrandingService
    {

        /// <summary>
        /// The order repository
        /// </summary>
        private readonly IOrderRepository orderRepository;
        
      
        private readonly IBrandingRepository brandingRepository;

     
        private readonly IBrandingFactory brandingFactory;

      
        private readonly ILookupRepository lookupRepository;

    
        private readonly ISessionStateService session;

        private readonly IOrderSummaryFactory orderSummaryFactory;

        private readonly IDigitalFileServices digitalFileServices;

      
        private readonly IDigitalFileRepository digitalFileRepository;

        private readonly ILookupService lookUpServices;

       
        private readonly IAccountRepository accountRepository;

        private readonly IEnvironment environment;

      
        private readonly IEmailFactory emailFactory;

       
        private readonly IEmail emailService;

      
        private readonly IOrderServices orderServices;

        private readonly ITransactionService transactionService;


        /// <summary>
        /// Initializes a new instance of the <see cref="BrandingService"/> class.
        /// </summary>
        /// <param name="brandingRepository">The branding repository.</param>
        /// <param name="accountRepository">The account repository.</param>
        /// <param name="orderRepository">The order repository.</param>
        /// <param name="brandingFactory">The branding factory.</param>
        /// <param name="lookupRepository">The lookup repository.</param>
        /// <param name="digitalFileServices">The digital file services.</param>
        /// <param name="session">The session.</param>
        /// <param name="digitalFileRepository">The digital file repository.</param>
        /// <param name="orderSummaryFactory">The order summary factory.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="emailFactory">The email factory.</param>
        /// <param name="emailService">The email service.</param>
        /// <param name="lookUpServices">The look up services.</param>
        /// <param name="orderServices">The order services.</param>
        /// <param name="transactionService">The transaction service.</param>
        
        public BrandingService(IBrandingRepository brandingRepository, IAccountRepository accountRepository, IOrderRepository orderRepository,
            IBrandingFactory brandingFactory,
            ILookupRepository lookupRepository, IDigitalFileServices digitalFileServices,
            ISessionStateService session, IDigitalFileRepository digitalFileRepository,
            IOrderSummaryFactory orderSummaryFactory, IEnvironment environment, IEmailFactory emailFactory,
            IEmail emailService, 
            ILookupService lookUpServices, IOrderServices orderServices, ITransactionService transactionService)
        {
            this.lookupRepository = lookupRepository;
            this.brandingFactory = brandingFactory;
            this.brandingRepository = brandingRepository;
            this.session = session;
            this.orderSummaryFactory = orderSummaryFactory;
            this.digitalFileServices = digitalFileServices;
         
            this.digitalFileRepository = digitalFileRepository;
            this.lookUpServices = lookUpServices;
            this.emailFactory = emailFactory;
            this.emailService = emailService;
            this.environment = environment;
            this.accountRepository = accountRepository;
            this.orderServices = orderServices;
            this.transactionService = transactionService;
            this.orderRepository = orderRepository;
        }


        /// <summary>
        /// Gets the branding view.
        /// </summary>
        /// <returns></returns>
        public IBrandingView GetBrandingView()
        {
            var colorList = this.lookupRepository.GetColor();
            var DesignElementList = this.lookupRepository.GetDesignElementPriceList();
            var BrandingMaterialList = this.lookupRepository.GetMaterialPriceList();

            return this.brandingFactory.GetBrandingView(BrandingMaterialList, colorList, DesignElementList);
        }

        /// <summary>
        /// Processes the view.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="designMaterial">The design material.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingView</exception>
        public string ProcessView(IBrandingView brandingView, HttpPostedFileBase designMaterial, out int orderId)
        {
            if (brandingView == null)
            {
                throw new ArgumentNullException(nameof(brandingView));
            }


            // save files uploaded by calling digital file services, the id returned will be zero if no files are uploaded - no need to check anything here
            var processingScriptMessage = digitalFileServices.SaveFile(FileType.Image, designMaterial, out var digitalScriptFileId);


            orderId = -1;

            var userId = (int) session.GetSessionValue(SessionKey.UserId);

            // Get order number
            orderId = this.orderServices.GetOrderIdentifier(userId);

            brandingView.DesignDigitalFileId = digitalScriptFileId; //Assign Branding ID 
            brandingView.UserId = userId;
            brandingView.OrderId= orderId;

            //Store Transaction
            var proccessignMessage =
                this.brandingRepository.saveBrandingTransactionInfo(brandingView, out var brandingTransactionId);

            if (string.IsNullOrEmpty(proccessignMessage) && brandingTransactionId > 0)
            {
                //Store Material Info
                this.brandingRepository.saveBrandingTransactionMaterialInfo(brandingView, brandingTransactionId);

                //Store Attachement
                this.brandingRepository.saveBrandingTransactionAttachmentInfo(brandingView, brandingTransactionId);

                //Store Transaction Color
                this.brandingRepository.saveBrandingTransactionColorInfo(brandingView, brandingTransactionId);

                //Store Design Element
                this.brandingRepository.saveBrandingTransactionDesignElementInfo(brandingView, brandingTransactionId);
            }

            //Update The Cart For The User
            transactionService.UpdateCart(orderId);
            return proccessignMessage;
        }


        /// <summary>
        /// Updates the branding transaction.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="designMaterial">The design material.</param>
        /// <returns></returns>
        public string UpdateBrandingTransaction(IBrandingView brandingView, HttpPostedFileBase designMaterial)
        {
            int brandingTransactionId = brandingView.BrandingTransactionId;
            var digitalDesignFileId = -1;
            string processingMessageScripting = string.Empty;

            processingMessageScripting =
                this.digitalFileServices.SaveFile(FileType.Image, designMaterial, out digitalDesignFileId);

            // check if file saved to database and save the Id as part of the profile record
            if (digitalDesignFileId > 0)
            {
                brandingView.DesignDigitalFileId = digitalDesignFileId;
            }

            var selectedColor = this.brandingRepository.GetSelectedColorById(brandingTransactionId);


            var processingMessage = this.brandingRepository.UpdateBrandingTransaction(brandingView);
            this.brandingRepository.UpdateBrandingTransactionMaterialInfo(brandingView);
            this.brandingRepository.UpdateBrandingTransactionAttachments(brandingView);
            this.brandingRepository.UpdateBrandingTransactionColorInfo(brandingView,
                selectedColor.BrandingTransactionColorId);
            this.brandingRepository.UpdateBrandingTransactionDesignElementInfo(brandingView);

            return processingMessage;
        }


        /// <summary>
        /// Gets the edit branding transaction view.
        /// </summary>
        /// <param name="trasactionId">The trasaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IBrandingView GetEditBrandingTransactionView(int trasactionId, int userId, string message)
        {
            //Get Color list
            var colorList = this.lookupRepository.GetColor();

            //Get The Design Element
            var DesignElementList = this.lookupRepository.GetDesignElementPriceList();
            //Get Branding Element
            var BrandingMaterialList = this.lookupRepository.GetMaterialPriceList();


            //Get Selected Colors List
            var selectedColor = this.brandingRepository.GetSelectedColor(trasactionId);

            //Get Transaction Details
            var transactionDetails = this.brandingRepository.GetTransactionDetails(trasactionId);
            var brandingFile = this.brandingRepository.GetBrandingAttachmentTransactionsById(transactionDetails.BrandingTransactionId);


            if (brandingFile.BrandingTransactionAttachmentId > 0)
            {
                var scriptFileDetail =
                    this.digitalFileRepository.GetDigitalFileDetail(brandingFile.BrandingTransactionAttachmentId);

                transactionDetails.BrandingAttachmentDescription = scriptFileDetail == null ? "" : scriptFileDetail.Filename;
            }
            return this.brandingFactory.GetBrandingTransactionView(BrandingMaterialList, colorList, DesignElementList,
                transactionDetails, selectedColor, "");
        }

        /// <summary>
        /// Gets the material ListView model.
        /// </summary>
        /// <param name="selectedBrandingMaterialId">The selected branding material identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IBrandingMaterialListView GetMaterialListViewModel(int selectedBrandingMaterialId,
            string selectedDescription, string message)
        {
            var theCollection = this.lookupRepository.GetMaterialList().ToList();
            return this.brandingFactory.CreateBrandingMaterialListView(theCollection, message,
                selectedBrandingMaterialId, selectedDescription);
        }


        /// <summary>
        /// Gets the branding material price view model.
        /// </summary>
        /// <param name="selectedBrandingMaterialPriceId">The selected branding material price identifier.</param>
        /// <param name="selectedBrandingMaterial">The selected branding material.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IMaterialPriceListView GetBrandingMaterialPriceViewModel(int selectedBrandingMaterialPriceId,
            string selectedBrandingMaterial, string message)
        {
            var theCollection = this.lookupRepository.GetBrandingMaterialPriceList();
            var viewModel = this.brandingFactory.CreateBrandingMaterialPriceListView(theCollection, message,
                selectedBrandingMaterialPriceId, selectedBrandingMaterial);
            return viewModel;
        }


        /// <summary>
        /// Gets the material price view.
        /// </summary>
        /// <returns></returns>
        public IBrandingMaterialPriceView GetMaterialPriceView()
        {
            var materialtype = this.lookupRepository.GetMaterialList();
            var serviceType = this.lookupRepository.GetServiceType();

            var viewModel = this.brandingFactory.CreateMaterialPriceView(materialtype);

            return viewModel;
        }


        /// <summary>
        /// Processes the material price information.
        /// </summary>
        /// <param name="materialInfo">The material information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">materialInfo</exception>
        public string ProcessMaterialPriceInfo(IBrandingMaterialPriceView materialInfo)
        {
            if (materialInfo == null)
            {
                throw new System.ArgumentNullException(nameof(materialInfo));
            }

            var brandingModel = this.brandingRepository.SaveMaterialPrice(materialInfo);


            return brandingModel;
        }


        /// <summary>
        /// Processes the branding material information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        public string ProcessBrandingMaterialInfo(IBrandingMaterialView brandingView)
        {
            var processingMessage = string.Empty;

            //Check that The Description Name Does not Exist Already

            var material = this.brandingRepository.GetBrandingMaterialByName(brandingView.Description);


            //Check The Names
            if (material != null)
            {
                processingMessage = Messages.DescriptionExist; // Name Already Existed
            }
            else
            {
                //All is Fine, We can Store
                processingMessage = this.brandingRepository.SaveMaterialInfo(brandingView);
            }


            //Return Processing Mesage
            return processingMessage;
        }

        /// <summary>
        /// Gets the branding material view.
        /// </summary>
        /// <returns></returns>
        public IBrandingMaterialView GetBrandingMaterialView()
        {
            return this.brandingFactory.CreateBrandingMaterialView();
        }

        /// <summary>
        /// Gets the selected branding material information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IBrandingMaterialView GetSelectedBrandingMaterialInfo(int Id)
        {
            var brandingmaterialById = this.lookupRepository.GetBrandingMaterialById(Id);
            return this.brandingFactory.CreateEditBrandingMaterialView(brandingmaterialById);
        }

        /// <summary>
        /// Processes the delete branding material information.
        /// </summary>
        /// <param name="brandingMaterialId">The branding material identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteBrandingMaterialInfo(int brandingMaterialId)
        {
            var brandingMaterialEdting = this.brandingRepository.DeleteBrandingMaterialInfo(brandingMaterialId);
            return brandingMaterialEdting;
        }


        /// <summary>
        /// Processes the edit branding material price information.
        /// </summary>
        /// <param name="brandingMaterialPriceView">The branding material price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">brandingMaterialPriceView</exception>
        public string ProcessEditBrandingMaterialPriceInfo(IBrandingMaterialPriceView brandingMaterialPriceView)
        {
            if (brandingMaterialPriceView == null) throw new ArgumentException(nameof(brandingMaterialPriceView));
            string processingMessage = string.Empty;


            var brandingMaterialView = this.brandingRepository.EditBrandingMaterialPrice(brandingMaterialPriceView);
            return brandingMaterialView;
        }

        /// <summary>
        /// Processes the delete material price information.
        /// </summary>
        /// <param name="brandingMaterialPriceId">The branding material price identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteMaterialPriceInfo(int brandingMaterialPriceId)
        {
            var brandingMaterialPrice = this.brandingRepository.DeleteBrandingMaterialPrice(brandingMaterialPriceId);

            return brandingMaterialPrice;
        }


        /// <summary>
        /// Gets the selected branding material pricenfo.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IBrandingMaterialPriceView GetSelectedBrandingMaterialPricenfo(int Id)
        {
            var brandingMaterialPrice = this.lookupRepository.GetBrandingMaterialPriceById(Id);


            var MaterialType = this.lookupRepository.GetMaterialList();

            return this.brandingFactory.EditBrandingMaterialPrice(MaterialType, brandingMaterialPrice);
        }

        /// <summary>
        /// Gets the branding material view.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IBrandingMaterialView GetBrandingMaterialView(IBrandingMaterialView brandingMaterialView, string message)
        {
            return this.brandingFactory.CreateBrandingMaterialView(brandingMaterialView, message);
        }


        /// <summary>
        /// Updates the branding material information.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">brandingMaterialView</exception>
        public string UpdateBrandingMaterialInfo(IBrandingMaterialView brandingMaterialView)
        {
            var processingMessage = string.Empty;

            if (brandingMaterialView == null)
            {
                throw new ArgumentException(nameof(brandingMaterialView));
            }


            //Check that The Description Name Does not Exist Already

            var material = this.brandingRepository.GetBrandingMaterialByName(brandingMaterialView.Description);


            //Check The Names
            if (material != null)
            {
                processingMessage = Messages.DescriptionExist; // Name Already Existed
            }
            else
            {
                //All is Fine, We can Update
                processingMessage = this.brandingRepository.EditMaterial(brandingMaterialView);
            }


            return processingMessage;
        }

        /// <summary>
        /// Gets the material price view.
        /// </summary>
        /// <param name="brandingMaterialPriceView">The branding material price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IBrandingMaterialPriceView GetMaterialPriceView(IBrandingMaterialPriceView brandingMaterialPriceView,
            string message)
        {
            var materialTypeList = this.lookupRepository.GetMaterialList();
            return this.brandingFactory.CreateBrandingMaterialPriceView(brandingMaterialPriceView, message,
                materialTypeList);
        }

        /// <summary>
        /// Gets the branding material price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IBrandingView GetBrandingMaterialPrice(int Id)
        {
            var BrandingMaterial = this.lookupRepository.GetBrandingMaterialAmountById(Id);

            return this.brandingFactory.GetBrandingMaterialViews(BrandingMaterial);
        }


        //gets the  order details by  user
        /// <summary>
        /// Gets the user branding view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        public IBrandingView GetUserBrandingView(int transactionId)
        {
            var brandingTransaction = this.brandingRepository.GetTransactionDetails(transactionId);
            var brandingAttachmentTransaction =
                this.brandingRepository.GetBrandingAttachmentTransactionsById(transactionId);
            var brandingColor = this.brandingRepository.GetSelectedColor(transactionId);
            var bradningDesignTransaction =
                this.brandingRepository.GetBrandingTransactionDesignElementById(transactionId);
            var brandingMaterialTransaction =
                this.brandingRepository.GetIBrandingTransactionMaterialById(transactionId);
            return this.brandingFactory.GetUserBrandingTransaction(brandingTransaction, brandingColor,
                brandingAttachmentTransaction, bradningDesignTransaction, brandingMaterialTransaction);
        }




       

        /// <summary>
        /// Updates the cart.
        /// </summary>
        public void UpdateCart()
        {
            //Get Current Cart Value
            var cart = 0;

            var brandingCart = 0;

            var isBrandingCartValueExist = session.CheckCurrentSessionValueExists(SessionKey.BrandingCart);


            //Check Tv Cart
            if (isBrandingCartValueExist)
            {
                var orders = new List<IBrandingView>();
                orders = (List<IBrandingView>) session.GetSessionValue(SessionKey.BrandingCart);
                brandingCart = orders.Count;
                cart += brandingCart;
            }


            //TODO: Radio Order, Online Order, Print Media, Brading Order

            session.AddValueToSession(SessionKey.CartNumber, cart);
        }


        
      
        /// <summary>
        /// Deletes the brand order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        public string DeleteBrandOrder(int transactionId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }
            return this.brandingRepository.DeleteBrandOrder(transactionId);
        }
       

        /// <summary>
        /// Gets the branding attachment message replies ListView.
       
        

        public IBrandingView GetBrandingUpdatedView(IBrandingView brandingView, string ProcessingMessage)
        {

            var colorList = this.lookupRepository.GetColor();
            var DesignElementList = this.lookupRepository.GetDesignElementPriceList();
            var BrandingMaterialList = this.lookupRepository.GetMaterialList();

            return this.brandingFactory.CreateUpdateBrandingView(brandingView, BrandingMaterialList, colorList, DesignElementList, ProcessingMessage);
        }

      
    }
}