﻿using MongoDB.Bson;
using MongoDB.Driver;
using ProductManager.Core.Client.Interfaces;
using ProductManager.Core.Models;
using ProductManager.Core.Repositories.Interfaces;

namespace ProductManager.Core.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _products;
    public ProductRepository(IDbClient dbClient)
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
        var filter = Builders<Product>.Filter.Eq("_id", product.Id);
        var update = Builders<Product>.Update.Set("name", product.Name)
            .Set("Features", product.Features).Inc("AuditInfo.Version", 1);
        var opt = new FindOneAndUpdateOptions<Product> { ReturnDocument = ReturnDocument.After };
        var result = _products.FindOneAndUpdate(filter, update, opt);

        return result;
    }

    public Product UpdateProductName(Product product)
    {
        var filter = Builders<Product>.Filter.Eq("_id", product.Id);
        var update = Builders<Product>.Update.Set("name", product.Name).Inc("AuditInfo.Version", 1);
        var opt = new FindOneAndUpdateOptions<Product> { ReturnDocument = ReturnDocument.After };
        var result = _products.FindOneAndUpdate(filter, update, opt);

        return result;
    }

    public List<Product> GetProductsShortInfo()
    {
        var projection = Builders<Product>.Projection.Include(x=> x.Name);
        var result = _products.Find(product => true).Project<Product>(projection).ToList();
        return result;
    }

    public List<Product> GetUpdatedProducts()
    {
        var filter = Builders<Product>.Filter.Gt("AuditInfo.Version", 1);
        var result = _products.Find(filter).SortBy(p => p.AuditInfo.Version).ToList();
        return result;
    }

    public List<Product> AddProducts(List<Product> products)
    {
        foreach (var product in products)
        {
            product.AuditInfo.CreatedOn = DateTime.UtcNow;
        }

        _products.InsertMany(products);
        return products;
    }

    public void DeleteProductsWithEmptyFeatures()
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Or(builder.Size("Features", 0), builder.Exists("Features", false));

        var result = _products.DeleteMany(filter);
    }
}
