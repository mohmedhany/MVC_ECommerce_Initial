using WebApplication3.Models;

namespace WebApplication3.Repositeries.IServices
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task AddItemToCartAsync(string userId, int productId, int quantity);
        //Task<Cart> UpdateCartItemQuantityAsync(string userId, int cartItemId, int quantity);
        //Task<Cart> RemoveCartItemAsync(string userId, int cartItemId);
        //Task<Cart> ClearCartAsync(string userId);
        Task<List<CartItem>> GetCartItemsByUserIdAsync(string userId);
        Task RemoveItemFromCartAsync(string userId, int productId);
        Task ClearCartAsync(string userId);
    }
}
