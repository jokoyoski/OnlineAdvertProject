using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IPrintRepository
    {
        /// <summary>
        /// Gets the type of the active p media.
        /// </summary>
        /// <returns></returns>
        IList<IPrintMediaType> GetActivePMediaType();
        /// <summary>
        /// Deletes the print media type description.
        /// </summary>
        /// <param name="printMediaTypeId">The print media type identifier.</param>
        /// <returns></returns>
        string DeletePrintMediaTypeDescription(int printMediaTypeId);


        /// <summary>
        /// Updates the print media type information.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <returns></returns>
        string UpdatePrintMediaTypeInfo(IPrintMediaType printMediaType);
        /// <summary>
        /// Saves the type of the add print media.
        /// </summary>
        /// <param name="printMediaType">Type of the print media.</param>
        /// <returns></returns>
        string SaveAddPrintMediaType(IPrintMediaType printMediaType);
        /// <summary>
        /// Gets the name of the print media type by.
        /// </summary>
        /// <param name="newsPaperName">Name of the news paper.</param>
        /// <returns></returns>
        IPrintMediaType GetPrintMediaTypeByName(string newsPaperName);
        /// <summary>
        /// Gets the print service colors.
        /// </summary>
        /// <returns></returns>
        IList<IPrintServiceColor> GetPrintServiceColors();
        
        /// <summary>
        /// Deletes the print order.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        string DeletePrintOrder(int transactionId);
        /// <summary>
        /// Updates the print transaction.
        /// </summary>
        /// <param name="printTransactionUI">The print transaction UI.</param>
        /// <returns></returns>
        string UpdatePrintTransaction(IPrintTransactionUI printTransactionUI);
        /// <summary>
        /// Deletes the print transaction airing.
        /// </summary>
        /// <param name="PrintTranscationId">The print transcation identifier.</param>
        /// <returns></returns>
        string DeletePrintTransactionAiring(int PrintTranscationId);
        /// <summary>
        /// Saves the print transaction.
        /// </summary>
        /// <param name="printTransactionUI">The print transaction UI.</param>
        /// <param name="PrintTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        string SavePrintTransaction(IPrintTransactionUI printTransactionUI, out int PrintTransactionId);
        /// <summary>
        /// Gets the print transaction airing list.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<IPrintTransactionAiringUI> GetPrintTransactionAiringList(int transactionId);
        /// <summary>
        /// Saves the print transaction airing.
        /// </summary>
        /// <param name="Printview">The printview.</param>
        /// <param name="PrintTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        string SavePrintTransactionAiring(IList<IPrintTransactionAiringUI> Printview, int PrintTransactionId);

        /// <summary>
        /// Gets the selected color by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<IPrintTransactionColor> GetSelectedColorById(int transactionId);

        /// <summary>
        /// Gets the print transaction by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IPrintTransaction GetPrintTransactionById(int transactionId);

        /// <summary>
        /// Gets the print transaction airing by identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<IPrintTransactionAiring> GetPrintTransactionAiringById(int transactionId);


        /// <summary>
        /// Saves the add news paper.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        string SaveAddNewsPaper(INewsPaperView newsPaperInfo);

        /// <summary>
        /// Saves the type of the add print service.
        /// </summary>
        /// <param name="printServiceTypeInfo">The print service type information.</param>
        /// <returns></returns>
        string SaveAddPrintServiceType(IPrintServiceTypeView printServiceTypeInfo);

        /// <summary>
        /// Saves the print service type description.
        /// </summary>
        /// <param name="PrintServiceTypeInfo">The print service type information.</param>
        /// <returns></returns>
        string SavePrintServiceTypeDescription(IPrintServiceTypeView PrintServiceTypeInfo);

        /// <summary>
        /// Deletes the print service type description.
        /// </summary>
        /// <param name="printServiceTypeId">The print service type identifier.</param>
        /// <returns></returns>
        string DeletePrintServiceTypeDescription(int printServiceTypeId);
        /// <summary>
        /// Updates the news paper information.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <returns></returns>
        string UpdateNewsPaperInfo(INewsPaperView newsPaperInfo);
        /// <summary>
        /// Deletes the news paper description.
        /// </summary>
        /// <param name="newsPaperId">The news paper identifier.</param>
        /// <returns></returns>
        string DeleteNewsPaperDescription(int newsPaperId);

        /// <summary>
        /// Saves the add print category.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <returns></returns>
        string SaveAddPrintCategory(IPrintCategoryView printCategoryInfo);
        /// <summary>
        /// Updates the print category description.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <returns></returns>
        string UpdatePrintCategoryDescription(IPrintCategoryView printCategoryInfo);



        /// <summary>
        /// Deletes the print category description.
        /// </summary>
        /// <param name="printCategoryId">The print category identifier.</param>
        /// <returns></returns>
        string DeletePrintCategoryDescription(int printCategoryId);
        /// <summary>
        /// Saves the add print service type price.
        /// </summary>
        /// <param name="printServiceTypePriceInfo">The print service type price information.</param>
        /// <returns></returns>
        string SaveAddPrintServiceTypePrice(IPrintServiceTypePriceView printServiceTypePriceInfo);
        /// <summary>
        /// Saves the print service type price description.
        /// </summary>
        /// <param name="printServiceTypePriceInfo">The print service type price information.</param>
        /// <returns></returns>
        IPrintServiceTypePriceView savePrintServiceTypePriceDescription(IPrintServiceTypePriceView printServiceTypePriceInfo);

       
        string DeletePrintServiceTypePriceDescription(int printServiceTypePriceId);

      
        string SavePrintTransactionPublis(IPrintMediaModelView Printview, int PrintTransactionId);
        string SavePrintTransactionColor(IPrintMediaModelView Printview, int PrintTransactionId);

    
        IList<IPrintTransaction> GetActivePmTransaction(int userId);


        /// <summary>
        /// Gets the name of the news paper description by.
        /// </summary>
        /// <param name="newsPaperName">Name of the news paper.</param>
        /// <returns></returns>
        INewsPaper GetNewsPaperDescriptionByName(string newsPaperName);

        /// <summary>
        /// Gets the name of the print category by.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        IPrintCategory GetPrintCategoryByName(string categoryName);


        /// <summary>
        /// Gets the name of the print service type by.
        /// </summary>
        /// <param name="printServiceType">Type of the print service.</param>
        /// <returns></returns>
        IPrintServiceType GetPrintServiceTypeByName(string printServiceType);
        /// <summary>
        /// Saves the print transaction airing.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        string SavePrintTransactionAiring(IPrintTransactionAiringView view);

        /// <summary>
        /// Updates the print transaction airing.
        /// </summary>
        /// <param name="printInfo">The print information.</param>
        /// <param name="printTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        string UpdatePrintTransactionAiring(IPrintMediaModelView printInfo, int printTransactionId);
        /// <summary>
        /// Updates the color of the print transaction.
        /// </summary>
        /// <param name="printInfo">The print information.</param>
        /// <param name="printTransactionId">The print transaction identifier.</param>
        /// <returns></returns>
        string UpdatePrintTransactionColor(IPrintMediaModelView printInfo, int printTransactionId);
        
        /// <summary>
        /// Gets the type of the service.
        /// </summary>
        /// <param name="newspaper">The newspaper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        IPrintServiceTypePrice GetServiceType(int newspaper, int serviceType,int serviceColorId,int printMediaTypeId);

        /// <summary>
        /// Gets the print transaction airing.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns></returns>
        IList<IPrintTransactionAiring> GetPrintTransactionAiring(int transactionId);

        /// <summary>
        /// Saves the color of the add print service.
        /// </summary>
        /// <param name="printServiceColorView">The print service color view.</param>
        /// <returns></returns>
        string SaveAddPrintServiceColor(IPrintServiceColor printServiceColorView);

        /// <summary>
        /// Gets the name of the print service color description by.
        /// </summary>
        /// <param name="PrintServiceTypeColor">Color of the print service type.</param>
        /// <returns></returns>
        IPrintServiceColor GetPrintServiceColorDescriptionByName(string PrintServiceTypeColor);

        /// <summary>
        /// Deletes the print service color description.
        /// </summary>
        /// <param name="printServiceTypeColorId">The print service type color identifier.</param>
        /// <returns></returns>
        string DeletePrintServiceColorDescription(int printServiceTypeColorId);

        /// <summary>
        /// Updates the print service color information.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <returns></returns>
        string UpdatePrintServiceColorInfo(IPrintServiceColor printServiceColor);

       

        /// <summary>
        /// Gets the name of the art work price description by.
        /// </summary>
        /// <param name="ServiceTypeCode">The service type code.</param>
        /// <returns></returns>
        IOnlineArtworkPrice GetArtWorkPriceDescriptionByName(string ServiceTypeCode);


        /// <summary>
        /// Saves the add art work price.
        /// </summary>
        /// <param name="onlineArtworkPrice">The online artwork price.</param>
        /// <returns></returns>
        string SaveAddArtWorkPrice(IOnlineArtworkPrice onlineArtworkPrice);

        /// <summary>
        /// Updates the art work price information.
        /// </summary>
        /// <param name="onlineArtworkPrice">The online artwork price.</param>
        /// <returns></returns>
        string UpdateArtWorkPriceInfo(IOnlineArtworkPrice onlineArtworkPrice);  

    }
}

