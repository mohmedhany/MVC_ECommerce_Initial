using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositeries.IServices;

namespace WebApplication3.Repositeries.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync() => await _context.Products.ToListAsync();

        public async Task<Product> GetProductByIdAsync(int productId) => await _context.Products.FindAsync(productId);



        public async Task<List<Product>> GetProductsRelatedToCartAsync(int cartId)
        {

            var cartItems = await _context.CartItems
              .Where(ci => ci.CartId == cartId)
              .ToListAsync();

            var productIds = cartItems.Select(ci => ci.ProductId).ToList();

            var products = await _context.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync();

            return products;
        }


    }
}
