using ADit.Domain.Resources;
using ADit.Interfaces;
using System;

namespace ADit.Domain.Services
{
   
    public class GeneralService : IGeneralService
    {
      
        private readonly IGeneralRepository generalRepository;
        
        private readonly IGeneralFactory generalFactory;
      
        private readonly ILookupRepository lookupRepository;
       
        public GeneralService(IGeneralRepository generalRepository, IGeneralFactory generalFactory, ILookupRepository lookupRepository)
        {
            this.generalFactory = generalFactory;
            this.generalRepository = generalRepository;
            this.lookupRepository = lookupRepository;
        }



        /// <summary>
        /// Gets the delete design element.
        /// </summary>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        public string GetDeleteDesignElement(int designElementId)
        {
            var returnMessage = this.generalRepository.DeleteDesignElementDescription(designElementId);

            return returnMessage;
        }


        /// <summary>
        /// Gets the edit design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <returns></returns>
        public string  GetEditDesignElement(IDesignElementView designElementView)
        {

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //check if description is already in database
            var valueData = this.lookupRepository.GetDesignDescriptionByValue(designElementView.Description);
            var isRecordExist = (valueData == null) ? false : true;

            if (isRecordExist)
            {
                isDataOkay = false;
                processingMessage = Messages.DesignExist;
                return processingMessage;
            }



            var returnView = this.generalRepository.EditDesignElementDescription(designElementView);
            return returnView;
        }

        /// <summary>
        /// Processes the apcon approval type price view.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">apconInfo</exception>
        public string ProcessApconApprovalTypePriceView(IApconApprovalTypePriceView apconInfo)
        {
            if (apconInfo == null)
            {
                throw new System.ArgumentNullException(nameof(apconInfo));
            }
           
            var processingmessage = this.generalRepository.SaveApconPrice(apconInfo);

            return processingmessage;
        }



        /// <summary>
        /// Processes the radio service price view.
        /// </summary>
        /// <param name="radioService">The radio service.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">radioService</exception>
        public string ProcessRadioServicePriceView(IRadioServicePriceList radioService)
        {
            if (radioService == null)
            {
                throw new System.ArgumentNullException(nameof(radioService));
            }

            var processingmessage = this.generalRepository.SaveRadioServicePrice(radioService);

            return processingmessage;
        }

        /// <summary>
        /// Checks the radio service.
        /// </summary>
        /// <param name="radioServicePriceList">The radio service price list.</param>
        /// <returns></returns>
        public bool CheckRadioService(IRadioServicePriceList radioServicePriceList)
        {
            return this.generalRepository.CheckRadioServiceprice(radioServicePriceList);
        }

        /// <summary>
        /// Gets the design element view model.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">designElementInfo</exception>
        public string GetDesignElementViewModel(IDesignElementView designElementInfo)
        {
            //Check if the User Input is Null
            if (designElementInfo == null) throw new ArgumentNullException(nameof(designElementInfo));

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //check if description is already in database
            var valueData = this.lookupRepository.GetDesignDescriptionByValue(designElementInfo.Description);
            var isRecordExist = (valueData == null) ? false : true;

            if (isRecordExist)
            {
                isDataOkay = false;
                processingMessage = Messages.DesignExist;
                return processingMessage;
            }


            //Generate the Return View

            var  returnView= this.generalRepository.SaveAddDesignElement(designElementInfo);

            return returnView;
        }


        /// <summary>
        /// Processes the edit element price information.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        public string ProcessEditElementPriceInfo(IDesignElementPriceView designElementInfo)
        {
            var editDesignElement = this.generalRepository.EditDesignElementTypePrice(designElementInfo);


            return editDesignElement;
        }

        /// <summary>
        /// Processes the color of the edit.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        public string ProcessEditColor(IColorView colorView)
        {
            var colorEditing = this.generalRepository.EditColor(colorView);
            return colorEditing;
        }

