using AA.Infrastructure.Extensions;
using ADit.Domain.Models;
using ADit.Domain.Utilities;
using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.ITvFactory" />
    public class TvFactory : ITvFactory
    {


        /// <summary>
        /// Creates the tv station ListView.
        /// </summary>
        /// <param name="tvStationListCollection">The tv station list collection.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedTvStationId">The selected tv station identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvStationListCollection</exception>
        public ITvStationListView CreateTvStationListView(IList<ITvStation> tvStationListCollection, string message,
            int selectedTvStationId, string selectedDescription)
        {
            if (tvStationListCollection == null)
            {
                throw new ArgumentNullException(nameof(tvStationListCollection));
            }

            //search by Tv Id
            var FilteredList = tvStationListCollection.Where(x =>
                x.TVStationId.Equals(selectedTvStationId < 1 ? x.TVStationId : selectedTvStationId)).ToList();

            //search by Description
            FilteredList = FilteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();

            var returnView = new TvStationListView
            {
                TvStationCollection = FilteredList.ToList(),
                SelectedTvStationId = selectedTvStationId,
                SelectedDescription = selectedDescription,
                ProcessingMessage = message
            };
            return returnView;
        }


        /// <summary>
        /// Creates the tv station view.
        /// </summary>
        /// <returns></returns>
        public ITvStationView CreateTvStationView()
        {
            var TvView = new TvStationView
            {
                ProcessingMessage = string.Empty
            };
            return TvView;
        }


        /// <summary>
        /// Creates the tv station view.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">tvStationView</exception>
        public ITvStationView CreateTvStationView(ITvStationView tvStationView, string message)
        {
            if (tvStationView == null)
            {
                throw new ArgumentException("tvStationView");
            }


            tvStationView.ProcessingMessage = message;
            return tvStationView;
        }


        /// <summary>
        /// Gets the tv material transaction ListView.
        /// </summary>
        /// <param name="tvMaterialTransactions">The tv material transactions.</param>
        /// <param name="tvTransaction">The tv transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// tvMaterialTransactions
        /// or
        /// tvTransaction
        /// </exception>
        public ITvTransactionMaterialListView GetTvMaterialTransactionListView(
            IList<ITvMaterialTransactionModel> tvMaterialTransactions, ITvTransaction tvTransaction,
            IDigitalFile digitalFile, int? Id, int RepliesId,IList<IMessage>messages,IList<IReplies>replies)
        {
            if (tvMaterialTransactions == null)
            {
                throw new ArgumentNullException(nameof(tvMaterialTransactions));
            }

            if (tvMaterialTransactions == null)
            {
                throw new ArgumentNullException(nameof(tvTransaction));
            }

            var radioList = new TvTransactionMaterialListView
            {
                MessageId = Id,
                AdditionalInfo = tvTransaction.AiringInstruction,
                Name = tvTransaction.UserName,
                OrderTitle = tvTransaction.OrderTitle,
                TvMaterialTransaction = tvMaterialTransactions,

                SentToId = tvTransaction.UserId,
                transactionId = tvTransaction.TVTransactionId,

                RepliesId = RepliesId,
               
                messages=messages,
                replies =replies,
                DigitalFileId = tvTransaction.ProductionDigitalFileId
            };

            return radioList;
        }

        /// <summary>
        /// Creates the updated tv view.
        /// </summary>
        /// <param name="apconApprovalTypeCollections">The apcon approval type collections.</param>
        /// <param name="materialTypeCollections">The material type collections.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="durationTypeCollections">The duration type collections.</param>
        /// <param name="TimingId">The timing identifier.</param>
        /// <param name="materialQuestionCollections">The material question collections.</param>
        /// <param name="timeBeltList">The time belt list.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="tvMainTransaction">The tv main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedTvStationIds">The selected tv station ids.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconApprovalType
        /// or
        /// materialType
        /// or
        /// materialQuestion</exception>
        public ITVTransactionUIView CreateUpdatedView(IList<IApconApprovalType> apconApprovalTypeCollections,
            IList<IMaterialType> materialTypeCollections, IList<ITvStation> tvStation,
            IList<IDurationType> durationTypeCollections, IList<IMaterialTypeTimingModel> TimingId,
            IList<IScriptMaterialQuestion> materialQuestionCollections, IList<ITimeBelt> timeBeltList,
            string processingMessage, ITvTransactionUI tvMainTransaction,
            IEnumerable<ITvTransactionAiringUI> transactionAiring, List<int> selectedTvStationIds)
        {
            if (apconApprovalTypeCollections == null)
            {
                throw new ArgumentNullException("apconApprovalTypeCollections");
            }

            if (materialTypeCollections == null)
            {
                throw new ArgumentNullException("materialTypeCollections");
            }

            if (materialQuestionCollections == null)
            {
                throw new ArgumentNullException(nameof(materialQuestionCollections));
            }

            var apconApprovalTypeDDL = GetDropDownList.ApconApprovalListItems(apconApprovalTypeCollections, -1);
            var materialTypeDDL = GetDropdownMaterialTypeList.MaterialTypeListItems(materialTypeCollections, -1);
            var materialQuestionDDL = GetDropDownList.ScriptMaterialQuestionListItems(materialQuestionCollections, "");
            var tvTimingDDL = GetDropdownTimingList.TimingList(TimingId, -1);
            var timeBeltDDL = GetDropDownTimeBelt.TimeBeltItems(timeBeltList, -1);

            //Checking for Selected Television Stations and Set IsSelected to true if a Tv Station is selected
            transactionAiring.Each(x => x.IsSelected = selectedTvStationIds.Contains(x.TvStationId));


            var updatedAiringList = transactionAiring.ToList();


            var viewModel = new TvTransactionUIView
            {
                ApconApprovalType = apconApprovalTypeDDL,
                ActiveMaterialType = materialTypeDDL,
                TvStationList = tvStation,
                TimingType = tvTimingDDL,
                ScriptQuestion = materialQuestionDDL,
                TimeBeltList = timeBeltDDL,
                SelectedTvStationIds = selectedTvStationIds,
                ProcessingMessage = processingMessage,
                AiringDetailsList = updatedAiringList,
                OrderTitle = tvMainTransaction.OrderTitle,
                ScriptDescription = tvMainTransaction.ScriptDescription,
                ScriptingAmount = tvMainTransaction.ScriptingAmount,
                ProductionAmount = tvMainTransaction.ProductionAmount,
                ScriptDigitalFileId = tvMainTransaction.ScriptDigitalFileId,
                ApconApprovalAmount = tvMainTransaction.ApconApprovalAmount,
                ApconApprovalNumber = tvMainTransaction.ApconApprovalNumber,
                IsHaveApconApproval = tvMainTransaction.IsHaveApconApproval,
                IsHaveMaterial = tvMainTransaction.IsHaveMaterial,
                TvTransactionId = tvMainTransaction.TvTransactionId,
                OrderId = tvMainTransaction.OrderId,
                AiringInstruction = tvMainTransaction.AiringInstruction
            };
            return viewModel;
        }


        /// <summary>
        /// Gets the edit tv station view.
        /// </summary>
        /// <param name="tvStationView">The tv station view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvStationView</exception>
        public ITvStationView GetEditTvStationView(ITvStation tvStationView)
        {
            if (tvStationView == null) throw new ArgumentNullException(nameof(tvStationView));
            var view = new TvStationView
            {
                ProcessingMessage = "",
                Description = tvStationView.Description,
                TVStationId = tvStationView.TVStationId
            };

            return view;
        }

        /// <summary>
        /// Gets the tv view.
        /// </summary>
        /// <param name="apconApprovalTypeCollections">The apcon approval type collections.</param>
        /// <param name="materialTypeCollections">The material type collections.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="durationTypeCollections">The duration type collections.</param>
        /// <param name="timingCollections">The timing collectons.</param>
        /// <param name="materialQuestionCollections">The material question collections.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconApprovalType
        /// or
        /// materialType
        /// or
        /// materialQuestionCollections</exception>
        public ITVTransactionUIView GetTvView(IList<IApconApprovalType> apconApprovalTypeCollections,
            IList<IMaterialType> materialTypeCollections, IList<ITvStation> tvStation,
            IList<IDurationType> durationTypeCollections,
            IList<ITiming> timingCollections,
            IList<IScriptMaterialQuestion> materialQuestionCollections, IList<ITimeBelt> timeBelts)
        {
            if (apconApprovalTypeCollections == null)
            {
                throw new ArgumentNullException("apconApprovalTypeCollections");
            }

            if (materialTypeCollections == null)
            {
                throw new ArgumentNullException("materialTypeCollections");
            }

            if (materialQuestionCollections == null)
            {
                throw new ArgumentNullException(nameof(materialQuestionCollections));
            }

            if (timeBelts == null)
            {
                throw new ArgumentNullException(nameof(timeBelts));
            }

            var apconApprovalTypeDDL = GetDropDownList.ApconApprovalListItems(apconApprovalTypeCollections, -1);
            var materialTypeDDL = GetDropdownMaterialTypeList.MaterialTypeListItems(materialTypeCollections, -1);
            var materialQuestionDDL = GetDropDownList.ScriptMaterialQuestionListItems(materialQuestionCollections, "");
            var tvTimingDDL = GetDropdownTimingList.TimingListItems(timingCollections, -1);
            var timeBeltDDL = GetDropDownTimeBelt.TimeBeltItems(timeBelts, -1);

            var tvAiringList = new List<ITvTransactionAiringUI>();

            foreach (var a in tvStation)
            {
                var tvAiring = new TvTransactionAiringUI
                {
                    TvStationId = a.TVStationId,
                    IsSelected = false
                };
                tvAiringList.Add(tvAiring);
            }

            var views = new TvTransactionUIView
            {
                ApconApprovalType = apconApprovalTypeDDL,
                ActiveMaterialType = materialTypeDDL,
                ScriptQuestion = materialQuestionDDL,
                AiringDetailsList = tvAiringList,
                TvStationList = tvStation,

                TimingType = tvTimingDDL,
                TimeBeltList = timeBeltDDL,
                ProcessingMessage = string.Empty
            };

            return views;
        }

        /// <summary>
        /// Gets the scripting price for tv.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price</exception>
        public ITvView GetScriptingPriceForTv(IMaterialScriptingPrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            var view = new TvView
            {
                MaterialScriptingTypeId = price.MaterialScriptingPriceId,
                ScriptingAmount = price.Amount
            };
            return view;
        }

        /// <summary>
        /// Gets the production price for tv.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price</exception>

        public ITvScriptTrsancsationListView GetTvScriptTrsancsationListView (int transactionId, int SentToId)
        {
            var tv = new TvScriptTrsancsationListView
            {
               transactionId = transactionId,
                SentToId = SentToId

            };

            return tv;
        }


        /// <summary>
        /// Gets the production price for tv.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price</exception>
        public ITvView GetProductionPriceForTv(IMaterialProductionPrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            var view = new TvView
            {
                MaterialProductionTypeId = price.MaterialProductionPriceId,
                ProductionAmount = price.Amount
            };
            return view;
        }


        /// <summary>
        /// Gets the tv transaction edit view.
        /// </summary>
        /// <param name="tvOrder">The tv order.</param>
        /// <param name="tvTransactionAirings">The tv transaction airing.</param>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="materialQuestion">The material question.</param>
        /// <param name="tvStations">The tv stations.</param>
        /// <param name="durationTypeCollections">The duration type collections.</param>
        /// <param name="timingCollections">The timing collections.</param>
        /// <param name="timeBeltCollections">The time belt collections.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconApprovalType
        /// or
        /// materialType
        /// or
        /// materialQuestion</exception>
        public ITVTransactionUIView GetTvTransactionEditView(ITvOrder tvOrder, IList<ITvTransactionAiringUI> tvTransactionAiring, IList<int> SelectionTvIds,
             IList<IApconApprovalType> apconApprovalType,
             IList<IMaterialType> materialType,
             IList<IScriptMaterialQuestion> materialQuestion, IList<ITvStation> tvStation,
             IList<IDurationType> durationTypeCollections,
             IList<ITiming> timingCollections,
             IList<ITimeBelt> timeBeltCollections,
             string processingMessage)


        {
            if (apconApprovalType == null)
            {
                throw new ArgumentNullException("apconApprovalType");
            }

            if (materialType == null)
            {
                throw new ArgumentNullException("materialType");
            }

            if (materialQuestion == null)
            {
                throw new ArgumentNullException(nameof(materialQuestion));
            }

            //The Apcon ApprovaleDropdown
            var apconApprovalTypeDDL =
                GetDropDownList.ApconApprovalListItems(apconApprovalType, tvOrder.ApconApprovalId.Value);

            var tvTimingDDL = GetDropdownTimingList.TimingListItems(timingCollections, -1);
            //Material Type Dropdown
            var materialTypeDDL =
                GetDropdownMaterialTypeList.MaterialTypeListItems(materialType, tvOrder.MaterialTypeId);

            //Material Question Dropdown    
            var materialQuestionDDL =
                GetDropDownList.ScriptMaterialQuestionListItems(materialQuestion, tvOrder.ScriptMaterialQuestionCode);
            var timeBeltDDL = GetDropDownTimeBelt.TimeBeltItems(timeBeltCollections,-1);
            //TV Duration TypeDrop Down
            var tvDurationTypeDDL = GetDropDownList.DurationTypeListItems(durationTypeCollections, "");

            //gets the list of selectedIds
            // transactionAiring.Each(x => x.IsSelected = selectedRadioStationIds.Contains(x.RadioStationId));
            tvTransactionAiring.Each(x => x.IsSelected = SelectionTvIds.Contains(x.TvStationId));
            var updatedAiringList = tvTransactionAiring.ToList();

            // add radio airing records for stations not added before from the database
            foreach (var r in tvStation)
            {
                if (!SelectionTvIds.Contains(r.TVStationId))
                {
                    var aTran = new TvTransactionAiringUI
                    {
                        TvStationId = r.TVStationId,
                        IsSelected = false
                    };

                    tvTransactionAiring.Add(aTran);
                }
            }
            var view = new TvTransactionUIView
            {
                TvTransactionId = tvOrder.TvTransactionId,
                AiringInstruction = tvOrder.AiringDescription,
                ApconApprovalAmount = tvOrder.ApconApprovalAmount,
                TimeBeltList=timeBeltDDL,
                TimingType=tvTimingDDL,
                ScriptDigitalFileId = tvOrder.ScriptingDigitalFileId,
                MaterialDigitalFileId = tvOrder.MaterialProductionPriceId,
                ApconApprovalTypeId = tvOrder.ApconApprovalId,
                ApconApprovalNumber = tvOrder.ApconApprovalNumber,
               ScriptQuestion= materialQuestionDDL,
                ScriptMaterialQuestionCode = tvOrder.ScriptMaterialQuestionCode,
                FinalAmount = tvOrder.FinalAmount,
                ProcessingMessage = processingMessage,
                OrderTitle = tvOrder.OrderTitle,
                ProductionAmount = tvOrder.ProductionAmount,
                ScriptingAmount = tvOrder.ScriptingAmount,
                MaterialTypeId = tvOrder.MaterialTypeId,
                
                TvStationList=tvStation,

                OrderId = tvOrder.OrderId,
                ScriptFileDescription=tvOrder.ScriptFileDescription,
                MaterialFileDescription=tvOrder.MaterialFileDescription,


                //Lists

                ApconApprovalType = apconApprovalTypeDDL,
                ActiveMaterialType = materialTypeDDL,


                AiringDetailsList = tvTransactionAiring.ToList()
            };
            return view;
        }

            /// <summary>
            /// Gets the tv airing view.
            /// </summary>
            /// <param name="transactionId">The transaction identifier.</param>
            /// <param name="tvStationList">The tv station list.</param>
            /// <param name="durationTypeList">The duration type list.</param>
            /// <param name="timingList">The timing list.</param>
            /// <param name="processingMessage">The processing message.</param>
            /// <returns></returns>
            public ITVTransactionAiringView GetTvAiringView(int transactionId,
            IList<ITvStation> tvStationList, IList<IDurationType> durationTypeList,
            IList<ITiming> timingList, string processingMessage)
        {
            var durationTypeDDL = GetDropDownList.DurationTypeListItems(durationTypeList, "-1");
            var timingDDL = GetDropdownTimingList.TimingListItems(timingList, -1);
            var stationDDL = GetDropDownList.TvStationListItems(tvStationList, -1);

            var modelView = new TVTransactionAiringView
            {
                TvTransactionId = transactionId,
                DurationTypeCodeList = durationTypeDDL,
                TvStationsList = stationDDL,
                Timing = timingDDL,

                ProcessingMessage = processingMessage,
            };

            return modelView;
        }

        /// <summary>
        /// Gets the itv service prices list.
        /// </summary>
        /// <param name="SelectedTvServicesPriceId">The selected tv services price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="tVServicePricesList">The t v service prices list.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tVServicePricesList</exception>
        public ITVServicePricesListMainView GetITVServicePricesList(int SelectedTvServicesPriceId,
            string selectedDescription, IList<ITVServicePricesList> tVServicePricesList, string processingMessage)
        {
            if (tVServicePricesList == null)
            {
                throw new ArgumentNullException(nameof(tVServicePricesList));
            }

            // filter with ApconApprovalTypeId
            var filteredList = tVServicePricesList.Where(x =>
                x.TvServicesPriceListId.Equals(SelectedTvServicesPriceId < 1
                    ? x.TvServicesPriceListId
                    : SelectedTvServicesPriceId)).ToList();

            // search by description
            filteredList = filteredList.Where(x => x.TvStationDescription.Contains(
                    string.IsNullOrEmpty(selectedDescription)
                        ? x.TvStationDescription
                        : selectedDescription))
                .ToList();


            //// filter with ApconApprovalTypeDescription

            var view = new TvServicePriceListMainView
            {
                tVServicePricesListCollection = filteredList,
                processingMessage = processingMessage ?? "",
                SelectedTvServicesPriceId = SelectedTvServicesPriceId
            };
            return view;
        }

        /// <summary>
        /// Getedits the tv service price ListView.
        /// </summary>
        /// <param name="tVServicePricesList">The t v service prices list.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="timing">The timing.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// tVServicePricesList
        /// or
        /// tvStation
        /// or
        /// timing
        /// </exception>
        public ITVServicePricesListView GeteditTvServicePriceListView(ITVServicePricesList tVServicePricesList,
            IList<ITvStation> tvStation, IList<ITiming> timing, IList<ITimeBelt> timeBelts,IList<IMaterialType>materialTypes)
        {
            if (tVServicePricesList == null)
            {
                throw new ArgumentNullException(nameof(tVServicePricesList));
            }

            if (tvStation == null)
            {
                throw new ArgumentNullException(nameof(tvStation));
            }

            if (timing == null)
            {
                throw new ArgumentNullException(nameof(timing));
            }

            var timingDDL = GetDropdownTimingList.TimingListItems(timing, -1);
            var tvStationDDL = GetDropDownTvStationList.tvStation(tvStation, -1);
            var timingBeltDDL = GetDropDownTimeBelt.TimeBeltItems(timeBelts, -1);
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(materialTypes, -1);
            var view = new TVServicesPricesListView
            {
                MaterialTypeId=tVServicePricesList.MaterialTypeId,
                MaterialType=materialType,
                Amount = tVServicePricesList.Amount,
                DateEffective = tVServicePricesList.DateEffective,
                DateInActive = tVServicePricesList.DateInActive,
                IsActive = tVServicePricesList.IsActive,
                TimingId = tVServicePricesList.Time,
                TimingCollection = timingDDL,
                TvStationId = tVServicePricesList.TvStation,
                tvCollection = tvStationDDL,
                TvServicesPriceListId = tVServicePricesList.TvServicesPriceListId,
                TimingBeltId = tVServicePricesList.TimingBeltId,

                timeBeltCollection = timingBeltDDL
            };
            return view;
        }

        /// <summary>
        /// Gets the tv service prices ListView.
        /// </summary>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="TimingType">Type of the timing.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// tvStation
        /// or
        /// TimingType
        /// </exception>
        public ITVServicePricesListView GetTVServicePricesListView(IList<ITvStation> tvStation,
            IList<ITiming> TimingType, IList<ITimeBelt> timeBelts,IList<IMaterialType>materialTypes)
        {
            if (tvStation == null)
            {
                throw new ArgumentNullException(nameof(tvStation));
            }

            if (TimingType == null)
            {
                throw new ArgumentNullException(nameof(TimingType));
            }

            var tvStationDDL = GetDropDownTvStationList.tvStation(tvStation, -1);
            var timingDDL = GetDropdownTimingList.TimingListItems(TimingType, -1);
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(materialTypes, -1);
            var timingBeltDDL = GetDropDownTimeBelt.TimeBeltItems(timeBelts, -1);
            var view = new TVServicesPricesListView
            {
                tvCollection = tvStationDDL,
                TimingCollection = timingDDL,
                timeBeltCollection = timingBeltDDL,
                MaterialType=materialType
                
            };
            return view;
        }

        /// <summary>
        /// Gets the updated tv services ListView.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="timing"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tVServicePricesListView</exception>
        public ITVServicePricesListView GetUpdatedTvServicesListView(ITVServicePricesListView tVServicePricesListView,
            string processingMessage, IList<ITvStation> tvStation, IList<ITiming> timing)
        {
            if (tVServicePricesListView == null)
            {
                throw new ArgumentNullException(nameof(tVServicePricesListView));
            }


            var tvDDL = GetDropDownTvStationList.tvStation(tvStation, -1);
            var timingDDL = GetDropdownTimingList.TimingListItems(timing, -1);
            tVServicePricesListView.tvCollection = tvDDL;
            tVServicePricesListView.TimingCollection = timingDDL;


            tVServicePricesListView.processingMessage = processingMessage;
            tVServicePricesListView.tvCollection = tvDDL;
            tVServicePricesListView.TimingCollection = timingDDL;

            return tVServicePricesListView;
        }


        /// <summary>
        /// Gets the add tv services ListView.
        /// </summary>
        /// <param name="tVServicePricesListView">The t v service prices ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="timing">The timing.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tVServicePricesListView</exception>
        public ITVServicePricesListView GetAddTvServicesListView(ITVServicePricesListView tVServicePricesListView,
            string processingMessage, IList<ITvStation> tvStation, IList<ITiming> timing)
        {
            if (tVServicePricesListView == null)
            {
                throw new ArgumentNullException(nameof(tVServicePricesListView));
            }


            var tvDDL = GetDropDownTvStationList.tvStation(tvStation, tVServicePricesListView.TvStationId);
            var timingDDL = GetDropdownTimingList.TimingListItems(timing, tVServicePricesListView.TimingId);
            tVServicePricesListView.tvCollection = tvDDL;
            tVServicePricesListView.TimingCollection = timingDDL;

            return tVServicePricesListView;
        }

        /// <summary>
        /// Gets the material message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">message</exception>
        public IMessageRepliesListView GetMaterialMessageRepliesListView(IList<IReplies> replies, IMessage message,int sentToId,int transactionId,int OrderId)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var view = new MessageRepliesListView
            {
                InitialMessage = message.Message,
                MessageId = message.Id,
                SentToId = sentToId,
                transactionId = transactionId,
                UserId = message.UserId,
                Replies = replies,
                IsApproved = message.IsApproved,
                DigitalFileId = message.DigitalFileId,
                OrderId=OrderId,
            };
            return view;
        }

        /// <summary>
        /// Gets the tv script trsancsation ListView.
        /// </summary>
        /// <param name="tvScriptingTransactionModelViews">The tv scripting transaction model views.</param>
        /// <param name="tvTransaction">The tv transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// tvScriptingTransactionModelViews
        /// or
        /// tvTransaction
        /// </exception>
        public ITvScriptTrsancsationListView GetTvScriptTrsancsationListView(
            IList<ITvScriptingTransactionModelView> tvScriptingTransactionModelViews, ITvTransaction tvTransaction,
            IDigitalFile digitalFile, int? Id, int RepliesId,IList<IMessage>messages,IList<IReplies>replies)
        {
            if (tvScriptingTransactionModelViews == null)
            {
                throw new ArgumentNullException(nameof(tvScriptingTransactionModelViews));
            }

            if (tvTransaction == null)
            {
                throw new ArgumentNullException(nameof(tvTransaction));
            }

            var tvList = new TvScriptTrsancsationListView
            {
                AdditionalInfo = tvTransaction.AiringInstruction,
                Name = tvTransaction.UserName,
                OrderTitle = tvTransaction.OrderTitle,
                tvScriptTransaction = tvScriptingTransactionModelViews,
                UploadedScriptDetail = digitalFile,
                SentToId = tvTransaction.UserId,
                transactionId = tvTransaction.TVTransactionId,
                MessageId = Id,
                RepliesId = RepliesId,
                messageList = messages,
                repliesList = replies,
                DigitalFileId = tvTransaction.ScriptingDigitalFileId
            };

            return tvList;
        }


        /// <summary>
        /// Gets the script message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">message</exception>
        public IMessageRepliesListView GetScriptMessageRepliesListView(IList<IReplies> replies, IMessage message, int sentToId,int transactionId,int OrderId)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var view = new MessageRepliesListView
            {
                InitialMessage = message.Message,
                MessageId = message.Id,
                SentToId = sentToId,
                transactionId = transactionId,

                Replies = replies,
                IsApproved = message.IsApproved,
                DigitalFileId = message.DigitalFileId,
                OrderId=OrderId,
            };
            return view;
        }


        /// <summary>
        /// Gets the user transaction.
        /// </summary>
        /// <param name="tvOrder">The tv order.</param>
        /// <param name="tvTransactionAirings">The tv transaction airings.</param>
        /// <param name="materialTypes">The material types.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvOrder</exception>
        public ITvView GetUserTransaction(ITvOrder tvOrder, IList<ITvTransactionAiring> tvTransactionAirings,
            IList<IMaterialType> materialTypes)
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
            var view = new TvView
            {
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

                ApconApprovalNumber = tvOrder.ApconApprovalNumber,

                MaterialList = materialTypeDDL,

                FinalAmount = tvOrder.FinalAmount,

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