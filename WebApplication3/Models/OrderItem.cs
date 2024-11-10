using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        public string OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Price{ get; set; }

        public virtual Order Order { get; set;}
        [ForeignKey("ProductId")]
        public virtual Product Product{ get; set;}
    }

}
