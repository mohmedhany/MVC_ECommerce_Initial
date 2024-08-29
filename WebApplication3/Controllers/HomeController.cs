using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Controllers
{
    
    public class HomeController : Controller
    {

        private ApplicationDbContext _db;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext db , UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db; 
        }

        public async Task<IActionResult> Index(string searchString , int? page =1)
        {
            var produc = from m in _db.Products
                         select m;
            if (!String.IsNullOrEmpty(searchString)) {
                produc = produc.Where(s => s.Name!.ToUpper().Contains(searchString));
            }
            int pageSize = 10; // number of items per page
            int pageNumber = (page ?? 1); // current page number

            var pagedProducts = await PaginatedList<Product>.CreateAsync(produc.AsNoTracking(), pageNumber, pageSize);

            return View(pagedProducts);
            //IEnumerable<Product> products = _db.Products;

        }

        public ActionResult Detail(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.Category).FirstOrDefault(c => c.CategoryId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
