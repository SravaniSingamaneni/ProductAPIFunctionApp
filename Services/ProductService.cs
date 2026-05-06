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
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            switch (message.Action?.ToUpper())
            {
                case "CREATE":
                    if (message.Product == null)
                        throw new ArgumentException("Product is required!");

                    message.Product.ProductCreatedDate = DateTime.UtcNow;
                    await _productRepository.CreateAsync(message.Product);
                    break;

                case "DELETE":
                    if (String.IsNullOrEmpty(message.ProductId))
                        throw new ArgumentException("ProductId is required!");

                    await _productRepository.DeleteAsync(message.ProductId);
                    break;

                default:
                    throw new ArgumentException("Invalid Action");
            }
        }
    }
}
