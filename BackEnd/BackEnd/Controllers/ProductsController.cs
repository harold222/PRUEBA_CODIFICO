using Application.Functions.Queries.Products;
using Application.Functions.Vm;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly IMediator Mediator;

    public ProductsController(IMediator mediator)
    {
        this.Mediator = mediator;
    }

    [HttpGet("GetProducts")]
    [ProducesResponseType(typeof(ProductsVM), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductsVM>> GetProducts()
    {
        GetAllProductsQuery query = new();
        IReadOnlyList<ProductsVM> result = await Mediator.Send(query);

        return Ok(result);
    }
}
