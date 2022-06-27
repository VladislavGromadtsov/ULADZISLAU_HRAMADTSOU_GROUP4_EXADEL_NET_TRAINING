using MongoDB.Bson;
using MongoDB.Driver;
using ProductManager.Core.Client.Interfaces;
using ProductManager.Core.Models;
using ProductManager.Core.Services.Interfaces;

namespace ProductManager.Core.Services;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _products;
    public ProductService(IDbClient dbClient)
    {
        _products = dbClient.GetProductCollection();
    }

    public Product AddProduct(Product product)
    {
        _products.InsertOne(product);
        return product;
    }

    public void DeleteProduct(Guid id)
    {
        _products.DeleteOne(p => p.Id == id);
    }

    public Product GetProduct(Guid id)
    {
        return _products.Find(p => p.Id == id).First();
    }
     
    public List<Product> GetProducts()
    {
        return _products.Find(product => true).ToList();
    }

    public Product UpdateProduct(Product product)
    {
        var version = GetProduct(product.Id).AuditInfo.Version;
        product.AuditInfo.Version = version + 1;
        _products.ReplaceOne(p => p.Id == product.Id, product);
        return product;
    }

    public List<BsonDocument> GetProductsShortInfo()
    {
        var projection = Builders<Product>.Projection.Include("name");
        var result = _products.Find(product => true).Project(projection).ToList();
        return result;
    }
}
