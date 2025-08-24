using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProductApp.Data;
using MvcProductApp.Models;

namespace MvcProductApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Product Index page visited at {DT}", DateTime.UtcNow);
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Product '{ProductName}' created successfully.", product.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Note: For a complete app, you would also add GET and POST actions
        // for Edit, a GET for Details, and GET/POST for Delete.
        // Visual Studio's scaffolding can generate these for you automatically.
    }
}