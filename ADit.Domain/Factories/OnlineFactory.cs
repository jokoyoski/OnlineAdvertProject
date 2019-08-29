using AA.Infrastructure.Extensions;
using ADit.Domain.Models;
using ADit.Domain.Utilities;
using ADit.Interfaces;
using ADit.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineTransactionAiringModel = ADit.Domain.Models.OnlineTransactionAiringModel;

namespace ADit.Domain.Factories
{
    public class OnlineFactory : IOnlineFactory
    {
        /// <summary>
        /// Gets the online artwork transaction ListView.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="SentToId">The sent to identifier.</param>
        /// <returns></returns>
        public IOnlineArtworkTransactionListView GetOnlineArtworkTransactionListView(int transactionId)
        {
            var online = new OnlineArtworkTransactionListView
            {
                transactionId = transactionId,


            };
            return online;
        }
        /// <summary>
        /// Creates the online extra service ListView.
        /// </summary>
        /// <param name="onlineExtraServiceListCollection"></param>
        /// <param name="selectedOnlineExtraServiceId"></param>
        /// <param name="selectedDescription"></param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineExtraServiceListCollection</exception>
        public IOnlineExtraServiceListView CreateOnlineExtraServiceListView(
            IList<IOnlineExtraService> onlineExtraServiceListCollection, int selectedOnlineExtraServiceId,
            string selectedDescription, string message)

        {
            if (onlineExtraServiceListCollection == null)
            {
                throw new ArgumentNullException("onlineExtraServiceListCollection");
            }

            //id search
            var filteredList = onlineExtraServiceListCollection.Where(x =>
                x.OnlineExtraServiceId.Equals(selectedOnlineExtraServiceId < 1
                    ? x.OnlineExtraServiceId
                    : selectedOnlineExtraServiceId)).ToList();


            // description search
            filteredList = filteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();

            var viewModel = new OnlineExtraServiceListView
            {
                OnlineExtraServiceCollection = filteredList.ToList(),
                SelectOnlineExtraServiceId = selectedOnlineExtraServiceId,
                ProcessingMessage = message,
                SelectDescription = selectedDescription,
            };
            return viewModel;
        }

        /// <summary>
        /// Creates the online extra service view.
        /// </summary>
        /// <returns></returns>
        public IOnlineExtraServiceView CreateOnlineExtraServiceView()
        {
            var onlineView = new OnlineExtraServiceView
            {
                ProcessingMessage = string.Empty
            };

            return onlineView;
        }

        /// <summary>
        /// Creates the online platform ListView.
        /// </summary>
        /// <param name="onlinePlatformCollection">The online platform collection.</param>
        /// <param name="selectedOnlinePlatformId">The selected online platform identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlinePlatformCollection</exception>
        public IOnlinePlatformListView CreateOnlinePlatformListView(IList<IOnlinePlatform> onlinePlatformCollection,
            int selectedOnlinePlatformId, string selectedDescription, string message)
        {
            if (onlinePlatformCollection == null)
            {
                throw new ArgumentNullException("onlinePlatformCollection");
            }

            //id search
            var filteredList = onlinePlatformCollection.Where(x =>
                    x.OnlinePlatformId.Equals(selectedOnlinePlatformId < 1
                        ? x.OnlinePlatformId
                        : selectedOnlinePlatformId))
                .ToList();


            // description search
            filteredList = filteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();

            var viewModel = new OnlinePlatformListView
            {
                OnlinePlatformCollection = filteredList.ToList(),
                SelectOnlinePlatformId = selectedOnlinePlatformId,
                ProcessingMessage = message,
                SelectDescription = selectedDescription,
            };
            return viewModel;
        }

        /// <summary>
        /// Creates the online platform view.
        /// </summary>
        /// <returns></returns>
        public IOnlinePlatformView CreateOnlinePlatformView()
        {
            var onlineView = new OnlinePlatformView
            {
                ProcessingMessage = string.Empty
            };
            return onlineView;
        }

        /// <summary>
        /// Creates the online purpose ListView.
        /// </summary>
        /// <param name="onlinePurposeListCollection"></param>
        /// <param name="selectedOnlinePurposeId"></param>
        /// <param name="selectedDescription"></param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlinePurposeListCollection</exception>
        public IOnlinePurposeListView CreateOnlinePurposeListView(IList<IOnlinePurpose> onlinePurposeListCollection,
            int selectedOnlinePurposeId, string selectedDescription, string message)
        {
            if (onlinePurposeListCollection == null)
            {
                throw new ArgumentNullException("onlinePurposeListCollection");
            }

            //id search
            var filteredList = onlinePurposeListCollection.Where(x =>
                    x.OnlinePurposeId.Equals(selectedOnlinePurposeId < 1 ? x.OnlinePurposeId : selectedOnlinePurposeId))
                .ToList();


            // description search
            filteredList = filteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();

            var viewModel = new OnlinePurposeListView
            {
                OnlinePurposeCollection = filteredList.ToList(),
                SelectOnlinePurposeId = selectedOnlinePurposeId,
                ProcessingMessage = message,
                SelectDescription = selectedDescription,
            };
            return viewModel;
        }

        /// <summary>
        /// Creates the online purpose view.
        /// </summary>
        /// <returns></returns>
        public IOnlinePurposeView CreateOnlinePurposeView()
        {
            var onlineView = new OnlinePurposeView
            {
                ProcessingMessage = string.Empty
            };

            return onlineView;
        }


