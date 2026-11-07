using FTELMarket.API.Data;
using FTELMarket.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FTELMarket.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // GET : api/products
    [HttpGet]
    public ActionResult<IEnumerable<ProductResponse>> GetProducts()
    {
        var products = _context.Products
            .Include(p => p.Category)
            .Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId,
                CreatedAt = p.CreatedAt,
                CategoryName = p.Category.Name
            })
            .ToList();

        return Ok(products);
    }

    // GET : api/categories
    [HttpGet("/api/categories")]
    public ActionResult<IEnumerable<CategoryResponse>> GetCategories()
    {
        var categories = _context.Categories
            .Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();

        return Ok(categories);
    }

    // POST : api/products
    [HttpPost]
    public ActionResult<ProductResponse> CreateProduct([FromBody] ProductRequest request)
    {
        var category = _context.Categories
            .FirstOrDefault(c => c.Id == request.CategoryId);

        if (category == null)
            return BadRequest("Catégorie inexistante.");

        var user = _context.Users.FirstOrDefault();

        if (user == null)
            return BadRequest("Aucun utilisateur disponible.");

        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            CategoryId = request.CategoryId,
            UserId = user.Id,
            CreatedAt = DateTimeOffset.UtcNow
        };

        _context.Products.Add(product);
        _context.SaveChanges();

        return Ok(new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            CreatedAt = product.CreatedAt,
            CategoryName = category.Name
        });
    }

    // PUT : api/products/{id}
    [HttpPut("{id:int}")]
    public ActionResult<ProductResponse> UpdateProduct(
        int id,
        [FromBody] ProductRequest request)
    {
        var product = _context.Products
            .Include(p => p.Category)
            .FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        var category = _context.Categories
            .FirstOrDefault(c => c.Id == request.CategoryId);

        if (category == null)
            return BadRequest("Catégorie inexistante.");

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.CategoryId = request.CategoryId;

        _context.SaveChanges();

        return Ok(new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            CreatedAt = product.CreatedAt,
            CategoryName = category.Name
        });
    }

    // DELETE : api/products/{id}
    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _context.Products
            .FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        _context.SaveChanges();

        return NoContent();
    }

    // DTO : réponse produit
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CategoryName { get; set; } = "";
    }

    // DTO : réponse catégorie
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    // DTO : requête produit
    public class ProductRequest
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; } = "";

        [StringLength(1000)]
        public string? Description { get; set; }

        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}