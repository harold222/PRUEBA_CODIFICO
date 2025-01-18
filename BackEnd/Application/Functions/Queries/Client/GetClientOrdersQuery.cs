using Application.Functions.Vm;
using MediatR;

namespace Application.Functions.Queries.Client;

public class GetClientOrdersQuery : IRequest<IReadOnlyList<OrdersByClientVM>>
{
    public int Id { get; set; }
}
