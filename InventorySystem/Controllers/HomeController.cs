using System.Diagnostics;
using InventorySystem.Data;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Controllers
{
	public class HomeController : Controller
	{
        ApplicationDbContext _context;
        IWebHostEnvironment _WebHostEnvironment;
        public HomeController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _WebHostEnvironment = webHostEnvironment;
            _context = context;
        }
        

        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();  // Retrieve products from your data source
            return View(products);
        }

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            return View("ProductDetails", product);
        }
    }
}