using AutoMapper;
using Discount.Grpc.Business.Interfaces;
using Discount.Grpc.Protos;
using Grpc.Core;
using System.Net;
using CoupounVM = Discount.Grpc.Business.Entities.CouponModel;

namespace Discount.Grpc.Services
{
    public class DiscountServiceService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountServiceService(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        public override async Task<CouponModel> AddDiscount(UpdateDiscountRequest Coupon, ServerCallContext context)
        {
            if (Coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"Model is null"));
            }
            var couponModel = _mapper.Map<CoupounVM>(Coupon);
            couponModel = await _discountService.CreateDiscount(couponModel);
            if (couponModel is null || couponModel.Id <= 0)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Unable to add {Coupon.ProductName} to DB"));
            }
            return _mapper.Map<Grpc.Protos.CouponModel>(couponModel);
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.ProductName))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"ProductName is null"));
            }
            var couponModel = await _discountService.GetDiscount(request.ProductName);
            if (couponModel is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Unable to find product {request.ProductName} in DB"));
            }
            return _mapper.Map<Grpc.Protos.CouponModel>(couponModel);
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.ProductName))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"ProductName is null"));
            }
            var isSuccess = await _discountService.DeleteDiscount(request.ProductName);

            return new DeleteDiscountResponse { IsSuccess = isSuccess };
        }
    }
}
