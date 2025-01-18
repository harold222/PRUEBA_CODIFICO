using Application.Functions.Vm;
using MediatR;

namespace Application.Functions.Queries.Employees;

public class GetAllEmployeesQuery : IRequest<IReadOnlyList<ListEmployeesVM>>
{
}
