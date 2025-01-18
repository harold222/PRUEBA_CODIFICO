using Application.Functions.Vm;
using MediatR;

namespace Application.Functions.Queries.Shippers;

public class GetAllShippersQuery : IRequest<IReadOnlyList<ShippersVM>>
{
}
