using Microsoft.EntityFrameworkCore;

namespace CFDB_practice.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
    
}
