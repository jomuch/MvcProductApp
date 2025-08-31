using MvcProductApp.Models;

namespace MvcProductApp.Services
{
    public interface IProductService
    {
        Product? GetFeaturedProduct();
    }
}