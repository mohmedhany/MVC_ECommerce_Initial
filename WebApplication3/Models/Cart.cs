using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public string UserId { get; set; } // Nullable for anonymous carts
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
