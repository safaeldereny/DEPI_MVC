using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 5000, Description = "Portable computer" }
        };

        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult Add()
        {
            return View(new ProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new Product
                {
                    Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1,
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description
                };
                _products.Add(newProduct);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _products.FirstOrDefault(p => p.Id == model.Id);
                if (product == null) return NotFound();

                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}