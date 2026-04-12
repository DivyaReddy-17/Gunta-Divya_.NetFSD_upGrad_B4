using Week_7_Day_1.Models;

namespace Week_7_Day_1.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>()
            {
            new Product{Id=1,Name="Book",Price=50},
            new Product{Id=2,Name="Pen",Price=10},
            new Product{Id=3,Name="Pencil",Price=20}
            };
        }



       
        public List<Product>GetAllProducts()
        {
            return _products;
        }
        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void AddProduct(Product product)
        {
            product.Id=_products.Count>0?_products.Max(p=>p.Id)+1:1;
            _products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if(existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }
        public void DeleteProduct(int id)
        {
            var product= _products.FirstOrDefault(p => p.Id==id);

            if(product != null)
            {
                _products.Remove(product);
            }
        }

    }
}