        /// <summary>
        /// Creates the online extra service price view.
        /// </summary>
        /// <returns></returns>
        public IOnlineExtraServicePriceView CreateOnlineExtraServicePriceView()
        {
            var onlineExtraServicePriceView = new OnlineExtraServicePriceView
            {
                ProcessingMessage = string.Empty
            };
            return onlineExtraServicePriceView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onlineView"></param>
        /// <param name="processingMessage"></param>
        /// <param name="onlinePurpose"></param>
        /// <param name="onlinePlatform"></param>
        /// <param name="onlineExtraService"></param>
        /// <returns></returns>
        public IOnlineView CreateUpdatedOnlineView(IOnlineView onlineView, string ProcessingMessage,
            IList<IOnlineExtraService> onlineExtraService, IList<IOnlinePurpose> onlinePurpose,
            IList<IOnlinePlatform> onlinePlatform)
        {
            if (onlineView == null)
            {
                throw new ArgumentNullException("onlineTransactionView");
            }


            if (onlinePlatform == null)
            {
                throw new ArgumentNullException("onlinePlatform");
            }


            if (onlinePurpose == null)
            {
                throw new ArgumentNullException("onlinePurpose");
            }


            if (onlineExtraService == null)
            {
                throw new ArgumentNullException("onlineExtraService ");
            }


            var onlinePlatformDDL =
                GetOnlinePlatformDropdownList.OnlinePlatformListItems(onlinePlatform, onlineView.OnlinePlatformId);
            var onlinePurposeDDL =
                GetOnlinePurposeDropdownList.OnlinePurposeListItems(onlinePurpose, onlineView.OnlinePurposeId);
            var onlineExtraServiceDDL =
                GetOnlineExtraServiceDropdownList.OnlineExtraServiceListItems(onlineExtraService,
                    onlineView.OnlineExtraServiceId);


            return onlineView;
        }

        /// <summary>
        /// Gets the online extra service view.
        /// </summary>
        /// <param name="onlineExtraServiceView"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineExtraServiceView</exception>
        public IOnlineExtraServiceView CreateOnlineExtraServiceView(IOnlineExtraService onlineExtraServiceView)
        {
            if (onlineExtraServiceView == null) throw new ArgumentNullException(nameof(onlineExtraServiceView));
            var view = new OnlineExtraServiceView
            {
                ProcessingMessage = "",
                Description = onlineExtraServiceView.Description,
                OnlineExtraServiceId = onlineExtraServiceView.OnlineExtraServiceId
            };

            return view;
        }

        /// <summary>
        /// Creates the online platform view.
        /// </summary>
        /// <param name="onlinePlatformView">The online platform view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlinePlatformView</exception>
        public IOnlinePlatformView CreateOnlinePlatformView(IOnlinePlatform onlinePlatformView)
        {
            if (onlinePlatformView == null) throw new ArgumentNullException(nameof(onlinePlatformView));
            var view = new OnlinePlatformView
            {
                ProcessingMessage = "",
                Description = onlinePlatformView.Description,
                OnlinePlatformId = onlinePlatformView.OnlinePlatformId
            };

            return view;
        }

        /// <summary>
        /// Gets the online purpose view.
        /// </summary>
        /// <param name="onlinePurposeView"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlinePurposeView</exception>
        public IOnlinePurposeView CreateOnlinePurposeView(IOnlinePurpose onlinePurposeView)
        {
            if (onlinePurposeView == null) throw new ArgumentNullException(nameof(onlinePurposeView));
            var view = new OnlinePurposeView
            {
                ProcessingMessage = "",
                Description = onlinePurposeView.Description,
                OnlinePurposeId = onlinePurposeView.OnlinePurposeId
            };

            return view;
        }


        /// <summary>
        /// Gets the online view.
        /// </summary>
        /// <param name="onlinePurpose">The online purpose.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <param name="onlineArtWorkList">The online art work list.</param>
        /// <param name="onlineDurations">The online durations.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlinePlatform
        /// or
        /// onlinePurpose
        /// or
        /// onlineExtraService
        /// </exception>
        public IOnlineTransactionUIView GetOnlineView(IList<IOnlinePurpose> onlinePurpose, IList<IOnlinePlatform> onlinePlatform,
            IList<IOnlineExtraService> onlineExtraService, IEnumerable<IOnlineArtworkPrice> onlineArtWorkList,
            IList<IOnlineDuration> onlineDurations)
        {
            if (onlinePlatform == null)
            {
                throw new ArgumentNullException("onlinePlatform");
            }


            if (onlinePurpose == null)
            {
                throw new ArgumentNullException("onlinePurpose");
            }


            if (onlineExtraService == null)
            {
                throw new ArgumentNullException("onlineExtraService ");
            }

            var onlinePlatformDDL = GetOnlinePlatformDropdownList.OnlinePlatformListItems(onlinePlatform, -1);
            var onlinePurposeDDL = GetOnlinePurposeDropdownList.OnlinePurposeListItems(onlinePurpose, -1);
            var onlineExtraServiceDDL =
                GetOnlineExtraServiceDropdownList.OnlineExtraServiceListItems(onlineExtraService, -1);
            var artWorkPriceDDL = GetOnlineArtWorkDropdownList.ArtworkPrice(onlineArtWorkList, -1);
            var onlineDurationDLL = GetDropDownList.OnlineDurationListItems(onlineDurations, -1);

            var transactionAiringList = new List<IOnlineTransactionAiringUI>();
            foreach (var r in onlinePlatform)
            {
                var aTran = new OnlineTransactionAiringUI
                {
                    OnlinePlatformId = r.OnlinePlatformId,
                    IsSelected = false
                };

                transactionAiringList.Add(aTran);
            }

            var views = new OnlineTransactionUIView
            {
                ArtworkList = artWorkPriceDDL,
                OnlineExtraServiceList = onlineExtraServiceDDL,
                OnlinePurposeList = onlinePurposeDDL,
                OnlinePlatformList = onlinePlatformDDL,
                AiringDetailsList = transactionAiringList,
                PlatformPackages = onlinePlatform,
                OnlineDurationList = onlineDurationDLL,
                ProcessingMessage = string.Empty
            };
            return views;
        }


        /// <summary>
        /// Gets the tv transaction edit view.
        /// </summary>
        /// <param name="onlineTransaction">The online transaction.</param>
        /// <param name="onlineTransactionAiring">The online transaction airing.</param>
        /// <param name="onlinePurpose">The online purpose.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <param name="onlineArtWorkList">The online art work list.</param>
        /// <param name="onlineDurations">The online durations.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlinePlatform
        /// or
        /// onlinePurpose
        /// or
        /// onlineExtraService 
        /// </exception> 
        public IOnlineTransactionUIView GetOnlineTransactionEditView(IList<IOnlinePurpose> onlinePurpose, IList<IOnlinePlatform> onlinePlatform,
             IOnlineTransactionExtraService onlineExtra, IEnumerable<IOnlineArtworkPrice> onlineArtWorkList, IList<IOnlineDuration> onlineDurations,
             IList<IOnlineExtraService> onlineExtraService, IOnlineTransactionUI onlineTransaction, IList<IOnlineTransactionAiringUI> onlineTransactionAiring,
             List<int> selectedPlatformIds, string processingMessage)
        {
            if (onlinePlatform == null)
            {
                throw new ArgumentNullException("onlinePlatform");
            }
            if (onlineExtra == null)
            {
                throw new ArgumentNullException("onlineExtra");
            }


            if (onlinePurpose == null)
            {
                throw new ArgumentNullException("onlinePurpose");
            }


            if (onlineExtraService == null)
            {
                throw new ArgumentNullException("onlineExtraService ");
            }

            var onlinePlatformDDL =
                GetOnlinePlatformDropdownList.OnlinePlatformListItems(onlinePlatform,
                    onlineTransaction.OnlinePlatformId);
            var onlinePurposeDDL =
                GetOnlinePurposeDropdownList.OnlinePurposeListItems(onlinePurpose, onlineTransaction.OnlinePurposeId);
            var onlineExtraServiceDDL =
                GetOnlineExtraServiceDropdownList.OnlineExtraServiceListItems(onlineExtraService, onlineExtra.OnlineExtraServiceId);
            var artWorkPriceDDL = GetOnlineArtWorkDropdownList.ArtworkPrice(onlineArtWorkList, -1);
            var onlineDurationDLL = GetDropDownList.OnlineDurationListItems(onlineDurations, -1);


            // update transaction airing selected field, set to true if radio station is selected
            var onlineTransactionAiringList = onlineTransactionAiring.ToList();
            onlineTransactionAiringList.Each(x => x.IsSelected = selectedPlatformIds.Contains(x.OnlinePlatformId));
            onlineTransactionAiring.ToList();



            foreach (var online in onlinePlatform)
            {
                if (!selectedPlatformIds.Contains(online.OnlinePlatformId))
                {
                    var aTran = new OnlineTransactionAiringUI
                    {
                        OnlinePlatformId = online.OnlinePlatformId,
                        IsSelected = false
                    };

                    onlineTransactionAiringList.Add(aTran);
                }
            }


            var views = new OnlineTransactionUIView
            {
                OnlinePlatformId = onlineTransaction.OnlinePlatformId,
                OnlineTransactionId = onlineTransaction.OnlineTransactionId,
                OrderId = onlineTransaction.OrderId,
                OnlinePurposeId = onlineTransaction.OnlinePurposeId,
                UserId = onlineTransaction.UserId,
                AdditionalInformation = onlineTransaction.AdditionalInformation,
                IsHaveArtWork = onlineTransaction.IsHaveArtWork,
                ArtWorkId = onlineTransaction.ArtWorkPriceId,
                ArtworkDigitalFileId = onlineTransaction.ArtworkDigitalFileId,
                OnlineArtworkAmount = onlineTransaction.OnlineArtworkAmount,
                DateCreated = onlineTransaction.DateCreated,
                TransactionStatusCode = onlineTransaction.TransactionStatusCode,
                MaterialFileDescription = onlineTransaction.MaterialFileDescription,
                OrderTitle = onlineTransaction.OrderTitle,
                ArtWorkPriceId = onlineTransaction.ArtWorkPriceId,
                FinalAmount = onlineTransaction.FinalAmount,
                OnlineExtraServiceId = onlineExtra.OnlineExtraServiceId,
                OnlineExtraServiceAmount = onlineExtra.OnlineExtraServiceAmount,
                OnlineExtraServicePriceId = onlineExtra.OnlineExtraServicePriceId,
                ArtworkList = artWorkPriceDDL,
                OnlineExtraServiceList = onlineExtraServiceDDL,
                OnlinePurposeList = onlinePurposeDDL,
                AiringDetailsList = onlineTransactionAiringList,
                PlatformPackages = onlinePlatform,
                OnlineDurationList = onlineDurationDLL,

            };
            return views;
        }


        public IOnlineTransactionUIView GetOnlineView(IList<IOnlinePurpose> onlinePurpose, IList<IOnlinePlatform> onlinePlatform,
            IList<IOnlineExtraService> onlineExtraService,
            IEnumerable<IOnlineArtworkPrice> onlineArtWorkList,
            IList<IOnlineDuration> onlineDuration, IOnlineTransactionUI onlineMainTransaction, IEnumerable<IOnlineTransactionAiringUI> transactionAiring,
            List<int> selectedOnlinePlatformIds, string processingMessage)
        {
            if (onlinePlatform == null)
            {
                throw new ArgumentNullException("onlinePlatform");
            }

            if (onlineDuration == null)
            {
                throw new ArgumentNullException("onlineDuration");
            }


            if (onlinePurpose == null)
            {
                throw new ArgumentNullException("onlinePurpose");
            }


            if (onlineExtraService == null)
            {
                throw new ArgumentNullException("onlineExtraService ");
            }

            if (onlineMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(onlineMainTransaction));
            }


            var onlineDurationDLL = GetDropDownList.OnlineDurationListItems(onlineDuration, -1);
            var onlinePlatformDDL = GetOnlinePlatformDropdownList.OnlinePlatformListItems(onlinePlatform, -1);
            var onlinePurposeDDL = GetOnlinePurposeDropdownList.OnlinePurposeListItems(onlinePurpose, -1);
            var onlineExtraServiceDDL =
                GetOnlineExtraServiceDropdownList.OnlineExtraServiceListItems(onlineExtraService, -1);
            var artWorkPriceDDL = GetOnlineArtWorkDropdownList.ArtworkPrice(onlineArtWorkList, -1);

            // update transaction airing selected field, set to true if radio station is selected
            transactionAiring.Each(x => x.IsSelected = selectedOnlinePlatformIds.Contains(x.OnlinePlatformId));
            var updatedAiringList = transactionAiring.ToList();


            var view = new OnlineTransactionUIView
            {
                ArtworkList = artWorkPriceDDL,
                OnlineExtraServiceList = onlineExtraServiceDDL,
                OnlinePurposeList = onlinePurposeDDL,
                OnlinePlatformList = onlinePlatformDDL,
                PlatformPackages = onlinePlatform,
                OnlineDurationList = onlineDurationDLL,
                SelectedOnlinePackagesIds = selectedOnlinePlatformIds,
                ProcessingMessage = processingMessage,
                AiringDetailsList = updatedAiringList,
                OrderTitle = onlineMainTransaction.OrderTitle,
                OnlineTransactionId = onlineMainTransaction.OnlineTransactionId,
                OrderId = onlineMainTransaction.OrderId,
                OnlinePurposeId = onlineMainTransaction.OnlinePurposeId,
                OnlinePlatformPriceId = onlineMainTransaction.OnlinePlatformPriceId,
                OnlinePlatformAmount = onlineMainTransaction.OnlinePlatformAmount,
                AdditionalInformation = onlineMainTransaction.AdditionalInformation,
                IsHaveArtWork = onlineMainTransaction.IsHaveArtWork,
                ArtWorkId = onlineMainTransaction.ArtWorkId,
                ArtWorkPriceId = onlineMainTransaction.ArtWorkPriceId,
                TransactionStatusCode = onlineMainTransaction.TransactionStatusCode

            };
            return view;
        }

