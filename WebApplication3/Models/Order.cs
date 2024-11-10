using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace WebApplication3.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; } 
      
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime OrderDate {get; set; } = DateTime.Now;


        [StringLength(255)]
        public string ShippingAddress { get; set; }
        
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public string OrderStatus { get; set; } = string.Empty;

        public   List<OrderItem> OrderItems { get; set; }
    }
}
