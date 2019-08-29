namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGeneralService
    {
        /// <summary>
        /// Checks the radio service.
        /// </summary>
        /// <param name="radioServicePriceList">The radio service price list.</param>
        /// <returns></returns>
        bool CheckRadioService(IRadioServicePriceList radioServicePriceList);
        /// <summary>
        /// Processes the delete timing belt.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string ProcessDeleteTimingBelt(int Id);
        /// <summary>
        /// Updates the time belt information.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        string UpdateTimeBeltInfo(ITimeBeltView timeBeltView);
        /// <summary>
        /// Processes the time belt information.
        /// </summary>
        /// <param name="timeBeltView">The time belt view.</param>
        /// <returns></returns>
        string ProcessTimeBeltInfo(ITimeBeltView timeBeltView);
        /// <summary>
        /// Processes the delete material type information.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <returns></returns>
        string ProcessDeleteMaterialTypeInfo(int materialTypeId);

        /// <summary>
        /// Processes the delete duration type information.
        /// </summary>
        /// <param name="durationTypeCode">The duration type code.</param>
        /// <returns></returns>
        string ProcessDeleteDurationTypeInfo(string durationTypeCode);
        /// <summary>
        /// Processes the edit apcon.
        /// </summary>
        /// <param name="apconview">The apconview.</param>
        /// <returns></returns>
        string ProcessEditApcon(IApconApprovalView apconview);
        /// <summary>
        /// Processes the material type timing information.
        /// </summary>
        /// <param name="timingInfo">The timing information.</param>
        /// <returns></returns>
        string ProcessMaterialTypeTimingInfo(IMaterialTypeTimingView timingInfo);

        /// <summary>
        /// Processes the apcon view.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <returns></returns>
        string ProcessApconView(IApconApprovalView apconInfo);

        /// <summary>
        /// Processes the delete material type timing.
        /// </summary>
        /// <param name="TypeTiming">The type timing.</param>
        /// <returns></returns>
        string ProcessDeleteMaterialTypeTiming(int TypeTiming);

        /// <summary>
        /// Processes the delete apcon.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string ProcessDeleteApcon(int Id);
        /// <summary>
        /// Processes the design element price information.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        string ProcessDesignElementPriceInfo(IDesignElementPriceView designElementInfo);

        /// <summary>
        /// Processes the delete timing information.
        /// </summary>
        /// <param name="TimingId">The timing identifier.</param>
        /// <returns></returns>
        string ProcessDeleteTimingInfo(int TimingId);
        /// <summary>
        /// Processes the delete design element price information.
        /// </summary>
        /// <param name="esignElementPriceId">The esign element price identifier.</param>
        /// <returns></returns>
        string ProcessDeleteDesignElementPriceInfo(int esignElementPriceId);
        /// <summary>
        /// Processes the apcon approval type price view.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <returns></returns>
        string ProcessApconApprovalTypePriceView(IApconApprovalTypePriceView apconInfo);
        /// <summary>
        /// Processes the edit scripting price.
        /// </summary>
        /// <param name="apconview">The apconview.</param>
        /// <returns></returns>
        string ProcessEditScriptingPrice(IApconApprovalTypePriceView apconview);
        /// <summary>
        /// Processes the delete apcon approval type price.
        /// </summary>
        /// <param name="apcon">The apcon.</param>
        /// <returns></returns>
        string ProcessDeleteApconApprovalTypePrice(int apcon);
        /// <summary>
        /// Gets the delete design element.
        /// </summary>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        string GetDeleteDesignElement(int designElementId);
        /// <summary>
        /// Processes the timing ifo.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        string ProcessTimingIfo(ITimingView timingView);
        /// <summary>
        /// Updates the color information.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        string UpdateColorInfo(IColorView colorView);
        /// <summary>
        /// Processes the color of the edit.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        string ProcessEditColor(IColorView colorView);
        /// <summary>
        /// Updates the duration type information.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        string UpdateDurationTypeInfo(IDurationTypeView durationTypeView);
        /// <summary>
        /// Processes the edit element price information.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        string ProcessEditElementPriceInfo(IDesignElementPriceView designElementInfo);
        /// <summary>
        /// Updates the material type information.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        string UpdateMaterialTypeInfo(IMaterialTypeView materialTypeView);
        /// <summary>
        /// Processes the color information.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <returns></returns>
        string ProcessColorInfo(IColorView colorView);
        /// <summary>
        /// Gets the design element view model.
        /// </summary>
        /// <param name="designElementInfo">The design element information.</param>
        /// <returns></returns>
        string GetDesignElementViewModel(IDesignElementView designElementInfo);
        /// <summary>
        /// Processes the material type information.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <returns></returns>
        string ProcessMaterialTypeInfo(IMaterialTypeView materialTypeView);
        /// <summary>
        /// Updates the timing information.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <returns></returns>
        string UpdateTimingInfo(ITimingView timingView);
        /// <summary>
        /// Gets the edit design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <returns></returns>
        string GetEditDesignElement(IDesignElementView designElementView);
        /// <summary>
        /// Processes the duration type information.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <returns></returns>
        string ProcessDurationTypeInfo(IDurationTypeView durationTypeView);

        /// <summary>
        /// Gets the updated design element view.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <returns></returns>
        IDesignElementPriceView getUpdatedDesignElementView(IDesignElementPriceView designElementPriceView);
        /// <summary>
        /// Processes the radio service price view.
        /// </summary>
        /// <param name="radioService">The radio service.</param>
        /// <returns></returns>
        string ProcessRadioServicePriceView(IRadioServicePriceList radioService);
        /// <summary>
        /// Processes the edit scripting price.
        /// </summary>
        /// <param name="radioview">The radioview.</param>
        /// <returns></returns>
        string ProcessEditScriptingPrice(IRadioServicePriceList radioview);
        /// <summary>
        /// Processes the delete radio service price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        string ProcessDeleteRadioServicePrice(int Id);
    }
}