        /// <summary>
        /// Creates the online extra service list price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceListCollection">The online extra service price list collection.</param>
        /// <param name="selectedOnlineExtraServicePriceId">The selected online extra service price identifier.</param>
        /// <param name="selectedOnlineExtraServiced">The selected online extra serviced.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineExtraServicePriceListCollection</exception>
        public IOnlineExtraServicePriceListView CreateOnlineExtraServiceListPriceView(
            IList<IOnlineExtraServicePrice> onlineExtraServicePriceListCollection,
            int selectedOnlineExtraServicePriceId, int selectedOnlineExtraServiced, string message)
        {
            if (onlineExtraServicePriceListCollection == null)
            {
                throw new ArgumentNullException("onlineExtraServicePriceListCollection");
            }

            //id search
            var filteredList = onlineExtraServicePriceListCollection.Where(x =>
                x.OnlineExtraServicePriceId.Equals(selectedOnlineExtraServicePriceId < 1
                    ? x.OnlineExtraServicePriceId
                    : selectedOnlineExtraServicePriceId)).ToList();

            // description search
            filteredList = filteredList.Where(x =>
                x.OnlineExtraServiceId.Equals(selectedOnlineExtraServiced < 1
                    ? x.OnlineExtraServiceId
                    : selectedOnlineExtraServiced)).ToList();

            var viewModel = new OnlineExtraServicePriceListView
            {
                OnlineExtraServicePriceCollection = filteredList.ToList(),
                SelectOnlineExtraServicePriceId = selectedOnlineExtraServicePriceId,
                SelectOnlineExtraServiceId = selectedOnlineExtraServiced,
                ProcessingMessage = message,
            };
            return viewModel;
        }


