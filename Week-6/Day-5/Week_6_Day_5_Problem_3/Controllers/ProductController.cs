using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Week_6_Day_5_Problem_3.Models;

namespace Week_6_Day_5_Problem_3.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var productList=GetProductsFromSession();
            ViewBag.Products=productList;
            return View();
        }
        [HttpPost("add")]
        public IActionResult Add(string name, decimal price, int quantity)
        {
            var productList = GetProductsFromSession()??new List<Product>();
            productList.Add(
                new Product { Name = name, Price = price, Quantity = quantity });
            SaveProductsToSession(productList);
            ViewBag.Products = productList;
            return View("Index");
        }

        

        private List<Product>GetProductsFromSession()
        {
            var data = HttpContext.Session.GetString("Products");
            
            if(data==null)
            {
                return new List<Product>();
            }
            return JsonSerializer.Deserialize<List<Product >> (data)??new List<Product>();
        }
        private void SaveProductsToSession(List<Product>products)
        {
            HttpContext.Session.SetString("Products", JsonSerializer.Serialize(products));
        }
    }
}
