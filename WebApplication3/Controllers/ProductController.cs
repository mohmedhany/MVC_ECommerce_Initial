using WebApplication3.Data;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers

{
    public class ProductController : Controller
    {

        private ApplicationDbContext _context;
        public ProductController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        //public ProductController(MainRepositery<Product> main)
        //{
        //    _main = main;
        //}
        //private MainRepositery<Product> _main;
        public IActionResult Index(int page =1)
        {
            var products = _context.Products.ToList();
            var paginatedList = new PaginatedList<Product>(products, page, 10, products.Count);
            return View(paginatedList);
        }




        public IActionResult Create()
        {
           var categorList= _context.Categories.ToList();
            var selected_List = categorList.Select(c => new SelectListItem { Text = c.Name, Value=c.CategoryId.ToString() }).ToList();
            ViewBag.Category_List = selected_List;
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Product product)
        {
           
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var catlist = _context.Categories.ToList();
            var SelectedList = catlist.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CategoryId.ToString()
            }).ToList();
            ViewBag.Category_List = SelectedList;
            var product = _context.Products.Find(id);
            //SelectedListCategory();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
         
                _context.Products.Update(product);
                _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id) {

            var product = _context.Products.Find(id);
            return View(product);
        
        }

        public IActionResult Delete(int id)
        {

            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult NewArrival() {

            var new_arrival = _context.Products.Where(x => x.IsNewArrival);
            return View(new_arrival);
        }

      
    }
}
