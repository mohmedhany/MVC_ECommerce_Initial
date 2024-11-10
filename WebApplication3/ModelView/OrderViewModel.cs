using WebApplication3.Models;

namespace WebApplication3.ModelView
{
    public class OrderViewModel
    {
   
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
