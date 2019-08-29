namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGeneralRepository
    {
        /// <summary>
        /// Checks the radio serviceprice.
        /// </summary>
        /// <param name="radioServicePriceList">The radio service price list.</param>
        /// <returns></returns>
        bool CheckRadioServiceprice(IRadioServicePriceList radioServicePriceList);
        /// <summary>
        /// Deletes the time belt.
        /// </summary>
        /// <param name="TimeBeltId">The time belt identifier.</param>
        /// <returns></returns>
        string DeleteTimeBelt(int TimeBeltId);
        /// <summary>
        /// Edits the time belt.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        string EditTimeBelt(ITimeBeltView timeBeltView);
        /// <summary>
        /// Saves the time belt information.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        string SaveTimeBeltInfo(ITimeBeltView timeBeltView);
        /// <summary>
        /// Saves the apcon.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <returns></returns>
        string SaveApcon(IApconApprovalView apconInfo);
        /// <summary>
        /// Edits the type of the apcon approval.
        /// </summary>
        /// <param name="apconview">The apconview.</param>
        /// <returns></returns>
        string EditApconApprovalType(IApconApprovalView apconview);
        /// <summary>
        /// Deletes the type of the apcon approval.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string DeleteApconApprovalType(int Id);
        /// <summary>
        /// Saves the apcon price.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <returns></returns>
        string SaveApconPrice(IApconApprovalTypePriceView apconInfo);
        /// <summary>
        /// Edits the apcon approval type price.
        /// </summary>
        /// <param name="apconPrice">The apcon price.</param>
        /// <returns></returns>
        string EditApconApprovalTypePrice(IApconApprovalTypePriceView apconPrice);
        /// <summary>
        /// Deletes the apcon approval type price.
        /// </summary>
        /// <param name="apconPrice">The apcon price.</param>
        /// <returns></returns>
        string DeleteApconApprovalTypePrice(int apconPrice);
        /// <summary>
        /// Edits the material scripting price.
        /// </summary>
        /// <param name="materialScriptingPrice">The material scripting price.</param>
        /// <returns></returns>
        string EditMaterialScriptingPrice(IMaterialScriptingPriceView materialScriptingPrice);
        /// <summary>
        /// Deletes the material scripting price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string DeleteMaterialScriptingPrice(int Id);
        /// <summary>
        /// Edits the material production price.
        /// </summary>
        /// <param name="materialProductionPrice">The material production price.</param>
        /// <returns></returns>
        string EditMaterialProductionPrice(IMaterialProductionPriceView materialProductionPrice);
        /// <summary>
        /// Deletes the material production price.
        /// </summary>
        /// <param name="productionPrice">The production price.</param>
        /// <returns></returns>
        string DeleteMaterialProductionPrice(int productionPrice);
        /// <summary>
        /// Saves the timing information.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        string SaveTimingInfo(ITimingView timingView);
        /// <summary>
        /// Saves the color information.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        string SaveColorInfo(IColorView colorView);
        /// <summary>
        /// Saves the material type information.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        string SaveMaterialTypeInfo(IMaterialTypeView materialTypeView);
        /// <summary>
        /// Saves the duration type information.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        string SaveDurationTypeInfo(IDurationTypeView durationTypeView);
        /// <summary>
        /// Edits the color.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        string EditColor(IColorView colorView);
        /// <summary>
        /// Edits the timing.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        string EditTiming(ITimingView timingView);
        /// <summary>
        /// Edits the type of the duration.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        string EditDurationType(IDurationTypeView durationTypeView);
        /// <summary>
        /// Edits the type of the material.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        string EditMaterialType(IMaterialTypeView materialTypeView);
        /// <summary>
        /// Deletes the timing information.
        /// </summary>
        /// <param name="TimingId">The timing identifier.</param>
        /// <returns></returns>
        string DeleteTimingInfo(int TimingId);
        /// <summary>
        /// Deletes the duration type information.
        /// </summary>
        /// <param name="durationTypeId">The duration type identifier.</param>
        /// <returns></returns>
        string DeleteDurationTypeInfo(string durationTypeId);
        /// <summary>
        /// Deletes the material type information.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <returns></returns>
        string DeleteMaterialTypeInfo(int materialTypeId);
        /// <summary>
        /// Saves the design element price.
        /// </summary>
        /// <param name="designelement">The designelement.</param>
        /// <returns></returns>
        string SaveDesignElementPrice(IDesignElementPriceView designelement);
        /// <summary>
        /// Edits the design element type price.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <returns></returns>
        string EditDesignElementTypePrice(IDesignElementPriceView designElementPriceView);
        /// <summary>
        /// Deletes the design element price.
        /// </summary>
        /// <param name="designElementPriceId">The design element price identifier.</param>
        /// <returns></returns>
        string DeleteDesignElementPrice(int designElementPriceId);
        /// <summary>
        /// Saves the add design element.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        string SaveAddDesignElement(IDesignElementView designElementInfo);
        /// <summary>
        /// Saves the design element description.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        string EditDesignElementDescription(IDesignElementView designElementInfo);
        /// <summary>
        /// Deletes the design element description.
        /// </summary>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        string DeleteDesignElementDescription(int designElementId);
        /// <summary>
        /// Saves the material type timing.
        /// </summary>
        /// <param name="timingInfo">The timing information.</param>
        /// <returns></returns>
        string SaveMaterialTypeTiming(IMaterialTypeTimingView timingInfo);
        /// <summary>
        /// Edits the material type timing.
        /// </summary>
        /// <param name="timing">The timing.</param>
        /// <returns></returns>
        string EditMaterialTypeTiming(IMaterialTypeTimingView timing);
        /// <summary>
        /// Deletes the material type timing.
        /// </summary>
        /// <param name="TypeTiming">The type timing.</param>
        /// <returns></returns>
        string DeleteMaterialTypeTiming(int TypeTiming);
         
         
        /// <summary>
        /// Saves the radio service price.
        /// </summary>
        /// <param name="radioService">The radio service.</param>
        /// <returns></returns>
        string SaveRadioServicePrice(IRadioServicePriceList radioService);
        /// <summary>
        /// Edits the radio service price.
        /// </summary>
        /// <param name="Price">The price.</param>
        /// <returns></returns>
        string EditRadioServicePrice(IRadioServicePriceList Price);
        /// <summary>
        /// Deletes the radio service price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string DeleteRadioServicePrice(int Id);
        /// <summary>
        /// Updates the print media transaction airing.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns></returns>


        string SavePaymentTransaction(IPaymentModel paymentDetails); 
    }

}
