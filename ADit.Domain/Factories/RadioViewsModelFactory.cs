using System;
using System.Collections.Generic;
using ADit.Domain.Models;
using ADit.Domain.Utilities;
using ADit.Interfaces;
using System.Linq;
using AA.Infrastructure.Extensions;
using ADit.Repositories.Models;

namespace ADit.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IRadioViewsModelFactory" />
    public class RadioViewsModelFactory : IRadioViewsModelFactory
    {
        /// <summary>
        /// Creates the radio main view.
        /// </summary>
        /// <param name="ApconApprovalType">Type of the apcon approval.</param>
        /// <param name="radioStations">The radio stations.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="ScriptMaterialQuestion">The script material question.</param>
        /// <param name="activeMaterialTypeCollection">The active material type collection.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        public IRadioTransactionUIView CreateRadioMainView(IList<IApconApprovalType> ApconApprovalType,
            IList<IRadioStationModel> radioStations, IList<ITiming> Timing,
            IList<IScriptMaterialQuestion> ScriptMaterialQuestion, IList<IMaterialType> activeMaterialTypeCollection,
            IList<ITimeBelt> timeBelts)
        {
            if (ApconApprovalType == null)
            {
                throw new ArgumentNullException("ApconApprovalType");
            }

            if (Timing == null)
            {
                throw new ArgumentNullException("Timing");
            }

            if (ScriptMaterialQuestion == null)
            {
                throw new ArgumentNullException("ScriptMaterialQuestion");
            }

            var apconApprovalType = GetDropDownList.ApconApprovalListItems(ApconApprovalType, -1);
            var activematerialTypeDDL =
                GetDropdownMaterialTypeList.MaterialTypeListItems(activeMaterialTypeCollection, -1);
            var timing = GetDropdownTimingList.TimingListItems(Timing, -1);
            var materialQuestionDDL = GetDropDownList.ScriptMaterialQuestionListItems(ScriptMaterialQuestion, "");
            var timeBeltDDL = GetDropDownTimeBelt.TimeBeltItems(timeBelts, -1);

            var transactionAiringList = new List<IRadioTransactionAiringUI>();
            foreach (var r in radioStations)
            {
                var aTran = new RadioTransactionAiringUI
                {
                    RadioStationId = r.RadioStationId,
                    IsSelected = false
                };

                transactionAiringList.Add(aTran);
            }


            var view = new RadioTransactionUIView
            {
                ApconApprovalType = apconApprovalType,
                ActiveMaterialType = activematerialTypeDDL,
                RadioStationList = radioStations,
                AiringDetailsList = transactionAiringList,

                TimingType = timing,
                ScriptQuestion = materialQuestionDDL,
                TimeBeltList = timeBeltDDL,
                ProcessingMessage = string.Empty,
            };

            return view;
        }

        /// <summary>
        /// Creates the radio main view.
        /// </summary>
        /// <param name="ApconApprovalType">Type of the apcon approval.</param>
        /// <param name="radioStations">The radio stations.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="ScriptMaterialQuestion">The script material question.</param>
        /// <param name="activeMaterialTypeCollection">The active material type collection.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <param name="radioMainTransaction">The radio main transaction.</param>
        /// <param name="transactionAiring">The transaction airing.</param>
        /// <param name="selectedRadioStationIds">The selected radio station ids.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns>
        /// IRadioTransactionUIView.
        /// </returns>
        public IRadioTransactionUIView CreateRadioMainView(IList<IApconApprovalType> ApconApprovalType,
            IList<IRadioStationModel> radioStations, IList<ITiming> Timing,
            IList<IScriptMaterialQuestion> ScriptMaterialQuestion, IList<IMaterialType> activeMaterialTypeCollection,
            IList<ITimeBelt> timeBelts, IRadioTransactionUI radioMainTransaction,
            IEnumerable<IRadioTransactionAiringUI> transactionAiring, List<int> selectedRadioStationIds,
            string processingMessage)
        {
            if (ApconApprovalType == null)
            {
                throw new ArgumentNullException(nameof(ApconApprovalType));
            }

            if (Timing == null)
            {
                throw new ArgumentNullException(nameof(Timing));
            }

            if (ScriptMaterialQuestion == null)
            {
                throw new ArgumentNullException(nameof(ScriptMaterialQuestion));
            }

            if (radioMainTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioMainTransaction));
            }

            var apconApprovalType =
                GetDropDownList.ApconApprovalListItems(ApconApprovalType, radioMainTransaction.ApconApprovalTypeId);
            var activeMaterialTypeDDL = GetDropdownMaterialTypeList.MaterialTypeListItems(activeMaterialTypeCollection,
                radioMainTransaction.MaterialTypeId);
            var materialQuestionDDL = GetDropDownList.ScriptMaterialQuestionListItems(ScriptMaterialQuestion,
                radioMainTransaction.ScriptMaterialQuestionCode);
            var timing = GetDropdownTimingList.TimingListItems(Timing, -1);

            var timeBeltDDL = GetDropDownTimeBelt.TimeBeltItems(timeBelts, -1);

            // update transaction airing selected field, set to true if radio station is selected
            var radioTransactionAiringList = transactionAiring.ToList();
            radioTransactionAiringList.Each(x => x.IsSelected = selectedRadioStationIds.Contains(x.RadioStationId));

            // add radio airing records for stations not added before from the database
            foreach (var r in radioStations)
            {
                if (!selectedRadioStationIds.Contains(r.RadioStationId))
                {
                    var aTran = new RadioTransactionAiringUI
                    {
                        RadioStationId = r.RadioStationId,
                        IsSelected = false
                    };

                    radioTransactionAiringList.Add(aTran);
                }
            }

            // create view model 
            var viewModel = new RadioTransactionUIView
            {
                MaterialTypeId = radioMainTransaction.MaterialTypeId,
                ApconApprovalTypeId = radioMainTransaction.ApconApprovalTypeId,
                FinalAmount = radioMainTransaction.FinalAmount,
                ApconApprovalType = apconApprovalType,
                ActiveMaterialType = activeMaterialTypeDDL,
                RadioStationList = radioStations,
                TimingType = timing,
                ScriptQuestion = materialQuestionDDL,
                TimeBeltList = timeBeltDDL,
                SelectedRadioStationIds = selectedRadioStationIds,
                ProcessingMessage = processingMessage,
                AiringDetailsList = radioTransactionAiringList,
                OrderTitle = radioMainTransaction.OrderTitle,
                ScriptDescription = radioMainTransaction.ScriptDescription,
                ScriptingAmount = radioMainTransaction.ScriptingAmount,
                ProductionAmount = radioMainTransaction.ProductionAmount,
                ScriptDigitalFileId = radioMainTransaction.ScriptDigitalFileId,
                MaterialDigitalFileId = radioMainTransaction.MaterialDigitalFileId,
                ScriptFileDescription = radioMainTransaction.ScriptFileDescription,
                MaterialFileDescription = radioMainTransaction.MaterialFileDescription,
                ApconApprovalAmount = radioMainTransaction.ApconApprovalAmount,
                ApconApprovalNumber = radioMainTransaction.ApconApprovalNumber,
                IsHaveApconApproval = radioMainTransaction.IsHaveApconApproval,
                IsHaveMaterial = radioMainTransaction.IsHaveMaterial,
                RadioTransactionId = radioMainTransaction.RadioTransactionId,
                OrderId = radioMainTransaction.OrderId,
                AiringInstruction = radioMainTransaction.AiringInstruction
            };

            return viewModel;
        }

        /// <summary>
        /// Gets the edit radio station type view.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radio</exception>
        public IRadioStationView GetEditRadioStationTypeView(IRadioStationModel radio, string message)
        {
            if (radio == null) throw new ArgumentNullException(nameof(radio));
            var view = new RadioStationView
            {
                ProcessingMessage = message,
                Description = radio.Description,
                RadioStationId = radio.RadioStationId
            };

            return view;
        }


        /// <summary>
        /// Creates the material production price view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ServiceType
        /// or
        /// MaterialType
        /// </exception>
        /// <exception cref="System.ArgumentNullException">ServiceType
        /// or
        /// MaterialType</exception>
        public IMaterialProductionPriceView CreateMaterialProductionPriceView(IList<IServiceType> ServiceType,
            IList<IMaterialType> MaterialType)
        {
            if (ServiceType == null)
            {
                throw new ArgumentNullException("ServiceType");
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);

            var view = new MaterialProductionPriceView
            {
                ProcessingMessage = string.Empty,
                ServiceType = serviceType,
                MaterialType = materialType
            };
            return view;
        }


        /// <summary>
        /// Creates the material production price view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="view">The view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ServiceType
        /// or
        /// MaterialType
        /// </exception>
        public IMaterialProductionPriceView CreateMaterialProductionPriceView(IList<IServiceType> ServiceType,
            IList<IMaterialType> MaterialType, IMaterialProductionPriceView view, string message)
        {
            if (ServiceType == null)
            {
                throw new ArgumentNullException("ServiceType");
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);


            view.ProcessingMessage = message;
            view.ServiceType = serviceType;
            view.MaterialType = materialType;

            return view;
        }

        /// <summary>
        /// Edits the material production price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="productionPrice">The production price.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">serviceType
        /// or
        /// materialType
        /// or
        /// productionPrice</exception>
        public IMaterialProductionPriceView EditMaterialProductionPriceView(IList<IServiceType> serviceType,
            IList<IMaterialType> materialType, IMaterialProductionPrice productionPrice, string message)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (materialType == null)
            {
                throw new ArgumentNullException(nameof(materialType));
            }

            if (productionPrice == null)
            {
                throw new ArgumentNullException(nameof(productionPrice));
            }


            var ServiceTypeDDL = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, "");
            var MaterialType = GetDropdownMaterialTypeList.MaterialTypeListItems(materialType, -1);

            var view = new MaterialProductionPriceView
            {
                MaterialType = MaterialType,
                ServiceType = ServiceTypeDDL,
                Comment = productionPrice.Comment,
                Amount = productionPrice.Amount,
                DateCreated = productionPrice.DateCreated,
                DateInactive = productionPrice.DateInactive,
                IsActive = productionPrice.IsActive,
                EffectiveDate = productionPrice.EffectiveDate,
                ServiceTypeCode = productionPrice.ServiceTypeCode,
                MaterialProductionPriceId = productionPrice.MaterialProductionPriceId,
                MaterialTypeId = productionPrice.MaterialTypeId,

                ProcessingMessage = message
            };
            return view;
        }


        /// <summary>
        /// Creates the updated material production price view.
        /// </summary>
        /// <param name="productionInfo">The production information.</param>
        /// <param name="ProcessingMessages">The processing messages.</param>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// productionInfo
        /// or
        /// MaterialType
        /// or
        /// MaterialType
        /// </exception>
        /// <exception cref="System.ArgumentNullException">productionInfo
        /// or
        /// MaterialType
        /// or
        /// MaterialType</exception>
        public IMaterialProductionPriceView CreateUpdatedMaterialProductionPriceView(
            IMaterialProductionPriceView productionInfo, string ProcessingMessages,
            IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType)
        {
            if (productionInfo == null)
            {
                throw new ArgumentNullException(nameof(productionInfo));
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException(nameof(MaterialType));
            }

            if (ServiceType == null)
            {
                throw new ArgumentNullException(nameof(MaterialType));
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);

            productionInfo.MaterialType = materialType;
            productionInfo.ServiceType = serviceType;
            productionInfo.ProcessingMessage = ProcessingMessages;

            return productionInfo;
        }


        /// <summary>
        /// Creates the material scripting price view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ServiceType
        /// or
        /// MaterialType
        /// </exception>
        /// <exception cref="System.ArgumentNullException">ServiceType
        /// or
        /// MaterialType</exception>
        public IMaterialScriptingPriceView CreateMaterialScriptingPriceView(IList<IServiceType> ServiceType,
            IList<IMaterialType> MaterialType)
        {
            if (ServiceType == null)
            {
                throw new ArgumentNullException("ServiceType");
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);

            var view = new MaterialScriptingPriceView
            {
                ProcessingMessage = string.Empty,
                ServiceType = serviceType,
                MaterialType = materialType
            };
            return view;
        }

        /// <summary>
        /// Creates the material scripting price view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="view">The view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ServiceType
        /// or
        /// MaterialType</exception>
        public IMaterialScriptingPriceView CreateMaterialScriptingPriceView(IList<IServiceType> ServiceType,
            IList<IMaterialType> MaterialType, IMaterialScriptingPriceView view, string message)
        {
            if (ServiceType == null)
            {
                throw new ArgumentNullException("ServiceType");
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);


            view.ProcessingMessage = message;
            view.ServiceType = serviceType;
            view.MaterialType = materialType;

            return view;
        }


        /// <summary>
        /// Edits the material scripting price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="scriptingPrice">The scripting price.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">serviceType
        /// or
        /// materialType
        /// or
        /// scriptingPrice</exception>
        public IMaterialScriptingPriceView EditMaterialScriptingPriceView(IList<IServiceType> serviceType,
            IList<IMaterialType> materialType, IMaterialScriptingPrice scriptingPrice, string message)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (materialType == null)
            {
                throw new ArgumentNullException(nameof(materialType));
            }

            if (scriptingPrice == null)
            {
                throw new ArgumentNullException(nameof(scriptingPrice));
            }


            var ServiceTypeDDL = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, "");
            var MaterialType = GetDropdownMaterialTypeList.MaterialTypeListItems(materialType, -1);

            var view = new MaterialScriptingPriceView
            {
                MaterialType = MaterialType,
                ServiceType = ServiceTypeDDL,
                Comment = scriptingPrice.Comment,
                Amount = scriptingPrice.Amount,
                DateCreated = scriptingPrice.DateCreated,
                DateInactive = scriptingPrice.DateInactive,
                IsActive = scriptingPrice.IsActive,
                EffectiveDate = scriptingPrice.EffectiveDate,
                ServiceTypeCode = scriptingPrice.ServiceTypeCode,
                MaterialScriptingPriceId = scriptingPrice.MaterialScriptingPriceId,
                MaterialTypeId = scriptingPrice.MaterialTypeId,

                ProcessingMessage = message
            };
            return view;
        }


        /// <summary>
        /// Creates the updated material scripting price view.
        /// </summary>
        /// <param name="scriptingInfo">The scripting information.</param>
        /// <param name="ProcessingMessages">The processing messages.</param>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// scriptingInfo
        /// or
        /// MaterialType
        /// or
        /// MaterialType
        /// </exception>
        /// <exception cref="System.ArgumentNullException">scriptingInfo
        /// or
        /// MaterialType
        /// or
        /// MaterialType</exception>
        public IMaterialScriptingPriceView CreateUpdatedMaterialScriptingPriceView(
            IMaterialScriptingPriceView scriptingInfo, string ProcessingMessages,
            IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType)
        {
            if (scriptingInfo == null)
            {
                throw new ArgumentNullException(nameof(scriptingInfo));
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException(nameof(MaterialType));
            }

            if (ServiceType == null)
            {
                throw new ArgumentNullException(nameof(MaterialType));
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);

            scriptingInfo.MaterialType = materialType;
            scriptingInfo.ServiceType = serviceType;
            scriptingInfo.ProcessingMessage = ProcessingMessages;

            return scriptingInfo;
        }


        /// <summary>
        /// Creates the radio station view.
        /// </summary>
        /// <param name="radioStationCollection">The radiostationcollection.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedRadioStationId">The selected radio station identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radiostationcollection</exception>
        public IRadioSationListView CreateRadioStationView(IList<IRadioStationModel> radioStationCollection,
            string message,
            int selectedRadioStationId, string selectedDescription)
        {
            if (radioStationCollection == null)
            {
                throw new ArgumentNullException(nameof(radioStationCollection));
            }


            //Search by radio station Id
            var filteredList = radioStationCollection.Where(x =>
                    x.RadioStationId.Equals(selectedRadioStationId < 1 ? x.RadioStationId : selectedRadioStationId))
                .ToList();

            // search by description
            filteredList = filteredList.Where(x => x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                    ? x.Description
                    : selectedDescription))
                .ToList();

            // Search By radio description
            //filteredList = filteredList.Where(x => x.Description.Contains(string.IsNullOrEmpty(selectedDescription) ? x.Description : selectedDescription)).ToList();


            var returnView = new RadioStationListView
            {
                RadioStationCollection = filteredList.ToList(),
                SelectedRadioStationId = selectedRadioStationId,
                SelectedDescription = selectedDescription,
                ProcessingMessage = message
            };

            return returnView;
        }


        /// <summary>
        /// Creates the radio station.
        /// </summary>
        /// <returns></returns>
        public IRadioStationView CreateRadioStation()
        {
            var view = new RadioStationView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }

        /// <summary>
        /// Creates the radio station.
        /// </summary>
        /// <param name="radioView">The radio view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IRadioStationView CreateRadioStation(IRadioStationView radioView, string message)
        {
            radioView.ProcessingMessage = message;

            return radioView;
        }


        /// <summary>
        /// Creates the scripting price view.
        /// </summary>
        /// <param name="materialScriptingType">Type of the material scripting.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedMaterialScriptingPriceId">The selected material scripting price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialScriptingType</exception>
        /// <exception cref="System.ArgumentNullException">MaterialScriptingPriceCollection</exception>
        public IScriptingPriceListView CreateScriptingPriceView(IList<IMaterialScriptingPrice> materialScriptingType,
            string message,
            int selectedMaterialScriptingPriceId, string selectedDescription, string selectedServiceTypeCode)
        {
            if (materialScriptingType == null)
            {
                throw new ArgumentNullException(nameof(materialScriptingType));
            }

            //Search by Price Id
            var filteredList = materialScriptingType.Where(x =>
                x.MaterialScriptingPriceId.Equals(selectedMaterialScriptingPriceId < 1
                    ? x.MaterialScriptingPriceId
                    : selectedMaterialScriptingPriceId)).ToList();

            ////search by Material Id
            //filteredList = filteredList.Where(x =>
            //    x.MaterialTypeDescription.Equals(selectedMaterialId < 1 ? x.MaterialTypeId : selectedMaterialId)).ToList();
            filteredList = filteredList.Where(x => x.MaterialTypeDescription.Contains(
                    string.IsNullOrEmpty(selectedDescription)
                        ? x.MaterialTypeDescription
                        : selectedDescription))
                .ToList();
            //search by service code
            filteredList = filteredList.Where(x =>
                x.ServiceTypeCode.Contains(string.IsNullOrEmpty(selectedServiceTypeCode)
                    ? x.ServiceTypeCode
                    : selectedServiceTypeCode)).ToList();


            var returnView = new ScriptingPriceListView
            {
                MaterialScriptingPriceCollection = filteredList.ToList(),
                SelectedMaterialScriptingPriceId = selectedMaterialScriptingPriceId,
                SelectedDescription = selectedDescription,
                SelectedServiceTypeCode = selectedServiceTypeCode,
                ProcessingMessage = message
            };

            return returnView;
        }

        /// <summary>
        /// Creates the production price view.
        /// </summary>
        /// <param name="materialProductionType">Type of the material production.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedMaterialProductionPriceId">The selected material production price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="selectedServiceTypeCode">The selected service type code.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialProductionType</exception>
        /// <exception cref="System.ArgumentNullException">materialProductionType</exception>
        public IProductionPriceListView CreateProductionPriceView(
            IList<IMaterialProductionPrice> materialProductionType, string message,
            int selectedMaterialProductionPriceId, string selectedDescription, string selectedServiceTypeCode)
        {
            if (materialProductionType == null)
            {
                throw new ArgumentNullException(nameof(materialProductionType));
            }

            //search by production price Id
            var filteredList = materialProductionType.Where(x =>
                x.MaterialProductionPriceId.Equals(selectedMaterialProductionPriceId < 1
                    ? x.MaterialProductionPriceId
                    : selectedMaterialProductionPriceId)).ToList();

            //search by material type Id
            filteredList = filteredList.Where(x => x.MaterialTypeDescription.Contains(
                    string.IsNullOrEmpty(selectedDescription)
                        ? x.MaterialTypeDescription
                        : selectedDescription))
                .ToList();

            //search by service code
            filteredList = filteredList.Where(x =>
                x.ServiceTypeCode.Contains(string.IsNullOrEmpty(selectedServiceTypeCode)
                    ? x.ServiceTypeCode
                    : selectedServiceTypeCode)).ToList();

            var returnView = new ProductionPriceListView
            {
                MaterialProductionPriceCollection = filteredList.ToList(),
                SelectedDescription = selectedDescription,
                SelectedMaterialProductionPriceId = selectedMaterialProductionPriceId,
                SelectedServiceTypeCode = selectedServiceTypeCode,
                ProcessingMessage = message
            };
            return returnView;
        }


        /// <summary>
        /// Creates the timing list vew.
        /// </summary>
        /// <param name="timingCollection">The timing collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ITimingListView CreateTimingListVew(IList<ITiming> timingCollection, string message)
        {
            var returnView = new TimingListView
            {
                TimingCollection = timingCollection,
                ProcessingMessage = message ?? ""
            };
            return returnView;
        }

        /// <summary>
        /// Creates the timing view.
        /// </summary>
        /// <param name="timingCollection">The timing collection.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timingCollection</exception>
        /// <exception cref="System.ArgumentNullException">timingCollection</exception>
        public ITimingView CreateTimingView(IList<ITiming> timingCollection, int Id)
        {
            if (timingCollection == null) throw new ArgumentNullException(nameof(timingCollection));

            var timingcollection = GetDropdownTimingList.TimingListItems(timingCollection, Id);

            var view = new TimingView
            {
                TimingId = Id,
                ParentTimingDropDown = timingcollection,
                ProcessingMessage = string.Empty
            };

            return view;
        }

        /// <summary>
        /// Creates the radio transaction view.
        /// </summary>
        /// <param name="apconApprovalTypePriceList">The apcon approval type price list.</param>
        /// <param name="durationTypeList">The duration type list.</param>
        /// <param name="scriptMaterialQuestionList">The script material question list.</param>
        /// <param name="materialTypeTimeList">The material type time list.</param>
        /// <param name="productionPriceList">The production price list.</param>
        /// <param name="scriptingPriceList">The scripting price list.</param>
        /// <param name="radioStationList">The radio station list.</param>
        /// <returns></returns>
        public IRadioTransactionView CreateRadioTransactionView(
            IList<IApconApprovalTypePrice> apconApprovalTypePriceList, IList<IDurationType> durationTypeList,
            IList<IScriptMaterialQuestion> scriptMaterialQuestionList,
            IList<IMaterialTypeTimingDetail> materialTypeTimeList,
            IList<IMaterialProductionPrice> productionPriceList, IList<IMaterialScriptingPrice> scriptingPriceList,
            IList<IRadioStationModel> radioStationList)
        {
            var apconAprovalTypeDDL = GetDropDownList.ApconApprovalPriceListItems(apconApprovalTypePriceList, -1);
            var durationTypeDDL = GetDropDownList.DurationTypeListItems(durationTypeList, "-1");
            var materialTypeTimeDDL = GetDropDownList.MateriaTypeTimeListItems(materialTypeTimeList, -1);
            var materialQuestionDDL = GetDropDownList.ScriptMaterialQuestionListItems(scriptMaterialQuestionList, "");
            var stationDDL = GetDropDownList.RadioStationListItems(radioStationList, -1);

            var viewModel = new RadioTransactionView
            {
                ProductionPriceList = productionPriceList,
                ScriptingPriceList = scriptingPriceList,
                ApconApprovalTypeList = apconAprovalTypeDDL,
                DurationTypeList = durationTypeDDL,
                MaterialTypeTimeList = materialTypeTimeDDL,
                ScriptMaterialQuestionList = materialQuestionDDL,
                StationList = stationDDL
            };
            return viewModel;
        }


        /// <summary>
        /// Gets the scripting price for radio.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price</exception>
        public IRadioMainView GetScriptingPriceForRadio(IMaterialScriptingPrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            var view = new RadioMainView
            {
                MaterialScriptingPriceId = price.MaterialScriptingPriceId,

                ScriptingAmount = price.Amount
            };
            return view;
        }


        /// <summary>
        /// Gets the production price for radio.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price</exception>
        public IRadioMainView GetProductionPriceForRadio(IMaterialProductionPrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            var view = new RadioMainView
            {
                MaterialProductionPriceId = price.MaterialProductionPriceId,
                ProductionAmount = price.Amount
            };
            return view;
        }


        /// <summary>
        /// Gets the radio transaction edit view.
        /// </summary>
        /// <param name="radioOrder">The radio order.</param>
        /// <param name="radioTransactionAiring">The radio transaction airing.</param>
        /// <param name="ApconApprovalType">Type of the apcon approval.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="RadioStationType">Type of the radio station.</param>
        /// <param name="DurationType">Type of the duration.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="ScriptMaterialQuestion">The script material question.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ApconApprovalType
        /// or
        /// MaterialType
        /// or
        /// RadioStationType
        /// or
        /// DurationType
        /// or
        /// Timing
        /// or
        /// ScriptMaterialQuestion
        /// </exception>
        /// <exception cref="System.ArgumentNullException">ApconApprovalType
        /// or
        /// MaterialType
        /// or
        /// RadioStationType
        /// or
        /// DurationType
        /// or
        /// Timing
        /// or
        /// ScriptMaterialQuestion</exception>
        /// <!-- Badly formed XML comment ignored for member "M:ADit.Interfaces.IRadioViewsModelFactory.GetRadioTransactionEditView(ADit.Interfaces.IRadioOrder,System.Collections.Generic.IList{ADit.Interfaces.IRadioTransactionAiring},System.Collections.Generic.IList{ADit.Interfaces.IApconApprovalType},System.Collections.Generic.IList{ADit.Interfaces.IMaterialType},System.Collections.Generic.IList{ADit.Interfaces.IRadioStationModel},System.Collections.Generic.IList{ADit.Interfaces.IDurationType},System.Collections.Generic.IList{ADit.Interfaces.IMaterialTypeTimingModel},System.Collections.Generic.IList{ADit.Interfaces.IScriptMaterialQuestion},System.Collections.Generic.IList{ADit.Interfaces.IYesNoQuestion})" -->
        public IRadioMainView GetRadioTransactionEditView(IRadioOrder radioOrder,
            IList<IRadioTransactionAiring> radioTransactionAiring, IList<IApconApprovalType> ApconApprovalType,
            IList<IMaterialType> MaterialType,
            IList<IRadioStationModel> RadioStationType, IList<IDurationType> DurationType,
            IList<IMaterialTypeTimingModel> Timing, IList<IScriptMaterialQuestion> ScriptMaterialQuestion,
            string processingMessage, IList<ITimeBelt> timeBelts)

        {
            if (ApconApprovalType == null)
            {
                throw new ArgumentNullException("ApconApprovalType");
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }

            if (RadioStationType == null)
            {
                throw new ArgumentNullException("RadioStationType");
            }

            if (DurationType == null)
            {
                throw new ArgumentNullException("DurationType");
            }


            if (Timing == null)
            {
                throw new ArgumentNullException("Timing");
            }


            if (ScriptMaterialQuestion == null)
            {
                throw new ArgumentNullException("ScriptMaterialQuestion");
            }

            var apconApprovalType =
                GetDropDownList.ApconApprovalListItems(ApconApprovalType, radioOrder.ApconApprovalTypeId);
            var materialType =
                GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, radioOrder.MaterialTypeId);

            var scriptMaterialQuestion =
                GetDropDownList.ScriptMaterialQuestionListItems(ScriptMaterialQuestion, radioOrder.MaterialQuestionId);

            //TV Duration TypeDrop Down
            var tvDurationTypeDDL = GetDropDownList.DurationTypeListItems(DurationType, "");

            //Timing Drop Down
            var tvTimingDDL = GetDropdownTimingList.TimingList(Timing, -1);

            var selectedTimeBelt = -1;
            var selectedTiming = -1;
            DateTime selectedStartDate = DateTime.Now;
            DateTime selectedEndDate = DateTime.Now;
            int Slot = 1;
            int TotalSlot = 1;

            decimal Price = 0;

            RadioAiringTransactionModel radioAiringTransactionModel = new RadioAiringTransactionModel();

            foreach (var j in RadioStationType)
            {
                var selectedRadioStation =
                    radioTransactionAiring.SingleOrDefault(x => x.RadioStationId == j.RadioStationId);

                if (selectedRadioStation != null)
                {
                    selectedTimeBelt = selectedRadioStation.TimeBeltId;
                    selectedTiming = selectedRadioStation.MaterialTypeTimingId;
                    Slot = selectedRadioStation.Slots;
                    TotalSlot = selectedRadioStation.TotalSlots;
                    Price = selectedRadioStation.Price;
                }

                if (selectedRadioStation == null)
                {
                    selectedEndDate = DateTime.Now;
                    radioAiringTransactionModel.EndDate.Add(selectedEndDate);
                }
                else
                {
                    selectedEndDate = selectedRadioStation.EndDate;
                    radioAiringTransactionModel.EndDate.Add(selectedEndDate);
                }


                if (selectedRadioStation == null)
                {
                    selectedStartDate = DateTime.Now;
                    radioAiringTransactionModel.StartDate.Add(selectedStartDate);
                }
                else
                {
                    selectedStartDate = selectedRadioStation.StartDate;
                    radioAiringTransactionModel.StartDate.Add(selectedStartDate);
                }

                radioAiringTransactionModel.RadioStation.Add(j);


                if (selectedRadioStation == null)
                {
                    selectedTiming = -1;
                }

                //Timing Drop Down
                var radioTimingDropdown = GetDropdownTimingList.TimingList(Timing, selectedTiming);
                radioAiringTransactionModel.MaterialTypeTiming.Add(radioTimingDropdown);
                //TimeBelt
                if (selectedRadioStation == null)
                {
                    selectedTimeBelt = -1;
                }

                var radioTimeBeltDropDown = GetDropDownTimeBelt.TimeBeltItems(timeBelts, selectedTimeBelt);
                radioAiringTransactionModel.TimeBelts.Add(radioTimeBeltDropDown);

                if (selectedRadioStation == null)
                {
                    Slot = 1;
                }

                radioAiringTransactionModel.Slots.Add(Slot);
                if (selectedRadioStation == null)
                {
                    TotalSlot = 1;
                }

                radioAiringTransactionModel.TotalSlot.Add(TotalSlot);


                if (selectedRadioStation == null)
                {
                    Price = 0;
                }

                radioAiringTransactionModel.Price.Add(Price);
            }


            var view = new RadioMainView
            {
                RadioTransactionId = radioOrder.RadioTransactionId,
                ApconApprovalType = apconApprovalType,
                AiringDescription = radioOrder.AiringDescription,
                ApconApprovalAmount = radioOrder.ApconApprovalAmount,
                DateInactive = radioOrder.DateInactive,
                DateCreated = radioOrder.DateCreated,
                Comment = radioOrder.Comment,
                ApconApprovalTypeId = radioOrder.ApconApprovalTypeId,

                ApconApprovalNumber = radioOrder.ApconApprovalNumber,
                MaterialType = materialType,
                ScriptQuestion = scriptMaterialQuestion,
                FinalAmount = radioOrder.FinalAmount,
                ProcessingMessage = processingMessage,
                OrderTitle = radioOrder.OrderTitle,
                OrderNumber = radioOrder.OrderNumber,
                ProductionAmount = radioOrder.ProductionAmount,
                ScriptingAmount = radioOrder.ScriptingAmount,
                MaterialTypeId = radioOrder.MaterialTypeId,
                MaterialScriptingPriceId = radioOrder.MaterialScriptingPriceId,
                MaterialProductionPriceId = radioOrder.MaterialProductionPriceId,
                ScriptDigitalFileId = radioOrder.ScriptDigitalFileId,
                ApconApprovalTypePriceId = radioOrder.ApconApprovalTypePriceId,
                DurationCode = radioOrder.DurationCode,
                MaterialDigitalFileId = radioOrder.MaterialDigitalFileId,
                EffectiveDate = radioOrder.EffectiveDate,
                TimingId = radioOrder.MaterialTypeTimingId,

                RadioAiringList = radioTransactionAiring,


                ActiveMaterialType = materialType,
                RadioStationList = RadioStationType,
                DurationType = tvDurationTypeDDL,
                TimingType = tvTimingDDL,

                //TV Transaction Details
                RadioAiringListDetails = radioAiringTransactionModel,
            };
            return view;
        }

        /// <summary>
        /// Gets the radio transaction.
        /// </summary>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioTransaction</exception>
        public IRadioMainListView getRadioTransaction(IList<IRadioTransaction> radioTransaction)
        {
            if (radioTransaction == null)
            {
                throw new ArgumentNullException("radioTransaction");
            }


            var radio = new RadionMainListView

            {
                radioCollection = radioTransaction
            };

            return radio;
        }


        /// <summary>
        /// Gets the radio airing view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="radioStationList">The radio station list.</param>
        /// <param name="durationTypeList">The duration type list.</param>
        /// <param name="timingList">The timing list.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IRadioTransactionAiringView GetRadioAiringView(int transactionId,
            IList<IRadioStationModel> radioStationList, IList<IDurationType> durationTypeList,
            IList<ITiming> timingList, string processingMessage)
        {
            var durationTypeDDL = GetDropDownList.DurationTypeListItems(durationTypeList, "-1");
            var timingDDL = GetDropdownTimingList.TimingListItems(timingList, -1);
            var stationDDL = GetDropDownList.RadioStationListItems(radioStationList, -1);

            var modelView = new RadioTransactionAiringView
            {
                RadioTransactionId = transactionId,
                DurationTypeCodeList = durationTypeDDL,
                RadioStationsList = stationDDL,
                Timing = timingDDL,

                ProcessingMessage = processingMessage,
            };

            return modelView;
        }

        /// <summary>
        /// Gets the radio production view by identifier.
        /// </summary>
        /// <param name="radioOrder">The radio order.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioTransaction</exception>
        public IRadioMainView GetRadioProductionViewById(IRadioTransaction radioOrder)
        {
            if (radioOrder == null)
            {
                throw new ArgumentNullException("radioTransaction");
            }

            var view = new RadioMainView
            {
                FirstName = radioOrder.FirstName,
                LastName = radioOrder.LastName,
                RadioTransactionId = radioOrder.RadioTransactionId,


                ProcessingMessage = string.Empty,
                OrderTitle = radioOrder.OrderTitle,
            };
            return view;
        }


        /// <summary>
        /// Gets the radio main ListView.
        /// </summary>
        /// <param name="radioOrder">The radio order.</param>
        /// <param name="radioProduction">The radio production.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioProduction</exception>
        public IRadioProductionListView GetRadioMainListView(IRadioTransaction radioOrder,
            IList<IRadioProduction> radioProduction, IDigitalFile digitalFile)
        {
            if (radioProduction == null)
            {
                throw new ArgumentNullException("radioProduction");
            }


            var radioProductionListView = new RadioProductionListView
            {
                UploadedProductionMaterialDetail = digitalFile,
                Name = radioOrder.UserName,
                RadioTransactionId = radioOrder.RadioTransactionId,


                processingMessage = string.Empty,
                OrderTitle = radioOrder.OrderTitle,
                radioProductionCollection = radioProduction
            };

            return radioProductionListView;
        }

        /// <summary>
        /// Gets the radio transaction by identifier.
        /// </summary>
        /// <param name="radioOrder">The radio order.</param>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="radioTransactionAiring">The radio transaction airing.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// radioOrder
        /// or
        /// apconApprovalType
        /// or
        /// materialType
        /// </exception>
        public IRadioMainView getRadioTransactionById(IRadioOrder radioOrder,
            IList<IApconApprovalType> apconApprovalType, IList<IMaterialType> materialType, string processingMessage,
            IList<IRadioTransactionAiring> radioTransactionAiring)
        {
            if (radioOrder == null)
            {
                throw new ArgumentNullException(nameof(radioOrder));
            }


            if (apconApprovalType == null)
            {
                throw new ArgumentNullException(nameof(apconApprovalType));
            }

            if (materialType == null)
            {
                throw new ArgumentNullException(nameof(materialType));
            }

            var apconApprovalTypeDDL =
                GetDropDownList.ApconApprovalListItems(apconApprovalType, radioOrder.ApconApprovalTypePriceId);
            var materialTypeDDL =
                GetDropdownMaterialTypeList.MaterialTypeListItems(materialType, radioOrder.MaterialTypeId);


            var RadioMainView = new RadioMainView
            {
                RadioTransactionId = radioOrder.RadioTransactionId,
                ApconApprovalType = apconApprovalTypeDDL,
                AiringDescription = radioOrder.AiringDescription,
                ApconApprovalAmount = radioOrder.ApconApprovalAmount,

                DateCreated = radioOrder.DateCreated,

                ApconApprovalTypeId = radioOrder.ApconApprovalTypeId,
                ApconApprovalNumber = radioOrder.ApconApprovalNumber,

                MaterialType = materialTypeDDL,

                FinalAmount = radioOrder.FinalAmount,
                ProcessingMessage = processingMessage,
                OrderTitle = radioOrder.OrderTitle,
                ProductionAmount = radioOrder.ProductionAmount,
                ScriptingAmount = radioOrder.ScriptingAmount,
                MaterialTypeId = radioOrder.MaterialTypeId,


                RadioAiringList = radioTransactionAiring,
            };

            return RadioMainView;
        }

        /// <summary>
        /// Gets the radio script transaction ListView.
        /// </summary>
        /// <param name="radioScriptTransaction">The radio script transaction.</param>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// radioScriptTransaction
        /// or
        /// radioTransaction
        /// </exception>
        public IRadioScriptTransactionListView GetRadioScriptTransactionListView(
            IList<IRadioScriptTransaction> radioScriptTransaction, IRadioTransaction radioTransaction,
            IDigitalFile digitalFile, int? Id, int RepliesId, IList<IMessage> messages, IList<IReplies> replies)
        {
            if (radioScriptTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioScriptTransaction));
            }

            if (radioTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioTransaction));
            }

            var radioList = new RadioScriptTransactionListView
            {
                AdditionalInfo = radioTransaction.AiringInstruction,
                Name = radioTransaction.UserName,
                OrderTitle = radioTransaction.OrderTitle,
                radioScriptTransaction = radioScriptTransaction,
                UploadedScriptDetail = digitalFile,
                SentToId = radioTransaction.UserId,
                transactionId = radioTransaction.RadioTransactionId,
                MessageId = Id,
                RepliesId = RepliesId,

                DigitalFileId = radioTransaction.ScriptingDigitalFileId,
                messageList = messages,
                repliesList = replies
            };

            return radioList;
        }

        /// <summary>
        /// Gets all radio transaction.
        /// </summary>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioTransaction</exception>
        public IRadioTransactionListView getAllRadioTransaction(IList<IRadioTransaction> radioTransaction,
            IList<IMessage> messages, string ProcessingMessage, IList<IMessage> messageList, IList<IReplies> replies)
        {
            if (radioTransaction == null)
            {
                throw new ArgumentNullException("radioTransaction");
            }

            var view = new RadioTransactionListView
            {
                radioTransaction = radioTransaction,
                messagesLists = messages,
                ProcessingMessage = ProcessingMessage,
                repliesLists = replies,
            };
            return view;
        }

        /// <summary>
        /// Gets the radio material transaction ListView.
        /// </summary>
        /// <param name="radioMaterialTransaction">The radio material transaction.</param>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// radioMaterialTransaction
        /// or
        /// radioTransaction
        /// </exception>
        public IRadioTransactionMaterialListView GetRadioMaterialTransactionListView(
            IList<IRadioMaterialTransaction> radioMaterialTransaction, IRadioTransaction radioTransaction)
        {
            if (radioMaterialTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioMaterialTransaction));
            }

            if (radioTransaction == null)
            {
                throw new ArgumentNullException(nameof(radioTransaction));
            }

            var radioList = new RadioTransactionMaterialListView
            {
                AdditionalInfo = radioTransaction.AiringInstruction,
                Name = radioTransaction.UserName,
                OrderTitle = radioTransaction.OrderTitle,
                radioMaterialTransaction = radioMaterialTransaction,

                userId = radioTransaction.UserId,
                transactionId = radioTransaction.RadioTransactionId,
                UploadedMaterialDetail = radioTransaction.ProductionDigitalFileId
            };

            return radioList;
        }

        /// <summary>
        /// Gets the script message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">message</exception>
        public IMessageRepliesListView GetScriptMessageRepliesListView(IList<IReplies> replies, IMessage message,
            int SentToId, int transactionId, int OrderId)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var view = new MessageRepliesListView
            {
                UserId = message.UserId,
                InitialMessage = message.Message,
                MessageId = message.Id,
                SentToId = SentToId,
                transactionId = transactionId,
                DigitalFileId = message.DigitalFileId,
                Replies = replies,
                IsApproved = message.IsApproved,
                OrderId = OrderId,
            };
            return view;
        }

        /// <summary>
        /// Gets the radio material transaction ListView.
        /// </summary>
        /// <param name="radioMaterialTransactions">The radio material transactions.</param>
        /// <param name="radioTransaction">The radio transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// radioMaterialTransactions
        /// or
        /// radioTransaction
        /// </exception>
        public IRadioTransactionMaterialListView GetRadioMaterialTransactionListView(
            IList<IRadioMaterialTransaction> radioMaterialTransactions, IRadioTransaction radioTransaction,
            IDigitalFile digitalFile, int? Id, int RepliesId, IList<IMessage> messages, IList<IReplies> replies)
        {
            if (radioMaterialTransactions == null)
            {
                throw new ArgumentNullException(nameof(radioMaterialTransactions));
            }

            if (radioMaterialTransactions == null)
            {
                throw new ArgumentNullException(nameof(radioTransaction));
            }

            var radioList = new RadioTransactionMaterialListView
            {
                MessageId = Id,
                AdditionalInfo = radioTransaction.AiringInstruction,
                Name = radioTransaction.UserName,
                OrderTitle = radioTransaction.OrderTitle,
                radioMaterialTransaction = radioMaterialTransactions,

                SentToId = radioTransaction.UserId,
                transactionId = radioTransaction.RadioTransactionId,

                RepliesId = RepliesId,
                messageList = messages,
                repliesList = replies,
                DigitalFileId = radioTransaction.ProductionDigitalFileId
            };

            return radioList;
        }


        /// <summary>
        /// Gets the material message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">message</exception>
        public IMessageRepliesListView GetMaterialMessageRepliesListView(IList<IReplies> replies, IMessage message,
            int SentToId, int transactionId, int OrderId)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var view = new MessageRepliesListView
            {
                InitialMessage = message.Message,
                MessageId = message.Id,
                SentToId = SentToId,
                transactionId = transactionId,
                UserId = message.UserId,
                Replies = replies,
                IsApproved = message.IsApproved,
                DigitalFileId = message.DigitalFileId,
                OrderId = OrderId,
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
        public IRadioMainView GetUserTransaction(IRadioOrder radioOrder,
            IList<IRadioTransactionAiring> radioAiringTransactionModels, IList<IMaterialType> materialTypes)
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

            var materialTypeDDL =
                GetDropdownMaterialTypeList.MaterialTypeListItems(materialTypes, radioOrder.MaterialTypeId);
            var view = new RadioMainView
            {
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

                ApconApprovalNumber = radioOrder.ApconApprovalNumber,

                MaterialType = materialTypeDDL,

                FinalAmount = radioOrder.FinalAmount,

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
            };
            return view;
        }


       
    }
}