using Discount.API.Business.Entities;

namespace Discount.API.Business.Interfaces
{
    public interface IDiscountService
    {
        Task<CouponModel?> CreateDiscount(CouponModel couponModel);
        Task<bool> DeleteDiscount(string ProductName);
        Task<CouponModel> GetDiscount(string ProductName);
        Task<CouponModel?> UpdateDiscount(CouponModel couponModel);
    }
}