using WebApplication3.Models;

namespace WebApplication3.ModelView
{
    public class CartViewModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int TotalQuantity => CartItems.Sum(ci => ci.Quantity);

        public decimal TotalPrice => CartItems.Sum(ci => ci.Product.Price * ci.Quantity);
    }
}