        /// <summary>
        /// Processes the apcon view.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">apconInfo</exception>
        public string ProcessApconView(IApconApprovalView apconInfo)
        {
            if (apconInfo == null)
            {
                throw new System.ArgumentNullException(nameof(apconInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            //check if description is already in database
            var valueData = this.lookupRepository.GetApconDescriptionByValue(apconInfo.Description);
            var isRecordExist = (valueData == null) ? false : true;

            if (isRecordExist)
            {
                isDataOkay = false;
                processingMessage = Messages.ApconExist;
                return processingMessage;
            }



            var apconView = this.generalRepository.SaveApcon(apconInfo);
            return apconView;
        }
        /// <summary>
        /// Processes the color information.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>


        public string ProcessColorInfo(IColorView colorView)
        {

            var processingMessages = string.Empty;

            var dataValue = this.lookupRepository.GetColorDescriptionByValue(colorView.Description);
            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.ColorExist;
                return processingMessages;
            }

            var colorInfo = this.generalRepository.SaveColorInfo(colorView);

            return colorInfo;
        }








        /// <summary>
        /// Processes the time belt information.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        public string ProcessTimeBeltInfo(ITimeBeltView timeBeltView)
        {

            var processingMessages = string.Empty;

            var dataValue = this.lookupRepository.GetTimeBeltDescriptionByValue(timeBeltView.name);
            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.ColorExist;
                return processingMessages;
            }

            var timeBeltInfo = this.generalRepository.SaveTimeBeltInfo(timeBeltView);

            return timeBeltInfo;
        }

        /// <summary>
        /// Processes the delete apcon.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Id</exception>
        public string ProcessDeleteApcon(int Id)
        {
            if (Id < 1)
            {
                throw new ArgumentOutOfRangeException("Id");
            }
            var delete = this.generalRepository.DeleteApconApprovalType(Id);
            return delete;
        }



        /// <summary>
        /// Processes the delete timing belt.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Id</exception>
        public string ProcessDeleteTimingBelt(int Id)
        {
            if (Id < 1)
            {
                throw new ArgumentOutOfRangeException("Id");
            }
            var delete = this.generalRepository.DeleteTimeBelt(Id);
            return delete;
        }

        /// <summary>
        /// Processes the delete apcon approval type price.
        /// </summary>
        /// <param name="apcon">The apcon.</param>
        /// <returns></returns>
        public string ProcessDeleteApconApprovalTypePrice(int apcon)
        {
           
            var delete = this.generalRepository.DeleteApconApprovalTypePrice(apcon);
            return delete;
        }

        /// <summary>
        /// Processes the delete radio service price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteRadioServicePrice(int Id)
        {

            var delete = this.generalRepository.DeleteRadioServicePrice(Id);
            return delete;
        }

        /// <summary>
        /// Processes the delete design element price information.
        /// </summary>
        /// <param name="designElementPriceId">The design element price identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteDesignElementPriceInfo(int designElementPriceId)
        {
            var designElement = this.lookupRepository.DeleteDesignElementPrice(designElementPriceId);


            return designElement;
        }


        /// <summary>
        /// Processes the delete duration type information.
        /// </summary>
        /// <param name="durationTypeCode">The duration type code.</param>
        /// <returns></returns>
        public string ProcessDeleteDurationTypeInfo(string durationTypeCode)
        {
            var DurationEdting = this.generalRepository.DeleteDurationTypeInfo(durationTypeCode);
            return DurationEdting;
        }


        /// <summary>
        /// Processes the delete material type information.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteMaterialTypeInfo(int materialTypeId)
        {
            var materialEdting = this.generalRepository.DeleteMaterialTypeInfo(materialTypeId);
            return materialEdting;
        }



        /// <summary>
        /// Processes the delete material type timing.
        /// </summary>
        /// <param name="TypeTiming">The type timing.</param>
        /// <returns></returns>
        public string ProcessDeleteMaterialTypeTiming(int TypeTiming)
        {
            var delete = this.generalRepository.DeleteMaterialTypeTiming(TypeTiming);

           

            return delete;
        }
        /// <summary>
        /// Processes the delete timing information.
        /// </summary>
        /// <param name="TimingId">The timing identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteTimingInfo(int TimingId)
        {
            var materialEdting = this.generalRepository.DeleteTimingInfo(TimingId);
            return materialEdting;
        }


        /// <summary>
        /// Processes the design element price information.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">designElementInfo</exception>
        public string ProcessDesignElementPriceInfo(IDesignElementPriceView designElementInfo)
        {
            if (designElementInfo == null)
            {
                throw new System.ArgumentNullException(nameof(designElementInfo));
            }

            var designElementPriceInfo = this.generalRepository.SaveDesignElementPrice(designElementInfo);

            return designElementPriceInfo;
        }
        ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// Processes the duration type information.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        public string ProcessDurationTypeInfo(IDurationTypeView durationTypeView)
        {

            var processingMessages = string.Empty;

            //Check to see if the data exists
            var dataValue = this.lookupRepository.GetDurationTypeDescriptionByValue(durationTypeView.Description);

            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.ColorExist;
                return processingMessages;
            }


            var durationModel = this.generalRepository.SaveDurationTypeInfo(durationTypeView);
            return durationModel;
        }
        /// <summary>
        /// Processes the edit apcon.
        /// </summary>
        /// <param name="apconview">The apconview.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">apconview</exception>
        public string ProcessEditApcon(IApconApprovalView apconview)
        {
            if (apconview == null)
            {
                throw new System.ArgumentNullException(nameof(apconview));
            }

            var editApcon = this.generalRepository.EditApconApprovalType(apconview);
            return editApcon;
        }
        /// <summary>
        /// Processes the edit scripting price.
        /// </summary>
        /// <param name="apconview">The apconview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconview</exception>
        /// <exception cref="System.ArgumentNullException">apconview</exception>
        public string ProcessEditScriptingPrice(IApconApprovalTypePriceView apconview)
        {
            if (apconview == null)
            {
                throw new ArgumentNullException(nameof(apconview));
            }
          
            var editApconPrice = this.generalRepository.EditApconApprovalTypePrice(apconview);
            return editApconPrice;
        }

