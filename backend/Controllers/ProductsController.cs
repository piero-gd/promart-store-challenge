using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromartStore.API.Data;
using PromartStore.API.Models;

namespace PromartStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController(AppDbContext db) : ControllerBase
{
    /// <summary>
    /// Retorna todos los productos disponibles.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await db.Products
            .Include(p => p.Rating)
            .AsNoTracking()
            .ToListAsync();

        return Ok(products);
    }

    /// <summary>
    /// Retorna los productos filtrados por categoría.
    /// </summary>
    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(string category)
    {
        var products = await db.Products
            .Include(p => p.Rating)
            .Where(p => p.Category.ToLower() == category.ToLower())
            .AsNoTracking()
            .ToListAsync();

        return Ok(products);
    }

    /// <summary>
    /// Retorna un producto por su ID.
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await db.Products
            .Include(p => p.Rating)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null) return NotFound();

        return Ok(product);
    }
}
