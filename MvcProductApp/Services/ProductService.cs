using MvcProductApp.Data;
using MvcProductApp.Models;

namespace MvcProductApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product? GetFeaturedProduct()
        {
            // Business logic: The "featured" product is the most expensive one.
            return _context.Products
                .OrderByDescending(p => p.Price)
                .FirstOrDefault();
        }
    }
}
