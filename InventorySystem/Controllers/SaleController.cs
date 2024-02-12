using InventorySystem.Data;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventorySystem.Controllers
{
    public class SaleController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _WebHostEnvironment;
        public SaleController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _WebHostEnvironment = webHostEnvironment;
            _context = context;
        }
        [HttpGet]
        public IActionResult DisplaySales()
        {
            return View(_context.Sales.OrderByDescending(x => x.Id).ToList());
        }
        [HttpGet]
        public IActionResult SaleProduct()
        {
            ViewBag.ProductName = new SelectList(_context.Products.Select(x => x.ProductName).ToList());
            return View();
        }
        [HttpPost]
        public IActionResult SaleProduct(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return RedirectToAction("DisplaySales");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Sale sale = _context.Sales.Where(p => p.Id == id).SingleOrDefault();
            ViewBag.ProductName = new SelectList(_context.Sales.Select(x => x.SaleProduct).ToList());
            return View(sale);
        }
        [HttpPost]
        public IActionResult Edit( Sale sale)
        {
            _context.Sales.Update(sale);
            _context.SaveChanges();
            return RedirectToAction("DisplaySales");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Sale _sale = _context.Sales.Where(p => p.Id == id).SingleOrDefault();
            ViewBag.ProductName = new SelectList(_context.Products.Select(x => x.ProductName).ToList());
            return View(_sale);
        }

        [HttpPost]
        public IActionResult Delete(Sale sale)
        {
            
            _context.Sales.Remove(sale);
            _context.SaveChanges();
            return RedirectToAction("DisplaySales");

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Sale? _sale = _context.Sales.Where(p => p.Id == id).SingleOrDefault();
            ViewBag.ProductName = new SelectList(_context.Sales.Select(x => x.SaleProduct).ToList());
            return View(_sale);
        }


    }
}
