using Application.Contracts.Persistence;
using Application.Functions.Vm;
using AutoMapper;
using MediatR;

namespace Application.Functions.Queries.Shippers;

public class GetAllShippersQueryHandler : IRequestHandler<GetAllShippersQuery, IReadOnlyList<ShippersVM>>
{
    private readonly IAsyncRepository<Domain.Shippers> _ShipeersRepository;
    private readonly IMapper Mapper;

    public GetAllShippersQueryHandler(IAsyncRepository<Domain.Shippers> repository, IMapper mapper)
    {
        this._ShipeersRepository = repository;
        this.Mapper = mapper;
    }

    public async Task<IReadOnlyList<ShippersVM>> Handle(GetAllShippersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Shippers> all = await this._ShipeersRepository.GetAllAsync(new() { "Shipperid", "Companyname" });
        return Mapper.Map<IReadOnlyList<ShippersVM>>(all);
    }
}
