using System.ComponentModel.DataAnnotations;

namespace Week_7_Day_4.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Department { get; set; }

        [Range(0, 1000000)]
        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }
    }

}

