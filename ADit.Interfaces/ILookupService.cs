using System.Web;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILookupService
    {
        /// <summary>
        /// Sends the contact mmail.
        /// </summary>
        /// <param name="contactView">The contact view.</param>
        void SendContactMail(IContactView contactView);
        /// <summary>
        /// Gets the contact view.
        /// </summary>
        /// <returns></returns>
        IContactView GetContactView();

        /// <summary>
        /// Gets the time belt by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITimeBeltView GetTimeBeltById(int Id, string message);
        /// <summary>
        /// Gets the selected time belt by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        ITimeBeltView GetSelectedTimeBeltByInfo(int Id);
        /// <summary>
        /// Gets the time belt view.
        /// </summary>
        /// <returns></returns>
        ITimeBeltView GetTimeBeltView();
        /// <summary>
        /// Gets the apcon approval type price view model.
        /// </summary>
        /// <param name="selectedApconApprovalTypePriceId">The selected apcon approval type price identifier.</param>
        /// <param name="selectedApconApprovalId">The selected apcon approval identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IApconApprovalTypePriceListView GetApconApprovalTypePriceViewModel(int selectedApconApprovalTypePriceId, int selectedApconApprovalId, string message);
        /// <summary>
        /// Gets the apcon approval type price view.
        /// </summary>
        /// <returns></returns>
        IApconApprovalTypePriceView GetApconApprovalTypePriceView();
        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        string RandomString(int length);
        /// <summary>
        /// Gets the apcon approval type price view.
        /// </summary>
        /// <param name="priceView">The price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IApconApprovalTypePriceView GetApconApprovalTypePriceView(IApconApprovalTypePriceView priceView, string message);
        /// <summary>
        /// Gets the apcon approval type price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IApconApprovalTypePriceView GetApconApprovalTypePriceById(int Id);

        /// <summary>
        /// Gets the delete apcon approval type price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IApconApprovalTypePriceView GetDeleteApconApprovalTypePriceById(int Id);


        /// <summary>
        /// Gets the color ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IColorListView GetColorListViewModel(int selectedId,string selectedDescription,string message);

        /// <summary>
        /// Gets the material type ListView model.
        /// </summary>
        /// <param name="materialTypeId">The material type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialTypeListView GetMaterialTypeListViewModel(int materialTypeId, string selectedDescription, string message);

        /// <summary>
        /// Gets the apcon approval type ListView.
        /// </summary>
        /// <param name="selectedApconApprovalTypeId">The selected apcon approval type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IApconApprovalTypeListView GetApconApprovalTypeListView(int selectedApconApprovalTypeId, string selectedDescription, string message);

        /// <summary>
        /// Gets the duration type ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDurationTypeId">The selected duration type identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDurationTypeListView GetDurationTypeListView(string selectedId, string selectedDurationTypeId,string message);

        /// <summary>
        /// Gets the timing ListView.
        /// </summary>
        /// <param name="selctedId">The selcted identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITimingListView GetTimingListView(int selctedId, string selectedDescription, string message);


        /// <summary>
        /// Gets the design element view model.
        /// </summary>
        /// <returns></returns>
        IDesignElementView GetDesignElementViewModel();

        /// <summary>
        /// Gets the edit design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        IDesignElementView GetEditDesignElement(IDesignElementView designElementView, int designElementId);

        //IDesignElementView GetEditUpdateDesignElement(IDesignElementView designElementView);

        /// <summary>
        /// Gets the delete design element.
        /// </summary>
        /// <param name="designElementView">The design element view.</param>
        /// <param name="designElementId">The design element identifier.</param>
        /// <returns></returns>
        IDesignElementView GetDeleteDesignElement(IDesignElementView designElementView, int designElementId);

        // IDesignElementListView GetDesignElementListView(int SelectedDesignElementId, string SelectedDescription, string message);
        //IDesignElementListView GetDesignElementListView(string message);
        /// <summary>
        /// Gets the design element ListView.
        /// </summary>
        /// <param name="SelectedDesignElementId">The selected design element identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDesignElementListView GetDesignElementListView(int SelectedDesignElementId, string SelectedDescription, string message);
        /// <summary>
        /// Admins the save timing.
        /// </summary>
        /// <param name="colorView">The color view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>


        IColorView GetColorView(IColorView  colorView,string message);

        /// <summary>
        /// Gets the color view.
        /// </summary>
        /// <returns></returns>
        IColorView GetColorView();

        /// <summary>
        /// Gets the duration type view.
        /// </summary>
        /// <returns></returns>
        IDurationTypeView GetDurationTypeView();

        /// <summary>
        /// Gets the duration type view.
        /// </summary>
        /// <param name="durationTypeView">The duration type view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDurationTypeView GetDurationTypeView(IDurationTypeView durationTypeView,string message);


        /// <summary>
        /// Gets the material type view.
        /// </summary>
        /// <param name="materialTypeView">The material type view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialTypeView GetMaterialTypeView(IMaterialTypeView materialTypeView,string message);
        /// <summary>
        /// Gets the material type view.
        /// </summary>
        /// <returns></returns>
        IMaterialTypeView GetMaterialTypeView();
        /// <summary>
        /// Creates the timing view.
        /// </summary>
        /// <param name="timingView">The timing view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        ITimingView GetTimingView(ITimingView timingView ,string message);
        /// <summary>
        /// Gets the timing view.
        /// </summary>
        /// <returns></returns>
        ITimingView GetTimingView();








        /// <summary>
        /// Gets the selected color by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IColorView GetSelectedColorByInfo(int Id);

        /// <summary>
        /// Gets the material type selected information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IMaterialTypeView GetMaterialTypeSelectedInfo(int Id);

        /// <summary>
        /// Gets the selected duration type information.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IDurationTypeView GetSelectedDurationTypeInfo(string code);

        /// <summary>
        /// Gets the selected timing by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        ITimingView GetSelectedTimingByInfo(int Id);






        /// <summary>
        /// Gets the apcon view.
        /// </summary>
        /// <returns></returns>
        IApconApprovalView GetApconView();
        /// <summary>
        /// Gets the apcon view.
        /// </summary>
        /// <param name="apconInfo">The apcon information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IApconApprovalView GetApconView(IApconApprovalView apconInfo, string processingMessage);

        /// <summary>
        /// Gets the apcon approval by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IApconApprovalView GetApconApprovalById(int Id, string message);

        /// <summary>
        /// Gets the selected design element price information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IDesignElementPriceView GetSelectedDesignElementPriceInfo(int Id);

        /// <summary>
        /// Gets the delete design element price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IDesignElementPriceView GetDeleteDesignElementPriceById(int Id);

        /// <summary>
        /// Ges the design element price view model.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="SelectedDesignElementPriceId">The selected design element price identifier.</param>
        /// <param name="SelectedServiceTypeCode">The selected service type code.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <returns></returns>
        IDesignElementPriceListView GeDesignElementPriceViewModel(string message, int SelectedDesignElementPriceId, string SelectedServiceTypeCode, string SelectedDescription);

        /// <summary>
        /// Gets the design element price view.
        /// </summary>
        /// <param name="designElementPriceView">The design element price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDesignElementPriceView GetDesignElementPriceView(IDesignElementPriceView designElementPriceView, string message);

        /// <summary>
        /// Gets the design element price view.
        /// </summary>
        /// <returns></returns>
        IDesignElementPriceView GetDesignElementPriceView();




        /// <summary>
        /// Gets the material type timing ListView.
        /// </summary>
        /// <param name="selectedMaterialTypeTimingId">The selected material type timing identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialTypeTimingListView GetMaterialTypeTimingListView(int selectedMaterialTypeTimingId, int selectedTimingId, string selectedDescription, string message);

        /// <summary>
        /// Gets the material type timing view.
        /// </summary>
        /// <returns></returns>
        IMaterialTypeTimingView GetMaterialTypeTimingView();


        /// <summary>
        /// Gets the edit material type timing by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialTypeTimingView GetEditMaterialTypeTimingById(int Id, string message);
        /// <summary>
        /// Gets the radio service type price view.
        /// </summary>
        /// <param name="priceView">The price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IRadioServicePriceList GetRadioServiceTypePriceView(IRadioServicePriceList priceView, string message);       IMaterialTypeTimingView GetDeleteMaterialTypeTimingById(int Id, string message);
        /// <summary>
        /// Gets the material type timing view.
        /// </summary>
        /// <param name="materialView">The material view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialTypeTimingView GetMaterialTypeTimingView(IMaterialTypeTimingView materialView, string message);
        /// <summary>
        /// Gets the user message.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IScriptingViewList GetUserMessage(int userId, string message);
        /// <summary>
        /// Gets the radio service type price view.
        /// </summary>
        /// <returns></returns>
        IRadioServicePriceList GetRadioServiceTypePriceView();
        /// <summary>
        /// Gets the radio service price view model.
        /// </summary>
        /// <param name="selectedRadioServiceId">The selected radio service identifier.</param>
        /// <param name="selectedRadioId">The selected radio identifier.</param>
        /// <param name="selectedTimingId">The selected timing identifier.</param>
        /// <param name="selectedMaterialTypeId">The selected material type identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IRadioServicePriceListView GetRadioServicePriceViewModel(int selectedRadioServiceId, int selectedRadioId, int selectedTimingId, int selectedMaterialTypeId, string message);
        /// <summary>
        /// Gets the radio service price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IRadioServicePriceList GetRadioServicePriceById(int Id);
        /// <summary>
        /// Gets the delete radio service price by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IRadioServicePriceList GetDeleteRadioServicePriceById(int Id);

        /// <summary>
     
       
        /// <summary>
        /// Gets the script file for download.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IDigitalFile GetScriptFileForDownload(int Id);

       
       
       

        /// <summary>
        /// Gets the time belt ListView.
        /// </summary>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        ITimeBeltListView GetTimeBeltListView( string selectedDescription);

    }
}



