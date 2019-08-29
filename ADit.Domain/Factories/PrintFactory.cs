using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AA.Infrastructure.Extensions;
using ADit.Domain.Utilities;
using ADit.Domain.Models;
using ADit.Repositories.Models;

namespace ADit.Domain.Factories
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IPrintFactory" />
    public class PrintFactory : IPrintFactory
    {

        ///  public IRadioScriptTransactionListView GetRadioScriptTransactionListView(int transactionId, int SentToId, string Ordertitle)
        /// {
        ///    var radio = new RadioScriptTransactionListView
        ///   {
        ///       transactionId = transactionId,
        ///      SentToId = SentToId

        ///    };
        ///    return radio;
        /// }



        public IPrintTransactionView GetPrintTransactionView(int transactionId, int SentToId, string Ordertitle)
        {
            var print = new PrintTransactionView
            {
                PrintTransactionId = transactionId,
                SentToId = SentToId,
                OrderTitle = Ordertitle,

            };
            return print;
        }
        /// <summary>
        /// </summary>
        /// <param name="printView"></param>
        /// <param name="printCategoryList"></param>
        /// <param name="printServiceTypesList"></param>
        /// <param name="newspaperList"></param>
        /// <param name="color"></param>
        /// <param name="designElement"></param>
        /// <param name="durationType"></param>
        /// <param name="apconApprovalType"></param>
        /// <param name="processingMesage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// printView
        /// or
        /// printCategoryList
        /// or
        /// printCategoryList
        /// or
        /// color
        /// or
        /// designElement
        /// </exception>
        public IPrintView CreateUpdatePrintView(IPrintView printView, IList<IPrintCategory> printCategoryList,
            IList<IPrintServiceType> printServiceTypesList, IList<INewsPaper> newspaperList, IList<IColor> color,
            IList<IDesignElement> designElement, IList<IDurationType> durationType,
            IList<IApconApprovalType> apconApprovalType, string processingMesage)
        {
            if (printView == null)
            {
                throw new ArgumentNullException("printView");
            }

            if (printCategoryList == null)
            {
                throw new ArgumentNullException("printCategoryList");
            }

            if (printCategoryList == null)
            {
                throw new ArgumentNullException("printCategoryList");
            }

            if (color == null)
            {
                throw new ArgumentNullException("color");
            }

            if (designElement == null)
            {
                throw new ArgumentNullException("designElement");
            }



            var printCategoryDDL =
                GetDropDownPrintCategoryList.PrintCategoryItems(printCategoryList, printView.PrintCategoryId);
            var printServiceTypeDDL =
                GetDropDownServiceTypeList.PrintServiceTypeItems(printServiceTypesList, printView.PrintServiceTypeId);
            var newspaperDDL = GetDropDownNewspaperList.NewsPaperItems(newspaperList, printView.NewsPaperId);

            var colorDDL = GetDropDownColorList.ColorListItems(color, null);
            var designElementDDL = GetDropDownDesignElementList.DesignElementListItems(designElement, -1);

            printView.PrintServiceTypeList = printServiceTypeDDL;
            printView.PrintCategoryList = printCategoryDDL;
            printView.PrintNewspaperList = newspaperDDL;
            printView.ColorList = colorDDL;
            printView.DesignElementList = designElementDDL;
            printView.ProcessingMessage = processingMesage;

            return printView;
            //throw new NotImplementedException();
        }


        /// <summary>
        /// Gets the print view.
        /// </summary>
        /// <param name="printCategoryList">The print category list.</param>
        /// <param name="printServiceTypesList">The print service types list.</param>
        /// <param name="newspaperList">The newspaper list.</param>
        /// <param name="color">The color.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="apconApprovalType">Type of the apcon approval.</param>
        /// <returns></returns>
        public IPrintView GetPrintView(IList<IPrintCategory> printCategoryList,
            IList<IPrintServiceType> printServiceTypesList, IList<INewsPaper> newspaperList, IList<IColor> color,
            IList<IDesignElement> designElement, IList<IDurationType> durationType,
            IList<IApconApprovalType> apconApprovalType)
        {


            var printCategoryDDL = GetDropDownPrintCategoryList.PrintCategoryItems(printCategoryList, -1);
            var printServiceTypeDDL = GetDropDownServiceTypeList.PrintServiceTypeItems(printServiceTypesList, -1);
            var newspaperDDL = GetDropDownNewspaperList.NewsPaperItems(newspaperList, -1);
            var colorDDL = GetDropDownColorList.ColorListItems(color, null);
            var designElementDDL = GetDropDownDesignElementList.DesignElementListItems(designElement, -1);
            var ApconApprovalDDL = GetDropDownList.ApconApprovalListItems(apconApprovalType, -1);
            var DurationTypeDDL = GetDropDownList.DurationTypeListItems(durationType, "");

            var view = new PrintView
            {
                PrintCategoryList = printCategoryDDL,
                PrintNewspaperList = newspaperDDL,
                PrintServiceTypeList = printServiceTypeDDL,
                ColorList = colorDDL,
                DesignElementList = designElementDDL,
                DurationList = DurationTypeDDL,
                ApconApprovalList = ApconApprovalDDL,

                ProcessingMessage = string.Empty
            };

            return view;
        }

        /// <summary>
        /// Creates the print news paper ListView.
        /// </summary>
        /// <param name="selectedPrintNewsPaperId">The selected print news paper identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="printNewsPaperCollection">The print news paper collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printNewsPaperCollection</exception>
        public IPrintNewsPaperListView CreatePrintNewsPaperListView(int selectedPrintNewsPaperId,
            string selectedDescription, IList<INewsPaper> printNewsPaperCollection, string message)
        {
            if (printNewsPaperCollection == null)
            {
                throw new ArgumentNullException(nameof(printNewsPaperCollection));
            }

            var filteredList = printNewsPaperCollection.Where(x =>
                x.NewsPaperId.Equals(selectedPrintNewsPaperId < 1 ? x.NewsPaperId : selectedPrintNewsPaperId)).ToList();
            filteredList = filteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();

            var returnView = new PrintNewsPaperListView
            {
                SelectedPrintNewsPaperId = selectedPrintNewsPaperId,
                SelectedDescription = selectedDescription,
                PrintNewsPaperCollection = filteredList.ToList(),
                ProcessingMessage = message
            };

            return returnView;
        }









        public IPrintMediaTypeListView CreatePrintMediaTypeListView(int selectedPrintMediaTypeId,
            string selectedDescription, IList<IPrintMediaType> printMediaTypeCollection, string message)
        {

            if (printMediaTypeCollection == null)
            {
                throw new ArgumentNullException(nameof(printMediaTypeCollection));
            }

            var filteredList = printMediaTypeCollection.Where(x =>
                x.PrintMediaTypeId.Equals(selectedPrintMediaTypeId < 1 ? x.PrintMediaTypeId : selectedPrintMediaTypeId)).ToList();
            filteredList = filteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();

            var returnView = new PrintMediaTypeListView
            {
                selectedPrintMediaTypeId = selectedPrintMediaTypeId,
                selectedDescription = selectedDescription,
                GetPrintMediaTypes = filteredList.ToList(),

            };

            return returnView;
        }
        /// <summary>
        /// Creates the print category ListView.
        /// </summary>
        /// <param name="selectedPrintCategoryId">The selected print category identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="printCategoryCollection">The print category collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printCategoryCollection</exception>
        public IPrintCategoryListView CreatePrintCategoryListView(int selectedPrintCategoryId,
            string selectedDescription, IList<IPrintCategory> printCategoryCollection,
            string message)
        {
            if (printCategoryCollection == null)
            {
                throw new ArgumentNullException(nameof(printCategoryCollection));
            }

            var filteredList = printCategoryCollection.Where(x =>
                    x.PrintCategoryId.Equals(selectedPrintCategoryId < 1 ? x.PrintCategoryId : selectedPrintCategoryId))
                .ToList();
            filteredList = filteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();

            var returnView = new PrintCategoryListView
            {
                SelectedPrintCategoryId = selectedPrintCategoryId,
                SelectedDescription = selectedDescription,
                PrintCategoryCollection = filteredList.ToList(),
                ProcessingMessage = message
            };

            return returnView;
        }

        /// <summary>
        /// Creates the print service type ListView.
        /// </summary>
        /// <param name="selectedPrintServiceTypeId">The selected print service type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="printServiceTypeCollection">The print service type collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypeCollection</exception>
        public IPrintServiceTypeListView CreatePrintServiceTypeListView(int selectedPrintServiceTypeId,
            string selectedDescription, IList<IPrintServiceType> printServiceTypeCollection, string message)
        {
            if (printServiceTypeCollection == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypeCollection));
            }

            var filteredList = printServiceTypeCollection.Where(x =>
                x.PrintServiceTypeId.Equals(selectedPrintServiceTypeId < 1
                    ? x.PrintServiceTypeId
                    : selectedPrintServiceTypeId)).ToList();
            filteredList = filteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();
            var returnView = new PrintServiceTypeListView
            {
                SelectedPrintServiceTypeId = selectedPrintServiceTypeId,
                SelectedDescription = selectedDescription,
                PrintServiceTypeCollection = filteredList.ToList(),
                ProcessingMessage = message
            };

            return returnView;
        }

        /// <summary>
        /// Creates the print service type price ListView.
        /// </summary>
        /// <param name="selectedPrintServiceTypePriceId">The selected print service type price identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="printServiceTypePriceCollection">The print service type price collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypePriceCollection</exception>
        public IPrintServiceTypePriceListView CreatePrintServiceTypePriceListView(int selectedPrintServiceTypePriceId,
            string selectedDescription, IList<IPrintServiceTypePrice> printServiceTypePriceCollection, string message)
        {
            if (printServiceTypePriceCollection == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypePriceCollection));
            }

            var filteredList = printServiceTypePriceCollection.Where(x =>
                x.PrintServiceTypePriceId.Equals(selectedPrintServiceTypePriceId < 1
                    ? x.PrintServiceTypePriceId
                    : selectedPrintServiceTypePriceId)).ToList();
            filteredList = filteredList.Where(x => x.NewspaperDescription.Contains(string.IsNullOrEmpty(selectedDescription) ? x.NewspaperDescription : selectedDescription)).ToList();
            var returnView = new PrintServiceTypePriceListView
            {
                SelectedPrintServiceTypePriceId = selectedPrintServiceTypePriceId,
                SelectedDescription = selectedDescription,
                PrintServiceTypePriceCollection = filteredList.ToList(),
                ProcessingMessage = message
            };

            return returnView;
        }


        /// <summary>
        /// Creates the print serice type view.
        /// </summary>
        /// <returns></returns>
        public IPrintServiceTypeView CreatePrintSericeTypeView()
        {
            var returnView = new PrintServiceTypeView
            {
            };

            return returnView;
        }

        /// <summary>
        /// Creates the print service type view.
        /// </summary>
        /// <param name="printServiceTypeInfo">The print service type information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypeInfo</exception>
        public IPrintServiceTypeView CreatePrintServiceTypeView(IPrintServiceTypeView printServiceTypeInfo,
            string processingMessage)
        {
            if (printServiceTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypeInfo));
            }

            var returnView = new PrintServiceTypeView
            {
                Description = printServiceTypeInfo.Description,
                ProcessingMessage = printServiceTypeInfo.ProcessingMessage ?? ""
            };

            return returnView;
        }


        /// <summary>
        /// Creates the edit print serice type view.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        public IPrintServiceTypeView CreateEditPrintSericeTypeView(IPrintServiceTypeView printServiceTypeView,
            string description)
        {
            var returnView = new PrintServiceTypeView
            {
                Description = description,
                PrintServiceTypeId = printServiceTypeView.PrintServiceTypeId,
                IsActive = printServiceTypeView.IsActive
            };

            return returnView;
        }

        /// <summary>
        /// Creates the news paper view.
        /// </summary>
        /// <returns></returns>
        public INewsPaperView CreateNewsPaperView()
        {
            var returnView = new NewsPaperView
            {
            };

            return returnView;
        }



        /// <summary>
        /// Creates the news paper view.
        /// </summary>
        /// <returns></returns>
        public IPrintMediaType CreatePrintMediaView()
        {
            var returnView = new PrintMediaTypeView
            {
            };

            return returnView;
        }


        /// <summary>
        /// Creates the news paper view.
        /// </summary>
        /// <param name="newsPaperInfo">The news paper information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperInfo</exception>
        public INewsPaperView CreateNewsPaperView(INewsPaperView newsPaperInfo, string processingMessage)
        {
            if (newsPaperInfo == null)
            {
                throw new ArgumentNullException(nameof(newsPaperInfo));
            }

            var returnView = new NewsPaperView
            {
                Description = newsPaperInfo.Description,
                ProcessingMessage = newsPaperInfo.ProcessingMessage ?? ""
            };

            return returnView;
        }

        /// <summary>
        /// Creates the edit news paper view.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        public INewsPaperView CreateEditNewsPaperView(INewsPaperView newsPaperView, string description)
        {
            var returnView = new NewsPaperView
            {
                Description = description,
                NewsPaperId = newsPaperView.NewsPaperId,
                IsActive = newsPaperView.IsActive
            };

            return returnView;
        }



        /// Creates the edit news paper view.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        public IPrintMediaType CreateEditPrintMediaTypeView(IPrintMediaType printMediaType, string description)
        {
            var returnView = new PrintMediaTypeView
            {
                Description = description,
                PrintMediaTypeId = printMediaType.PrintMediaTypeId,
                IsActive = printMediaType.IsActive
            };

            return returnView;
        }




        /// <summary>
        /// Creates the print category view.
        /// </summary>
        /// <returns></returns>
        public IPrintCategoryView CreatePrintCategoryView()
        {
            var returnView = new PrintCategoryView
            {
            };

            return returnView;
        }

        /// <summary>
        /// Creates the print category view.
        /// </summary>
        /// <param name="printCategoryInfo">The print category information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printCategoryInfo</exception>
        public IPrintCategoryView CreatePrintCategoryView(IPrintCategoryView printCategoryInfo,
            string processingMessage)
        {
            if (printCategoryInfo == null)
            {
                throw new ArgumentNullException(nameof(printCategoryInfo));
            }

            var returnView = new PrintCategoryView
            {
                Description = printCategoryInfo.Description,
                ProcessingMessage = printCategoryInfo.ProcessingMessage ?? ""
            };

            return returnView;
        }

        /// <summary>
        /// Creates the edit print category view.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        public IPrintCategoryView CreateEditPrintCategoryView(IPrintCategoryView printCategoryView, string description)
        {
            var returnView = new PrintCategoryView
            {
                Description = description,
                PrintCategoryId = printCategoryView.PrintCategoryId,
                IsActive = printCategoryView.IsActive
            };

            return returnView;
        }


        /// <summary>
        /// Creates the add print serice type price view.
        /// </summary>
        /// <param name="printServiceTypeList">The print service type list.</param>
        /// <param name="newspaperList">The newspaper list.</param>
        /// <returns></returns>
        public IPrintServiceTypePriceView CreateAddPrintSericeTypePriceView(
            IList<IPrintServiceType> printServiceTypeList, IList<INewsPaper> newspaperList, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes)
        {
            var printServiceTypeDDL = GetDropDownServiceTypeList.PrintServiceTypeItems(printServiceTypeList, -1);
            var newsPaperDDL = GetDropDownNewspaperList.NewsPaperItems(newspaperList, -1);
            var printColorDDl = GetDropDownPrintServiceColors.PrintServiceColorItems(printServiceColors, -1);
            var printMediatypeDDl = GetDropDownPrintServiceColors.PrintMediaTypeItems(printMediaTypes, -1);
            var returnView = new PrintServiceTypePriceView
            {
                PrintServiceTypeCollection = printServiceTypeDDL,
                PrintNewsPaperCollection = newsPaperDDL,
                PrintServiceColorCollection = printColorDDl,
                PrintMediaTypeCollection = printMediatypeDDl
            };

            return returnView;
        }


        /// <summary>
        /// Creates the update add print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceInfo">The print service type price information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypePriceInfo</exception>
        public IPrintServiceTypePriceView CreateUpdateAddPrintServiceTypePriceView(
            IPrintServiceTypePriceView printServiceTypePriceInfo, string processingMessage)
        {
            if (printServiceTypePriceInfo == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypePriceInfo));
            }

            var returnView = new PrintServiceTypePriceView
            {
                Comment = printServiceTypePriceInfo.Comment, //comment appers on table as description
                Amount = printServiceTypePriceInfo.Amount,
                ProcessingMessage = printServiceTypePriceInfo.ProcessingMessage ?? ""
            };

            return returnView;
        }


        /// <summary>
        /// Creates the edit print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="printServiceTypeList">The print service type list.</param>
        /// <param name="newspaperList">The newspaper list.</param>
        /// <param name="printServicePrice">The print service price.</param>
        /// <returns></returns>
        public IPrintServiceTypePriceView CreateEditPrintServiceTypePriceView(
            IPrintServiceTypePriceView printServiceTypePriceView, IList<IPrintServiceType> printServiceTypeList,
            IList<INewsPaper> newspaperList, IPrintServiceTypePrice printServicePrice, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes)
        {
            var printServiceTypeDDL =
                GetDropDownServiceTypeList.PrintServiceTypeItems(printServiceTypeList,
                    printServicePrice.PrintServiceTypeId);
            var newsPaperDDL = GetDropDownNewspaperList.NewsPaperItems(newspaperList, printServicePrice.NewsPaperId);
            var printColor = GetDropDownPrintServiceColors.PrintServiceColorItems(printServiceColors, printServicePrice.PrintServiceColorId ?? -1);
            var printMediaTypeDDL = GetDropDownPrintServiceColors.PrintMediaTypeItems(printMediaTypes, printServicePrice.PrintMediaTypeId);
            var returnView = new PrintServiceTypePriceView
            { PrintServiceColorCollection = printColor,
                PrintServiceTypeCollection = printServiceTypeDDL,
                PrintNewsPaperCollection = newsPaperDDL,
                Comment = printServicePrice.Comment,
                Amount = printServicePrice.Amount,
                IsActive = printServicePrice.IsActive,
                DateInactive = printServicePrice.DateInactive,
                PrintServiceTypeId = printServicePrice.PrintServiceTypeId,
                PrintServiceTypePriceId = printServicePrice.PrintServiceTypePriceId,
                NewsPaperId = printServicePrice.NewsPaperId,
                EffectiveDate = printServicePrice.EffectiveDate,
                DateCreated = printServicePrice.DateCreated,
                PrintMediaTypeCollection = printMediaTypeDDL,
                PrintServiceColorId = printServicePrice.PrintServiceColorId,
                PrintMediaTypeId = printServicePrice.PrintMediaTypeId,
            };

            return returnView;
        }

        /// <summary>
        /// Creates the delete print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        public IPrintServiceTypePriceView CreateDeletePrintServiceTypePriceView(
            IPrintServiceTypePriceView printServiceTypePriceView, IPrintServiceTypePrice description)
        {
            var returnView = new PrintServiceTypePriceView
            {
                Comment = printServiceTypePriceView.Comment,
                Amount = printServiceTypePriceView.Amount,
                IsActive = printServiceTypePriceView.IsActive,
                PrintServiceTypePriceId = printServiceTypePriceView.PrintServiceTypePriceId
            };

            return returnView;
        }



        /// <summary>
        /// Gets the print view factory.
        /// </summary>
        /// <param name="apconApprovalTypePrice">The price.</param>
        /// <param name="designelementPrice">The designelement.</param>
        /// <param name="printcategory">The printcategory.</param>
        /// <param name="newspaperList">The newspaper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price
        /// or
        /// designelement
        /// or
        /// printcategory
        /// or
        /// newspaper
        /// or
        /// serviceType
        /// or
        /// durationType</exception>
        public IPrintMediaModelView GetPrintViewFactory(IList<IApconApprovalTypePrice> apconApprovalTypePrice,
            IList<IDesignElementPrice> designelementPrice,
            IList<IPrintCategory> printcategory, IList<INewsPaper> newspaperList,
            IList<IPrintServiceType> serviceType,
            IList<IDurationType> durationType, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes)
        {
            if (apconApprovalTypePrice == null)
            {
                throw new ArgumentNullException("apconApprovalTypePrice");
            }

            if (designelementPrice == null)
            {
                throw new ArgumentNullException("designelementPrice");
            }

            if (printcategory == null)
            {
                throw new ArgumentNullException("printcategory");
            }


            if (newspaperList == null)
            {
                throw new ArgumentNullException("newspaperList");
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            if (durationType == null)
            {
                throw new ArgumentNullException("durationType");
            }



            var apconPriceDDL = GetDropDownBrandingMaterialList.PrintMediaApconPriceItems(apconApprovalTypePrice, -1);
            var designElementPriceDDL = GetDropDownBrandingMaterialList.PrintMediaDesignElementItems(designelementPrice, -1);
            var printCategoiesDDL = GetDropDownPrintCategoryList.PrintCategoryItems(printcategory, -1);
            var newspaperDLL = GetDropDownNewspaperList.NewsPaperItems(newspaperList, -1);
            var serviceTypeDDL = GetDropDownServiceTypeList.PrintServiceTypeItems(serviceType, -1);
            var durationDDL = GetDropdownDurationTypeList.DurationTypeListItems(durationType, "");
            var printColorDDl = GetDropDownPrintServiceColors.PrintServiceColorItems(printServiceColors, -1);
            var printMediaTypeDDL = GetDropDownPrintServiceColors.PrintMediaTypeItems(printMediaTypes, -1);
            var printAiringList = new List<IPrintTransactionAiringUI>();

            foreach (var a in newspaperList)
            {
                var printAiring = new PrintTransactionAiringUI
                {
                    NewsPaperId = a.NewsPaperId,
                    IsSelected = false
                };
                printAiringList.Add(printAiring);

            }

            var views = new PrintMediaModelView
            {
                ApconApprovalCollectionList = apconPriceDDL,
                DesignElementType = designElementPriceDDL,
                PrintCategoryType = printCategoiesDDL,
                PrintMediaTypeList = printMediaTypeDDL,
                NewspaperType = newspaperDLL,
                PrintServiceType = serviceTypeDDL,
                DurationType = durationDDL,
                NewsPaperList = newspaperList,
                AiringDetailsList = printAiringList,
                ServiceColorDDl = printColorDDl,

            };
            return views;
        }


        /// <summary>
        /// Gets the print view factory.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="designelement">The designelement.</param>
        /// <param name="printcategory">The printcategory.</param>
        /// <param name="newspaper">The newspaper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="ApconApprovalType">Type of the apcon approval.</param>
        /// <param name="message">The message.</param>
        /// <param name="printTransactionAiringUIs">The print transaction airing u is.</param>
        /// <param name="printTransactionUI">The print transaction UI.</param>
        /// <param name="SelectedNewspapersId">The selected newspapers identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// price
        /// or
        /// designelement
        /// or
        /// printcategory
        /// or
        /// newspaper
        /// or
        /// serviceType
        /// or
        /// durationType
        /// </exception>
        public IPrintMediaModelView GetPrintViewFactory(IList<IApconApprovalTypePrice> price, IList<IDesignElement> designelement,
           IList<IPrintCategory> printcategory, IList<INewsPaper> newspaper, IList<IPrintServiceType> serviceType,
           IList<IDurationType> durationType, IList<IApconApprovalType> ApconApprovalType, string message, IEnumerable<IPrintTransactionAiringUI> printTransactionAiringUIs, IPrintTransactionUI printTransactionUI, IList<int> SelectedNewspapersId, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            if (designelement == null)
            {
                throw new ArgumentNullException("designelement");
            }

            if (printcategory == null)
            {
                throw new ArgumentNullException("printcategory");
            }


            if (newspaper == null)
            {
                throw new ArgumentNullException("newspaper");
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            if (durationType == null)
            {
                throw new ArgumentNullException("durationType");
            }

            var printCateoryDDL = GetDropDownPrintCategoryList.PrintCategoryItems(printcategory, printTransactionUI.PrintCategoryId);
            var apconApprovalTypeDDl = GetDropDownList.ApconApprovalListItems(ApconApprovalType, printTransactionUI.ApconApprovalTypeId);
            var designElementDDl = GetDropDownDesignElementList.DesignElementListItems(designelement, printTransactionUI.DesignElementId);
            var serviceTypeDDL = GetDropDownServiceTypeList.PrintServiceTypeItems(serviceType, -1);
            var serviceColor = GetDropDownPrintServiceColors.PrintServiceColorItems(printServiceColors, -1);
            var printMediaDDL = GetDropDownPrintServiceColors.PrintMediaTypeItems(printMediaTypes, -1);
            printTransactionAiringUIs.Each(x => x.IsSelected = SelectedNewspapersId.Contains(x.NewsPaperId));
            var updatedAiringList = printTransactionAiringUIs.ToList();

            var view = new PrintMediaModelView
            {
                AiringInstruction = printTransactionUI.AiringInstruction,
                ApconAmount = printTransactionUI.ApconAmount,
                PrintCategoryType = printCateoryDDL,
                ApconApprovalCollectionList = apconApprovalTypeDDl,
                DesignElementType = designElementDDl,
                ApconApprovalId = printTransactionUI.ApconApprovalTypeId,
                ApconApprovalNumber = printTransactionUI.ApconApprovalNumber,
                ApconApprovalTypePriceId = printTransactionUI.ApconApprovalTypePriceId,
                OrderTitle = printTransactionUI.OrderTitle,
                ColorDescription = printTransactionUI.ColorDescription,
                DesignElementPriceId = printTransactionUI.DesignElementPriceId,
                AiringDetailsList = updatedAiringList,
                NewsPaperList = newspaper,
                DesignElementAmount = printTransactionUI.DesignElementAmount,
                TotalAmount = printTransactionUI.TotalAmount,
                PrintServiceType = serviceTypeDDL,
                ServiceColorDDl = serviceColor,
                PrintMediaTypeList = printMediaDDL,




            };
            return view;
        }

        /// <summary>
        /// Gets the apcon price views.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price</exception>
        public IPrintMediaModelView GetApconPriceViews(IApconApprovalTypePrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException(nameof(price));
            }

            var view = new PrintMediaModelView
            {
                ApconAmount = price.Amount,
                ApconApprovalTypePriceId = price.ApconTypePriceId,

                IsActive = price.IsActive,
                DateCreated = price.DateCreated,
                EffectiveDate = price.EffectiveDate,
                DateInactive = price.DateInactive,
                ApconApprovalId = price.ApconTypeId,
                Comment = price.Comment
            };
            return view;
        }

        /// <summary>
        /// Gets the design element views.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">price</exception>
        public IPrintMediaModelView GetDesignElementViews(IDesignElementPrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            var view = new PrintMediaModelView
            {
                DesignElementAmount = price.Amount,
                DesignElementPriceId = price.DesignElementPriceId
            };
            return view;
        }

        /// <summary>
        /// Creates the print transaction view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="selectedPrintTransactionId">The selected print transaction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">view</exception>
        public IPrintMediaModelViewList CreatePrintTransactionView(IList<IPrintTransaction> view,
            int selectedPrintTransactionId)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            //search by production price Id
            var filteredList = view.Where(x =>
                x.PrintTransactionId.Equals(selectedPrintTransactionId < 1
                    ? x.PrintTransactionId
                    : selectedPrintTransactionId)).ToList();


            var returnView = new PrintMediaModelViewList
            {
                printCollection = filteredList.ToList(),
            };
            return returnView;
        }

        /// <summary>
        /// Edits the print view.
        /// </summary>
        /// <param name="apconApprovalTypePrices">The apcon approval type prices.</param>
        /// <param name="designelement">The designelement.</param>
        /// <param name="printcategory">The printcategory.</param>
        /// <param name="color">The color.</param>
        /// <param name="newsPapersLists">The news papers lists.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="printTransaction">The print transaction.</param>
        /// <param name="printTransactionAiring">The print transaction airing.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">apconApprovalTypePrices
        /// or
        /// designelement
        /// or
        /// printcategory
        /// or
        /// color
        /// or
        /// newsPapersLists
        /// or
        /// serviceType
        /// or
        /// printTransaction
        /// or
        /// durationType</exception>
        public IPrintMediaModelView EditPrintView(IList<IApconApprovalTypePrice> price, IList<IApconApprovalType> apconApprovalTypes, IList<IDesignElementPrice> designelement,
            IList<IPrintCategory> printcategory, IList<IColor> color, IList<INewsPaper> newspaper, IList<IPrintServiceType> serviceType,
            IList<IDurationType> durationType, IPrintTransaction printTransaction,
            IEnumerable<IPrintTransactionAiringUI> transactionAiring, List<int> selectedPrintNewsPapersIds, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes)
        {
            if (price == null)
            {
                throw new ArgumentNullException(nameof(price));
            }

            if (designelement == null)
            {
                throw new ArgumentNullException(nameof(designelement));
            }

            if (printcategory == null)
            {
                throw new ArgumentNullException(nameof(printcategory));
            }

            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }

            if (newspaper == null)
            {
                throw new ArgumentNullException(nameof(newspaper));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (printTransaction == null)
            {
                throw new ArgumentNullException(nameof(printTransaction));
            }

            if (durationType == null)
            {
                throw new ArgumentNullException(nameof(durationType));
            }


            int[] colorID = { };


            var ApconPriceDDL = GetDropDownBrandingMaterialList.PrintMediaApconPriceItems(price,
                printTransaction.ApconApprovalTypePriceId ?? -1);
            var DesignElementPriceDDL =
                GetDropDownBrandingMaterialList.PrintMediaDesignElementItems(designelement,
                    printTransaction.DesignElementId);
            var CategoryDDL = GetDropDownPrintCategoryList.PrintCategoryItems(printcategory, -1);
            var ApconTypeDDl = GetDropDownList.ApconApprovalListItems(apconApprovalTypes, printTransaction.ApconApprovalTypeId);

            var ServiceTypeDDL = GetDropDownServiceTypeList.PrintServiceTypeItems(serviceType, -1);
            var DurationDDL = GetDropdownDurationTypeList.DurationTypeListItems(durationType, "");
            var printColorDDl = GetDropDownPrintServiceColors.PrintServiceColorItems(printServiceColors, -1);

            var printMediaTypeDDL = GetDropDownPrintServiceColors.PrintMediaTypeItems(printMediaTypes, -1);


            //Checking for Selected Print NewsPaper and Set IsSelected to true if a NewsPaper is selected
            transactionAiring.Each(x => x.IsSelected = selectedPrintNewsPapersIds.Contains(x.NewsPaperId));


            var updatedAiringList = transactionAiring.ToList();


            foreach (var r in newspaper)
            {
                if (!selectedPrintNewsPapersIds.Contains(r.NewsPaperId))
                {
                    var aTran = new PrintTransactionAiringUI
                    {
                        NewsPaperId = r.NewsPaperId,
                        IsSelected = false
                    };

                    updatedAiringList.Add(aTran);
                }
            }



            var view = new PrintMediaModelView
            {
                ApconApprovalNumber = printTransaction.ApconApprovalNumber,
                OrderTitle = printTransaction.OrderTitle,
                PrintTransactionId = printTransaction.PrintTransactionId,
                ApconApprovalCollectionList = ApconTypeDDl,
                DesignElementType = DesignElementPriceDDL,
                PrintCategoryType = CategoryDDL,
                NewsPaperList = newspaper,
                AiringInstruction = printTransaction.AiringInstruction,
                PrintServiceType = ServiceTypeDDL,
                DurationType = DurationDDL,
                DesignElementAmount = printTransaction.DesignAmount,
                ApconAmount = printTransaction.ApconApprovalAmount,
                OrdeId = printTransaction.OrderId,
                IsHaveMaterial = printTransaction.IsHaveMaterial,
                MaterialDigitalFileId = printTransaction.MaterialDigitalFileId,
                ApconApprovalId = printTransaction.ApconApprovalTypeId,
                ApconApprovalTypePriceId = printTransaction.ApconApprovalTypePriceId,
                PrintCategoryId = printTransaction.PrintCategoryId,
                DesignElementId = printTransaction.DesignElementId,
                Duration = printTransaction.DurationTypeCode,
                DurationQuantity = printTransaction.DurationQuantity,
                TotalAmount = printTransaction.TotalPrice,
                ColorDescription = printTransaction.ColorDescription,
                ColorId = printTransaction.ColorId,
                ApconApprovalTypeId = printTransaction.ApconApprovalTypeId ?? -1,
                AiringDetailsList = updatedAiringList,
                PrintFileDescription = printTransaction.PrintFileDescription,
                ServiceColorDDl = printColorDDl,
                PrintMediaTypeList = printMediaTypeDDL,

            };
            return view;
        }

        /// <summary>
        /// Gets the updated print service type price view.
        /// </summary>
        /// <param name="printServiceTypePriceView">The print service type price view.</param>
        /// <param name="newsPaper">The news paper.</param>
        /// <param name="printServiceType">Type of the print service.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypePriceView</exception>
        public IPrintServiceTypePriceView GetUpdatedPrintServiceTypePriceView(
            IPrintServiceTypePriceView printServiceTypePriceView, IList<INewsPaper> newsPaper,
            IList<IPrintServiceType> printServiceType, IList<IPrintServiceColor> printServiceColors, IList<IPrintMediaType> printMediaTypes)
        {
            if (printServiceTypePriceView == null)
            {
                throw new ArgumentNullException(nameof(printServiceTypePriceView));
            }

            var printServiceTypeDDL =
                GetDropDownServiceTypeList.PrintServiceTypeItems(printServiceType,
                    printServiceTypePriceView.PrintServiceTypeId);

            var printmediaTypeDDL =
                GetDropDownPrintServiceColors.PrintMediaTypeItems(printMediaTypes, printServiceTypePriceView.PrintMediaTypeId);
            var newsPaperDDL =
                GetDropDownNewspaperList.NewsPaperItems(newsPaper, printServiceTypePriceView.NewsPaperId);
            var printColor = GetDropDownPrintServiceColors.PrintServiceColorItems(printServiceColors, printServiceTypePriceView.PrintServiceColorId ?? -1);
            printServiceTypePriceView.PrintServiceTypeCollection = printServiceTypeDDL;
            printServiceTypePriceView.PrintNewsPaperCollection = newsPaperDDL;
            printServiceTypePriceView.PrintMediaTypeCollection = printmediaTypeDDL;
            return printServiceTypePriceView;
        }

        /// <summary>
        /// Gets the updated news paper view.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperView</exception>
        public INewsPaperView getUpdatedNewsPaperView(INewsPaperView newsPaperView, string message)
        {
            if (newsPaperView == null)
            {
                throw new ArgumentNullException("newsPaperView");
            }

            var view = new NewsPaperView
            {
                ProcessingMessage = message,
                Description = newsPaperView.Description,
                NewsPaperId = newsPaperView.NewsPaperId,
            };
            return view;
        }





        /// <summary>
        /// Gets the updated news paper view.
        /// </summary>
        /// <param name="newsPaperView">The news paper view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">newsPaperView</exception>
        public IPrintMediaType getUpdatedPrintMediaType(IPrintMediaType printMediaType, string message)
        {
            if (printMediaType == null)
            {
                throw new ArgumentNullException("printMediaType");
            }

            var view = new PrintMediaTypeView
            {

                Description = printMediaType.Description,
                PrintMediaTypeId = printMediaType.PrintMediaTypeId,
            };
            return view;
        }


        /// <summary>
        /// Gets the updated print category view.
        /// </summary>
        /// <param name="printCategoryView">The print category view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printCategoryView</exception>
        public IPrintCategoryView getUpdatedPrintCategoryView(IPrintCategoryView printCategoryView, string message)
        {
            if (printCategoryView == null)
            {
                throw new ArgumentNullException("printCategoryView");
            }

            var view = new PrintCategoryView
            {
                ProcessingMessage = message,
                Description = printCategoryView.Description,
                PrintCategoryId = printCategoryView.PrintCategoryId,
            };
            return view;
        }

        /// <summary>
        /// Gets the updated print service type view.
        /// </summary>
        /// <param name="printServiceTypeView">The print service type view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceTypeView</exception>
        public IPrintServiceTypeView getUpdatedPrintServiceTypeView(IPrintServiceTypeView printServiceTypeView,
            string message)
        {
            if (printServiceTypeView == null)
            {
                throw new ArgumentNullException("printServiceTypeView");
            }

            var view = new PrintServiceTypeView
            {
                ProcessingMessage = message,
                PrintServiceTypeId = printServiceTypeView.PrintServiceTypeId,
                Description = printServiceTypeView.Description,
                IsActive = printServiceTypeView.IsActive,
            };
            return view;
        }


        /// <summary>
        /// Generates the airing view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="newsPaper">The news paper.</param>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IPrintTransactionAiringView GenerateAiringView(int Id, IList<INewsPaper> newsPaper,
            IList<IPrintServiceType> serviceType, string message)
        {
            //Get Items dropdown from database
            var newsList = GetDropDownNewspaperList.NewsPaperItems(newsPaper, -1);
            var serviceTypeList = GetDropDownServiceTypeList.PrintServiceTypeItems(serviceType, -1);

            var modelView = new PrintTransactionAiringView
            {
                PrintTransactionId = Id,
                ServiceTypeCodeList = serviceTypeList,
                NewspaperList = newsList,
                ProcessingMessage = message
            };

            return modelView;
        }


        /// <summary>
        /// Gets the user print transaction.
        /// </summary>
        /// <param name="printTransaction">The print transaction.</param>
        /// <param name="printTransactionAirings">The print transaction airings.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printTransaction</exception>
        public IPrintMediaModelView GetUserPrintTransaction(IPrintTransaction printTransaction, IList<IPrintTransactionAiring> printTransactionAirings)
        {
            if (printTransaction == null)
            {
                throw new ArgumentNullException(nameof(printTransaction));
            }
            List<string> NewspaperList = new List<string>();
            List<string> PrintServciceTypeList = new List<string>();
            List<int> NumberOfInsertList = new List<int>();
            List<decimal> PricesList = new List<decimal>();

            foreach (var j in printTransactionAirings)
            {
                NewspaperList.Add(j.Newspaper);
                PrintServciceTypeList.Add(j.PrintServiceType);
                NumberOfInsertList.Add(j.NumberOfInserts);
                PricesList.Add(j.Price);

            }

            var view = new PrintMediaModelView
            {
                ApconAmount = printTransaction.ApconApprovalAmount,
                Name = printTransaction.Name,
                Email = printTransaction.Email,
                PhoneNumber = printTransaction.PhoneNumber,
                MaterialDigitalFileId = printTransaction.MaterialDigitalFileId,
                OrderTitle = printTransaction.OrderTitle,
                ApconType = printTransaction.ApconType,
                ApconApprovalNumber = printTransaction.ApconApprovalNumber,
                Category = printTransaction.Category,
                DesignElement = printTransaction.DesignElement,
                DesignElementAmount = printTransaction.DesignAmount,
                DurationTypes = printTransaction.DurationType,
                NewspapersList = NewspaperList,
                PrintServciceTypeList = PrintServciceTypeList,
                NummberOfInsertList = NumberOfInsertList,
                PricesList = PricesList,
                TotalAmount = printTransaction.TotalPrice,

            };
            return view;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <!-- Badly formed XML comment ignored for member "M:ADit.Interfaces.IPrintFactory.CreatePrintServiceColorView" -->
        public IPrintServiceColor CreatePrintServiceColorView()
        {
            var returnView = new PrintServiceColorView
            {
            };

            return returnView;
        }

        /// <summary>
        /// Gets the color of the updated print service.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceColorView</exception>
        public IPrintServiceColor GetUpdatedPrintServiceColor(IPrintServiceColor printServiceColor, string message)
        {
            if (printServiceColor == null)
            {
                throw new ArgumentNullException("printServiceColorView");
            }

            var view = new PrintServiceColorView
            {

                PrintServiceTypeColor = printServiceColor.PrintServiceTypeColor,
                PrintServiceTypeColorId = printServiceColor.PrintServiceTypeColorId,
            };
            return view;
        }


        /// <summary>
        /// Creates the print service color ListView.
        /// </summary>
        /// <param name="SelectedPrintServiceTypeColorId">The selected print service type color identifier.</param>
        /// <param name="SelectedPrintServiceTypeColor">Color of the selected print service type.</param>
        /// <param name="printServiceColorCollection">The print service color collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">printServiceColorCollection</exception>
        public IPrintServiceColorListView CreatePrintServiceColorListView(int? SelectedPrintServiceTypeColorId, string SelectedPrintServiceTypeColor, IList<IPrintServiceColor> printServiceColorCollection, string message)
        {
            if (printServiceColorCollection == null)
            {
                throw new ArgumentNullException(nameof(printServiceColorCollection));
            }

            var filteredList = printServiceColorCollection.Where(x =>
                x.PrintServiceTypeColorId.Equals(SelectedPrintServiceTypeColorId < 1 ? x.PrintServiceTypeColorId : SelectedPrintServiceTypeColorId ?? 0)).ToList();
            filteredList = filteredList.Where(x =>
                    x.PrintServiceTypeColor.Contains(string.IsNullOrEmpty(SelectedPrintServiceTypeColor)
                        ? x.PrintServiceTypeColor
                        : SelectedPrintServiceTypeColor))
                .ToList();

            var returnView = new PrintServiceColorListView
            {
                SelectedPrintServiceTypeColorId = SelectedPrintServiceTypeColorId ?? 0,
                SelectedPrintServiceTypeColor = SelectedPrintServiceTypeColor,
                GetPrintServiceColor = filteredList.ToList(),

            };

            return returnView;
        }


        /// <summary>
        /// Creates the edit print service color view.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <returns></returns>
        public IPrintServiceColor CreateEditPrintServiceColorView(IPrintServiceColor printServiceColor)
        {
            var returnView = new PrintServiceColorView
            {
                
                PrintServiceTypeColorId = printServiceColor.PrintServiceTypeColorId,
                PrintServiceTypeColor = printServiceColor.PrintServiceTypeColor,
                IsActive = printServiceColor.IsActive
            };

            return returnView;
        }


        /// <summary>
        /// Creates the delete print service type color view.
        /// </summary>
        /// <param name="printServiceColor">Color of the print service.</param>
        /// <returns></returns>
        public IPrintServiceColor CreateDeletePrintServiceTypeColorView(IPrintServiceColor printServiceColor)
        { 
             var returnView = new PrintServiceColorView
             {
                 PrintServiceTypeColorId = printServiceColor.PrintServiceTypeColorId,
                 PrintServiceTypeColor = printServiceColor.PrintServiceTypeColor,
                 IsActive = printServiceColor.IsActive
             };

            return returnView;
        }


     


        /// <summary>
        /// Creates the art work price ListView.
        /// </summary>
        /// <param name="SelectedArtWorkPriceId">The selected art work price identifier.</param>
        /// <param name="SelectedDescription">The selected description.</param>
        /// <param name="ArtWorkPriceCollection">The art work price collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IOnlineArtworkPriceListView CreateArtWorkPriceListView(int? SelectedArtWorkPriceId, string SelectedDescription, IList<IOnlineArtworkPrice> ArtWorkPriceCollection, string message)
        {
            if (ArtWorkPriceCollection == null)
            {
                throw new ArgumentNullException(nameof(ArtWorkPriceCollection));
            }

            var filteredList = ArtWorkPriceCollection.Where(x =>
                x.ArtWorkPriceId.Equals(SelectedArtWorkPriceId < 1 ? x.ArtWorkPriceId : SelectedArtWorkPriceId ?? 0)).ToList();
            filteredList = filteredList.Where(x =>
                    x.ServiceTypeCode.Contains(string.IsNullOrEmpty(SelectedDescription)
                        ? x.ServiceTypeCode
                        : SelectedDescription))
                .ToList();

            var returnView = new OnlineArtworkPriceListView
            {
                SelectedArtworkPriceId = SelectedArtWorkPriceId ?? 0,
                SelectedDescription = SelectedDescription,
                GetArtWorkPrice = filteredList.ToList(),

            };

            return returnView;
        }

        
    }
}
