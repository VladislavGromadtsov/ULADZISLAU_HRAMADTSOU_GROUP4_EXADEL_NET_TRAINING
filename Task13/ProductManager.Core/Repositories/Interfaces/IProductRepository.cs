﻿using MongoDB.Bson;
using ProductManager.Core.Models;

namespace ProductManager.Core.Repositories.Interfaces;

public interface IProductRepository
{
    List<Product> GetProducts();
    Product AddProduct(Product product);
    Product GetProduct(Guid id);
    void DeleteProduct(Guid id);
    Product UpdateProduct(Product product);
    List<Product> GetProductsShortInfo();
    List<Product> GetUpdatedProducts();
    List<Product> AddProducts(List<Product> products);
    Product UpdateProductName(Product product);
    void DeleteProductsWithEmptyFeatures();
}
