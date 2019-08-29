using System.Collections.Generic;
using System.Web;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingService
    {
        /// <summary>
     
        /// Deletes the brand order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string DeleteBrandOrder(int transactionId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandingMaterial"></param>
        /// <param name="color"></param>
        /// <param name="designElement"></param>
        /// <param name="brandingView"></param>
        /// <returns></returns>
        IBrandingView GetBrandingUpdatedView( IBrandingView brandingView,string ProcessingMessage);
        /// <summary>
        /// Gets the user branding view.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        IBrandingView GetUserBrandingView(int transactionId);

       

        /// <summary>
        /// Gets the branding view.
        /// </summary>
        /// <returns></returns>
        IBrandingView GetBrandingView();


        /// <summary>
        /// Processes the view.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="designMaterial">The design material.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        string ProcessView(IBrandingView brandingView, HttpPostedFileBase designMaterial, out int orderId);
        /// <summary>
        /// Updates the branding transaction.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="designMaterial">The design material.</param>
        /// <returns></returns>
        string UpdateBrandingTransaction(IBrandingView brandingView, HttpPostedFileBase designMaterial);


        /// <summary>
        /// Gets the material ListView model.
        /// </summary>
        /// <param name="selectedBrandingMaterialId">The selected branding material identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IBrandingMaterialListView GetMaterialListViewModel(int selectedBrandingMaterialId, string selectedDescription,
            string message);

        /// <summary>
        /// Processes the branding material information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        string ProcessBrandingMaterialInfo(IBrandingMaterialView brandingView);

        /// <summary>
        /// Gets the branding material view.
        /// </summary>
        /// <returns></returns>
        IBrandingMaterialView GetBrandingMaterialView();

        /// <summary>
        /// Gets the branding material view.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IBrandingMaterialView GetBrandingMaterialView(IBrandingMaterialView brandingMaterialView, string message);
        /// <summary>
        /// Gets the selected branding material information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IBrandingMaterialView GetSelectedBrandingMaterialInfo(int Id);


        /// <summary>
        /// Updates the branding material information.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <returns></returns>
        string UpdateBrandingMaterialInfo(IBrandingMaterialView brandingMaterialView);


        /// <summary>
        /// Gets the material price view.
        /// </summary>
        /// <param name="brandingMaterialPriceView">The branding material price view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IBrandingMaterialPriceView GetMaterialPriceView(IBrandingMaterialPriceView brandingMaterialPriceView,
            string message);

        /// <summary>
        /// Processes the delete branding material information.
        /// </summary>
        /// <param name="brandingMaterialId">The branding material identifier.</param>
        /// <returns></returns>
        string ProcessDeleteBrandingMaterialInfo(int brandingMaterialId);

        /// <summary>
        /// Gets the branding material price view model.
        /// </summary>
        /// <param name="selectedBrandingMaterialPriceId">The selected branding material price identifier.</param>
        /// <param name="selectedBrandingMaterial">The selected branding material.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMaterialPriceListView GetBrandingMaterialPriceViewModel(int selectedBrandingMaterialPriceId,
            string selectedBrandingMaterial, string message);

        /// <summary>
        /// Gets the material price view.
        /// </summary>
        /// <returns></returns>
        IBrandingMaterialPriceView GetMaterialPriceView();
        /// <summary>
        /// Processes the material price information.
        /// </summary>
        /// <param name="materialInfo">The material information.</param>
        /// <returns></returns>
        string ProcessMaterialPriceInfo(IBrandingMaterialPriceView materialInfo);
        /// <summary>
        /// Gets the selected branding material pricenfo.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IBrandingMaterialPriceView GetSelectedBrandingMaterialPricenfo(int Id);
        /// <summary>
        /// Processes the edit branding material price information.
        /// </summary>
        /// <param name="brandingMaterialPriceView">The branding material price view.</param>
        /// <returns></returns>
        string ProcessEditBrandingMaterialPriceInfo(IBrandingMaterialPriceView brandingMaterialPriceView);
        /// <summary>
        /// Processes the delete material price information.
        /// </summary>
        /// <param name="brandingMaterialPriceId">The branding material price identifier.</param>
        /// <returns></returns>
        string ProcessDeleteMaterialPriceInfo(int brandingMaterialPriceId);
        /// <summary>
        /// Gets the branding material price.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IBrandingView GetBrandingMaterialPrice(int Id);
        /// <summary>
        /// Updates the cart.
        /// </summary>
        void UpdateCart();

        /// <summary>
        /// Gets the edit branding transaction view.
        /// </summary>
        /// <param name="trasactionId">The trasaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IBrandingView GetEditBrandingTransactionView(int trasactionId, int userId, string message);

    
       



       
    }
}