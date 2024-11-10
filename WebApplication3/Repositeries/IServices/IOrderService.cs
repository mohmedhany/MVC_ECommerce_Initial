using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Repositeries.IServices
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrder();
        Task<Order> GetOrderById(string orderId);
        Task<Order> CreateOrderAsync(string userId, List<CartItem> cartItems);
        Task<List<OrderItem>> GetOrderItemsByOrderId(string orderId);

    }
}
