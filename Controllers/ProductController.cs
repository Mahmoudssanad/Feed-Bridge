using FeedBridge_00.Models;
using FeedBridge_00.Models.Entities;
using FeedBridge_00.Models.Status;
using FeedBridge_00.Repository;
using FeedBridge_00.Services;
using Microsoft.AspNetCore.Mvc;

namespace FeedBridge_00.Controllers
{
    public class ProductController : Controller
    {
        //IProductRepository _productRepository;
        //public ProductController(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult AllProducts()
        {
            List<Product> products = _productService.GetAll();
            return View(products);
        }

        public IActionResult New()
        {
            // Ask ولكن انا محتاج Create Object لان انا هنا ب Violate Dependancy Inversion دي كدا بت 
            return View(new Product());
        }
        [HttpPost]
        public IActionResult SaveNew(int id, Product product)
        {
            if(ModelState.IsValid)
            {
                _productService.Insert(product);
                _productService.Save();
                return RedirectToAction("All", product);
            }
            return View("New", product);
        }

        public IActionResult Details(int id)
        {
            var productById = _productService.GetById(id);
            return View(productById);
        }

        public IActionResult Edit(int id)
        {
             var product = _productService.GetById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult SaveEdit(Product newProductUpdate, int id)
        {
            var product = _productService.GetById(id);
            if (ModelState.IsValid)
            {
                _productService.Update(newProductUpdate, id);
                _productService.Save();
                return RedirectToAction("AllProducts");
            }
            return View("Edit");
        }

        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if(product != null)
            {
                _productService.Delete(id);
                _productService.Save();
                return View("AllProducts");
            }
            return Content("NotFound");
        }
    }
}
