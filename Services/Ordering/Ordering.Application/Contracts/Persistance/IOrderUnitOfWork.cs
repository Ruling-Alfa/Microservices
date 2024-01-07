using CrossCutting.Persistance.SQL.Interfaces;
using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Persistance
{
    public interface IOrderUnitOfWork : IGenericUnitOfWork<Order>
    {
    }
}
