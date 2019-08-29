using System;
using System.Collections.Generic;

namespace ADit.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<CartItem> Items { get; private set; }

        /// <summary>
        /// The instance
        /// </summary>
        public static readonly ShoppingCart Instance;
        /// <summary>
        /// The wr
        /// </summary>
        public static ShoppingCart Wr;

        // The static constructor is called as soon as the class is loaded into memory
        /// <summary>
        /// Initializes the <see cref="ShoppingCart"/> class.
        /// </summary>
        static ShoppingCart()
        {
            // If the cart is not in the session, create one and put it there
            // Otherwise, get it from the session
            if (Wr == null)
            {
                Instance = new ShoppingCart();
                Instance.Items = new List<CartItem>();
                Wr = Instance;
            }
            else
            {
                Instance = Wr;
            }
        }

        // A protected constructor ensures that an object can't be created from outside
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCart"/> class.
        /// </summary>
        protected ShoppingCart() { }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        public void AddItem(int productId)
        {
            // Create a new item to add to the cart
            CartItem newItem = new CartItem(productId);

            // If this item already exists in our list of items, increase the quantity
            // Otherwise, add the new item to the list
            if (Items.Contains(newItem))
            {
                foreach (CartItem item in Items)
                {
                    if (item.Equals(newItem))
                    {
                        item.Quantity++;
                        return;
                    }
                }
            }
            else
            {
                newItem.Quantity = 1;
                Items.Add(newItem);
            }
        }

        /// <summary>
        /// Sets the item quantity.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        public void SetItemQuantity(int productId, int quantity)
        {
            // If we are setting the quantity to 0, remove the item entirely
            if (quantity == 0)
            {
                RemoveItem(productId);
                return;
            }

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }

        /// <summary>
        /// Sets the item unit price.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="unitPrice">The unit price.</param>
        public void SetItemUnitPrice(int productId, decimal unitPrice)
        {
            // If we are setting the quantity to 0, remove the item entirely

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.UnitPrice = unitPrice;
                    return;
                }
            }
        }

        /// <summary>
        /// Sets the item description.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="description">The description.</param>
        public void SetItemDescription(int productId, string description)
        {
            // If we are setting the quantity to 0, remove the item entirely

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.Description = description;
                    return;
                }
            }
        }

        /// <summary>
        /// Gets the item quantity.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public int GetItemQuantity(int productId)
        {

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);
            
            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                   //var a = Items.FindLast();
                    return item.Quantity;

                }
            }
            return 0;
        }

        /// <summary>
        /// Gets the item next.
        /// </summary>
        /// <returns></returns>
        public int GetItemNext()
        {
          return Items.Count + 1;
        }

        /// <summary>
        /// Gets the item description.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public String GetItemDescription(int productId)
        {

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    return item.Description;

                }
            }
            return "Nothing";
        }










        /// <summary>
        /// Gets the item unit price.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public decimal GetItemUnitPrice(int productId)
        {

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    return item.UnitPrice;

                }
            }
            return 0;
        }


        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        public void RemoveItem(int productId)
        {
            CartItem removedItem = new CartItem(productId);
            Items.Remove(removedItem);
        }

        /// <summary>
        /// Gets the sub total.
        /// </summary>
        /// <returns></returns>
        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (CartItem item in Items)
                subTotal += item.TotalPrice;

            return subTotal;
        }


    }

}
