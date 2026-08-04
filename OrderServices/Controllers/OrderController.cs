using Microsoft.AspNetCore.Mvc;
using OrderServices.Data;
using OrderServices.Model;
using OrderServices.Services;

namespace OrderServices.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    private readonly OrderStore _orderStore;
    private readonly ProductClient _productClient;


    public OrderController(
        OrderStore orderStore,
        ProductClient productClient)
    {
        _orderStore = orderStore;
        _productClient = productClient;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_orderStore.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        var order = _orderStore.GetById(id);

        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        var product = await _productClient.GetProduct(order.ProductId);

        if (product == null)
        {
            return BadRequest("Product does not exist.");
        }


        var createdOrder = _orderStore.Add(
            order.ProductId,
            order.Quantity
        );


        return Ok(createdOrder);
    }
}