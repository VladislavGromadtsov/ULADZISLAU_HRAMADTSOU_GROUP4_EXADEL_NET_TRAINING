using MongoDB.Driver;
using ProductManager.Core.Models;

namespace ProductManager.Core.Client.Interfaces;

public interface IDbClient
{
    IMongoCollection<Product> GetProductCollection();
}
