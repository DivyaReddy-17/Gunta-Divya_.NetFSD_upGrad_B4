using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_7_Day_1.Models;
using Week_7_Day_1.Services;

namespace Week_7_Day_1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var products=_productService.GetAllProducts();


            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product=_productService.GetProductById(id);

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _productService.AddProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error is occured by creating a view");
                return Content("error occured pls try again", ex.Message);


            }
            
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product= _productService.GetProductById(id);
            
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _productService.UpdateProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch(Exception  ex)
            {
                ModelState.AddModelError(string.Empty, "error msg is getting when we updating th edit");
                return Content("error occured at updation", ex.Message);

            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product=_productService.GetProductById(id);
            
            return View(product) ;
        }

        // POST: ProductController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occured at delete");
                return Content("an error occured at", ex.Message);

            }
        }
    }
}
