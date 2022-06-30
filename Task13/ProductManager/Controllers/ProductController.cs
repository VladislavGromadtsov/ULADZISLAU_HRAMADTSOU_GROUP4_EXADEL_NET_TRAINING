using Microsoft.AspNetCore.Mvc;
using ProductManager.Core.Models;
using MongoDB.Bson;
using ProductManager.Core.Repositories.Interfaces;

namespace ProductManager.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productService;

    public ProductController(IProductRepository productService)
    { 
        _productService = productService;
    }

    [HttpGet("GetProductsShortInfo")]
    public IActionResult GetProductsShortInfo()
    {
        var result = _productService.GetProductsShortInfo();
        return Ok(result);
    }

    [HttpGet("GetUpdatedProducts")]
    public IActionResult GetUpdatedProducts()
    {
        var result = _productService.GetUpdatedProducts();
        return Ok(result);
    }

    [HttpGet("All")]
    public IActionResult GetAllProducts()
    {
        return Ok(_productService.GetProducts());
    }

    [HttpGet("{id}", Name ="GetProduct")]
    public IActionResult GetProduct(Guid id)
    {
        var result = _productService.GetProduct(id); 
        return Ok(result);
    }

    [HttpPost("AddProducts")]
    public IActionResult AddProducts(List<Product> products)
    {
        var result = _productService.AddProducts(products);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        var result = _productService.AddProduct(product);
        return CreatedAtRoute("GetProduct", new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(Guid id)
    {
        _productService.DeleteProduct(id);
        return Ok(); 
    }

    [HttpPut]
    public IActionResult UpdateProduct(Product product)
    {
        return Ok(_productService.UpdateProduct(product));
    }

    [HttpPut("UpdateProductName")]
    public IActionResult UpdateProductName(Product product)
    {
        return Ok(_productService.UpdateProductName(product));
    }

    [HttpDelete("DeleteProductsWithEmptyFeatures")]
    public IActionResult DeleteProductsWithEmptyFeatures()
    {
        _productService.DeleteProductsWithEmptyFeatures();
        return Ok();
    }
}
