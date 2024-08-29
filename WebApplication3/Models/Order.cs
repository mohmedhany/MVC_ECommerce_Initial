using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
      
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime OrderDate {get; set; } = DateTime.Now;
        [StringLength(255)]
        public string ShippingAddress { get; set; }
        [StringLength(255)]
        public string BillingAddress { get; set; }
      
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public string OrderStatus { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
