using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositeries
{

    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        //public Cart Create(int id)
        //{
           
        //}

        public bool Exist(int id)
        {
            var cart = _context.Carts.Where(x => x.UserId == id).Include(x => x.Customer);
            if (cart != null) {
                return true;
            }
            return false;
        }

        public Cart Get(int id)
        {
            var exist = Exist(id);
            if (exist) {
            var cart =  _context.Carts.SingleOrDefault(x => x.UserId == id);
                return cart;
            }
            return null;
        }
    }
}
