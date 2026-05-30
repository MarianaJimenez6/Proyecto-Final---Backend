//Escritorio\ecommerce\ECommerce.Api\Controllers\OrdersController.cs

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Features.Orders.Commands.CreateOrder;
using ECommerce.Application.Features.Orders.Queries.GetOrdersByUserId;
using ECommerce.Application.Features.Orders.Queries.GetOrderById;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetOrderByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(Guid userId)
    {
        var result = await _mediator.Send(new GetOrdersByUserIdQuery(userId));
        return Ok(result);
    }
}