using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Models
{
    public class ApplicationUser : IdentityUser
    { 
    }

    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }


        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int Quantity { get; set; }
        public decimal Price { get; set; }

   
    }
}