        /// <summary>
        /// Creates the platfrom package price view.
        /// </summary>
        /// <param name="onlinePlatformCollections">The online platform collections.</param>
        /// <param name="onlineDurationCollections">The online duration collections.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlinePlatformCollections
        /// or
        /// onlineDurationCollections
        /// </exception>
        public IOnlinePlatformPackagePriceView CreatePlatfromPackagePriceView(
            IList<IOnlinePlatform> onlinePlatformCollections,
            IList<IOnlineDuration> onlineDurationCollections, IList<IDurationType> onlineDuration)
        {
            if (onlinePlatformCollections == null)
            {
                throw new ArgumentNullException("onlinePlatformCollections");
            }

            if (onlineDurationCollections == null)
            {
                throw new ArgumentNullException("onlineDurationCollections");
            }

            if (onlineDuration == null)
            {
                throw new ArgumentNullException("onlineDuration");
            }

            var OnlinePlatform = GetOnlinePlatformDropdownList.OnlinePlatformListItems(onlinePlatformCollections, -1);
            var OnlineDurationList = GetDropDownList.OnlineDurationListItems(onlineDurationCollections, -1);
            var DurationList = GetDropdownDurationTypeList.DurationTypeListItems(onlineDuration, "");
            var view = new OnlinePlatformPackagePriceView
            {
                OnlineDurationsList = OnlineDurationList,
                OnlinePlatform = OnlinePlatform,
                DurationsType = DurationList,
                ProcessingMessage = string.Empty
            };
            return view;
        }


        /// <summary>
        /// Creates the platfrom package price view.
        /// </summary>
        /// <param name="Onlineplatform">The onlineplatform.</param>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <param name="onlineDuraionCollections">The online duraion collections.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Onlineplatform
        /// or
        /// onlineDuraionCollections
        /// </exception>
        /// <exception cref="ArgumentException">onlinePlatformPackagePriceView</exception>
        public IOnlinePlatformPackagePriceView CreatePlatfromPackagePriceView(IList<IOnlinePlatform> Onlineplatform,
            IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView,
            string ProcessingMessage, IList<IOnlineDuration> onlineDuraionCollections,
            IList<IDurationType> onlineDuration)
        {
            if (Onlineplatform == null)
            {
                throw new ArgumentNullException("Onlineplatform");
            }

            if (onlineDuraionCollections == null)
            {
                throw new ArgumentNullException("onlineDuraionCollections");
            }

            if (onlineDuration == null)
            {
                throw new ArgumentNullException("onlineDuration");
            }

            if (onlinePlatformPackagePriceView == null)
            {
                throw new ArgumentException("onlinePlatformPackagePriceView");
            }

            var OnlinePlatformDD = GetOnlinePlatformDropdownList.OnlinePlatformListItems(Onlineplatform,
                onlinePlatformPackagePriceView.OnlinePlatformId);
            var DurationList = GetDropdownDurationTypeList.DurationTypeListItems(onlineDuration, "");
            var OnlineDurationDD = GetDropDownList.OnlineDurationListItems(onlineDuraionCollections,
                onlinePlatformPackagePriceView.OnlineDurationId);


            onlinePlatformPackagePriceView.OnlineDurationsList = OnlineDurationDD;
            onlinePlatformPackagePriceView.DurationsType = DurationList;
            onlinePlatformPackagePriceView.OnlinePlatform = OnlinePlatformDD;
            onlinePlatformPackagePriceView.ProcessingMessage = ProcessingMessage ?? "";

            return onlinePlatformPackagePriceView;
        }


        /// <summary>
        /// Creates the updated platfrom package price view.
        /// </summary>
        /// <param name="platformview">The platformview.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <param name="Onlineplatform">The onlineplatform.</param>
        /// <param name="Durationtype">The durationtype.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// Onlineplatform
        /// or
        /// Durationtype
        /// or
        /// platformview
        /// </exception>
        public IOnlinePlatformPackagePriceView CreatePlatfromPackagePriceView(
            IOnlinePlatformPackagePriceView platformview, string ProcessingMessage,
            IList<IOnlinePlatform> Onlineplatform, IList<IOnlineDuration> onlineDurations)
        {
            if (Onlineplatform == null)
            {
                throw new ArgumentNullException("Onlineplatform");
            }

            if (onlineDurations == null)
            {
                throw new ArgumentNullException("onlineDurations");
            }

            if (platformview == null)
            {
                throw new ArgumentNullException("platformview");
            }

            if (platformview.OnlinePlatformId == 0)
            {
                platformview.OnlinePlatformId = -1;
            }

            var OnlinePlatform =
                GetOnlinePlatformDropdownList.OnlinePlatformListItems(Onlineplatform, platformview.OnlinePlatformId);
            var DurationType = GetDropDownList.OnlineDurationListItems(onlineDurations, -1);

            platformview.OnlinePlatform = OnlinePlatform;
            platformview.OnlineDurationsList = DurationType;
            platformview.ProcessingMessage = ProcessingMessage;

            return platformview;
        }


        /// <summary>
        /// Gets the edit platfrom package price view.
        /// </summary>
        /// <param name="pricingView">The pricing view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">pricingView</exception>
        public IOnlinePlatformPackagePriceView GetEditPlatfromPackagePriceView(IOnlinePlatformPrice pricingView)
        {
            if (pricingView == null) throw new ArgumentNullException(nameof(pricingView));
            var view = new OnlinePlatformPackagePriceView
            {
                OnlinePlatformPriceId = pricingView.OnlinePlatformPriceId,
                Amount = pricingView.Amount,
                ProcessingMessage = string.Empty
            };
            return view;
        }


        /// <summary>
        /// Edits the online platform package price.
        /// </summary>
        /// <param name="onlineDurations">Type of the duration.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="onlinePlatformPrice">The online platform price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// durationType
        /// or
        /// onlinePlatform
        /// or
        /// onlinePlatformPrice
        /// </exception>
        public IOnlinePlatformPackagePriceView EditOnlinePlatformPackagePrice(IList<IOnlineDuration> onlineDurations,
            IList<IOnlinePlatform> onlinePlatform, IOnlinePlatformPrice
                onlinePlatformPrice)
        {
            if (onlineDurations == null)
            {
                throw new ArgumentNullException(nameof(onlineDurations));
            }

            if (onlinePlatform == null)
            {
                throw new ArgumentNullException(nameof(onlinePlatform));
            }

            if (onlinePlatformPrice == null)
            {
                throw new ArgumentNullException(nameof(onlinePlatformPrice));
            }


            var durationTypeDDL =
                GetDropDownList.OnlineDurationListItems(onlineDurations, onlinePlatformPrice.OnlineDurationId);
            var onlinePlatformDDl =
                GetOnlinePlatformDropdownList.OnlinePlatformListItems(onlinePlatform,
                    onlinePlatformPrice.OnlinePlatformId);

            var view = new OnlinePlatformPackagePriceView
            {
                OnlinePlatformPriceId = onlinePlatformPrice.OnlinePlatformPriceId,
                OnlinePlatform = onlinePlatformDDl,
                OnlineDurationsList = durationTypeDDL,
                DurationQuantity = onlinePlatformPrice.DurationQuantity,
                Amount = onlinePlatformPrice.Amount,
                Comment = onlinePlatformPrice.Comment,
                EffectiveDate = onlinePlatformPrice.EffectiveDate,
                DateInactive = onlinePlatformPrice.DateInactive ?? DateTime.Now,
                DateCreated = onlinePlatformPrice.DateCreated,
                OnlineDurationId = onlinePlatformPrice.OnlineDurationId,
                OnlinePlatformId = onlinePlatformPrice.OnlinePlatformId,


            };
            return view;
        }


