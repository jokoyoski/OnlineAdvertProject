using ADit.Domain.Models;
using ADit.Domain.Utilities;
using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ADit.Domain.Factories
{
    public class GeneralFactory : IGeneralFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apconApprovalTypeCollection"></param>
        /// <param name="message"></param>
        /// <param name="selectedApconApprovalTypeId"></param>
        /// <param name="selectedDescription"></param>
        /// <returns></returns>
        //this is the function that display the apconapproval list view
        public IApconApprovalTypeListView apconApprovalTypeListView(IList<IApconApprovalType> apconApprovalTypeCollection, string message, int selectedApconApprovalTypeId, string selectedDescription)
        {
            if (apconApprovalTypeCollection == null)
            {
                throw new ArgumentNullException(nameof(apconApprovalTypeCollection));
            }


            // filter with ApconApprovalTypeId
            var filteredList = apconApprovalTypeCollection.Where(x => x.ApoconTypeId.Equals(selectedApconApprovalTypeId < 1 ? x.ApoconTypeId : selectedApconApprovalTypeId)).ToList();
            // filter with ApconApprovalTypeDescription
            filteredList = filteredList.Where(x => x.Description.Contains(string.IsNullOrEmpty(selectedDescription) ? x.Description : selectedDescription)).ToList();

            var returnView = new ApconApprovalTypeListView
            {

                ApconApprovalTypeCollection = filteredList.ToList(),
                //ApconApprovalTypeCollection = apconApprovalTypeCollection,
                SelectedApconApprovalTypeId = selectedApconApprovalTypeId,
                SelectedDescription = selectedDescription,
                ProcessingMessage = message

            };
            return returnView;

        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //this shows the view  for the apconView where admin can add new item to the application
        public IApconApprovalView CreateApconView()
        {
            var view = new ApconApprovalView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="apconView"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        //updated view for the apcon view
        public IApconApprovalView CreateApconView(IApconApprovalView apconView, string processingMessage)
        {
            if (apconView == null)
            {
                throw new ArgumentNullException(nameof(apconView));
            }
            apconView.ProcessingMessage = processingMessage;

            return apconView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApconPrice"></param>
        /// <param name="message"></param>
        /// <param name="selectedApconApprovalTypePriceId"></param>
        /// <param name="selectedApconApprovalId"></param>
        /// <returns></returns>
        //this displays a list of apcon on the view 
        public IApconApprovalTypePriceListView CreateApconApprovalTypePriceViewModel(IList<IApconApprovalTypePrice> ApconPrice, string message,
            int selectedApconApprovalTypePriceId, int selectedApconApprovalId)
        {
            if (ApconPrice == null)
            {
                throw new ArgumentNullException(nameof(ApconPrice));
            }

            //Filter by Price Id
            var filteredList = ApconPrice.Where(x => x.ApconTypePriceId.Equals(selectedApconApprovalTypePriceId < 1 ? x.ApconTypePriceId : selectedApconApprovalTypePriceId)).ToList();
            //Filter by Price Id
            filteredList = filteredList.Where(x => x.ApconTypeId.Equals(selectedApconApprovalId < 1 ? x.ApconTypeId : selectedApconApprovalId)).ToList();


            var returnView = new ApconApprovalTypePriceListView
            {

                ApconApprovalTypePriceCollection = filteredList.ToList(),
                SelectedApconApprovalTypePriceId = selectedApconApprovalId,
                SelectedApconApprovalId = selectedApconApprovalId,
                ProcessingMessage = message
            };

            return returnView;
        }


        /// <summary>
        /// Creates the radio service price view model.
        /// </summary>
        /// <param name="RadioService">The radio service.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedRadioServiceId">The selected radio service identifier.</param>
        /// <param name="selectedRadioId">The selected radio identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedMaterialTypeId">The selected material type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">RadioService</exception>
        public IRadioServicePriceListView CreateRadioServicePriceViewModel(IList<IRadioServicePriceListModel> RadioService, string message,
         int selectedRadioServiceId, int selectedRadioId, int selectedTimingId, 
         int selectedMaterialTypeId)
        {
            if (RadioService == null)
            {
                throw new ArgumentNullException(nameof(RadioService));
            }

            //Filter by Price Id
            var filteredList = RadioService.Where(x => x.Id.Equals(selectedRadioServiceId < 1 ? x.Id : selectedRadioServiceId)).ToList();
            //Filter by Price Id
            filteredList = filteredList.Where(x => x.RadioId.Equals(selectedRadioId < 1 ? x.RadioId : selectedRadioId)).ToList();
            filteredList = filteredList.Where(x => x.TimingId.Equals(selectedTimingId < 1 ? x.TimingId : selectedTimingId)).ToList();
            filteredList = filteredList.Where(x => x.MaterialTypeId.Equals(selectedMaterialTypeId < 1 ? x.MaterialTypeId : selectedMaterialTypeId)).ToList();


            var returnView = new RadioServicePriceListView
            {

                RadioServicePriceCollection = filteredList.ToList(),
                SelectedRadioId = selectedRadioId,
                SelectedTimingId = selectedTimingId,
                SelectedMaterialTypeId = selectedMaterialTypeId,
                ProcessingMessage = message
            };

            return returnView;
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApconType"></param>
        /// <returns></returns>
        //apcon price view to add new info to the app
        public IApconApprovalTypePriceView CreateApconApprovalTypePriceView(IList<IApconApprovalType> ApconType)
        {
            if (ApconType == null)
            {
                throw new ArgumentNullException("ApconType");
            }
            

            var apconType = GetDropDownList.ApconApprovalListItems(ApconType, -1);
            
            var view = new ApconApprovalTypePriceView
            {
                ProcessingMessage = string.Empty,
                ApconApprovalType = apconType
                
            };
            return view;
        }

        /// <summary>
        /// Creates the radio service price view.
        /// </summary>
        /// <param name="RadioStation">The radio station.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="timeBelts">The time belts.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// RadioStation
        /// or
        /// Timing
        /// or
        /// MaterialType
        /// </exception>
        public IRadioServicePriceList CreateRadioServicePriceView(IList<IRadioStationModel> RadioStation, IList<ITiming> Timing,
            IList<IMaterialType> MaterialType,IList<ITimeBelt>timeBelts)
        {
            if (RadioStation == null)
            {
                throw new ArgumentNullException("RadioStation");
            }
            if (Timing == null)
            {
                throw new ArgumentNullException("Timing");
            }
            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }


            var radioStation = GetDropDownList.RadioStationListItems(RadioStation, -1);
            var timing = GetDropdownTimingList.TimingListItems(Timing, -1); 
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);
            var timingBelt = GetDropDownTimeBelt.TimeBeltItems(timeBelts, -1);

            var view = new RadioServicePriceListMain
            {
                ProcessingMessages = string.Empty,
                RadioStationType = radioStation,
                TimingType = timing,
                MaterialType = materialType,
               TimingBelt=timingBelt


            };
            return view;
        }

        /// <summary>
        /// Creates the radio service price view.
        /// </summary>
        /// <param name="radio">The radio.</param>
        /// <param name="RadioStation">The radio station.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// RadioStation
        /// or
        /// Timing
        /// or
        /// MaterialType
        /// </exception>
        public IRadioServicePriceList CreateRadioServicePriceView(IRadioServicePriceList radio, IList<IRadioStationModel> RadioStation, IList<ITiming> Timing,
           IList<IMaterialType> MaterialType, string message)
        {
            if (RadioStation == null)
            {
                throw new ArgumentNullException("RadioStation");
            }
            if (Timing == null)
            {
                throw new ArgumentNullException("Timing");
            }
            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }


            var radioStation = GetDropDownList.RadioStationListItems(RadioStation, -1);
            var timing = GetDropdownTimingList.TimingListItems(Timing, -1);
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);



            radio.ProcessingMessages = message;
            radio.RadioStationType = radioStation;
            radio.TimingType = timing;
            radio.MaterialType = materialType;


             
            return radio;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApconType"></param>
        /// <param name="priceView"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        //update view for the apcon type price view 
        public IApconApprovalTypePriceView CreateApconApprovalTypePriceView(IList<IApconApprovalType> ApconType,
            IApconApprovalTypePriceView priceView, string message)
        {
            if (ApconType == null)
            {
                throw new ArgumentNullException("ApconType");
            }
            if (priceView == null)
            {
                throw new ArgumentNullException("priceView");
            }


            var apconType = GetDropDownList.ApconApprovalListItems(ApconType, -1);

            priceView.ApconApprovalType = apconType;
            priceView.ProcessingMessage = message;

            return priceView;
        }


        /// <summary>
        /// Edits the apcon approval type price view.
        /// </summary>
        /// <param name="apconType">Type of the apcon.</param>
        /// <param name="apconPrice">The apcon price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// apconType
        /// or
        /// apconPrice
        /// </exception>
        public IApconApprovalTypePriceView EditApconApprovalTypePriceView(IList<IApconApprovalType> apconType,IApconApprovalTypePrice apconPrice)
        {
            if (apconType == null)
            {
                throw new ArgumentNullException(nameof(apconType));
            }
            
            if (apconPrice == null)
            {
                throw new ArgumentNullException(nameof(apconPrice));
            }


           
            var ApconType = GetDropDownList.ApconApprovalListItems(apconType, -1);

            var view = new ApconApprovalTypePriceView
            {
                ApconApprovalType = ApconType,
                
                Comment = apconPrice.Comment,
                Amount = apconPrice.Amount,
                DateCreated = apconPrice.DateCreated,
                DateInactive = apconPrice.DateInactive,
                IsActive = apconPrice.IsActive,
                EffectiveDate = apconPrice.EffectiveDate,
                
                ApconApprovalTypePriceId = apconPrice.ApconTypePriceId,
                ApconApprovalTypeId = apconPrice.ApconTypeId,

                ProcessingMessage = string.Empty



            };
            return view;

        }

        /// <summary>
        /// Edits the radio service price view.
        /// </summary>
        /// <param name="radioservice">The radioservice.</param>
        /// <param name="RadioStation">The radio station.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="timingBelts">The timing belts.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// radioservice
        /// or
        /// RadioStation
        /// or
        /// Timing
        /// or
        /// MaterialType
        /// </exception>
        public IRadioServicePriceList EditRadioServicePriceView(IRadioServicePriceListModel radioservice, IList<IRadioStationModel> RadioStation, 
            IList<ITiming> Timing,  IList<IMaterialType> MaterialType,IList<ITimeBelt>timingBelts)
        {
            if (radioservice == null)
            {
                throw new ArgumentNullException(nameof(radioservice));
            }

            if (RadioStation == null)
            {
                throw new ArgumentNullException(nameof(RadioStation));
            }
            if (Timing == null)
            {
                throw new ArgumentNullException(nameof(Timing));
            }
            if (MaterialType == null)
            {
                throw new ArgumentNullException(nameof(MaterialType));
            }


            var radioStation = GetDropDownList.RadioStationListItems(RadioStation, -1);
            var timing = GetDropdownTimingList.TimingListItems(Timing, -1);
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);
            var timingBelt = GetDropDownTimeBelt.TimeBeltItems(timingBelts, -1);

            var view = new RadioServicePriceListMain
            {
                RadioStationType = radioStation,
                Amount = radioservice.Amount,
                DateCreated = radioservice.DateCreated,
                DateInActive = radioservice.DateInActive,
                IsActive = radioservice.IsActive,
                DateEffective = radioservice.DateEffective,
                TimingBelt=timingBelt,
                TimingBeltId = radioservice.TimingBeltId,

                Id = radioservice.Id,
                RadioId = radioservice.RadioId,
                TimingId = radioservice.TimingId,
                MaterialTypeId = radioservice.MaterialTypeId,
                TimingType = timing,
                MaterialType = materialType,
                ProcessingMessages = string.Empty



            };
            return view;

        }


        /// <summary>
        /// Creates the delete apcon approval type price view.
        /// </summary>
        /// <param name="apconPrice">The apcon price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconPrice</exception>
        public IApconApprovalTypePriceView CreateDeleteApconApprovalTypePriceView(IApconApprovalTypePrice apconPrice)
        {
            if (apconPrice == null)
            {
                throw new ArgumentNullException(nameof(apconPrice));
            }

            var view = new ApconApprovalTypePriceView
            {

                Comment = apconPrice.Comment,
                Amount = apconPrice.Amount,
                DateCreated = apconPrice.DateCreated,

                ApconApprovalTypePriceId = apconPrice.ApconTypePriceId,
                ApconApprovalTypeId = apconPrice.ApconTypeId,
                
                EffectiveDate = apconPrice.EffectiveDate
            };
            return view;
        }

        /// <summary>
        /// Creates the delete radio service price view.
        /// </summary>
        /// <param name="radioservice">The radioservice.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioservice</exception>
        public IRadioServicePriceList CreateDeleteRadioServicePriceView(IRadioServicePriceListModel radioservice)
        {
            if (radioservice == null)
            {
                throw new ArgumentNullException(nameof(radioservice));
            }

            var view = new RadioServicePriceListMain
            {
                 
                Amount = radioservice.Amount,
                DateCreated = radioservice.DateCreated,
                DateInActive = radioservice.DateInActive,
                IsActive = radioservice.IsActive,
                DateEffective = radioservice.DateEffective,

                Id = radioservice.Id,
                RadioId = radioservice.RadioId,
                TimingId = radioservice.TimingId,
                MaterialTypeId = radioservice.MaterialTypeId,
               
                ProcessingMessages = string.Empty



            };
            return view;
        }


        /// <summary>
        /// Creates the color ListView.
        /// </summary>
        /// <param name="colorCollection">The color collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">colorCollection</exception>
        public IColorListView CreateColorListView( int selectedId, string selectedDescription,IList<IColor> colorCollection, string message)
        {
            if (colorCollection == null)
            {
                throw new ArgumentNullException(nameof(colorCollection));
            }

            // filter with colorId
            var filteredList = colorCollection.Where(x => x.ColorId.Equals(selectedId < 1 ? x.ColorId : selectedId)).ToList();

            //filter with desciprtion
            filteredList = filteredList.Where(x => x.Description.Contains(string.IsNullOrEmpty(selectedDescription) ? x.Description : selectedDescription)).ToList();

            var returnView = new ColorListView
            {
                SelectedColorId=selectedId,
                SelectedDescription=selectedDescription,
                
                ColorCollection = filteredList.ToList(),
                ProcessingMessage = message ?? ""
               

            };
            return returnView;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="materialTypeCollection"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IMaterialTypeListView CreateMaterialTypeListView(int materialTypeId, string selectedDescription,IList<IMaterialType> materialTypeCollection, string message)
        {


            // filter with companyId
            var filteredList = materialTypeCollection.Where(x => x.MaterialTypeId.Equals(materialTypeId < 1 ? x.MaterialTypeId : materialTypeId)).ToList();

           

            //filter with departmentname
            filteredList = filteredList.Where(x => x.Description.Contains(string.IsNullOrEmpty(selectedDescription) ? x.Description : selectedDescription)).ToList();


         

            var returnView = new MaterialTypeListView
            {
                SelectedDescription=selectedDescription,
                SelectedMaterialTypeId=materialTypeId,
                MaterialTypeCollection =filteredList,
                ProcessingMessage = message ?? ""
                


            };
            return returnView;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timingCollection"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ITimingListView CreateTimingListVew(int SelectedTimingId, string selectedDescription, IList<ITiming> timingCollection, string message)
        {

            // filter with timingIdId
            var filteredList = timingCollection.Where(x => x.TimingId.Equals(SelectedTimingId < 1 ? x.TimingId : SelectedTimingId)).ToList();

            
            filteredList = filteredList.Where(x => x.Description.Contains(string.IsNullOrEmpty(selectedDescription) ? x.Description : selectedDescription)).ToList();
            var returnView = new TimingListView
            {

                SelectedDescription=selectedDescription,
                SelectedTimingId=SelectedTimingId,
                TimingCollection = filteredList,
                ProcessingMessage = message ?? ""



            };
            return returnView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="durationTypeCollection"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IDurationTypeListView durationTypeListView(string selectedDurationTypeCode, string selectedDescription, IList<IDurationType> durationTypeCollection, string message)
        {
            if (durationTypeCollection == null)
            {
                throw new ArgumentNullException(nameof(durationTypeCollection));
            }

            //filter duration type code
          var  filteredList = durationTypeCollection.Where(x => x.DurationTypeCode.Contains(string.IsNullOrEmpty(selectedDurationTypeCode) ? x.DurationTypeCode : selectedDurationTypeCode)).ToList();

            //filter with duratintypename
            filteredList = filteredList.Where(x => x.Description.Contains(string.IsNullOrEmpty(selectedDescription) ? x.Description : selectedDescription)).ToList();
            var returnView = new DurationTypeListView
            {

                SelectedDescription=selectedDescription,
                SelectedDurationTypeId=selectedDurationTypeCode,
                DurationTypeCollection = filteredList,
                ProcessingMessage = message ?? ""

            };
            return returnView;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="designElementlCollection"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IDesignElementListView CreateDesignElementListView(int selectedDesignElementId, string selectedDescription, IList<IDesignElement> designElementlCollection, string message)
        {
            if (designElementlCollection == null)
            {
                throw new ArgumentNullException(nameof(designElementlCollection));
            }

            var filteredList = designElementlCollection.Where(x => x.DesignElementId.Equals(selectedDesignElementId < 1 ? x.DesignElementId : selectedDesignElementId)).ToList();

            filteredList = filteredList.Where(x => x.Description.Contains(string.IsNullOrEmpty(selectedDescription) ? x.Description : selectedDescription)).ToList();


            var returnView = new DesignElementListView
            {
                SelectedDesignElementId = selectedDesignElementId,
                SelectedDescription = selectedDescription,
                DesignElementCollection = filteredList.ToList(),
                ProcessingMessage = message
            };

            return returnView;
        }


        /// <summary>
        /// Creates the time belt view.
        /// </summary>
        /// <returns></returns>
        public ITimeBeltView CreateTimeBeltView()
        {
            var view = new TimeBeltView
            {
                ProcesingMessage = string.Empty
            };
            return view;
        }



        /// <summary>
        /// Creates the color view.
        /// </summary>
        /// <returns></returns>
        public IColorView CreateColorView()
        {
            var view = new ColorView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }


        /// <summary>
        /// Gets the edit apcon view.
        /// </summary>
        /// <param name="apconview">The apconview.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconview</exception>
        public IApconApprovalView GetEditApconView(IApconApprovalType apconview, string message)
        {
            if (apconview == null) throw new ArgumentNullException(nameof(apconview));
            var view = new ApconApprovalView
            {
                ProcessingMessage = "",
                Description = apconview.Description,
                ApconApprovalTypeId = apconview.ApoconTypeId

            };

            return view;
        }



        /// <summary>
        /// Gets the edit time belt view.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timeBeltView</exception>
        public ITimeBeltView GetEditTimeBeltView(ITimeBelt timeBeltView, string message)
        {
            if (timeBeltView == null) throw new ArgumentNullException(nameof(timeBeltView));
            var view = new TimeBeltView
            {
              ProcesingMessage = "",
                Description = timeBeltView.Description,
                TimeBeltId =timeBeltView.TimeBeltId,
                name=timeBeltView.name


            };

            return view;
        }







        /// <summary>
        /// Creates the duration type view.
        /// </summary>
        /// <returns></returns>
        public IDurationTypeView CreateDurationTypeView()
        {
            var view = new DurationTypeView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMaterialTypeView CreateMaterialTypeView()
        {
            var view = new MaterialTypeView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ITimingView CreateTimingView()
        {
            var view = new TimingView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="colorView"></param>
        /// <returns></returns>
        public IColorView CreateColorView(IColor colorView)
        {
            if (colorView == null) throw new ArgumentNullException(nameof(colorView));
            var view = new ColorView
            {
                ProcessingMessage = "",
                Description = colorView.Description,
                ColorId = colorView.ColorId

            };

            return view;
        }





        /// <summary>
        /// Creates the time belt view.
        /// </summary>
        /// <param name="timeBelt">The time belt.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timeBelt</exception>
        public ITimeBeltView CreateTimeBeltView(ITimeBelt timeBelt)
        {
            if (timeBelt == null) throw new ArgumentNullException(nameof(timeBelt));
            var view = new TimeBeltView
            {
              ProcesingMessage="",
              Description=timeBelt.Description,
              isActive=timeBelt.isActive,
              name=timeBelt.name,
              TimeBeltId=timeBelt.TimeBeltId

            };

            return view;
        }



        /// <summary>
        /// Gets the edit timing view.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timingView</exception>
        public ITimingView GetEditTimingView(ITiming timingView)
        {
            if (timingView == null) throw new ArgumentNullException(nameof(timingView));
            var view = new TimingView
            {
                ProcessingMessage = "",
                Description = timingView.Description,
                TimingId = timingView.TimingId
            };
            return view;
        }


        /// <summary>
        /// Gets the edit material type view.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">materialTypeView</exception>
        public IMaterialTypeView GetEditMaterialTypeView(IMaterialType materialTypeView)
        {
            if (materialTypeView == null) throw new ArgumentNullException(nameof(materialTypeView));
            var view = new MaterialTypeView
            {
                ProcessingMessage = "",
                Description = materialTypeView.Description,
                MaterialTypeId = materialTypeView.MaterialTypeId

            };

            return view;
        }

        /// <summary>
        /// Gets the edit duration type view.
        /// </summary>
        /// <param name="durationTypeView"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">durationTypeView</exception>
        public IDurationTypeView CreateDurationTypeView(IDurationType durationTypeView)
        {
            if (durationTypeView == null) throw new ArgumentNullException(nameof(durationTypeView));
            var view = new DurationTypeView
            {
                ProcessingMessage = "",
                Description = durationTypeView.Description,
                DurationTypeCode = durationTypeView.DurationTypeCode

            };

            return view;
        }




        /// <summary>
        /// Creates the design element price view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="DesignElement">The design element.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ServiceType
        /// or
        /// MaterialType
        /// </exception>
        public IDesignElementPriceView CreateDesignElementPriceView(IList<IServiceType> ServiceType, IList<IDesignElement> DesignElement)
        {
            if (ServiceType == null)
            {
                throw new ArgumentNullException("ServiceType");
            }

            if (DesignElement == null)
            {
                throw new ArgumentNullException("MaterialType");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var designElement = GetDropDownDesignElementList.DesignElementListItems(DesignElement, -1);

            var view = new DesignElementPriceView
            {
                ProcessingMessage = string.Empty,
                ServiceType = serviceType,
                DesignElementType = designElement
            };
            return view;
        }


        /// <summary>
        /// Creates the updated branding material ListView.
        /// </summary>
        /// <param name="designelementInfo">The designelement information.</param>
        /// <param name="ProcessingMessages">The processing messages.</param>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="DesignElement">The design element.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// designelementInfo
        /// or
        /// DesignElement
        /// or
        /// ServiceType
        /// </exception>
        public IDesignElementPriceView CreateDesignElementPriceView(IDesignElementPriceView designelementInfo, string ProcessingMessages,
           IList<IServiceType> ServiceType, IList<IDesignElement> DesignElement)
        {
            if (designelementInfo == null)
            {
                throw new ArgumentNullException(nameof(designelementInfo));
            }
            if (DesignElement == null)
            {
                throw new ArgumentNullException(nameof(DesignElement));
            }
            if (ServiceType == null)
            {
                throw new ArgumentNullException(nameof(ServiceType));
            }

           
            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, designelementInfo.ServiceTypeCode);
            var designElement = GetDropDownDesignElementList.DesignElementListItems(DesignElement, designelementInfo.DesignElementId);

                
            designelementInfo.DesignElementType = designElement;
            designelementInfo.ServiceType = serviceType;
            designelementInfo.ProcessingMessage = ProcessingMessages??"";

            return designelementInfo;
        }



        /// <summary>
        /// Creates the design element price ListView.
        /// </summary>
        /// <param name="designelement">The designelement.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designelement</exception>
        public IDesignElementPriceListView CreateDesignElementPriceListView(IList<IDesignElementPrice> designelement, string message, int SelectedDesignElementPriceId, string SelectedServiceTypeCode, string SelectedDescription)
        {
            if (designelement == null)
            {
                throw new ArgumentNullException(nameof(designelement));
            }


            // filter with desgnElementPriceId
            var filteredList = designelement.Where(x => x.DesignElementPriceId.Equals(SelectedDesignElementPriceId < 1 ? x.DesignElementPriceId : SelectedDesignElementPriceId)).ToList();

            //filter with servicetypecode
            filteredList = filteredList.Where(x => x.Description.Contains(string.IsNullOrEmpty(SelectedDescription) ? x.Description : SelectedDescription)).ToList();

            var returnView = new DesignElementPriceListView
            {
                SelectedDescription=SelectedDescription,
                SelectedServiceTypeCode=SelectedServiceTypeCode,
                SelectedDesignElementPriceId=SelectedDesignElementPriceId,
                
                DesignElementPriceCollection = filteredList,
                ProcessingMessage = message ?? ""
                

            };
            return returnView;

        }


        /// <summary>
        /// Gets the contact view.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">contacts</exception>
        public IContactView GetContactView(IList<IContact>contacts)
        {
            if(contacts==null)
            {
                throw new ArgumentNullException(nameof(contacts));
            }
            var contactDDL = GetDropDownList.ContactListItems(contacts, -1);
            var view = new ContactView
            {
                contactList=contactDDL,
               
            };
            return view;
        }

        /// <summary>
        /// Creates the scripting ListView.
        /// </summary>
        /// <param name="material">The material.</param>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// service
        /// or
        /// material
        /// </exception>
        public IMaterialScriptingPriceView CreateScriptingListView(IList<IMaterialType> material, IList<IServiceType> service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }

            if (material == null)
            {
                throw new ArgumentNullException("material");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(service, "");
            var MaterialType = GetDropdownMaterialTypeList.MaterialTypeListItems(material, -1);

            var view = new MaterialScriptingPriceView
            {
                ProcessingMessage = string.Empty,
                ServiceType = serviceType,
                MaterialType = MaterialType
                
            };
            return view;

        }

        /// <summary>
        /// Creates the production ListView.
        /// </summary>
        /// <param name="material">The material.</param>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// service
        /// or
        /// material
        /// </exception>
        public IMaterialProductionPriceView CreateProductionListView(IList<IMaterialType> material, IList<IServiceType> service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }

            if (material == null)
            {
                throw new ArgumentNullException("material");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(service, "");
            var MaterialType = GetDropdownMaterialTypeList.MaterialTypeListItems(material, -1);

            var view = new MaterialProductionPriceView
            {
                ProcessingMessage = string.Empty,
                ServiceType = serviceType,
                MaterialType = MaterialType
            };
            return view;

        }

        /// <summary>
        /// Creates the delete material production price view.
        /// </summary>
        /// <param name="productionPrice">The production price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">productionPrice</exception>
        public IMaterialProductionPriceView CreateDeleteMaterialProductionPriceView(IMaterialProductionPrice productionPrice)
        {
            if (productionPrice == null)
            {
                throw new ArgumentNullException(nameof(productionPrice));
            }

            var view = new MaterialProductionPriceView
            {
                
                Comment = productionPrice.Comment,
                Amount = productionPrice.Amount,
                DateCreated = productionPrice.DateCreated,

                MaterialProductionPriceId = productionPrice.MaterialProductionPriceId,
                MaterialTypeId = productionPrice.MaterialTypeId,
                
                ServiceTypeCode = productionPrice.ServiceTypeCode,
                EffectiveDate = productionPrice.EffectiveDate
            };
            return view;
        }

        /// <summary>
        /// Creates the delete material scripting price view.
        /// </summary>
        /// <param name="scriptingPrice">The scripting price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">scriptingPrice</exception>
        public IMaterialScriptingPriceView CreateDeleteMaterialScriptingPriceView(IMaterialScriptingPrice scriptingPrice)
        {
            if (scriptingPrice == null)
            {
                throw new ArgumentNullException(nameof(scriptingPrice));
            }

            var view = new MaterialScriptingPriceView
            {

                Comment = scriptingPrice.Comment,
                Amount = scriptingPrice.Amount,
                DateCreated = scriptingPrice.DateCreated,

                MaterialScriptingPriceId = scriptingPrice.MaterialScriptingPriceId,
                MaterialTypeId = scriptingPrice.MaterialTypeId,
                
                ServiceTypeCode = scriptingPrice.ServiceTypeCode,
                EffectiveDate = scriptingPrice.EffectiveDate
            };
            return view;
        }


        /// <summary>
        /// Edits the design element price view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="designElementPrice">The design element price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// serviceType
        /// or
        /// designElement
        /// or
        /// designElementPrice
        /// </exception>
        public IDesignElementPriceView EditDesignElementPriceView(IList<IServiceType> serviceType, IList<IDesignElement> designElement, IDesignElementPrice designElementPrice)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (designElement == null)
            {
                throw new ArgumentNullException(nameof(designElement));
            }
            if (designElementPrice == null)
            {
                throw new ArgumentNullException(nameof(designElementPrice));
            }


            var ServiceTypeDDL = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, "");
            var DesignElementDDL = GetDropDownDesignElementList.DesignElementListItems(designElement, -1);

            var view = new DesignElementPriceView
            {
                DesignElementType = DesignElementDDL,
                ServiceType = ServiceTypeDDL,
                Comment = designElementPrice.Comment,
                Amount = designElementPrice.Amount,
                DateCreated = designElementPrice.DateCreated,
                DateInactive = designElementPrice.DateInactive,
                IsActive = designElementPrice.IsActive,
                EffectiveDate = designElementPrice.EffectiveDate,
                ServiceTypeCode = designElementPrice.ServiceTypeCode,
                DesignElementPriceId = designElementPrice.DesignElementPriceId,
                DesignElementId = designElementPrice.DesignElementId,
                ProcessingMessage = string.Empty

            };
            return view;

        }



        /// <summary>
        /// Creates the delete design element price view.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementPriceView</exception>
        public IDesignElementPriceView CreateDeleteDesignElementPriceView(IDesignElementPrice designElementPriceView)
        {
            if (designElementPriceView == null)
            {
                throw new ArgumentNullException(nameof(designElementPriceView));
            }

            
            var view = new DesignElementPriceView
            {
                DesignElementPriceId = designElementPriceView.DesignElementPriceId,
                Comment = designElementPriceView.Comment,
                Amount = designElementPriceView.Amount,
                DateCreated = designElementPriceView.DateCreated,

            };
            return view;
        }

        /// <summary>
        /// Creates the design element view.
        /// </summary>
        /// <returns></returns>
        public IDesignElementView CreateDesignElementView()
            {
                var returnView = new DesignElementView
                {
                };
                return returnView;
            }
        /// <summary>
        /// Creates the design element view.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementInfo</exception>
        public IDesignElementView CreateDesignElementView(IDesignElementView designElementInfo, string processingMessage)
            {
                if (designElementInfo == null)
                {
                    throw new ArgumentNullException(nameof(designElementInfo));
                }

                var returnView = new DesignElementView
                {
                    Description = designElementInfo.Description,
                   
                    ProcessingMessage = designElementInfo.ProcessingMessage ?? ""
                };
                return returnView;
            }
        /// <summary>
        /// Creates the edit design element view.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        public IDesignElementView CreateEditDesignElementView(IDesignElementView designElementView, string description)
            {
                var returnView = new DesignElementView
                {
                    Description = description,
                    DesignElementId = designElementView.DesignElementId,
                    IsActive = designElementView.IsActive
                };

                return returnView;

            }

            public INewsPaperView CreateAddNewsPaperView()
            {
                var returnView = new NewsPaperView
                {


                };

                return returnView;
            }



        /// <summary>
        /// Creates the material type timing list vew.
        /// </summary>
        /// <param name="timingCollection">The timing collection.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedMaterialTypeTimingId">The selected material type timing identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedMaterialTypeId">The selected material type identifier.</param>
        /// <returns></returns>
        public IMaterialTypeTimingListView CreateMaterialTypeTimingListVew(IList<IMaterialTypeTimingDetail> timingCollection, string message,
            int selectedMaterialTypeTimingId, int selectedTimingId, string selectedDescription)
        {
            //Search by Mateial Type Timing Id
            var filteredList = timingCollection.Where(x => x.MaterialTypeTimingId.Equals(selectedMaterialTypeTimingId < 1 ? x.MaterialTypeTimingId : selectedMaterialTypeTimingId)).ToList();

            // search by Material Id
            filteredList = filteredList.Where(x => x.MaterialDescription.Contains(string.IsNullOrEmpty(selectedDescription)
                           ? x.MaterialDescription
                           : selectedDescription))
                       .ToList();

            //Search by Timing Id
            filteredList = filteredList.Where(x => x.TimingId.Equals(selectedTimingId < 1 ? x.TimingId : selectedTimingId)).ToList();

            var returnView = new MaterialTypeTimingListView
            {
                MaterialTypeTimingCollection = filteredList,
                SelectedMaterialTypeTimingId = selectedMaterialTypeTimingId,
                selectedDescription = selectedDescription,
                SelectedTimingId = selectedTimingId,
                ProcessingMessages = message

            };
            return returnView;
        }
        /// <summary>
        /// Creates the material type timing view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="TimingType">Type of the timing.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ServiceType
        /// or
        /// MaterialType
        /// or
        /// TimingType
        /// </exception>
        public IMaterialTypeTimingView CreateMaterialTypeTimingView(IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType, IList<ITiming> TimingType)
        {
            if (ServiceType == null)
            {
                throw new ArgumentNullException("ServiceType");
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }

            if (TimingType == null)
            {
                throw new ArgumentNullException("TimingType");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);
            var timingType = GetDropdownTimingList.TimingListItems(TimingType, -1);

            var view = new MaterialTypeTimingView
            {

                ProcessingMessage = string.Empty,
                ServiceType = serviceType,
                MaterialType = materialType,
                TimingType = timingType
            };
            return view;
        }

        /// <summary>
        /// Creates the material type timing view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="TimingType">Type of the timing.</param>
        /// <param name="materialView">The material view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// materialView
        /// or
        /// ServiceType
        /// or
        /// MaterialType
        /// or
        /// TimingType
        /// </exception>
        public IMaterialTypeTimingView CreateMaterialTypeTimingView(IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType, IList<ITiming> TimingType, IMaterialTypeTimingView materialView, string message )
        {

            if (materialView == null)
            {
                throw new ArgumentNullException("materialView");
            }
            if (ServiceType == null)
            {
                throw new ArgumentNullException("ServiceType");
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }

            if (TimingType == null)
            {
                throw new ArgumentNullException("TimingType");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);
            var timingType = GetDropdownTimingList.TimingListItems(TimingType, -1);


            materialView.ProcessingMessage = string.Empty;
            materialView.ServiceType = serviceType;
            materialView.MaterialType = materialType;
            materialView.TimingType = timingType;
           
            return materialView;
        }

        /// <summary>
        /// Creates the updated material type timing view.
        /// </summary>
        /// <param name="timingInfo">The timing information.</param>
        /// <param name="ProcessingMessages">The processing messages.</param>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="TimingType">Type of the timing.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// timingInfo
        /// or
        /// MaterialType
        /// or
        /// ServiceType
        /// or
        /// TimingType
        /// </exception>
        public IMaterialTypeTimingView CreateUpdatedMaterialTypeTimingView(IMaterialTypeTimingView timingInfo, string ProcessingMessages,
            IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType, IList<ITiming> TimingType)
        {
            if (timingInfo == null)
            {
                throw new ArgumentNullException(nameof(timingInfo));
            }
            if (MaterialType == null)
            {
                throw new ArgumentNullException(nameof(MaterialType));
            }
            if (ServiceType == null)
            {
                throw new ArgumentNullException(nameof(ServiceType));
            }
            if (TimingType == null)
            {
                throw new ArgumentNullException(nameof(TimingType));
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);
            var timingType = GetDropdownTimingList.TimingListItems(TimingType, -1);

            timingInfo.MaterialType = materialType;
            timingInfo.ServiceType = serviceType;
            timingInfo.TimingType = timingType;
            timingInfo.ProcessingMessage = ProcessingMessages;

           


            
            return timingInfo;
        }
        /// <summary>
        /// Creates the updated apcon view.
        /// </summary>
        /// <param name="apconView">The apcon view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconView</exception>
        public IApconApprovalView CreateUpdatedApconView(IApconApprovalView apconView, string processingMessage)
        {
            if (apconView == null)
            {
                throw new ArgumentNullException(nameof(apconView));
            }
           
           
           
            apconView.ProcessingMessage = processingMessage;

            return apconView;
        }

        /// <summary>
        /// Edits the material type timing view.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="MaterialTypeTiming">The material type timing.</param>
        /// <param name="Timing">The timing.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// serviceType
        /// or
        /// MaterialType
        /// or
        /// Timing
        /// or
        /// MaterialTypeTiming
        /// </exception>
        public IMaterialTypeTimingView EditMaterialTypeTimingView(IList<IServiceType> serviceType, IList<IMaterialType> MaterialType, IMaterialTypeTimingModel MaterialTypeTiming, IList<ITiming> Timing, string message)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException(nameof(MaterialType));
            }
            if (Timing == null)
            {
                throw new ArgumentNullException(nameof(Timing));
            }
            if (MaterialTypeTiming == null)
            {
                throw new ArgumentNullException(nameof(MaterialTypeTiming));
            }


            var ServiceTypeDDL = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, "");
            var timing = GetDropdownTimingList.TimingListItems(Timing, -1);
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);
            var view = new MaterialTypeTimingView
            {
                MaterialTypeTimingId = MaterialTypeTiming.MaterialTypeTimingId,
                MaterialTypeId = MaterialTypeTiming.MaterialTypeId,
                TimingId = MaterialTypeTiming.TimingId,
                TimingType = timing,
                MaterialType = materialType,

                ServiceType = ServiceTypeDDL,
                
                IsActive = MaterialTypeTiming.IsActive,
               
                ServiceTypeCode = MaterialTypeTiming.ServiceTypeCode,
                
                ProcessingMessage = message

            };
            return view;

        }
        /// <summary>
        /// Creates the edit material type timing view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <param name="Timing">The timing.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ServiceType
        /// or
        /// MaterialType
        /// or
        /// Timing
        /// </exception>
        public IMaterialTypeTimingView CreateEditMaterialTypeTimingView(IList<IServiceType> ServiceType, IList<IMaterialType> MaterialType, IList<ITiming> Timing)
        {
            if (ServiceType == null)
            {
                throw new ArgumentNullException("ServiceType");
            }

            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }

            if (Timing == null)
            {
                throw new ArgumentNullException("Timing");
            }

            var serviceType = GetDropDownServiceTypeList.ServiceTypeListItems(ServiceType, "");
            var materialType = GetDropdownMaterialTypeList.MaterialTypeListItems(MaterialType, -1);
            var timing = GetDropdownTimingList.TimingListItems(Timing, -1);



            var view = new MaterialTypeTimingView
            {
                ProcessingMessage = string.Empty,
                ServiceType = serviceType,
                MaterialType = materialType,
                TimingType = timing
            };
            return view;
        }
        /// <summary>
        /// Creates the delete material type timing view.
        /// </summary>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">MaterialType</exception>
        public IMaterialTypeTimingView CreateDeleteMaterialTypeTimingView(IMaterialTypeTimingModel MaterialType)
        {
            if (MaterialType == null)
            {
                throw new ArgumentNullException(nameof(MaterialType));
            }

            var view = new MaterialTypeTimingView
            {
                MaterialTypeTimingId = MaterialType.MaterialTypeTimingId,
                MaterialTypeId = MaterialType.MaterialTypeId,
                TimingId = MaterialType.TimingId,
                ServiceTypeCode = MaterialType.ServiceTypeCode
            };
            return view;
        }

        /// <summary>
        /// Creates the color view.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">colorView</exception>
        public IColorView CreateColorView(IColorView colorView, string processingMessage)
        {
            if(colorView==null)
            {
                throw new ArgumentException("colorView");
            }


            colorView.ProcessingMessage = processingMessage;
            return colorView;
        }

        /// <summary>
        /// Creates the timing view.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">timingView</exception>
        public ITimingView CreateTimingView(ITimingView timingView, string processingMessage)
        {
            if (timingView == null)
            {
                throw new ArgumentException("timingView");
            }


           timingView.ProcessingMessage = processingMessage;
            return timingView;
        }
        /// <summary>
        /// Creates the duration type view.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">durationTypeView</exception>
        public IDurationTypeView CreateDurationTypeView(IDurationTypeView durationTypeView, string processingMessage)
        {
            if (durationTypeView == null)
            {
                throw new ArgumentException("durationTypeView");
            }


            durationTypeView.ProcessingMessage = processingMessage;
            return durationTypeView;
        }
        /// <summary>
        /// Creates the material type view.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">materialTypeView</exception>
        public IMaterialTypeView CreateMaterialTypeView(IMaterialTypeView materialTypeView, string processingMessage)
        {
            if (materialTypeView == null)
            {
                throw new ArgumentException("materialTypeView");
            }


            materialTypeView.ProcessingMessage = processingMessage;
            return materialTypeView;
        }

        /// <summary>
        /// Creates the delete design element price view.
        /// </summary>
        /// <param name="designElementPrice">The design element price.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// designElementPrice
        /// or
        /// designElement
        /// or
        /// serviceType
        /// </exception>
        public IDesignElementPriceView CreateDeleteDesignElementPriceView(IDesignElementPrice designElementPrice, IList<IDesignElement> designElement, IList<IServiceType> serviceType)
        {
           if(designElementPrice==null)
            {
                throw new ArgumentException("designElementPrice");
            }
            if (designElement == null)
            {
                throw new ArgumentException("designElement");
            }

            if (serviceType == null)
            {
                throw new ArgumentException("serviceType");
            }

            var serviceTypeDDL = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, designElementPrice.ServiceTypeCode);
            var designElementDDL = GetDropDownDesignElementList.DesignElementListItems(designElement, designElementPrice.DesignElementId);
            var view = new DesignElementPriceView
            {
                ServiceType = serviceTypeDDL,
                DesignElementType = designElementDDL,
                Comment = designElementPrice.Comment,
                Amount = designElementPrice.Amount,
                DateCreated = designElementPrice.DateCreated,
                DateInactive = designElementPrice.DateInactive,
                DesignElementId = designElementPrice.DesignElementId,
                DesignElementPriceId = designElementPrice.DesignElementPriceId,
                EffectiveDate = designElementPrice.EffectiveDate,
                IsActive = designElementPrice.IsActive,
                ProcessingMessage = string.Empty,
                ServiceTypeCode=designElementPrice.ServiceTypeCode
            

            };
            return view;

        }

        public IRadioMainView GetMaterialScripting(IMaterialScriptingPrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            var view = new RadioMainView
            {
                ScriptingAmount = price.Amount
            };
            return view;
        }


        /// <summary>
        /// Creates the updated design element price view.
        /// </summary>
        /// <param name="designElementPrice">The design element price.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementPrice</exception>
        public IDesignElementPriceView CreateUpdatedDesignElementPriceView(IDesignElementPriceView designElementPrice, IList<IDesignElement> designElement, IList<IServiceType> serviceType)
        {
            if(designElementPrice==null)
            {
                throw new ArgumentNullException(nameof(designElementPrice));


            }
            var designelement = GetDropDownDesignElementList.DesignElementListItems(designElement, designElementPrice.DesignElementId);
            var servicetype = GetDropDownServiceTypeList.ServiceTypeListItems(serviceType, designElementPrice.ServiceTypeCode);

            designElementPrice.DesignElementType = designelement;
            designElementPrice.ServiceType = servicetype;
            return designElementPrice;
        }



        /// <summary>
        /// Creates the tv transaction view model.
        /// </summary>
        /// <param name="TvTransaction">The tv transaction.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedTvTransactionId">The selected tv transaction identifier.</param>
        /// <param name="selectedUserId">The selected user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TvTransaction</exception>
        public ITvTransactionListView CreateTvTransactionViewModel(IList<ITvTransaction> TvTransaction, string message,
        int selectedTvTransactionId, int selectedUserId,IList<IMessage>messagesList,IList<IReplies>replies)
        {
            if (TvTransaction == null)
            {
                throw new ArgumentNullException(nameof(TvTransaction));
            }

            //Filter by Price Id
            var filteredList = TvTransaction.Where(x => x.TVTransactionId.Equals(selectedTvTransactionId < 1 ? x.TVTransactionId : selectedTvTransactionId)).ToList();
            //Filter by Price Id
            filteredList = filteredList.Where(x => x.UserId.Equals(selectedUserId < 1 ? x.UserId : selectedUserId)).ToList();


            var returnView = new TvTransactionListView
            {

                TvCollection = filteredList.ToList(),
                selectedTvTransactionId = selectedTvTransactionId,
                repliesLists = replies,
                selectedUserId = selectedUserId,
                 messagesLists=messagesList,
                ProcessingMessage = message
            };

            return returnView;
        }

        /// <summary>
        /// Creates the tv transaction view.
        /// </summary>
        /// <param name="tvMaterialTransaction">The tv material transaction.</param>
        /// <param name="tvTransaction">The tv transaction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">tvService</exception>
        public ITvTransactionView GetTvMaterialTransactionListView(IList<ITvMaterialTransactionModel> tvMaterialTransaction, ITvTransaction tvTransaction,
             IDigitalFile digitalFile, int? Id, int RepliesId)
        {
            if (tvMaterialTransaction == null)
            {
                throw new ArgumentNullException(nameof(tvMaterialTransaction));
            }

            if (tvTransaction == null)
            {
                throw new ArgumentNullException(nameof(tvTransaction));
            }

            var radioList = new TvTransactionView
            {
                Details = tvTransaction.AiringInstruction,
                Name = tvTransaction.UserName,
                OrderTitle = tvTransaction.OrderTitle,
                tvMaterialTransaction = tvMaterialTransaction,
                UserId = tvTransaction.UserId,
                TVTransactionId = tvTransaction.TVTransactionId,
                digitalMaterialFileId = tvTransaction.ProductionDigitalFileId,
                UploadedMaterialDetail = tvTransaction.DigitalFile,


                MessageId = Id,
                RepliesId = RepliesId,

            };

            return radioList;
        }

        /// <summary>
        /// Gets the tv scripting view.
        /// </summary>
        /// <param name="tvScriptingTransaction">The tv scripting transaction.</param>
        /// <param name="tvTransaction">The tv transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// tvScriptingTransaction
        /// or
        /// tvTransaction
        /// </exception>
        public ITvTransactionView GetTvScriptingView(IList<ITvScriptingTransactionModelView> tvScriptingTransaction, ITvTransaction tvTransaction,
             IDigitalFile digitalFile, int? Id, int RepliesId)
        { 
            if (tvScriptingTransaction == null)
            {
                throw new ArgumentNullException(nameof(tvScriptingTransaction));
            }

            if (tvTransaction == null)
            {
                throw new ArgumentNullException(nameof(tvTransaction));
            }

            var radioList = new TvTransactionView
            {
                Details = tvTransaction.AiringInstruction,
                Name = tvTransaction.UserName,
                OrderTitle = tvTransaction.OrderTitle,
                tvScriptTransaction = tvScriptingTransaction,
                UserId = tvTransaction.UserId,
                TVTransactionId = tvTransaction.TVTransactionId,
                digitalScriptFileId  = tvTransaction.ProductionDigitalFileId,
                 UploadedScriptDetail = tvTransaction.DigitalFile,


                MessageId = Id,
                RepliesId = RepliesId,

                
            };

            return radioList;
        }


        /// <summary>
        /// Creates the print transaction view model.
        /// </summary>
        /// <param name="PrintTransaction">The print transaction.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedPrintTransactionId">The selected print transaction identifier.</param>
        /// <param name="selectedUserId">The selected user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">PrintTransaction</exception>
        public IPrintTransactionListView CreatePrintTransactionViewModel(IList<IPrintTransaction> PrintTransaction, string message,
        int selectedPrintTransactionId, int selectedUserId,IList<IMessage>messagesList,IList<IReplies>repliesList)
        {
            if (PrintTransaction == null)
            {
                throw new ArgumentNullException(nameof(PrintTransaction));
            }

            //Filter by Price Id
            var filteredList = PrintTransaction.Where(x => x.PrintTransactionId.Equals(selectedPrintTransactionId < 1 ? x.PrintTransactionId : selectedPrintTransactionId)).ToList();
           
            //Filter by Price Id
            filteredList = filteredList.Where(x => x.UserId.Equals(selectedUserId < 1 ? x.UserId : selectedUserId)).ToList();


            var returnView = new PrintTransactionListView
            {

                PrintCollection = filteredList.ToList(),
                selectedPrintTransactionId = selectedPrintTransactionId,
                selectedUserId = selectedUserId,
                repliesLists=repliesList,
                messagesLists=messagesList,
                ProcessingMessage = message
            };

            return returnView;
        }



        /// <summary>
        /// Gets the print scripting view.
        /// </summary>
        /// <param name="tvScriptingTransaction">The tv scripting transaction.</param>
        /// <param name="tvTransaction">The tv transaction.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="Id">The identifier.</param>
        /// <param name="RepliesId">The replies identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// tvScriptingTransaction
        /// or
        /// tvTransaction
        /// </exception>
        public IPrintTransactionView GetPrintScriptingView(IList<IPrintScriptingTransactionModel> printScriptingTransaction, IPrintTransaction printTransaction,
             IDigitalFile digitalFile, int? Id, int RepliesId)
        {
            if (printScriptingTransaction == null)
            {
                throw new ArgumentNullException(nameof(printScriptingTransaction));
            }

            if (printTransaction == null)
            {
                throw new ArgumentNullException(nameof(printTransaction));
            }

            var radioList = new PrintTransactionView
            {
                Details = printTransaction.AiringInstruction,
                Name = printTransaction.UserName,
                OrderTitle = printTransaction.OrderTitle,
                tvScriptTransaction = printScriptingTransaction,
                SentToId = printTransaction.UserId,
                PrintTransactionId = printTransaction.PrintTransactionId,
                digitalScriptFileId = printTransaction.MaterialDigitalFileId,
                UploadedScriptDetail = printTransaction.DigitalFile,
               

                MessageId = Id??0,
                RepliesId = RepliesId,


            };

            return radioList;
        }

        /// <summary>
        /// Gets the tv message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">message</exception>
        public IMessageRepliesListView GetTvMessageRepliesListView(IList<IReplies> replies,
            IMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");

            }

            var view = new MessageRepliesListView
            {
                InitialMessage = message.Message,
                MessageId = message.Id,
                //SentTo = message.SentToId,
                transactionId = message.TransactionId,

                Replies = replies,
                IsApproved= message.IsApproved

            };
            return view;
        }

        /// <summary>
        /// Gets the print message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">message</exception>
        public IMessageRepliesListView GetPrintMessageRepliesListView(IList<IReplies> replies,
            IMessage message,int transactionId,int SentoId,int OrderId)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");

            }

            var view = new MessageRepliesListView
            {
                InitialMessage = message.Message,
                MessageId = message.Id,
                UserId = message.UserId,
                transactionId = transactionId,

                Replies = replies,
                IsApproved=message.IsApproved,
                SentToId=SentoId,
                DigitalFileId=message.DigitalFileId,
                OrderId=OrderId,
                
            };
            return view;
        }

        /// <summary>
        /// Gets the time belt ListView.
        /// </summary>
        /// <param name="timeBelts">The time belts.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        public ITimeBeltListView GetTimeBeltListView(IList<ITimeBelt>timeBelts, string selectedDescription)
        {
            var filteredList = timeBelts.Where(x => x.name.Contains(string.IsNullOrEmpty(selectedDescription)
                ? x.name
                : selectedDescription))
            .ToList();


            var view = new TimeBeltListView
            {
                GetTimeBeltsList = filteredList
            };

            return view;
        }
    }
}

