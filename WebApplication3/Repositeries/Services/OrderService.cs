using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ModelView;
using WebApplication3.Repositeries.IServices;

namespace WebApplication3.Repositeries.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllOrder() => await _dbContext.Orders.ToListAsync();

        public async Task<Order> GetOrderById(string orderId)
        {
            //Guid parsedId;
            //if (!Guid.TryParse(orderId, out parsedId)) { return null ; }
            if (string.IsNullOrWhiteSpace(orderId)) { return null; }

            return await _dbContext.Orders.FindAsync(orderId);

        }
        public async Task<Order> CreateOrderAsync(string userId, List<CartItem> cartItems)
        {
            // Validate input parameters (optional)
            if (string.IsNullOrEmpty(userId) || cartItems == null || cartItems.Count == 0)
            {
                throw new ArgumentException("Invalid input parameters.");
            }

            //Create a new Order instance
           var order = new Order
           {
               //  OrderId = Guid.NewGuid(),
               UserId = userId,
               OrderItems = cartItems.Select(ci => new OrderItem
               {
                   Product = ci.Product,
                   ProductId = ci.ProductId,
                   Quantity = ci.Quantity,
                   Price = ci.Product.Price
               }).ToList()
               ,
               OrderDate = DateTime.UtcNow, // Use UTC time for consistency
               TotalPrice = cartItems.Sum(ci => ci.Quantity * ci.Product.Price),
               OrderStatus = "Not Shipped",
               ShippingAddress = " " // Consider using a default value or allowing an empty address ,

           };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }


        public async Task<List<OrderItem>> GetOrderItemsByOrderId(string orderId)
        {
            Guid parsedId;
            if (!Guid.TryParse(orderId, out parsedId)) { return new List<OrderItem>(); }  // Return empty list if parsing fails

            var order = await _dbContext.Orders
                .Include(o => o.OrderItems).ThenInclude(c => c.Product)  // Eager loading for OrderItems
                .FirstOrDefaultAsync(o => o.OrderId == parsedId);

            return order?.OrderItems.ToList() ?? new List<OrderItem>(); // Return empty list if order not found or OrderItems is null
        }
    }
}
