using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.Data;
using Storage.Domain;
using Storage.DTOs;

namespace Storage.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductController:  ControllerBase
{
    private  readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("/api/product/add")]
    public IActionResult AddProduct([FromBody] ProductDto productRequest)
    {
        var product = new Product {Name = productRequest.Name, Price = productRequest.Price};
        _context.Products.Add(product);
        _context.SaveChanges();
        return Ok(product);
    }

    [HttpGet]
    [Route("/api/product/getAll")]
    public IActionResult GetAllProducts()
    {
        var products = _context.Products.
            ToList();
        return Ok(products);
    }
}