        /// <summary>
        /// Creates the online platform package price.
        /// </summary>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// durationType
        /// or
        /// onlinePlatform
        /// </exception>
        public IOnlinePlatformPackagePriceView CreateOnlinePlatformPackagePrice(IList<IOnlineDuration> onlineDurations,
            IList<IOnlinePlatform> onlinePlatform)
        {
            if (onlineDurations == null)
            {
                throw new ArgumentNullException(nameof(onlineDurations));
            }

            if (onlinePlatform == null)
            {
                throw new ArgumentNullException(nameof(onlinePlatform));
            }


            var durationTypeDDL = GetDropDownList.OnlineDurationListItems(onlineDurations, -1);
            var onlinePlatformDDl = GetOnlinePlatformDropdownList.OnlinePlatformListItems(onlinePlatform, -1);

            var view = new OnlinePlatformPackagePriceView
            {
                OnlineDurationsList = durationTypeDDL,
                OnlinePlatform = onlinePlatformDDl,
            };
            return view;
        }


        /// <summary>
        /// Creates the online extra service price view.
        /// </summary>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineExtraService</exception>
        public IOnlineExtraServicePriceView CreateOnlineExtraServicePriceView(
            IList<IOnlineExtraService> onlineExtraService)
        {
            if (onlineExtraService == null)
            {
                throw new ArgumentNullException("onlineExtraService");
            }

            var OnlineExtraService =
                GetOnlineExtraServiceDropdownList.OnlineExtraServiceListItems(onlineExtraService, -1);

            var view = new OnlineExtraServicePriceView
            {
                OnlineExtraService = OnlineExtraService,
                ProcessingMessage = string.Empty
            };
            return view;
        }

        /// <summary>
        /// Creates the online extra service price view.
        /// </summary>
        /// <param name="extraServicePriceView">The extra service price view.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineExtraService
        /// or
        /// extraServicePriceView
        /// </exception>
        public IOnlineExtraServicePriceView CreateOnlineExtraServicePriceView(
            IOnlineExtraServicePriceView extraServicePriceView, string ProcessingMessage,
            IList<IOnlineExtraService> onlineExtraService)
        {
            if (onlineExtraService == null)
            {
                throw new ArgumentNullException("onlineExtraService");
            }


            if (extraServicePriceView == null)
            {
                throw new ArgumentNullException("extraServicePriceView");
            }


            var OnlineExtraService =
                GetOnlineExtraServiceDropdownList.OnlineExtraServiceListItems(onlineExtraService,
                    extraServicePriceView.OnlineExtraServiceId);

            extraServicePriceView.OnlineExtraService = OnlineExtraService;
            extraServicePriceView.ProcessingMessage = ProcessingMessage ?? "";

            return extraServicePriceView;
        }


        /// <summary>
        /// Gets the edit online extra service price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineExtraServicePriceView</exception>
        public IOnlineExtraServicePriceView GetEditOnlineExtraServicePriceView(
            IOnlineExtraServicePrice onlineExtraServicePriceView)
        {
            if (onlineExtraServicePriceView == null)
                throw new ArgumentNullException(nameof(onlineExtraServicePriceView));
            var view = new OnlineExtraServicePriceView
            {
                OnlineExtraServicePriceId = onlineExtraServicePriceView.OnlineExtraServicePriceId,
                Amount = onlineExtraServicePriceView.Amount,
                ProcessingMessage = string.Empty
            };

            return view;
        }

        /// <summary>
        /// Edits the online extra service price.
        /// </summary>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <param name="onlineExtraServicePrice">The online extra service price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineExtraService
        /// or
        /// onlineExtraServicePrice
        /// </exception>
        public IOnlineExtraServicePriceView EditOnlineExtraServicePrice(IList<IOnlineExtraService> onlineExtraService,
            IOnlineExtraServicePrice onlineExtraServicePrice)
        {
            if (onlineExtraService == null)
            {
                throw new ArgumentNullException(nameof(onlineExtraService));
            }

            if (onlineExtraServicePrice == null)
            {
                throw new ArgumentNullException(nameof(onlineExtraServicePrice));
            }


            var OnlineExtraServiceDDl =
                GetOnlineExtraServiceDropdownList.OnlineExtraServiceListItems(onlineExtraService, -1);

            var view = new OnlineExtraServicePriceView
            {
                OnlineExtraServicePriceId = onlineExtraServicePrice.OnlineExtraServicePriceId,
                OnlineExtraService = OnlineExtraServiceDDl,
                Amount = onlineExtraServicePrice.Amount,
                Comment = onlineExtraServicePrice.Comment,
                EffectiveDate = onlineExtraServicePrice.EffectiveDate,
                DateInactive = onlineExtraServicePrice.DateInactive,

                ProcessingMessage = string.Empty,
            };
            return view;
        }


        /// <summary>
        /// Creates the online extra service price.
        /// </summary>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineExtraService</exception>
        public IOnlineExtraServicePriceView CreateOnlineExtraServicePrice(IList<IOnlineExtraService> onlineExtraService)
        {
            if (onlineExtraService == null)
            {
                throw new ArgumentNullException(nameof(onlineExtraService));
            }


            var onlineExtraServiceDDl =
                GetOnlineExtraServiceDropdownList.OnlineExtraServiceListItems(onlineExtraService, -1);

            var view = new OnlineExtraServicePriceView
            {
                OnlineExtraService = onlineExtraServiceDDl,
            };
            return view;
        }

        /// <summary>
        /// Creates the online platform view.
        /// </summary>
        /// <param name="onlinePlatformView"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">CreateOnlinePlatformView</exception>
        public IOnlinePlatformView CreateOnlinePlatformView(IOnlinePlatformView onlinePlatformView, string message)
        {
            if (onlinePlatformView == null)
            {
                throw new ArgumentNullException("CreateOnlinePlatformView");
            }


            onlinePlatformView.ProcessingMessage = message;
            return onlinePlatformView;
        }

        /// <summary>
        /// Creates the online purpose view.
        /// </summary>
        /// <param name="onlinePurposeView">The online purpose view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">CreateOnlinePurposeView</exception>
        public IOnlinePurposeView CreateOnlinePurposeView(IOnlinePurposeView onlinePurposeView, string message)
        {
            if (onlinePurposeView == null)
            {
                throw new ArgumentNullException("CreateOnlinePurposeView");
            }

            onlinePurposeView.ProcessingMessage = message;
            return onlinePurposeView;
        }

        /// <summary>
        /// Creates the online extra service view.
        /// </summary>
        /// <param name="onlineExtraServiceView">The online extra service view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">CreateOnlineExtraServiceView</exception>
        public IOnlineExtraServiceView CreateOnlineExtraServiceView(IOnlineExtraServiceView onlineExtraServiceView,
            string message)
        {
            if (onlineExtraServiceView == null)
            {
                throw new ArgumentNullException("CreateOnlineExtraServiceView");
            }

            onlineExtraServiceView.ProcessingMessage = message;

            return onlineExtraServiceView;
        }

        /// <summary>
        /// Creates the delete online extra servicet price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineExtraServicePriceView</exception>
        public IOnlineExtraServicePriceView CreateDeleteOnlineExtraServicetPriceView(
            IOnlineExtraServicePrice onlineExtraServicePriceView)
        {
            if (onlineExtraServicePriceView == null)
            {
                throw new ArgumentNullException(nameof(onlineExtraServicePriceView));
            }

            var view = new OnlineExtraServicePriceView
            {
                OnlineExtraServicePriceId = onlineExtraServicePriceView.OnlineExtraServicePriceId,
                Comment = onlineExtraServicePriceView.Comment,
                Amount = onlineExtraServicePriceView.Amount,
                DateCreated = onlineExtraServicePriceView.DateCreated,
            };
            return view;
        }

