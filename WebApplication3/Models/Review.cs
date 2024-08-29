using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        [StringLength(500)]
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
