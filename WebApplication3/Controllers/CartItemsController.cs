using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CartItemsController : Controller
    {
        public CartItemsController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        private readonly ApplicationDbContext _context;
        // GET: CartItemsController
        public ActionResult Index()
        {
            var cartitems = _context.CartItems.Include(x => x.Product).ToList();
            return View(cartitems);
        }

        // GET: CartItemsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartItemsController/Create
        public ActionResult Create()
        {
           var pro = _context.Products.ToList();
            var selected = pro.Select(p => new SelectListItem
            {
                Text = p.Name
            ,
                Value = p.ProductId.ToString()
            }).ToList();
            ViewBag.SelectedListItem = selected;
            return View();
        }

        // POST: CartItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CartItem cartItem)
        {

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: CartItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
