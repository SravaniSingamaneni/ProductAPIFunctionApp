using ProductAPIFunctionApp.Models;

namespace ProductAPIFunctionApp.Services
{
    public interface IProductService
    {
        Task HandleMessageAsync(ProductMessage message);
    }
}
