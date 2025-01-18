using Application.Functions.Queries.Shippers;
using Application.Functions.Vm;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShippersController : ControllerBase
{
    private readonly IMediator Mediator;

    public ShippersController(IMediator mediator)
    {
        this.Mediator = mediator;
    }

    [HttpGet("GetShippers")]
    [ProducesResponseType(typeof(ShippersVM), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<EmployeeVM>> GetShippers()
    {
        GetAllShippersQuery query = new();
        IReadOnlyList<ShippersVM> result = await Mediator.Send(query);

        return Ok(result);
    }
}
