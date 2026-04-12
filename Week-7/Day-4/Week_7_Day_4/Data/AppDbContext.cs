using Microsoft.EntityFrameworkCore;
using Week_7_Day_4.Models;

namespace Week_7_Day_4.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        
    }
}
