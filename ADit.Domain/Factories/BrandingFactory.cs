using ADit.Domain.Models;
using ADit.Domain.Utilities;
using ADit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADit.Domain.Factories
{
    public class BrandingFactory : IBrandingFactory
    {


       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandingView"></param>
        /// <param name="brandingMaterial"></param>
        /// <param name="color"></param>
        /// <param name="designElement"></param>
        /// <param name="ProcessingMessage"></param>
        /// <returns></returns>
        /// 
        public IBrandingView CreateUpdateBrandingView(IBrandingView brandingView,
            IList<IBrandingMaterial> brandingMaterial, IList<IColor> color, IList<IDesignElementPrice> designElement,
            string ProcessingMessage)
        {
            if (brandingView == null)
            {
                throw new ArgumentNullException("brandingTransactionView");
            }

            //int[] colorID = { };

            var brandingMaterialDDL =
                GetDropDownBrandingMaterialList.BrandingMaterialListItems(brandingMaterial, brandingView.BrandingMaterialId);
            var colorDDL = GetDropDownColorList.ColorListItems(color, brandingView.ColorId);
            var DesignElementDDL = GetDropDownBrandingMaterialList.PrintMediaDesignElementItems(designElement ,brandingView.DesignElementId);


            brandingView.MaterialList = brandingMaterialDDL;
            brandingView.ColorList = colorDDL;
            brandingView.DesignElementList = DesignElementDDL;

            return brandingView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandingMaterial"></param>
        /// <param name="color"></param>
        /// <param name="designElement"></param>
        /// <returns></returns>
        /// 
        //this is the view that gets the branding view initially when a user wants to get services
        public IBrandingView GetBrandingView(IList<IBrandingMaterialPrice> brandingMaterial, IList<IColor> color,
            IList<IDesignElementPrice> designElement)
        {
            if (brandingMaterial == null)
            {
                throw new ArgumentNullException("brandingMaterial");
            }

            if (color == null)
            {
                throw new ArgumentNullException("color");
            }

            if (designElement == null)
            {
                throw new ArgumentNullException("designElement");
            }

            int[] colorID = {

            };
          
            var brandingMaterialDDL =
                GetDropDownBrandingMaterialList.BrandingMaterialPriceListItems(brandingMaterial, -1);
            var colorDDL = GetDropDownColorList.ColorListItems(color, colorID);
            var DesignElementDDL = GetDropDownBrandingMaterialList.PrintMediaDesignElementItems(designElement, -1);

            var views = new BrandingView
            {
                MaterialList = brandingMaterialDDL,
                ColorList = colorDDL,
                DesignElementList = DesignElementDDL,
            };
            return views;
        }


        /// <summary>
        /// Gets the branding updated view.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <param name="color">The color.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="brandingView">The branding view.</param>
        /// <param name="ProcessingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// brandingView
        /// or
        /// brandingMaterial
        /// or
        /// color
        /// or
        /// designElement
        /// </exception>
        public IBrandingView GetBrandingUpdatedView(IList<IBrandingMaterialPrice> brandingMaterial, IList<IColor> color,
            IList<IDesignElementPrice> designElement,IBrandingView brandingView,string ProcessingMessage)
        {
            if (brandingView == null)
            {
                throw new ArgumentNullException("brandingView ");
            }

            if (brandingMaterial == null)
            {
                throw new ArgumentNullException("brandingMaterial");
            }

            if (color == null)
            {
                throw new ArgumentNullException("color");
            }

            if (designElement == null)
            {
                throw new ArgumentNullException("designElement");
            }

            int[] colorID = { };

            var brandingMaterialDDL =
                GetDropDownBrandingMaterialList.BrandingMaterialPriceListItems(brandingMaterial, brandingView.BrandingMaterialId);
            var colorDDL = GetDropDownColorList.ColorListItems(color, colorID);
            var DesignElementDDL = GetDropDownBrandingMaterialList.PrintMediaDesignElementItems(designElement, brandingView.DesignElementId);


            var views = new BrandingView
            {AdditionalColorInfo=brandingView.AdditionalColorInfo,
            
                MaterialList = brandingMaterialDDL,
                ColorList = colorDDL,
                DesignElementList = DesignElementDDL,
                BrandingMaterialAmount=brandingView.BrandingMaterialAmount,
                AdditionalInformation=brandingView.AdditionalInformation,
                BrandingMaterialPriceId=brandingView.BrandingMaterialPriceId,
                OrderTitle=brandingView.OrderTitle,
                OtherColor=brandingView.OtherColor,
                DesignElementPriceId=brandingView.DesignElementPriceId,
                DesignElementAmount=brandingView.DesignElementAmount,
                DesignElementId=brandingView.DesignElementId,
                BrandingMaterialId=brandingView.BrandingMaterialId,
                ProcessingMessage=ProcessingMessage
                
            };
            return views;
        }





        /// <summary>
        /// Gets the branding view.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <param name="color">The color.</param>
        /// <param name="designElement">The design element.</param>
        /// <param name="brandingTransaction">The branding transaction.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// brandingMaterial
        /// or
        /// color
        /// or
        /// designElement
        /// or
        /// brandingTransaction
        /// </exception>
        public IBrandingView GetBrandingTransactionView(IList<IBrandingMaterialPrice> brandingMaterial,
            IList<IColor> color,
            IList<IDesignElementPrice> designElement,
            IBrandingTransaction brandingTransaction,
            IList<IBrandingTransactionColor> selectedColors,
            string message)
        {
            if (brandingMaterial == null)
            {
                throw new ArgumentNullException(nameof(brandingMaterial));
            }

            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }

            if (designElement == null)
            {
                throw new ArgumentNullException(nameof(designElement));
            }

            if (brandingTransaction == null)
            {
                throw new ArgumentNullException(nameof(brandingTransaction));
            }


            //Get anc Convert the Color to Array
            var colorList = new List<int>();


            foreach (var selectedColor in selectedColors)
            {
                colorList.Add(selectedColor.ColorId);
            }

            int[] colorID = colorList.ToArray();



            var brandingMaterialDDL =
                GetDropDownBrandingMaterialList.BrandingMaterialPriceListItems(brandingMaterial,
                    brandingTransaction.BrandingMaterialId);

            var colorDDL = GetDropDownColorList.ColorListItems(color, colorID);


            var DesignElementDDL =
                GetDropDownBrandingMaterialList.PrintMediaDesignElementItems(designElement,
                    brandingTransaction.DesignElementId);

            var views = new BrandingView
            {
                MaterialList = brandingMaterialDDL,
                ColorList = colorDDL,
                DesignElementList = DesignElementDDL,
                OrderTitle = brandingTransaction.OrderTitle,
                OrderNumber = brandingTransaction.OrderId,
                DesignElementId = brandingTransaction.DesignElementId,
                DateCreated = brandingTransaction.DateCreated,
                BrandingMaterialAmount = brandingTransaction.BrandingMaterialAmount,
                DesignElementAmount = brandingTransaction.DesignElementAmount,
                AdditionalInformation = brandingTransaction.AdditionalInformation,
                BrandingMaterialId = brandingTransaction.BrandingMaterialId,
                DesignElementPriceId = brandingTransaction.DesignElementPriceId,
                OtherColor = brandingTransaction.OtherColor,
                ColorId = colorID,
                BrandingTransactionId = brandingTransaction.BrandingTransactionId,
                ProcessingMessage = message,
                BrandingAttachmentFileDescription=brandingTransaction.BrandingAttachmentDescription,
                TotalAmount=brandingTransaction.TotalAmount,
            };
            return views;
        }

        /// <summary>
        /// Creates the branding material ListView.
        /// </summary>
        /// <param name="theCollection">The collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// //it returns a list of material in the administration section
        public IBrandingMaterialListView CreateBrandingMaterialListView(IList<IBrandingMaterial> materialCollection,
            string message,
            int selectedBrandingMaterialId, string selectedDescription)
        {
            if (materialCollection == null)
            {
                throw new ArgumentNullException(nameof(materialCollection));
            }

            //search by Material Id
            var filteredList = materialCollection.Where(x =>
                x.BrandingMaterialId.Equals(selectedBrandingMaterialId < 1
                    ? x.BrandingMaterialId
                    : selectedBrandingMaterialId)).ToList();

            //search by description
            filteredList = filteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedDescription)
                        ? x.Description
                        : selectedDescription))
                .ToList();


            var returnView = new BrandingMaterialListView
            {
                BrandingMaterialCollection = filteredList.ToList(),
                SelectedBrandingMaterialId = selectedBrandingMaterialId,
                SelectedDescription = selectedDescription,
                ProcessingMessage = message
            };

            return returnView;
        }


        /// <summary>
        /// Creates the branding material price ListView.
        /// </summary>
        /// <param name="brandingmaterial">The brandingmaterial.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingmaterial</exception>
        /// 
        //this gets a list of branding material price to the view in the admin section
        public IMaterialPriceListView CreateBrandingMaterialPriceListView(
            IList<IBrandingMaterialPrice> brandingmaterial, string message,
            int selectedBrandingMaterialPriceId, string selectedBrandingMaterialId)
        {
            if (brandingmaterial == null)
            {
                throw new ArgumentNullException(nameof(brandingmaterial));
            }

            //filtered by Price Id
            var filteredList = brandingmaterial.Where(x =>
                x.BrandingMaterialPriceId.Equals(selectedBrandingMaterialPriceId < 1
                    ? x.BrandingMaterialPriceId
                    : selectedBrandingMaterialPriceId)).ToList();

            //search by Material Id

            filteredList = filteredList.Where(x =>
                    x.Description.Contains(string.IsNullOrEmpty(selectedBrandingMaterialId)
                        ? x.Description
                        : selectedBrandingMaterialId))
                .ToList();
            

            var returnView = new MaterialPriceListView
            {
                BrandingMaterialPriceCollection = filteredList.ToList(),
                SelectedBrandingMaterialPriceId = selectedBrandingMaterialPriceId,
                SelectedBrandingMaterial = selectedBrandingMaterialId,
                ProcessingMessage = message
            };
            return returnView;
        }

        /// <summary>
        /// Creates the material price view.
        /// </summary>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ServiceType
        /// or
        /// MaterialType
        /// </exception>
        /// //
        /// this gets the material price view for when admin wants to add a new price
        public IBrandingMaterialPriceView CreateMaterialPriceView(IList<IBrandingMaterial> MaterialType)
        {
            if (MaterialType == null)
            {
                throw new ArgumentNullException("MaterialType");
            }


            var materialType = GetDropDownBrandingMaterialList.BrandingMaterialListItems(MaterialType, -1);

            var view = new BrandingMaterialPriceView
            {
                ProcessingMessage = string.Empty,

                BrandingMaterialType = materialType
            };
            return view;
        }

        public IBrandingTransactionListVew GetAllBrandingTranasction(IList<IBrandingTransaction> brandingTransactions,IList<IMessage>messages,IList<IReplies>replies)
        {
            if (brandingTransactions == null)
            {
                throw new ArgumentNullException("brandingTransactions");
            }

            var view = new BrandingTransactionListView
            {
                repliesLists=replies,
                messagesLists=messages,
                GetBrandingTransactions = brandingTransactions
            };
            return view;
        }

        /// <summary>
        /// Creates the updated material price view.
        /// </summary>
        /// <param name="materialview">The materialview.</param>
        /// <param name="processingMessages">The processing messages.</param>
        /// <param name="ServiceType">Type of the service.</param>
        /// <param name="MaterialType">Type of the material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ServiceType
        /// or
        /// MaterialType
        /// </exception>
        /// //this gets  the updated view for the branding material price view
        public IBrandingMaterialPriceView CreateBrandingMaterialPriceView(IBrandingMaterialPriceView materialview,
            string processingMessages,
            IList<IBrandingMaterial> MaterialType)
        {
            var materialType =
                GetDropDownBrandingMaterialList.BrandingMaterialListItems(MaterialType,
                    materialview.BrandingMaterialId);

            materialview.BrandingMaterialType = materialType;

            materialview.ProcessingMessage = processingMessages;

            return materialview;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandingmaterialView"></param>
        /// <returns></returns>
        /// this  gets the view when admin wants to edit the branding material price view 
        public IBrandingMaterialView CreateEditBrandingMaterialView(IBrandingMaterial brandingmaterialView)
        {
            if (brandingmaterialView == null) throw new ArgumentNullException(nameof(brandingmaterialView));
            var view = new BrandingMaterialView
            {
                ProcessingMessage = "",
                Description = brandingmaterialView.Description,
                BrandingMaterialId = brandingmaterialView.BrandingMaterialId
            };

            return view;
        }


        /// <summary>
        /// Creates the branding material price view.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingMaterial</exception>
        public IBrandingMaterialPriceView CreateBrandingMaterialPriceView(IList<IBrandingMaterial> brandingMaterial)
        {
            if (brandingMaterial == null)
            {
                throw new ArgumentNullException(nameof(brandingMaterial));
            }


            var brandingMaterialDDl = GetDropDownBrandingMaterialList.BrandingMaterialListItems(brandingMaterial, -1);

            var view = new BrandingMaterialPriceView
            {
                BrandingMaterialType = brandingMaterialDDl
            };
            return view;
        }


        /// <summary>
        /// Edits the branding material price.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <param name="brandingMaterialPrice">The branding material price.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">brandingMaterial</exception>
        public IBrandingMaterialPriceView EditBrandingMaterialPrice(IList<IBrandingMaterial> brandingMaterial,
            IBrandingMaterialPrice brandingMaterialPrice)
        {
            if (brandingMaterial == null)
            {
                throw new ArgumentNullException(nameof(brandingMaterial));
            }


            var brandingMaterialDDl = GetDropDownBrandingMaterialList.BrandingMaterialListItems(brandingMaterial, -1);

            var view = new BrandingMaterialPriceView
            {
                BrandingMaterialPriceId = brandingMaterialPrice.BrandingMaterialPriceId,
                Amount = brandingMaterialPrice.Amount,
                DateCreated = brandingMaterialPrice.DateCreated,
                BrandingMaterialType = brandingMaterialDDl,
                Comment = brandingMaterialPrice.Comment,
                DateInactive = brandingMaterialPrice.DateInactive,
                BrandingMaterialId = brandingMaterialPrice.BrandingMaterialId,
                EffectiveDate = brandingMaterialPrice.EffectiveDate,
            };
            return view;
        }

        //this get the branding material view when a admin wants to add a new item to the database
        public IBrandingMaterialView CreateBrandingMaterialView()
        {
            var view = new BrandingMaterialView
            {
            };
            return view;
        }

        //updated view for branding materal view
        public IBrandingMaterialView CreateBrandingMaterialView(IBrandingMaterialView brandingMaterialView,
            string processingMessage)
        {
            if (brandingMaterialView == null)
            {
                throw new ArgumentException("brandingMaterialView");
            }

            brandingMaterialView.ProcessingMessage = processingMessage;
            return brandingMaterialView;
        }


        public IBrandingView GetBrandingMaterialViews(IBrandingMaterialPrice price)
        {
            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            var view = new BrandingView
            {
                BrandingMaterialAmount = price.Amount,
                BrandingMaterialPriceId = price.BrandingMaterialPriceId
            };
            return view;
        }

        public IBrandingAttachmentTransactionListView GetBrandingAttachmentTransactionListView(
            IList<IBrandingAttachmentTransaction> brandingMaterialTransactions,
            IBrandingTransaction brandingTransaction)
        {
            if (brandingTransaction == null)
            {
                throw new ArgumentNullException(nameof(brandingTransaction));
            }

            if (brandingTransaction == null)
            {
                throw new ArgumentNullException(nameof(brandingTransaction));
            }

            var brandList = new BrandingAttachmentTransactionListView
            {
                AdditionalInfo = brandingTransaction.AdditionalInformation,
                Name = brandingTransaction.UserName,
                OrderTitle = brandingTransaction.OrderTitle,
                brandingAttachmentTransactions = brandingMaterialTransactions,

                userId = brandingTransaction.UserId,
                transactionId = brandingTransaction.BrandingTransactionId,
                UploadedMaterialDetail = brandingTransaction.BrandingFileId
            };

            return brandList;
        }



       

        /// <summary>
        /// Gets the branding attachment message replies ListView.
        /// </summary>
        /// <param name="replies">The replies.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">message</exception>
        public IMessageRepliesListView GetBrandingAttachmentMessageRepliesListView(IList<IReplies> replies,
            IMessage message,int transactionId,int SentToId,int OrderId)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var view = new MessageRepliesListView
            {
                InitialMessage = message.Message,
                MessageId = message.Id,
                SentToId =SentToId,
                transactionId = transactionId,
                UserId = message.UserId,
                Replies = replies,
                IsApproved = message.IsApproved,
                DigitalFileId = message.DigitalFileId,
                OrderId=OrderId,

            };
            return view;
        }



        /// <summary>
        /// Gets the user branding transaction.
        /// </summary>
        /// <param name="brandingTransaction">The branding transaction.</param>
        /// <param name="brandingTransactionColors">The branding transaction colors.</param>
        /// <param name="brandingTransactionAttachment">The branding transaction attachment.</param>
        /// <param name="brandingTransactionDesignElement">The branding transaction design element.</param>
        /// <param name="brandingTransactionMaterial">The branding transaction material.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// brandingTransactionMaterial
        /// or
        /// brandingTransactionDesignElement
        /// or
        /// brandingTransactionAttachment
        /// </exception>
        public IBrandingView GetUserBrandingTransaction(IBrandingTransaction brandingTransaction,IList<IBrandingTransactionColor>brandingTransactionColors,IBrandingTransactionAttachment brandingTransactionAttachment,IBrandingTransactionDesignElement brandingTransactionDesignElement,IBrandingTransactionMaterial brandingTransactionMaterial)
        {

            


            if(brandingTransactionMaterial==null)
            {
                throw new ArgumentNullException(nameof(brandingTransactionMaterial));
            }
            if (brandingTransactionDesignElement == null)
            {
                throw new ArgumentNullException(nameof(brandingTransactionDesignElement));
            }
            if (brandingTransactionAttachment == null)
            {
                throw new ArgumentNullException(nameof(brandingTransactionAttachment));
            }
            List<string> Colors = new List<string>();
            foreach (var j in brandingTransactionColors )
            {
                // ad colors
                Colors.Add(j.Color);
            }

            var view = new BrandingView
            {
                OrderTitle = brandingTransaction.OrderTitle,
                BrandingMaterial = brandingTransactionMaterial.BrandingMaterial,
                BrandingMaterialAmount = brandingTransactionMaterial.BrandingMaterialAmount,
                AdditionalColorInfo = brandingTransaction.OtherColor,
                DesignElement = brandingTransactionDesignElement.DesignElement,
                DesignElementAmount = brandingTransactionDesignElement.DesignElementAmount,
                DesignDigitalFileId = brandingTransactionAttachment.DigitalFileId,
                AdditionalInformation = brandingTransaction.AdditionalInformation,
                Colors = Colors,
                TotalAmount=brandingTransaction.TotalAmount,
                Name=brandingTransaction.UserName,
                PhoneNumber=brandingTransaction.PhoneNumber,
                Email=brandingTransaction.Email,
                DateCreated=brandingTransaction.DateCreated

            };

            return view;
        }





    }
}