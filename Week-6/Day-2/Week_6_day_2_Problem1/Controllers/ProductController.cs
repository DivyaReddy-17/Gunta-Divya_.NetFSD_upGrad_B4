using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_6_day_2_Problem1.Models;

namespace Week_6_day_2_Problem1.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>
            {
                new Product{ProductId="P001",ProductName="Book"},
                new Product{ProductId="P002",ProductName="Pen"},
                new Product{ProductId="P003",ProductName="Pencil"},
            };
        // GET: ProductController
        public ActionResult Index()
        {
            
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        


                
    

        // GET: ProductController/Edit/5
        public ActionResult Edit(string ProductId)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
