using Application.Contracts.Persistence;
using Application.Functions.Vm;
using AutoMapper;
using MediatR;

namespace Application.Functions.Queries.Products;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<ProductsVM>>
{
    private readonly IAsyncRepository<Domain.Products> _ProductRepository;
    private readonly IMapper Mapper;

    public GetAllProductsQueryHandler(IAsyncRepository<Domain.Products> repository, IMapper mapper)
    {
        this._ProductRepository = repository;
        this.Mapper = mapper;
    }

    public async Task<IReadOnlyList<ProductsVM>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Products> all = await this._ProductRepository.GetAllAsync(new() { "Productid", "Productname" });
        return Mapper.Map<IReadOnlyList<ProductsVM>>(all);
    }
}
