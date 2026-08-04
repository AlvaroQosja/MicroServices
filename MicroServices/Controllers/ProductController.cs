using Microsoft.AspNetCore.Mvc;
using ProductServices.Data;

namespace ProductServices.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly ProductStore _catalog;

    public ProductsController(ProductStore catalog)
    {
        _catalog = catalog;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_catalog.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _catalog.GetById(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }
}