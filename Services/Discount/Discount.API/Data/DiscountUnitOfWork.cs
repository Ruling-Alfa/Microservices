using CrossCutting.Persistance.SQL;
using CrossCutting.Persistance.SQL.Interfaces;
using Discount.API.Data.Entities;
using Discount.API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Data
{
    public class DiscountUnitOfWork : GenericUnitOfWork<Coupon> , IDiscountUnitOfWork
    {
        public DiscountUnitOfWork(DbContext dbContext, IGenericRepository<Coupon> repo) : base(dbContext, repo)
        {
        }
    }
}
