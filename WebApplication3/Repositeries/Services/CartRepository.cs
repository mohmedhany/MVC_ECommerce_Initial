using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositeries.IServices;

namespace WebApplication3.Repositeries.Services
{
    public class CartService : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CartService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<CartItem>> GetCartItemsByUserIdAsync(string userId)
        {
            var cartItems = await _dbContext.CartItems
                .Where(ci => ci.Cart.UserId == userId)
                .ToListAsync();

            return cartItems;
        }


        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return cart ?? new Cart { UserId = userId };
        }

        public async Task AddItemToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await GetCartByUserIdAsync(userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _dbContext.Carts.Add(cart);
            }

            if (cart.CartItems == null)
            {
                cart.CartItems = new List<CartItem>();
            }

            var existingItem = cart?.CartItems?.FirstOrDefault(ci => ci.ProductId == productId);
            var pro = await _dbContext.Products.SingleOrDefaultAsync(ci => ci.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }

            else
            {
                var new_item = new CartItem { Cart = cart, Product = pro, Quantity = quantity, ProductId = productId, CartId = cart.CartId, Price = 700 };
                cart.CartItems.Add(new_item);
                _dbContext.CartItems.Add(new_item);
            }
            try
            {
                await _dbContext.SaveChangesAsync(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        public async Task ClearCartAsync(string userId)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart != null)
            {
                _dbContext.CartItems.RemoveRange(cart.CartItems);
                _dbContext.Carts.Remove(cart);

                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task RemoveItemFromCartAsync(string userId, int productId)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                if (cartItem != null)
                {
                    cart.CartItems.Remove(cartItem);
                    _dbContext.CartItems.Remove(cartItem);

                    await _dbContext.SaveChangesAsync();
                  
                }
            }
        }
        #region
        //public async Task<Cart> UpdateCartItemQuantityAsync(string userId, int cartItemId, int quantity)
        //{
        //    var cart = await GetCartByUserIdAsync(userId);

        //    var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);

        //    if (cartItem != null && quantity > 0)
        //    {
        //        cartItem.Quantity = quantity;
        //        await _dbContext.SaveChangesAsync();
        //    }

        //    return cart;
        //}

        //public async Task<Cart> RemoveCartItemAsync(string userId, int cartItemId)
        //{
        //    var cart = await GetCartByUserIdAsync(userId);

        //    var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);

        //    if (cartItem != null)
        //    {
        //        cart.CartItems.Remove(cartItem);
        //        await _dbContext.SaveChangesAsync();
        //    }

        //    return cart;
        //}

        //public async Task<Cart> ClearCartAsync(string userId)
        //{
        //    var cart = await GetCartByUserIdAsync(userId);

        //    cart.CartItems.Clear();
        //    await _dbContext.SaveChangesAsync();

        //    return cart;
        //}
        #endregion

    }
}