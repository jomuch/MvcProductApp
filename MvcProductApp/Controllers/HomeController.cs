using Microsoft.AspNetCore.Mvc;
using MvcProductApp.Models;
using MvcProductApp.Services; // Add this using statement
using System.Diagnostics;

namespace MvcProductApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService; // Add this field

        // Update the constructor to accept IProductService
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // Update the Index action to use the service
        public IActionResult Index()
        {
            var featuredProduct = _productService.GetFeaturedProduct();
            ViewData["FeaturedProduct"] = featuredProduct?.Name ?? "No products yet!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}