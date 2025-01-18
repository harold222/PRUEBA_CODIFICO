using Domain;

namespace Application.Contracts.Persistence;

public interface IRepositorySpecific
{
    Task<IEnumerable<Orders>> GetOrderByClient(int Id);
}
