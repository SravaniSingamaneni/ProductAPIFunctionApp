using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using ProductAPIFunctionApp.Models;

namespace ProductAPIFunctionApp.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config) 
        {
            var connectionString = config["MongoDbSettings:ConnectionString"];
            var dbName = config["MongoDbSettings:DatabaseName"];
            // var collectionName = config["MongoDbSettings:CollectionName"];

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(dbName);
        }
        public IMongoCollection<Product> Products =>
            _database.GetCollection<Product>("products");
    }
}
