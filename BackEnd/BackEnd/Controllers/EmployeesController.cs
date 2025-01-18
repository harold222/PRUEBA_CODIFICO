using Application.Functions.Queries.Employees;
using Application.Functions.Vm;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{

    private readonly IMediator Mediator;

    public EmployeesController(IMediator mediator)
    {
        this.Mediator = mediator;
    }

    [HttpGet("GetEmployees")]
    [ProducesResponseType(typeof(EmployeeVM), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<EmployeeVM>> GetEmployees()
    {
        GetAllEmployeesQuery query = new();
        IReadOnlyList<ListEmployeesVM> result = await Mediator.Send(query);

        return Ok(result);
    }
}
