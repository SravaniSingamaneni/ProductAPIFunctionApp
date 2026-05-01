using MongoDB.Driver;
using ProductAPIFunctionApp.Data;
using ProductAPIFunctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPIFunctionApp.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly MongoDbContext _context;
        public ProductRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id == id);
            await _context.Products.DeleteOneAsync(filter);
        }
    }
}
