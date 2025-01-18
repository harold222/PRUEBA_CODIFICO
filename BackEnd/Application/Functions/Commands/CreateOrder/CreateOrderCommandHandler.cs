using Application.Contracts.Persistence;
using Application.Functions.Vm;
using Domain;
using MediatR;
using System.Data;

namespace Application.Functions.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, NewOrderVm>
{
    private readonly IAsyncRepository<CreateNewOrder> _repository;

    public CreateOrderCommandHandler(IAsyncRepository<CreateNewOrder> repository)
    {
        this._repository = repository;
    }

    public async Task<NewOrderVm> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        string keyOutput = "NewOrderId";

        IDictionary<string, object> newOrder = await this._repository.ExecuteStoredProcedureAsync("CreateNewOrder", request, new Dictionary<string, DbType>
        {
            { keyOutput, DbType.Int32 }
        });

        return new NewOrderVm() { Id = (int)newOrder[keyOutput] };
    }
}
