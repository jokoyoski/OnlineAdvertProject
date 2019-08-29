using System.Collections.Generic;
using ADit.Domain.Models;
using ADit.Interfaces;
using System.Web.Script.Serialization;



namespace ADit.Domain.Factories
{
    public class CartFactory : ICartFactory

   {       
        public static IList<IPrintView> PrintCartList = new List<IPrintView>();


        /// <summary>
        /// Saves to cart.
        /// </summary>
        /// <param name="printInfo">The print information.</param>
        public void SaveToCart(IPrintView printInfo)
       {
           IPrintView cartPrint = new PrintView();
           IPrintView cartPrinta = new PrintView();

            JavaScriptSerializer js = new JavaScriptSerializer();
           string json = js.Serialize(cartPrint);

           var serializer = new JavaScriptSerializer();
            
           var data = (PrintView)serializer.DeserializeObject(json);
           data.DesignElementId = 5;

           
           


            cartPrint.PrintCategoryId = printInfo.PrintCategoryId;
           cartPrint.NewsPaperId = printInfo.NewsPaperId;
           cartPrint.PrintServiceTypeId = printInfo.PrintServiceTypeId;
           cartPrint.ColorId = printInfo.ColorId;
           cartPrint.DesignElementId = printInfo.DesignElementId;
           cartPrint.DurationTypeCode = printInfo.DurationTypeCode;
           cartPrint.ApconApprovalTypeId = printInfo.ApconApprovalTypeId;
          
           PrintCartList.Add(cartPrint); 
           var cartItem = ShoppingCart.Instance;
           var cartItemId = cartItem.GetItemNext();
           cartItem.AddItem(cartItemId);

       }
    }
}
