using Application.Contracts.Persistence;
using Application.Functions.Vm;
using AutoMapper;
using MediatR;

namespace Application.Functions.Queries.Employees;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IReadOnlyList<ListEmployeesVM>>
{
    private readonly IAsyncRepository<Domain.Employees> _EmployeeRepository;
    private readonly IMapper Mapper;

    public GetAllEmployeesQueryHandler(IAsyncRepository<Domain.Employees> repository, IMapper mapper)
    {
        this._EmployeeRepository = repository;
        this.Mapper = mapper;
    }

    public async Task<IReadOnlyList<ListEmployeesVM>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Employees> all = await this._EmployeeRepository.GetAllAsync(new() { "Empid", "FullName" });
        return Mapper.Map<IReadOnlyList<ListEmployeesVM>>(all);
    }
}