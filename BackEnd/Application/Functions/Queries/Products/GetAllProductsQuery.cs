using Application.Functions.Vm;
using MediatR;
namespace Application.Functions.Queries.Products;

public class GetAllProductsQuery : IRequest<IReadOnlyList<ProductsVM>>
{
}
