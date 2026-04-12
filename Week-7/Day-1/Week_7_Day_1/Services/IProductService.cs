using Week_7_Day_1.Models;

namespace Week_7_Day_1.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
