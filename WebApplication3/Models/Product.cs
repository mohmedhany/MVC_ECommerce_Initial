using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication3.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Quantity In Stock")]
        public int QuantityInStock { get; set; }
        [DisplayName("Image For The Product")]
        public string ImageUrl { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public bool IsNewArrival {  get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
