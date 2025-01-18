using Application.Functions.Vm;
using MediatR;

namespace Application.Functions.Queries.Order;

public class GetNextOrderQuery : IRequest<IReadOnlyList<NextOrderVM>>
{
    public string Filter { get; set; }
}
