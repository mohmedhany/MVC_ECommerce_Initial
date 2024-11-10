using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId
        {
            get; set;
        }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName{get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string PasswordHash
        { get; set; } // Store hashed password
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public ICollection<Review> Reviews { get; set; } // Navigation property
    }
}
