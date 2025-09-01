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

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add this block to seed the database
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1299.99m },
                new Product { Id = 2, Name = "Wireless Mouse", Price = 79.99m },
                new Product { Id = 3, Name = "Mechanical Keyboard", Price = 149.50m },
                new Product { Id = 4, Name = "4K Monitor", Price = 650.00m }
            );
        }
    }
}
