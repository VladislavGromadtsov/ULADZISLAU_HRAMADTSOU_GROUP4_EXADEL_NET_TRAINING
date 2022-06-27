using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductManager.Core.Client.Interfaces;
using ProductManager.Core.Configurations;
using ProductManager.Core.Models;

namespace ProductManager.Core.Client;

public class DbClient : IDbClient
{
    private readonly IMongoCollection<Product> _products;
    public DbClient(IOptions<ProductManagerDbConfig> productDbConfig)
    {
        var client = new MongoClient(productDbConfig.Value.Connection_String);
        var database = client.GetDatabase(productDbConfig.Value.Database_Name);
        _products = database.GetCollection<Product>(productDbConfig.Value.Products_Collection_Name);
    }
    public IMongoCollection<Product> GetProductCollection() => _products;
}