        /// <summary>
        /// Creates the delete platform package price view.
        /// </summary>
        /// <param name="platformPackagePriceView">The platform package price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">platformPackagePriceView</exception>
        public IOnlinePlatformPackagePriceView CreateDeletePlatformPackagePriceView(
            IOnlinePlatformPrice platformPackagePriceView)
        {
            if (platformPackagePriceView == null)
            {
                throw new ArgumentNullException(nameof(platformPackagePriceView));
            }

            var view = new OnlinePlatformPackagePriceView
            {
                OnlinePlatformPriceId = platformPackagePriceView.OnlinePlatformPriceId,
                Comment = platformPackagePriceView.Comment,
                Amount = platformPackagePriceView.Amount,
                DateCreated = platformPackagePriceView.DateCreated,
            };
            return view;
        }

        /// <summary>
        /// Creates the online platfrom package price view.
        /// </summary>
        /// <param name="Onlineplatform">The onlineplatform.</param>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <param name="Durationtype">The durationtype.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IOnlinePlatformPackagePriceView CreateOnlinePlatfromPackagePriceView(
            IList<IOnlinePlatform> Onlineplatform, IOnlinePlatformPackagePriceView
                onlinePlatformPackagePriceView, string ProcessingMessage, IList<IDurationType> Durationtype)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the platform package price ListView.
        /// </summary>
        /// <param name="onlinePlatformPriceListCollection">The online platform price list collection.</param>
        /// <param name="SelectedOnlinePlatformPriceId">The selected online platform price identifier.</param>
        /// <param name="SelectedOnlinePlatformId">The selected online platform identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlinePlatformPriceListCollection</exception>
        public IPlatformPackagePriceListView CreatePlatformPackagePriceListView(
            IList<IOnlinePlatformPrice> onlinePlatformPriceListCollection, int SelectedOnlinePlatformPriceId,
            int SelectedOnlinePlatformId, string message)
        {
            if (onlinePlatformPriceListCollection == null)
            {
                throw new ArgumentNullException("onlinePlatformPriceListCollection");
            }

            var filteredList = onlinePlatformPriceListCollection.Where(x =>
                x.OnlinePlatformPriceId.Equals(SelectedOnlinePlatformPriceId < 1
                    ? x.OnlinePlatformPriceId
                    : SelectedOnlinePlatformPriceId)).ToList();

            // search for onlineplatformid
            filteredList = filteredList.Where(x =>
                    x.OnlinePlatformId.Equals(SelectedOnlinePlatformId < 1
                        ? x.OnlinePlatformId
                        : SelectedOnlinePlatformId))
                .ToList();

            var returnView = new PlatformPackagePriceListView
            {
                OnlinePlatformPriceCollection = filteredList.ToList(),
                SelectedOnlinePlatformId = SelectedOnlinePlatformId,
                ProcessingMessage = message ?? ""
            };
            return returnView;
        }

        /// <summary>
        /// Creates the online platfrom package price view.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <param name="onlineDurationList">The durationtype.</param>
        /// <param name="Onlineplatform">The onlineplatform.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlinePlatformPackagePriceView
        /// or
        /// Onlineplatform
        /// or
        /// Durationtype
        /// </exception>
        public IOnlinePlatformPackagePriceView CreateOnlinePlatfromPackagePriceView(
            IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView, string ProcessingMessage,
            IList<IOnlineDuration> onlineDurationList, IList<IOnlinePlatform> Onlineplatform)
        {
            if (onlinePlatformPackagePriceView == null)
            {
                throw new ArgumentNullException("onlinePlatformPackagePriceView");
            }


            if (Onlineplatform == null)
            {
                throw new ArgumentNullException("Onlineplatform");
            }

            if (onlineDurationList == null)
            {
                throw new ArgumentNullException("Durationtype");
            }


            var onlinePlatform = GetOnlinePlatformDropdownList.OnlinePlatformListItems(Onlineplatform,
                onlinePlatformPackagePriceView.OnlinePlatformId);
            var onlineDurationDDL = GetDropDownList.OnlineDurationListItems(onlineDurationList,
                onlinePlatformPackagePriceView.OnlineDurationId);

            onlinePlatformPackagePriceView.OnlinePlatform = onlinePlatform;
            onlinePlatformPackagePriceView.OnlineDurationsList = onlineDurationDDL;
            onlinePlatformPackagePriceView.ProcessingMessage = ProcessingMessage ?? "";

            return onlinePlatformPackagePriceView;
        }

        /// <summary>
        /// Gets the online extra service price.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price</exception>
        public IOnlineView GetOnlineExtraServicePrice(IOnlineExtraServicePrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            var view = new OnlineView
            {
                OnlineExtraServicAmount = price.Amount
            };
            return view;
        }
        /// <summary>
        /// Gets the online artwork price.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price</exception>
        public IOnlineView GetOnlineArtworkPrice(IOnlineArtworkPrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            var view = new OnlineView
            {
                OnlineArtWorkPriceId = price.ArtWorkPriceId,
                OnlineArtworkAmount = price.Amount
            };
            return view;
        }



        /// <summary>
        /// Creates the artwork price view.
        /// </summary>
        /// <param name="onlineArtworkPrice">The online artwork price.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineArtworkPrice</exception>
        public IOnlineArtworkPriceListView CreateArtworkPriceView(IEnumerable<IOnlineArtworkPrice> onlineArtworkPrice,
            string message)
        {
            if (onlineArtworkPrice == null)
            {
                throw new ArgumentNullException("onlineArtworkPrice");
            }


            var view = new OnlineArtworkPriceListView
            {
                SelectedDescription = string.Empty,
                onlineArtworkPriceListView = onlineArtworkPrice,


                ProcessingMessage = message ?? ""
            };
            return view;
        }


        /// <summary>
        /// Gets the updated online platform package price view.
        /// </summary>
        /// <param name="onlinePlatformPackagePriceView">The online platform package price view.</param>
        /// <param name="onlinePlatform">The online platform.</param>
        /// <param name="onlineDurations">The online durations.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlinePlatformPackagePriceView</exception>
        public IOnlinePlatformPackagePriceView getUpdatedOnlinePlatformPackagePriceView(
            IOnlinePlatformPackagePriceView onlinePlatformPackagePriceView, IList<IOnlinePlatform> onlinePlatform,
            IList<IOnlineDuration> onlineDurations)
        {
            if (onlinePlatformPackagePriceView == null)
            {
                throw new ArgumentNullException(nameof(onlinePlatformPackagePriceView));
            }

            var onlinePlatformDDL =
                GetOnlinePlatformDropdownList.OnlinePlatformListItems(onlinePlatform,
                    onlinePlatformPackagePriceView.OnlinePlatformId);
            var durationTypeDDL =
                GetDropDownList.OnlineDurationListItems(onlineDurations,
                    onlinePlatformPackagePriceView.OnlineDurationId);

            onlinePlatformPackagePriceView.OnlineDurationsList = durationTypeDDL;
            onlinePlatformPackagePriceView.OnlinePlatform = onlinePlatformDDL;
            return onlinePlatformPackagePriceView;
        }


