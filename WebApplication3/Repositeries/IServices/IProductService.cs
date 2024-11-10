using WebApplication3.Models;

namespace WebApplication3.Repositeries.IServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<List<Product>> GetProductsRelatedToCartAsync(int cartId);
    }
}
