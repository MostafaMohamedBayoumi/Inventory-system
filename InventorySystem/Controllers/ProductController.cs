using InventorySystem.Data;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
	public class ProductController : Controller
	{
		ApplicationDbContext _context;
		IWebHostEnvironment _WebHostEnvironment;
		public ProductController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
		{
			_WebHostEnvironment = webHostEnvironment;
			_context = context;
		}
		
		[HttpGet]
		public IActionResult DisplayProduct()
		{
			return View(_context.Products.OrderByDescending(x => x.Id).ToList());
		}

		[HttpGet]
		public IActionResult CreateProduct()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateProduct(Product product, IFormFile? imageFormFile)
		{
            if (imageFormFile != null)
            {
                string imgExtension = Path.GetExtension(imageFormFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imgName = imgGuid + imgExtension;
                string imgUrl = "\\images\\" + imgName;
                product.ImageUrl = imgUrl;

                string imgPath = _WebHostEnvironment.WebRootPath + imgUrl;

                //fileStream

                FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                imageFormFile.CopyTo(imgStream);
                imgStream.Dispose();
            }
            else
            {
                product.ImageUrl = "\\images\\No_Image.png";
            }
            _context.Products.Add(product);
			_context.SaveChanges();
			return RedirectToAction("DisplayProduct");
		}
		[HttpGet]
		public IActionResult UpdateProduct(int id)
		{
			Product product = _context.Products.FirstOrDefault(p=>p.Id==id);
			if (product == null)
			{
				return View("DisplayProduct");
			}
			else
			{
				return View(product);

			}
		}
		[HttpPost]
        public IActionResult UpdateProduct(Product product, IFormFile? imageFormFile)
        {
            if (imageFormFile != null)
            {
                if (product.ImageUrl != "\\images\\No_Image.png")
                {
                    string oldImgPath = _WebHostEnvironment.WebRootPath + product.ImageUrl;

                    if (System.IO.File.Exists(oldImgPath) == true)
                    {
                        System.IO.File.Delete(oldImgPath);
                    }
                }

                string imgExtension = Path.GetExtension(imageFormFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imgName = imgGuid + imgExtension;
                string imgUrl = "\\images\\" + imgName;
                product.ImageUrl = imgUrl;

                string imgPath = _WebHostEnvironment.WebRootPath + imgUrl;

                //fileStream

                FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                imageFormFile.CopyTo(imgStream);
                imgStream.Dispose();
            }
            else
            {
                product.ImageUrl = "\\images\\No_Image.png";
            }
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("DisplayProduct");


        }
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return View("DisplayProduct");
            }
            else
            {
                return View(product);

            }
        }
        [HttpPost]
        public IActionResult DeleteProduct(Product product, IFormFile? imageFormFile)
        {
            if (product.ImageUrl != "\\images\\No_Image.png")
            {
                string imgPath = _WebHostEnvironment.WebRootPath + product.ImageUrl;
                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("DisplayProduct");


        }

		[HttpGet]
		public IActionResult GetProduct(int id)
		{
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
			return View(product);
        }




    } 
}
