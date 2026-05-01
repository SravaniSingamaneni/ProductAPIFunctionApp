using ProductAPIFunctionApp.Models;
using ProductAPIFunctionApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPIFunctionApp.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task HandleMessageAsync(ProductMessage message)
        {
            switch (message.Action)
            {
                case "CREATE":
                    message.Product.ProductCreatedDate = DateTime.UtcNow;
                    await _productRepository.CreateAsync(message.Product);
                    break;

                case "DELETE":
                    await _productRepository.DeleteAsync(message.ProductId);
                    break;

                default:
                    throw new BadRequestException("Invalid Action");
            }
        }
    }
}
