namespace ProductApi.Models
{
    public class AddProductDto
    {
        public int ID{ get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
    }
}
