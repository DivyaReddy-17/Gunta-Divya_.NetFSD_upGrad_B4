using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var allproducts = _context.Products.ToList();
            return Ok(allproducts);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if(product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] AddProductDto addProductDto)
        {
            var ProductEntity = new Product()
            {

                Name = addProductDto.Name,
                Price = addProductDto.Price,
                Category = addProductDto.Category,
                Stock = addProductDto.Stock,
            };
            _context.Products.Add(ProductEntity);
            _context.SaveChanges();
            return Ok(ProductEntity);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = updateProductDto.Name;
            product.Price = updateProductDto.Price;
            product.Category = updateProductDto.Category;
            product.Stock = updateProductDto.Stock;
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}


    

