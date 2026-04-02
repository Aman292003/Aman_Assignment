using Microsoft.EntityFrameworkCore;

namespace ProductTask.Models
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions dbContextOptions):base(dbContextOptions) { 
        
        }

        public DbSet<Product> Products { get; set; }
    }
}
