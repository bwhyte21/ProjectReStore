using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Context;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly StoreContext _context;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="context"></param>
    public ProductsController(StoreContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets full list of products.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        return await _context.Products.FindAsync(id);
    }
}