using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infanos.Models;

namespace Infanos.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string CartId { get; set; }

        private Context db = new Context();

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            CartId = GetCartId();

            var cartItem = db.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == CartId
                && c.GameId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    GameId = id,
                    CartId = CartId,
                    Game = db.Games.SingleOrDefault(
                     p => p.GameID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            db.SaveChanges();
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItem> GetCartItems()
        {
            CartId = GetCartId();

            return db.ShoppingCartItems.Where(
                c => c.CartId == CartId).ToList();
        }

        public decimal GetTotal()
        {
            CartId = GetCartId();
            // Multiply product price by quantity of that product to get        
            // the current price for each of those products in the cart.  
            // Sum all product price totals to get the cart total.   
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in db.ShoppingCartItems
                               where cartItems.CartId == CartId
                               select (int?)cartItems.Quantity *
                               cartItems.Game.GamePrice).Sum();
            return total ?? decimal.Zero;
        }

        public ShoppingCartActions GetCart(HttpContext context)
        {
            using (var cart = new ShoppingCartActions())
            {
                cart.CartId = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            using (var db = new Infanos.Models.Context())
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<CartItem> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Game.GameID == CartItemUpdates[i].GameId)
                            {
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.GameId);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.GameId, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeGameID)
        {
            using (var db = new Infanos.Models.Context())
            {
                try
                {
                    var myItem = (from c in db.ShoppingCartItems where c.CartId == removeCartID && c.Game.GameID == removeGameID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        db.ShoppingCartItems.Remove(myItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateCartID, int updateGameID, int quantity)
        {
            using (var db = new Infanos.Models.Context())
            {
                try
                {
                    var myItem = (from c in db.ShoppingCartItems where c.CartId == updateCartID && c.Game.GameID == updateGameID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Quantity = quantity;
                        db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyCart()
        {
            CartId = GetCartId();
            var cartItems = db.ShoppingCartItems.Where(
                c => c.CartId == CartId);
            foreach (var cartItem in cartItems)
            {
                db.ShoppingCartItems.Remove(cartItem);
            }
            // Save changes.             
            db.SaveChanges();
        }

        public int GetCount()
        {
            CartId = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in db.ShoppingCartItems
                          where cartItems.CartId == CartId
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int GameId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

        public void MigrateCart(string cartId, string userName)
        {
            var shoppingCart = db.ShoppingCartItems.Where(c => c.CartId == cartId);
            foreach (CartItem item in shoppingCart)
            {
                item.CartId = userName;
            }
            HttpContext.Current.Session[CartSessionKey] = userName;
            db.SaveChanges();
        }
    }
}