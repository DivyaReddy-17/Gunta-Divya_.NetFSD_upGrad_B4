using System.ComponentModel.DataAnnotations;

namespace Week_7_Day_1.Models
{
    public class Product
    {
        public int Id { get;set;  }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Range(1,1000,ErrorMessage="Price is between 1 and 1000")]
        public double Price {  get; set; }
    }
}
