using Application.Functions.Commands.CreateOrder;
using Application.Functions.Queries.Client;
using Application.Functions.Queries.Order;
using Application.Functions.Vm;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator Mediator;

    public OrderController(IMediator mediator)
    {
        this.Mediator = mediator;
    }

    [HttpGet("NextOrder")]
    [ProducesResponseType(typeof(NextOrderVM), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<NextOrderVM>> NextOrder([FromQuery] string? filter = "")
    {
        GetNextOrderQuery query = new();
        query.Filter = filter;

        IReadOnlyList<NextOrderVM> result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("GetOrderByClient/{Id}")]
    [ProducesResponseType(typeof(OrdersByClientVM), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<OrdersByClientVM>> GetOrderByClient([FromRoute] int id)
    {
        GetClientOrdersQuery query = new();
        query.Id = id;

        IReadOnlyList<OrdersByClientVM> result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("CreateOrder")]
    [ProducesResponseType(typeof(NewOrderVm), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<NewOrderVm>> CreateOrder([FromBody] CreateOrderCommand request)
    {
        NewOrderVm result = await Mediator.Send(request);

        return Ok(result);
    }
}