        /// <summary>
        /// Processes the edit scripting price.
        /// </summary>
        /// <param name="radioview">The radioview.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">radioview</exception>
        public string ProcessEditScriptingPrice(IRadioServicePriceList radioview)
        {
            if (radioview == null)
            {
                throw new ArgumentNullException(nameof(radioview));
            }

            var editRadioService = this.generalRepository.EditRadioServicePrice(radioview);
            return editRadioService;
        }

        /// <summary>
        /// Processes the material type information.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        public string ProcessMaterialTypeInfo(IMaterialTypeView materialTypeView)
        {

            var processingMessages = string.Empty;

            //Check to see if the data exists
            var dataValue = this.lookupRepository.GetMaterialTypeDescriptionByValue(materialTypeView.Description);

            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.MaterialTypeExist;
                return processingMessages;
            }


            var materialTypeInfo = this.generalRepository.SaveMaterialTypeInfo(materialTypeView);
            return materialTypeInfo;
        }
        /// <summary>
        /// Processes the material type timing information.
        /// </summary>
        /// <param name="timingInfo">The timing information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">timingInfo</exception>
        public string ProcessMaterialTypeTimingInfo(IMaterialTypeTimingView timingInfo)
        {
            if (timingInfo == null)
            {
                throw new System.ArgumentNullException(nameof(timingInfo));
            }
            
            var processingmessage = this.generalRepository.SaveMaterialTypeTiming(timingInfo); ;
            return processingmessage;
        }
        /// <summary>
        /// Processes the timing ifo.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        public string ProcessTimingIfo(ITimingView timingView)
        {

            var processingMessages = string.Empty;

            //Check to see if the data exists
            var dataValue = this.lookupRepository.GetTimingDescriptionByValue(timingView.Description);

            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.ColorExist;
                return processingMessages;
            }


