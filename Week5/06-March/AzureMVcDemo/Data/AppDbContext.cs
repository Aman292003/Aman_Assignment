using Microsoft.EntityFrameworkCore;
using AzureMVcDemo.Models;
namespace AzureMVcDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person> persons { set; get; }
    }
}
