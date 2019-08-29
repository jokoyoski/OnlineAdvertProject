using ADit.Domain.Models;
using ADit.Domain.Utilities;
using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADit.Domain.Factories
{
    public class FulfilmentFactory : IFulfilmentFactory
    {
        /// <summary>
        /// Creates the fulfilment summary.
        /// </summary>
        /// <param name="fulfilmentSummary">The fulfilment summary.</param>
        /// <returns></returns>
        public IFulfilmentStatusSummaryViewModel CreateFulfilmentSummary(
            IList<IFulfilmentStatusSummaryModel> fulfilmentSummary)
        {
            var fulfilmentSummaries = new FulfilmentStatusSummaryViewModel
            {
                FulfilmentStatusSummaries = fulfilmentSummary
            };

            return fulfilmentSummaries;
        }





        // <summary>
        /// Creates the fulfilment summary.
        /// </summary>
        /// <param name="fulfilmentSummary">The fulfilment summary.</param>
        /// <returns></returns>
        public IFulfilmentServiceSummaryView CreateFulfilmentServiceSummary(
            IList<IFulfilmentServiceSummaryModel> fulfilmentSummary)
        {
            var fulfilmentSummaries = new FulfilmentServiceSummaryView
            {
                FulfilmentServiceSummaries=fulfilmentSummary
            };

            return fulfilmentSummaries;
        }

        /// <summary>
        /// Gets the order fufilments.
        /// </summary>
        /// <param name="orderFufilments">The order fufilments.</param>
        /// <returns></returns>
        public IOrderFulfilmentListView GetOrderFufilments(IList<IOrderFulfilment> orderFufilments)
        {
            var order = new OrderFulfilmentListView
            {
                OrderFulfilments = orderFufilments,
               
            };
            return order;
        }


        /// <summary>
        /// Gets the fulfilment branding transaction.
        /// </summary>
        /// <param name="brandingTransaction">The branding transaction.</param>
        /// <param name="brandingTransactionColors">The branding transaction colors.</param>
        /// <param name="brandingTransactionAttachment">The branding transaction attachment.</param>
        /// <param name="brandingTransactionDesignElement">The branding transaction design element.</param>
        /// <param name="brandingTransactionMaterial">The branding transaction material.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="orderFulfilmentStatuses">The order fulfilment statuses.</param>
        /// <param name="CurrentStatusCode">The current status code.</param>
        /// <param name="OrderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// brandingTransactionMaterial
        /// or
        /// brandingTransactionDesignElement
        /// or
        /// brandingTransactionAttachment
        /// </exception>
        public IBrandingView GetFulfilmentBrandingTransaction(IBrandingTransaction brandingTransaction,
            IList<IBrandingTransactionColor> brandingTransactionColors,
            IBrandingTransactionAttachment brandingTransactionAttachment,
            IBrandingTransactionDesignElement brandingTransactionDesignElement,
            IBrandingTransactionMaterial brandingTransactionMaterial, IDigitalFile digitalFile,
            IList<IOrderFulfilmentStatus> orderFulfilmentStatuses, string CurrentStatusCode,string CurrentStatusDescription, int OrderFulfilmentId)
        {
            if (brandingTransactionMaterial == null)
            {
                throw new ArgumentNullException(nameof(brandingTransactionMaterial));
            }

            if (brandingTransactionDesignElement == null)
            {
                throw new ArgumentNullException(nameof(brandingTransactionDesignElement));
            }

            if (brandingTransactionAttachment == null)
            {
                throw new ArgumentNullException(nameof(brandingTransactionAttachment));
            }

            List<string> Colors = new List<string>();
            foreach (var j in brandingTransactionColors)
            {
                // ad colors
                Colors.Add(j.Color);
            }

            var statusCodeDDl = GetOrderStatusDropdown.OrderSelectListItem(orderFulfilmentStatuses, -1);

            var view = new BrandingView
            {
                OrderTitle = brandingTransaction.OrderTitle,
                BrandingMaterial = brandingTransactionMaterial.BrandingMaterial,
                BrandingMaterialAmount = brandingTransactionMaterial.BrandingMaterialAmount,
                AdditionalColorInfo = brandingTransaction.OtherColor,
                DesignElement = brandingTransactionDesignElement.DesignElement,
                DesignElementAmount = brandingTransactionDesignElement.DesignElementAmount,
                DesignDigitalFileId = brandingTransactionAttachment.DigitalFileId,
                AdditionalInformation = brandingTransaction.AdditionalInformation,
                Colors = Colors,
                TotalAmount = brandingTransaction.TotalAmount,
                Name = brandingTransaction.UserName,
                PhoneNumber = brandingTransaction.PhoneNumber,
                Email = brandingTransaction.Email,
                BrandingFileId = brandingTransaction.BrandingFileId,
                UserId = brandingTransaction.UserId,
                BrandingTransactionId = brandingTransaction.BrandingTransactionId,
                OrderFulfilmentId = OrderFulfilmentId,
                DateCreated = brandingTransaction.DateCreated,
                StatusCodeList = statusCodeDDl,
                digitalFile = digitalFile,
                OrderId = brandingTransaction.OrderId,
                CurrentOrderStatus = CurrentStatusCode,
                CurrentStatusDescription=CurrentStatusDescription,
            };

            return view;
        }

        /// <summary>
        /// Gets the fufillment print transaction.
        /// </summary>
        /// <param name="printTransaction">The print transaction.</param>
        /// <param name="printTransactionAirings">The print transaction airings.</param>
        /// <param name="replies">The replies.</param>
        /// <param name="messages">The messages.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printTransaction</exception>
        public IPrintMediaModelView GetFufillmentPrintTransaction(IPrintTransaction printTransaction,
            IList<IPrintTransactionAiring> printTransactionAirings,
            IList<IOrderFulfilmentStatus> orderFulfilmentStatuses, string CurrentStatusCode,string CurrentStatusDescription ,int OrderFulfilmentId)
        {
            if (printTransaction == null)
            {
                throw new ArgumentNullException(nameof(printTransaction));
            }

            List<string> NewspaperList = new List<string>();
            List<string> PrintServciceTypeList = new List<string>();
            List<int> NumberOfInsertList = new List<int>();
            List<decimal> PricesList = new List<decimal>();
            List<string> PrintMediaTypeList = new List<string>();

            foreach (var j in printTransactionAirings)
            {
                NewspaperList.Add(j.Newspaper);
                PrintServciceTypeList.Add(j.PrintServiceType);
                NumberOfInsertList.Add(j.NumberOfInserts);
                PricesList.Add(j.Price);
                PrintMediaTypeList.Add(j.PrintMediaType);
            }

            var statusCodeDDl = GetOrderStatusDropdown.OrderSelectListItem(orderFulfilmentStatuses, -1);


            var view = new PrintMediaModelView
            {
                DateCreated = printTransaction.DateCreated,
                ApconAmount = printTransaction.ApconApprovalAmount,
                Name = printTransaction.Name,
                Email = printTransaction.Email,
                PhoneNumber = printTransaction.PhoneNumber,
                MaterialDigitalFileId = printTransaction.MaterialDigitalFileId,
                OrderTitle = printTransaction.OrderTitle,
                ApconType = printTransaction.ApconType,
                ApconApprovalNumber = printTransaction.ApconApprovalNumber,
                Category = printTransaction.Category,
                DesignElement = printTransaction.DesignElement,
                DesignElementAmount = printTransaction.DesignAmount,
                DurationTypes = printTransaction.DurationType,
                NewspapersList = NewspaperList,
                PrintServciceTypeList = PrintServciceTypeList,
                NummberOfInsertList = NumberOfInsertList,
                PricesList = PricesList,
                TotalAmount = printTransaction.TotalPrice,
                StatusCodeList = statusCodeDDl,
                PrintTransactionId = printTransaction.PrintTransactionId,
                UserId = printTransaction.UserId,
                CurrentStatusCode = CurrentStatusCode,
                OrderId = printTransaction.OrderId,
                PrintMediaList= PrintMediaTypeList,
                OrderFulfilmentId = OrderFulfilmentId,
                CurrentStatusDescription=CurrentStatusDescription
            };
            return view;
        }

        /// <summary>
        /// Gets the user transaction.
        /// </summary>
        /// <param name="radioOrder">The radio order.</param>
        /// <param name="radioAiringTransactionModels">The radio airing transaction models.</param>
        /// <param name="materialTypes">The material types.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioOrder</exception>
        public IRadioMainView GetFulfilmentTransaction(IRadioOrder radioOrder,
            IList<IMaterialType> activeMaterialTypeCollection,
            IList<IRadioTransactionAiring> radioAiringTransactionModels,
            IList<IOrderFulfilmentStatus> orderFufilmentStatuses, string CurrentStatusCode ,string currentStatusDescrption,int OrderFulfilmentId,
            string processingMessage)
        {
            if (radioOrder == null)
            {
                throw new ArgumentNullException(nameof(radioOrder));
            }

            List<string> radioStationList = new List<string>();
            List<string> TimingList = new List<string>();
            List<int> SlotList = new List<int>();
            List<int> TotalSlotList = new List<int>();
            List<decimal> Prices = new List<decimal>();
            List<DateTime> StartDateList = new List<DateTime>();
            List<DateTime> EndDateList = new List<DateTime>();
            List<string> TimeBeltNameList = new List<string>();

            //gets the Airing information to  a list


            foreach (var j in radioAiringTransactionModels)
            {
                //radio station name
                radioStationList.Add(j.RadioStationName);
                //timing name
                TimingList.Add(j.TimeBeltName);
                //slot List
                SlotList.Add(j.Slots);
                //total slot
                TotalSlotList.Add(j.TotalSlots);
                //prices
                Prices.Add(j.Price);
                //start date
                StartDateList.Add(j.StartDate);
                //end date
                EndDateList.Add(j.EndDate);
                //timebelt name
                TimeBeltNameList.Add(j.TimeBeltName);
            }

            var activeMaterialTypeDDL =
                GetDropdownMaterialTypeList.MaterialTypeListItems(activeMaterialTypeCollection, -1);

            var statusCodeDDl = GetOrderStatusDropdown.OrderSelectListItem(orderFufilmentStatuses, -1);

            var view = new RadioMainView
            {
                OrderFulfilmentId = OrderFulfilmentId,
                userId = radioOrder.userId,
                RadioTransactionId = radioOrder.RadioTransactionId,
                ApconType = radioOrder.ApconType,
                AiringDescription = radioOrder.AiringDescription,
                ApconApprovalAmount = radioOrder.ApconApprovalAmount,
                IsHaveApconApproval = radioOrder.IsHaveApconApproval,
                ApconApprovalTypeId = radioOrder.ApconApprovalTypeId,
                DateCreated = radioOrder.DateCreated,
                email = radioOrder.Email,
                PhoneNumber = radioOrder.PhoneNumber,
                FirstName = radioOrder.FirstName,
                LastName = radioOrder.LastName,
                ProcessingMessage = processingMessage,
                ApconApprovalNumber = radioOrder.ApconApprovalNumber,
                StatusCodeList = statusCodeDDl,
                MaterialTypeName = radioOrder.MaterialTypeName,
                CurrentStatusCode = CurrentStatusCode,
                FinalAmount = radioOrder.FinalAmount,
                ActiveMaterialType = activeMaterialTypeDDL,
                OrderTitle = radioOrder.OrderTitle,
                ProductionAmount = radioOrder.ProductionAmount,
                ScriptingAmount = radioOrder.ScriptingAmount,
                MaterialTypeId = radioOrder.MaterialTypeId,
                ScriptDigitalFileId = radioOrder.ScriptDigitalFileId,
                MaterialDigitalFileId = radioOrder.MaterialDigitalFileId,
                IsHaveMaterial = radioOrder.IsHaveMaterial,
                TimeBeltNamesList = TimeBeltNameList,
                RadioStationNameList = radioStationList,
                TimingList = TimingList,
                SlotsList = SlotList,
                TotalSlotsList = TotalSlotList,
                PricesList = Prices,
                StartDateList = StartDateList,
                EndDateList = EndDateList,
                CurrentStatusDescription=currentStatusDescrption,
                OrderId = radioOrder.OrderId,
            };
            return view;
        }


        /// <summary>
        /// Gets the fulfilment online transaction.
        /// </summary>
        /// <param name="onlineTransaction">The online transaction.</param>
        /// <param name="onlineTransactionAiring">The online transaction airing.</param>
        /// <param name="onlineTransactionExtraService">The online transaction extra service.</param>
        /// <param name="orderFulfilmentStatuses">The order fulfilment statuses.</param>
        /// <param name="CurrentStatusCode">The current status code.</param>
        /// <param name="OrderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineTransaction
        /// or
        /// onlineTransactionAiring
        /// or
        /// onlineTransactionExtraService
        /// </exception>
        public IOnlineView GetFulfilmentOnlineTransaction(IOnlineTransaction onlineTransaction,
            IList<IOnlineTransactionAiringUI> onlineTransactionAiring,
            IOnlineTransactionExtraService onlineTransactionExtraService,
            IList<IOrderFulfilmentStatus> orderFulfilmentStatuses, string CurrentStatusCode, string CurrentStatusDescription,int OrderFulfilmentId)

        {
            if (onlineTransaction == null)
            {
                throw new ArgumentNullException(nameof(onlineTransaction));
            }


            if (onlineTransactionAiring == null)
            {
                throw new ArgumentNullException(nameof(onlineTransactionAiring));
            }


            if (onlineTransactionExtraService == null)
            {
                throw new ArgumentNullException(nameof(onlineTransactionExtraService));
            }

            List<string> durationList = new List<string>();
            List<decimal> priceList = new List<decimal>();
            List<string> platformList = new List<string>();


            foreach (var j in onlineTransactionAiring)
            {
                platformList.Add(j.OnlinePlatformDescription);

                priceList.Add(j.Price);

                durationList.Add(j.OnlineDurationDesccription);
            }


            var statusCodeDDl = GetOrderStatusDropdown.OrderSelectListItem(orderFulfilmentStatuses, -1);
            var view = new OnlineView
            {
                CurrentStatusDescription=CurrentStatusDescription,
                CuurentStatusCode = CurrentStatusCode,
                OrderNumber = onlineTransaction.OrderId,
                OnlinePurpose = onlineTransaction.OnlinePurpose,
                Email = onlineTransaction.Email,
                PhoneNumber = onlineTransaction.PhoneNumber,
                Name = onlineTransaction.Name,
                AdditionalInformation = onlineTransaction.AdditionalInformation,
                IsHaveArtWork = onlineTransaction.IsHaveArtWork,
                ArtWorkAmount = onlineTransaction.ArtWorkAmount,
                OrderTitle = onlineTransaction.OrderTitle,
                DateCreated = onlineTransaction.DateCreated,
                ArtworkDigitalFileId = onlineTransaction.ArtworkDigitalFileId,
                finalAmount = onlineTransaction.Price,
                OnlineExtraServicAmount = onlineTransactionExtraService.OnlineExtraServiceAmount,
                OnlineExtraService = onlineTransactionExtraService.OnlineExtraService,
                PlatformDescription = platformList,
                DurationDescription = durationList,
                Prices = priceList,
                StatusCodeList = statusCodeDDl,
                UserId = onlineTransaction.UserId,
                OnlineTransactionId = onlineTransaction.OnlineTransactionId,
                OrderFulfilmentId = OrderFulfilmentId
            };
            return view;
        }

        /// <summary>
        /// Gets the fulfiment transaction.
        /// </summary>
        /// <param name="tvOrder">The tv order.</param>
        /// <param name="tvTransactionAirings">The tv transaction airings.</param>
        /// <param name="materialTypes">The material types.</param>
        /// <param name="orderFulfilmentStatuses">The order fulfilment statuses.</param>
        /// <param name="CurrentStatusCode">The current status code.</param>
        /// <param name="OrderFulfilmentId">The order fulfilment identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvOrder</exception>
        public ITvView GetFulfimentTransaction(ITvOrder tvOrder, IList<ITvTransactionAiring> tvTransactionAirings,
            IList<IMaterialType> materialTypes, IList<IOrderFulfilmentStatus> orderFulfilmentStatuses,
            string CurrentStatusCode, string CurrentStatusDescription,int OrderFulfilmentId)
        {
            if (tvOrder == null)
            {
                throw new ArgumentNullException(nameof(tvOrder));
            }

            List<string> tvStationList = new List<string>();
            List<string> TimingList = new List<string>();
            List<int> SlotList = new List<int>();
            List<int> TotalSlotList = new List<int>();
            List<decimal> Prices = new List<decimal>();
            List<DateTime> StartDateList = new List<DateTime>();
            List<DateTime> EndDateList = new List<DateTime>();
            List<string> TimeBeltNameList = new List<string>();

            //gets the Airing information to  a list


            foreach (var j in tvTransactionAirings)
            {
                //radio station name
                tvStationList.Add(j.TVStationName);
                //timing name
                TimingList.Add(j.TimingName);
                //slot List
                SlotList.Add(j.Slots);
                //total slot
                TotalSlotList.Add(j.TotalSlots);
                //prices
                Prices.Add(j.Price);
                //start date
                StartDateList.Add(j.StartDate);
                //end date
                EndDateList.Add(j.EndDate);
                //timebelt name
                TimeBeltNameList.Add(j.TimeBeltName);
            }

            var materialTypeDDL =
                GetDropdownMaterialTypeList.MaterialTypeListItems(materialTypes, tvOrder.MaterialTypeId);

            var statusCodeDDl = GetOrderStatusDropdown.OrderSelectListItem(orderFulfilmentStatuses, -1);
            var view = new TvView
            {
                OrderId = tvOrder.OrderId,
                UserId = tvOrder.UserId,
                TVTransactionId = tvOrder.TvTransactionId,
                ApconType = tvOrder.ApconType,
                AiringInstruction = tvOrder.AiringDescription,
                ApconApprovalAmount = tvOrder.ApconApprovalAmount,
                IsHaveApconApproval = tvOrder.IsHaveApconApproval,
                // ApconApprovalTypeId = tvOrder.ApconApprovalTypeId,
                DateCreated = tvOrder.DateCreated,
                email = tvOrder.email,
                PhoneNumber = tvOrder.PhoneNumber,
                UserName = tvOrder.Name,
                CurrentStatusDescription=CurrentStatusDescription,
                ApconApprovalNumber = tvOrder.ApconApprovalNumber,
                CurrentStatusCode = CurrentStatusCode,
                MaterialList = materialTypeDDL,
                OrderFulfilmentId = OrderFulfilmentId,
                FinalAmount = tvOrder.FinalAmount,
                StatusCodeList = statusCodeDDl,
                OrderTitle = tvOrder.OrderTitle,
                ProductionAmount = tvOrder.ProductionAmount,
                ScriptingAmount = tvOrder.ScriptingAmount,
                MaterialTypeId = tvOrder.MaterialTypeId,
                ScriptingDigitalFileId = tvOrder.ScriptingDigitalFileId,
                ProductionDigitalFileId = tvOrder.MaterialDigitalFileId,

                TimeBeltNamesList = TimeBeltNameList,
                TvStationNameList = tvStationList,
                TimingNameList = TimingList,
                SlotsList = SlotList,
                TotalSlotsList = TotalSlotList,
                PricesList = Prices,
                StartDateList = StartDateList,
                EndDateList = EndDateList,
            };
            return view;
        }
    }
}