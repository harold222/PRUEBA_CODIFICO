using Application.Contracts.Persistence;
using Application.Functions.Vm;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Functions.Queries.Client;

public class GetClientOrdersQueryHandler : IRequestHandler<GetClientOrdersQuery, IReadOnlyList<OrdersByClientVM>>
{
    private readonly IRepositorySpecific _OrderRepository;
    private readonly IMapper Mapper;

    public GetClientOrdersQueryHandler(IRepositorySpecific repository, IMapper mapper)
    {
        this._OrderRepository = repository;
        this.Mapper = mapper;
    }

    public async Task<IReadOnlyList<OrdersByClientVM>> Handle(GetClientOrdersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Orders> item = await this._OrderRepository.GetOrderByClient(request.Id);
        return Mapper.Map<IReadOnlyList<OrdersByClientVM>>(item);
    }
}