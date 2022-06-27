using MongoDB.Bson;
using ProductManager.Core.Models;

namespace ProductManager.Core.Services.Interfaces;

public interface IProductService
{
    List<Product> GetProducts();
    Product AddProduct(Product product);
    Product GetProduct(Guid id);
    void DeleteProduct(Guid id);
    Product UpdateProduct(Product product);
    List<BsonDocument> GetProductsShortInfo();
    List<Product> GetUpdatedProducts();
}
