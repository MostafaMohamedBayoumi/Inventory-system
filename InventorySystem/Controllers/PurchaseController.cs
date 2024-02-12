using InventorySystem.Data;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventorySystem.Controllers
{
    public class PurchaseController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _WebHostEnvironment;
        public PurchaseController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _WebHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DisplayPurchase()
        {
            return View(_context.purchase.OrderByDescending(x => x.Id).ToList());
        }
        [HttpGet]
        public IActionResult PurchaseProduct()
        {
            ViewBag.ProductName = new SelectList(_context.Products.Select(x => x.ProductName).ToList());
            return View();
        }
        [HttpPost]
        public IActionResult PurchaseProduct(Purchase purchase)
        {
            _context.purchase.Add(purchase);
            _context.SaveChanges();
            return RedirectToAction("DisplayPurchase");
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Purchase purchase = _context.purchase.Where(p => p.Id == id).SingleOrDefault();
            ViewBag.ProductName = new SelectList(_context.Products.Select(x => x.ProductName).ToList());
            return View(purchase);
        }
        [HttpPost]
        public IActionResult Edit( Purchase purchase)
        {
            _context.purchase.Update(purchase);
            _context.SaveChanges();
            return RedirectToAction("DisplayPurchase");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Purchase purchase = _context.purchase.Where(p => p.Id == id).SingleOrDefault();
            ViewBag.ProductName = new SelectList(_context.Products.Select(x => x.ProductName).ToList());
            return View(purchase);
        }

        [HttpPost]
        public IActionResult Delete(Purchase purchase)
        {
            
            _context.purchase.Remove(purchase);
            _context.SaveChanges();
            return RedirectToAction("DisplayPurchase");

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Purchase purchase = _context.purchase.Where(p => p.Id == id).SingleOrDefault();
            ViewBag.ProductName = new SelectList(_context.Products.Select(x => x.ProductName).ToList());
            return View(purchase);
        }
    }
}
