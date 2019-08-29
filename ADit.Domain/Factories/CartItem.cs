using System;

namespace ADit.Domain.Factories
{
    public class CartItem : IEquatable<CartItem>
    {
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                // To ensure that the Prod object will be re-created
                _product = null;
                _productId = value;
            }
        }

        private Product _product = null;
        public Product Prod
        {
            get
            {
                // Lazy initialization - the object won't be created until it is needed
                if (_product == null)
                {
                    _product = new Product(ProductId);
                }
                return _product;
            }
        }

     

        public decimal TotalPrice
        {
            get { return UnitPrice * Quantity; }
        }



        // CartItem constructor just needs a productId
        public CartItem(int productId)
        {
            this.ProductId = productId;
        }

        /**
         * Equals() - Needed to implement the IEquatable interface
         *    Tests whether or not this item is equal to the parameter
         *    This method is called by the Contains() method in the List class
         *    We used this Contains() method in the ShoppingCart AddItem() method
         */
        public bool Equals(CartItem item)
        {
            return item.ProductId == this.ProductId;
        }


    }
}

