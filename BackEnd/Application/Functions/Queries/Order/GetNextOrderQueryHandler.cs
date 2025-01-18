using Application.Contracts.Persistence;
using Application.Functions.Vm;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Functions.Queries.Order;

public class GetNextOrderQueryHandler : IRequestHandler<GetNextOrderQuery, IReadOnlyList<NextOrderVM>>
{
    private readonly IAsyncRepository<NextOrder> _OrderRepository;
    private readonly IMapper Mapper;

    public GetNextOrderQueryHandler(IAsyncRepository<NextOrder> repository, IMapper mapper)
    {
        this._OrderRepository = repository;
        this.Mapper = mapper;
    }

    public async Task<IReadOnlyList<NextOrderVM>> Handle(GetNextOrderQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<NextOrder> all = await this._OrderRepository.QueryStoredProcedureAsync("GetCustomerOrderPrediction", new { Filter = request.Filter ?? "" });
        return Mapper.Map<IReadOnlyList<NextOrderVM>>(all);
    }
}
