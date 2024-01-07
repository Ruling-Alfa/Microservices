using CrossCutting.Persistance.SQL.Interfaces;
using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Persistance
{
    public interface IOrderingRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string UserName);
    }
}
