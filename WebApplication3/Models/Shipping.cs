using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
        [Required]
        public string OrderId { get; set; }
        [StringLength(50)]
        public string Carrier { get; set; }
        [StringLength(50)]
        public string TrackingNumber { get; set; }
        public DateTime ShippingDate { get; set; }
        public virtual Order Order { get; set; }
    }
}