        /// <summary>
        /// Gets the updated online extra service price view.
        /// </summary>
        /// <param name="onlineExtraServicePriceView">The online extra service price view.</param>
        /// <param name="onlineExtraService">The online extra service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineExtraServicePriceView</exception>
        public IOnlineExtraServicePriceView getUpdatedOnlineExtraServicePriceView(
            IOnlineExtraServicePriceView onlineExtraServicePriceView, IList<IOnlineExtraService> onlineExtraService)
        {
            if (onlineExtraServicePriceView == null)
            {
                throw new ArgumentNullException(nameof(onlineExtraServicePriceView));
            }

            var onlineExtraServiceDDL =
                GetOnlineExtraServiceDropdownList.OnlineExtraServiceListItems(onlineExtraService,
                    onlineExtraServicePriceView.OnlineExtraServiceId);


            onlineExtraServicePriceView.OnlineExtraService = onlineExtraServiceDDL;
            return onlineExtraServicePriceView;
        }


        /// <summary>
        /// Creates the online duration view.
        /// </summary>
        /// <returns></returns>
        public IOnlineDurationView CreateOnlineDurationView()
        {
            var result = new OnlineDurationView
            {
                ProcessingMessage = string.Empty
            };

            return result;
        }

        /// <summary>
        /// Creates the online duration view.
        /// </summary>
        /// <param name="onlineDurationView">The online duration view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineDurationView</exception>
        public IOnlineDurationView CreateOnlineDurationView(IOnlineDuration onlineDurationView)
        {
            if (onlineDurationView == null) throw new ArgumentNullException(nameof(onlineDurationView));
            var view = new OnlineDurationView
            {
                ProcessingMessage = "",
                Description = onlineDurationView.Description,
                OnlineDurationId = onlineDurationView.OnlineDurationId
            };

            return view;
        }


        /// <summary>
        /// Creates the update online duration view.
        /// </summary>
        /// <param name="onlineDurationInfo">The online duration information.</param>
        /// <param name="processMessage">The process message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineDurationInfo</exception>
        public IOnlineDurationView CreateUpdateOnlineDurationView(IOnlineDurationView onlineDurationInfo,
            string processMessage)
        {
            if (onlineDurationInfo == null)
            {
                throw new ArgumentNullException(nameof(onlineDurationInfo));
            }

            onlineDurationInfo.ProcessingMessage = processMessage;

            return onlineDurationInfo;
        }



        /// <summary>
        /// Creates the online duration ListView.
        /// </summary>
        /// <param name="onlineDurationListCollection">The online duration list collection.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineDurationListCollection</exception>
        public IOnlineDurationList CreateOnlineDurationListView(IList<IOnlineDuration> onlineDurationListCollection,
            string selectedDescription, string message)
        {
            if (onlineDurationListCollection == null)
            {
                throw new ArgumentNullException(nameof(onlineDurationListCollection));
            }

            // description search
            var filteredList = onlineDurationListCollection.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();

            var viewModel = new OnlineDurationList
            {
                OnlineDuration = filteredList,
                ProcessingMessage = message,
                SelectDescription = selectedDescription,
            };
            return viewModel;
        }