            return this.generalRepository.SaveTimingInfo(timingView);
        }
        /// <summary>
        /// Updates the color information.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">colorView</exception>
        /// <exception cref="System.ArgumentNullException">colorView</exception>
        public string UpdateColorInfo(IColorView colorView)
        {
            if (colorView == null)
            {
                throw new ArgumentNullException(nameof(colorView));
            }


            var processingMessages = string.Empty;

            var dataValue = this.lookupRepository.GetColorDescriptionByValue(colorView.Description);
            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.ColorExist;
                return processingMessages;
            }


            var editColor = this.generalRepository.EditColor(colorView);

            return editColor;
        }






        /// <summary>
        /// Updates the time belt information.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">timeBeltView</exception>
        public string UpdateTimeBeltInfo(ITimeBeltView timeBeltView)
        {
            if (timeBeltView == null)
            {
                throw new ArgumentNullException(nameof(timeBeltView));
            }


            var processingMessages = string.Empty;

            var dataValue = this.lookupRepository.GetColorDescriptionByValue(timeBeltView.name);
            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.ColorExist;
                return processingMessages;
            }


            var editTimeBelt= this.generalRepository.EditTimeBelt(timeBeltView);

            return editTimeBelt;
        }
        /// <summary>
        /// Updates the duration type information.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">durationTypeView</exception>
        /// <exception cref="System.ArgumentNullException">durationTypeView</exception>
        public string UpdateDurationTypeInfo(IDurationTypeView durationTypeView)
        {
            if (durationTypeView == null)
            {
                throw new ArgumentNullException(nameof(durationTypeView));
            }

            var processingMessages = string.Empty;

            //Check to see if the data exists
            var dataValue = this.lookupRepository.GetDurationTypeDescriptionByValue(durationTypeView.Description);

            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.ColorExist;
                return processingMessages;
            }



            var processingMessage = this.generalRepository.EditDurationType(durationTypeView);
            return processingMessage;
        }
        /// <summary>
        /// Updates the material type information.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">materialTypeView</exception>
        /// <exception cref="System.ArgumentException">materialTypeView</exception>
        public string UpdateMaterialTypeInfo(IMaterialTypeView materialTypeView)
        {
            if (materialTypeView == null)
            {
                throw new ArgumentException("materialTypeView");
            }


            var processingMessages = string.Empty;

            //Check to see if the data exists
            var dataValue = this.lookupRepository.GetMaterialTypeDescriptionByValue(materialTypeView.Description);

            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.MaterialTypeExist;
                return processingMessages;
            }


            var processingMessage = this.generalRepository.EditMaterialType(materialTypeView);
            return processingMessage;
        }
        /// <summary>
        /// Updates the timing information.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">timingView</exception>
        /// <exception cref="System.ArgumentException">timingView</exception>
        public string UpdateTimingInfo(ITimingView timingView)
        {
            if (timingView == null)
            {
                throw new ArgumentException("timingView");
            }

            var processingMessages = string.Empty;

            //Check to see if the data exists
            var dataValue = this.lookupRepository.GetTimingDescriptionByValue(timingView.Description);

            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.TimingExist;
                return processingMessages;
            }

            return this.generalRepository.EditTiming(timingView);
        }

        /// <summary>
        /// Gets the updated design element view.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <returns></returns>
        public IDesignElementPriceView getUpdatedDesignElementView(IDesignElementPriceView designElementPriceView)
        {
            var serviceType = this.lookupRepository.GetServiceType();
            var designElement = this.lookupRepository.GetDesignElement();
            return this.generalFactory.CreateUpdatedDesignElementPriceView(designElementPriceView, designElement, serviceType);
        }

        
    }
}
