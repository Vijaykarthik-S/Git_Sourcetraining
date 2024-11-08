using Microsoft.EntityFrameworkCore;

namespace DTO_demo.Models
{
    public class MyContext : DbContext
    {
       public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
