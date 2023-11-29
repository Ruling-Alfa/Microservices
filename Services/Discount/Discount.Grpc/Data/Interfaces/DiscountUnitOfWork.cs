using CrossCutting.Persistance.SQL.Interfaces;
using Discount.Grpc.Data.Entities;

namespace Discount.Grpc.Data.Interfaces
{
    public interface IDiscountUnitOfWork : IGenericUnitOfWork<Coupon>
    {
    }
}
