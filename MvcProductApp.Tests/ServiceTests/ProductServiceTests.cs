using Microsoft.EntityFrameworkCore;
using Moq;
using MvcProductApp.Data;
using MvcProductApp.Models;
using MvcProductApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace MvcProductApp.Tests.ServiceTests
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetFeaturedProduct_ReturnsMostExpensiveProduct()
        {
            // Arrange: Set up the test data and mocks
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1200.00m },
                new Product { Id = 2, Name = "Mouse", Price = 25.50m },
                new Product { Id = 3, Name = "Monitor", Price = 350.00m }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductService(mockContext.Object);

            // Act: Call the method being tested
            var result = service.GetFeaturedProduct();

            // Assert: Verify the result is correct
            Assert.NotNull(result);
            Assert.Equal("Laptop", result.Name);
            Assert.Equal(1200.00m, result.Price);
        }
    }
}