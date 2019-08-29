using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingFactory
    {
        /// <summary>
         
       
        /// Gets the user branding transaction.
        /// </summary>
        /// <param name="brandingTransaction">The branding transaction.</param>
        /// <param name="brandingTransactionColors">The branding transaction colors.</param>
        /// <param name="brandingTransactionAttachment">The branding transaction attachment.</param>
        /// <param name="brandingTransactionDesignElement">The branding transaction design element.</param>
        /// <param name="brandingTransactionMaterial">The branding transaction material.</param>
        /// <returns></returns>
        IBrandingView GetUserBrandingTransaction(IBrandingTransaction brandingTransaction, IList<IBrandingTransactionColor> brandingTransactionColors, IBrandingTransactionAttachment brandingTransactionAttachment, IBrandingTransactionDesignElement brandingTransactionDesignElement, IBrandingTransactionMaterial brandingTransactionMaterial);
        /// <summary>
        /// Gets all branding tranasction.
        /// </summary>
        /// <param name="brandingTransactions">The branding transactions.</param>
        /// <returns></returns>
        /// IBrandingAttachmentTransactionListView GetBrandingAttachmentTransactionListView( IBrandingTransaction brandingTransaction);
        IBrandingTransactionListVew GetAllBrandingTranasction(IList<IBrandingTransaction> brandingTransactions,IList<IMessage>messages,IList<IReplies>replies);
        /// <summary>
        /// Gets the branding view.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <param name="color">The color.</param>
        /// <param name="designElement">The design element.</param>
        /// <returns></returns>
        IBrandingView GetBrandingView(IList<IBrandingMaterialPrice> brandingMaterial, IList<IColor> color, IList<IDesignElementPrice> designElement);

        /// <summary>
        /// Creates the update branding view.
        /// </summary>
        /// <param name="brandingTransactionView">The branding transaction view.</param>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <param name="color">The color.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="ProcessingMessage">The processing message.</param>
        /// <returns></returns>
        IBrandingView CreateUpdateBrandingView(IBrandingView brandingTransactionView, IList<IBrandingMaterial> brandingMaterial, 
                       IList<IColor> color, IList<IDesignElementPrice> designElement,string ProcessingMessage);


        /// <summary>
        /// Creates the branding material ListView.
        /// </summary>
        /// <param name="materialCollection">The material collection.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedBrandingMaterialId">The selected branding material identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <returns></returns>
        IBrandingMaterialListView CreateBrandingMaterialListView(IList<IBrandingMaterial> materialCollection, string message,
             int selectedBrandingMaterialId, string selectedDescription);

        /// <summary>
        /// Creates the branding material view.
        /// </summary>
        /// <returns></returns>
        IBrandingMaterialView CreateBrandingMaterialView();


        /// <summary>
        /// Creates the edit branding material view.
        /// </summary>
        /// <param name="brandingmaterialView">The brandingmaterial view.</param>
        /// <returns></returns>
        IBrandingMaterialView CreateEditBrandingMaterialView(IBrandingMaterial brandingmaterialView);

        /// <summary>
        /// Creates the material price view.
        /// </summary>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        IBrandingMaterialPriceView CreateMaterialPriceView( IList<IBrandingMaterial> MaterialType);
        /// <summary>
        /// Creates the branding material price view.
        /// </summary>
        /// <param name="materialview">The materialview.</param>
        /// <param name="processingMessages">The processing messages.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        IBrandingMaterialPriceView CreateBrandingMaterialPriceView(IBrandingMaterialPriceView materialview, string processingMessages,
            IList<IBrandingMaterial> MaterialType);
        /// <summary>
        /// Creates the branding material price ListView.
        /// </summary>
        /// <param name="brandingmaterial">The brandingmaterial.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedBrandingMaterialPriceId">The selected branding material price identifier.</param>
        /// <param name="selectedBrandingMaterialId">The selected branding material identifier.</param>
        /// <returns></returns>
        IMaterialPriceListView CreateBrandingMaterialPriceListView(IList<IBrandingMaterialPrice> brandingmaterial, string message,
           int selectedBrandingMaterialPriceId, string selectedBrandingMaterialId);

        /// <summary>
        /// Creates the branding material price view.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <returns></returns>
        IBrandingMaterialPriceView CreateBrandingMaterialPriceView( IList<IBrandingMaterial> brandingMaterial);

        /// <summary>
        /// Edits the branding material price.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <param name="brandingMaterialPrice">The branding material price.</param>
        /// <returns></returns>
        IBrandingMaterialPriceView EditBrandingMaterialPrice( IList<IBrandingMaterial> brandingMaterial, IBrandingMaterialPrice brandingMaterialPrice);

        /// <summary>
        /// Creates the branding material view.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IBrandingMaterialView CreateBrandingMaterialView(IBrandingMaterialView brandingMaterialView, string  processingMessage);
        /// <summary>
        /// Gets the branding material views.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        IBrandingView GetBrandingMaterialViews(IBrandingMaterialPrice price);

        /// <summary>
        /// Gets the branding view.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <param name="color">The color.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="brandingTransaction">The branding transaction.</param>
        /// <param name="selectedColor">Color of the selected.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IBrandingView GetBrandingTransactionView(IList<IBrandingMaterialPrice> brandingMaterial, IList<IColor> color,
            IList<IDesignElementPrice> designElement, IBrandingTransaction brandingTransaction, IList<IBrandingTransactionColor> selectedColor, string message);

       


        /// <summary>
        /// Gets the branding attachment message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IMessageRepliesListView GetBrandingAttachmentMessageRepliesListView(IList<IReplies> replies, IMessage message,int transactionId,int SentToId,int OrderId);
    }
}

