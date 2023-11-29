using CrossCutting.Persistance.SQL;
using CrossCutting.Persistance.SQL.Interfaces;
using Discount.Grpc.Data.Entities;
using Discount.Grpc.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountUnitOfWork : GenericUnitOfWork<Coupon> , IDiscountUnitOfWork
    {
        public DiscountUnitOfWork(DbContext dbContext, IGenericRepository<Coupon> repo) : base(dbContext, repo)
        {
        }
    }
}
