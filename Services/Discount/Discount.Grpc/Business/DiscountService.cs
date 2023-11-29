using AutoMapper;
using Discount.Grpc.Business.Entities;
using Discount.Grpc.Business.Interfaces;
using Discount.Grpc.Data.Entities;
using Discount.Grpc.Data.Interfaces;

namespace Discount.Grpc.Business
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DiscountService(IDiscountUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CouponModel> GetDiscount(string ProductName)
        {
            var coupon = await _unitOfWork.Repository.GetOneByQuery(c => c.ProductName == ProductName);
            if (coupon is null)
            {
                return new CouponModel()
                {
                    ProductName = "No Discount",
                    Amount = 0,
                    ProductDescription = "No Discount Description"
                };
            }
            return _mapper.Map<CouponModel>(coupon);
        }

        public async Task<CouponModel?> CreateDiscount(CouponModel couponModel)
        {
            var coupon = await _unitOfWork.Repository.GetOneByQuery(c => c.ProductName == couponModel.ProductName);
            if (coupon is null)
            {
                coupon = _mapper.Map<Coupon>(couponModel);
                var couponEntity = await _unitOfWork.Repository.Insert(coupon);
                await _unitOfWork.Save();
                coupon = couponEntity.Entity;
                return _mapper.Map<CouponModel>(coupon);
            }
            return default;
        }

        public async Task<CouponModel?> UpdateDiscount(CouponModel couponModel)
        {
            if (!await _unitOfWork.Repository.ExistsById(couponModel.Id))
            {
                return default;
            }
            var coupon = _mapper.Map<Coupon>(couponModel);
            _unitOfWork.Repository.Update(coupon);
            await _unitOfWork.Save();
            return couponModel;
        }

        public async Task<bool> DeleteDiscount(string ProductName)
        {
            var coupon = await _unitOfWork.Repository.GetOneByQuery(c => c.ProductName == ProductName);
            if (coupon is null)
            {
                return false;
            }
            await _unitOfWork.Repository.Delete(coupon.Id);
            await _unitOfWork.Save();
            return true;
        }

    }
}
