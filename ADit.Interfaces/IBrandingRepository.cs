using System.Collections.Generic;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingRepository
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="transactionId"></param>
     /// <returns></returns>
        string DeleteBrandOrder(int transactionId);
        /// <summary>
        /// Gets the branding attachment transactions by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IBrandingTransactionAttachment GetBrandingAttachmentTransactionsById(int transactionId);
        /// <summary>
        /// Gets the branding transaction design element by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IBrandingTransactionDesignElement GetBrandingTransactionDesignElementById(int transactionId);

        /// <summary>
        /// Gets the i branding transaction material by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IBrandingTransactionMaterial GetIBrandingTransactionMaterialById(int transactionId);

       
        /// <summary>
        /// Gets the branding transaction.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IBrandingTransaction GetBrandingTransaction(int UserId, int transactionId);

        /// <summary>
        /// Gets the branding attachment transactions.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<IBrandingAttachmentTransaction> GetBrandingAttachmentTransactions(int UserId, int transactionId);


        /// <summary>
        /// Gets all branding transaction.
        /// </summary>
        /// <returns></returns>
        IList<IBrandingTransaction>GetAllBrandingTransaction();
        /// <summary>
        /// Saves the branding transaction information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        string saveBrandingTransactionInfo(IBrandingView brandingView,out int brandingTransactionId);


        /// <summary>
        /// Saves the branding transaction material information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTranactionId">The branding tranaction identifier.</param>
        /// <returns></returns>
        string saveBrandingTransactionMaterialInfo(IBrandingView brandingView, int brandingTranactionId);


        /// <summary>
        /// Saves the branding transaction color information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        string saveBrandingTransactionColorInfo(IBrandingView brandingView,int brandingTransactionId);


        /// <summary>
        /// Saves the branding transaction design element information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        string saveBrandingTransactionDesignElementInfo(IBrandingView brandingView,int brandingTransactionId);


        /// <summary>
        /// Saves the branding transaction attachment information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        string saveBrandingTransactionAttachmentInfo(IBrandingView brandingView,int brandingTransactionId);


        /// <summary>
        /// Saves the material information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        string SaveMaterialInfo(IBrandingMaterialView brandingView);

        /// <summary>
        /// Edits the material.
        /// </summary>
        /// <param name="brandingMaterialView">The branding material view.</param>
        /// <returns></returns>
        string EditMaterial(IBrandingMaterialView brandingMaterialView);


        /// <summary>
        /// Deletes the branding material information.
        /// </summary>
        /// <param name="brandingMaterialId">The branding material identifier.</param>
        /// <returns></returns>
        string DeleteBrandingMaterialInfo(int brandingMaterialId);

        /// <summary>
        /// Saves the material price.
        /// </summary>
        /// <param name="materialprice">The materialprice.</param>
        /// <returns></returns>
        string SaveMaterialPrice(IBrandingMaterialPriceView materialprice);

        /// <summary>
        /// Deletes the branding material price.
        /// </summary>
        /// <param name="brandingMaterialPriceId">The branding material price identifier.</param>
        /// <returns></returns>
        string DeleteBrandingMaterialPrice( int brandingMaterialPriceId);

        /// <summary>
        /// Edits the branding material price.
        /// </summary>
        /// <param name="brandingMaterialPriceView">The branding material price view.</param>
        /// <returns></returns>
        string EditBrandingMaterialPrice(IBrandingMaterialPriceView brandingMaterialPriceView);

        /// <summary>
        /// Gets the name of the branding material by.
        /// </summary>
        /// <param name="materialName">Name of the material.</param>
        /// <returns></returns>
        IBrandingMaterial GetBrandingMaterialByName(string materialName);

        /// <summary>
        /// Gets the active branding transaction.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IList<IBrandingTransaction> getActiveBrandingTransaction(int Id);

        /// <summary>
        /// Gets the transaction details.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IBrandingTransaction GetTransactionDetails(int transactionId);

        /// <summary>
        /// Updates the branding transaction attachments.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        string UpdateBrandingTransactionAttachments(IBrandingView brandingView);

        /// <summary>
        /// Updates the branding transaction.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        string UpdateBrandingTransaction(IBrandingView brandingView);

        /// <summary>
        /// Updates the branding transaction material information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        string UpdateBrandingTransactionMaterialInfo(IBrandingView brandingView);

        /// <summary>
        /// Updates the branding transaction color information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="brandingTransactionId">The branding transaction identifier.</param>
        /// <returns></returns>
        string UpdateBrandingTransactionColorInfo(IBrandingView brandingView, int brandingTransactionId);

        /// <summary>
        /// Updates the branding transaction design element information.
        /// </summary>
        /// <param name="brandingView">The branding view.</param>
        /// <returns></returns>
        string UpdateBrandingTransactionDesignElementInfo(IBrandingView brandingView);

        /// <summary>
        /// Gets the color of the selected.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<IBrandingTransactionColor> GetSelectedColor(int transactionId);

        /// <summary>
        /// Gets the selected color by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IBrandingTransactionColor GetSelectedColorById(int transactionId);
    }
}
