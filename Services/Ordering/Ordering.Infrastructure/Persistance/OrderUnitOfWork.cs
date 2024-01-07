using CrossCutting.Persistance.SQL;
using CrossCutting.Persistance.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistance;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderUnitOfWork : GenericUnitOfWork<Order>, IOrderUnitOfWork
    {
        public OrderUnitOfWork(DbContext dbContext, IGenericRepository<Order> repo) : base(dbContext, repo)
        {
        }
    }
}