        /// <summary>
        /// Gets the user online transaction.
        /// </summary>
        /// <param name="onlineTransaction">The online transaction.</param>
        /// <param name="onlineTransactionAttachment">The online transaction attachment.</param>
        /// <param name="onlineTransactionAiring">The online transaction airing.</param>
        /// <param name="onlineTransactionExtraService">The online transaction extra service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// onlineTransaction
        /// or
        /// onlineTransactionAttachment
        /// or
        /// onlineTransactionAiring
        /// or
        /// onlineTransactionExtraService
        /// </exception>
        public IOnlineView GetUserOnlineTransaction(IOnlineTransaction onlineTransaction, IList<IOnlineTransactionAiringUI> onlineTransactionAiring, IOnlineTransactionExtraService onlineTransactionExtraService)

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
            var view = new OnlineView
            {
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




            };
            return view;
        }


        /// <summary>
        /// Gets all online tranasction.
        /// </summary>
        /// <param name="onlineTransactions">The online transactions.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">(onlineTransactions</exception>
        public IOnlineTransactionListView GetAllOnlineTranasction(IList<IOnlineTransaction> onlineTransactions, IList<IMessage> messagesList, IList<IReplies> replies)
        {

            if (onlineTransactions == null)
            {
                throw new ArgumentNullException("(onlineTransactions");

            }

            var view = new OnlineTransactionListView
            {
                onlineTransactions = onlineTransactions,

                repliesLists = replies,
                messagesLists = messagesList,
            };
            return view;
        }







        /// <summary>
        /// Gets the online artwork transaction ListView.
        /// </summary>
        /// <param name="onlineTransaction">The online transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineTransaction</exception>
        public IOnlineArtworkTransactionListView GetOnlineArtworkTransactionListView(IOnlineTransaction onlineTransaction, IDigitalFile digitalFile, int? Id, int RepliesId)
        {
            if (onlineTransaction == null)
            {
                throw new ArgumentNullException(nameof(onlineTransaction));
            }


            var radioList = new OnlineArtworkTransactionListView
            {
                MessageId = Id,
                AdditionalInfo = onlineTransaction.AdditionalInformation,
                Name = onlineTransaction.UserName,
                OrderTitle = onlineTransaction.OrderTitle,


                SentToId = onlineTransaction.UserId,
                transactionId = onlineTransaction.OnlineTransactionId,

                RepliesId = RepliesId,

                ArtworkFileId = onlineTransaction.ArtworkDigitalFileId


            };

            return radioList;
        }


        /// <summary>
        /// Gets the online artwork message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">message</exception>
        public IMessageRepliesListView GetOnlineArtworkMessageRepliesListView(IList<IReplies> replies, IMessage message, int transactionId, int OrderId)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");

            }

            var view = new MessageRepliesListView
            {
                InitialMessage = message.Message,
                MessageId = message.Id,

                transactionId = transactionId,
                UserId = message.UserId,

                Replies = replies,
                IsApproved = message.IsApproved,
                OrderId = OrderId,
                DigitalFileId = message.DigitalFileId

            };
            return view;
        }

        /// <summary>
        /// Creates the delete artworkt price view.
        /// </summary>
        /// <param name="artworkPrice">The artwork price.</param>
        /// <param name="onlineArtwork">The online artwork.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// designElementPrice
        /// or
        /// designElement
        /// or
        /// serviceType
        /// </exception>
        public IOnlineArtworkPriceView CreateOnlineArtworktPriceView(IOnlineArtworkPrice onlineArtworkPrice, IList<IServiceType> serviceType)
        {
            if (onlineArtworkPrice == null)
            {
                throw new ArgumentException("onlineArtworkPrice");
            }

            if (serviceType == null)
            {
                throw new ArgumentException("serviceType");
            }

            var serviceTypeDDL = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, onlineArtworkPrice.ServiceTypeCode);

            var view = new OnlineArtworkPriceView
            {
                ServiceType = serviceTypeDDL,
                Comment = onlineArtworkPrice.Comment,
                Amount = onlineArtworkPrice.Amount,
                DateCreated = onlineArtworkPrice.DateCreated,
                DateInactive = onlineArtworkPrice.DateInactive,
                ArtWorkPriceId = onlineArtworkPrice.ArtWorkPriceId,
                EffectiveDate = onlineArtworkPrice.EffectiveDate,
                IsActive = onlineArtworkPrice.IsActive,
                ProcessingMessage = string.Empty,
                ServiceTypeCode = onlineArtworkPrice.ServiceTypeCode


            };
            return view;
        }
        /// <summary>
        /// Creates the artwork ListView.
        /// </summary>
        /// <param name="SelectedArtWorkId">The selected art work identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="artWorklCollection">The art workl collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IOnlineArtworkPriceListView CreateArtworkListView(int SelectedArtWorkId, string SelectedDescription, IList<IOnlineArtworkPrice> artWorklCollection, string message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates the artwork price view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="ArtWork">The art work.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ServiceType
        /// or
        /// MaterialType
        /// </exception>
        public IOnlineArtworkPriceView CreateOnliineArtworkPriceView(IList<IServiceType> ServiceType) 
        {
            if (ServiceType == null)
            {
                throw new ArgumentNullException("ServiceType");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
           

            var view = new OnlineArtworkPriceView
            {
                ProcessingMessage = string.Empty,
                ServiceType = serviceType,
            };
            return view;
        }
        /// <summary>
        /// Creates the artwork price view.
        /// </summary>
        /// <param name="artworkInfo">The artwork information.</param>
        /// <param name="ProcessingMessages">The processing messages.</param>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="ArtWork">The art work.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// artworkInfo
        /// or
        /// ArtWork
        /// or
        /// ServiceType
        /// </exception>
        public IOnlineArtworkPriceView CreateArtworkPriceView(IOnlineArtworkPriceView artworkInfo, string ProcessingMessages, IList<IServiceType> ServiceType, IList<IOnlineArtworkPrice> ArtWork)
        {
            if (artworkInfo == null)
            {
                throw new ArgumentNullException(nameof(artworkInfo));
            }
          
            if (ServiceType == null)
            {
                throw new ArgumentNullException(nameof(ServiceType));
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, artworkInfo.ServiceTypeCode);
          


            
            artworkInfo.ServiceType = serviceType;
            artworkInfo.ProcessingMessage = ProcessingMessages ?? "";

            return artworkInfo;

        }
        /// <summary>
        /// Edits the artwork price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="artWork">The art work.</param>
        /// <param name="artWorkPrice">The art work price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// serviceType
        /// or
        /// artWork
        /// or
        /// artWorkPrice
        /// </exception>
        public IOnlineArtworkPriceView EditArtworkPriceView(IList<IServiceType> serviceType, IList<IOnlineArtworkPrice> artWork, IOnlineArtworkPrice artWorkPrice)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (artWork == null)
            {
                throw new ArgumentNullException(nameof(artWork));
            }
            if (artWorkPrice == null)
            {
                throw new ArgumentNullException(nameof(artWorkPrice));
            }

            var ServiceTypeDDL = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, "");
           

            var view = new OnlineArtworkPriceView
            {
               
                ServiceType = ServiceTypeDDL,
                Comment = artWorkPrice.Comment,
                Amount = artWorkPrice.Amount,
                DateCreated = artWorkPrice.DateCreated,
                DateInactive = artWorkPrice.DateInactive,
                IsActive = artWorkPrice.IsActive,
                EffectiveDate = artWorkPrice.EffectiveDate,
                ServiceTypeCode = artWorkPrice.ServiceTypeCode,
                ArtWorkPriceId = artWorkPrice.ArtWorkPriceId,
                ProcessingMessage = string.Empty

            };
            return view;

        }
        /// <summary>
        /// Creates the artwork price ListView.
        /// </summary>
        /// <param name="artwork">The artwork.</param>
        /// <param name="message">The message.</param>
        /// <param name="SelectedArtWorkPriceId">The selected art work price identifier.</param>
        /// <param name="SelectedServiceTypeCode">The selected service type code.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">artwork</exception>
        public IOnlineArtworkPriceListView CreateArtworkPriceListView(IList<IOnlineArtworkPrice> artwork, string message, int SelectedArtWorkPriceId, string SelectedServiceTypeCode, string SelectedDescription)
        {
            if (artwork == null)
            {
                throw new ArgumentNullException(nameof(artwork));
            }



            var returnView = new OnlineArtworkPriceListView
            {
                SelectedDescription = SelectedDescription,
                SelectedServiceTypeCode = SelectedServiceTypeCode,
                SelectedArtworkPriceId = SelectedArtWorkPriceId,

                OnlineArtWorkPriceCollection = artwork,
                ProcessingMessage = message ?? ""


            };
            return returnView;
        }

        /// <summary>
        /// Creates the delete artwork price view.
        /// </summary>
        /// <param name="artWorkPriceView">The art work price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">artWorkPriceView</exception>
        public IOnlineArtworkPriceView CreateDeleteArtworkPriceView(IOnlineArtworkPrice artWorkPriceView)
        {
            if (artWorkPriceView == null)
            {
                throw new ArgumentNullException(nameof(artWorkPriceView));
            }


            var view = new OnlineArtworkPriceView
            {
                ArtWorkPriceId = artWorkPriceView.ArtWorkPriceId,
                Comment = artWorkPriceView.Comment,
                Amount = artWorkPriceView.Amount,
                DateCreated = artWorkPriceView.DateCreated,

            };
            return view;
        }

        public IOnlineArtworkPriceView CreateDeleteOnlineArtworkPrice(IOnlineArtworkPrice onlineArtworkPrice,  IList<IServiceType> serviceType)
        {
            if (onlineArtworkPrice == null)
            {
                throw new ArgumentException("onlineArtworkPrice");
            }
           
            if (serviceType == null)
            {
                throw new ArgumentException("serviceType");
            }

            var serviceTypeDDL = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, onlineArtworkPrice.ServiceTypeCode);
           
            var view = new OnlineArtworkPriceView
            {
                ServiceType = serviceTypeDDL,
                Comment = onlineArtworkPrice.Comment,
                Amount = onlineArtworkPrice.Amount,
                DateCreated = onlineArtworkPrice.DateCreated,
                DateInactive = onlineArtworkPrice.DateInactive,
                ArtWorkPriceId = onlineArtworkPrice.ArtWorkPriceId,
                EffectiveDate = onlineArtworkPrice.EffectiveDate,
                IsActive = onlineArtworkPrice.IsActive,
                ProcessingMessage = string.Empty,
                ServiceTypeCode = onlineArtworkPrice.ServiceTypeCode


            };
            return view;

        }
        /// <summary>
        /// Creates the updated online artwork price view.
        /// </summary>
        /// <param name="onlineArtworkPrice">The online artwork price.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onlineArtworkPrice</exception>
        public IOnlineArtworkPriceView CreateUpdatedOnlineArtworkPriceView(IOnlineArtworkPriceView onlineArtworkPrice, IList<IServiceType> serviceType)
        {
           if (onlineArtworkPrice == null)
            {
                throw new ArgumentNullException(nameof(onlineArtworkPrice));

            }
            var servicetype = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, onlineArtworkPrice.ServiceTypeCode);

            onlineArtworkPrice.ServiceType = servicetype;


            return onlineArtworkPrice;

        }

    }
}
