using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; } // Nullable for anonymous carts

        [ForeignKey("UserId")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
