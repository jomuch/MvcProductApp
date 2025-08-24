using Microsoft.EntityFrameworkCore;
using MvcProductApp.Models;

namespace MvcProductApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // This DbSet represents the "Products" table in the database
        public DbSet<Product> Products { get; set; }
    }
}
