using CrossCutting.Persistance.SQL.Interfaces;
using Discount.API.Data.Entities;

namespace Discount.API.Data.Interfaces
{
    public interface IDiscountUnitOfWork : IGenericUnitOfWork<Coupon>
    {
    }
}
