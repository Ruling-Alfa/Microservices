using AutoMapper;
using Discount.Grpc.Business.Entities;
using Discount.Grpc.Data.Entities;


namespace Discount.Grpc.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CouponModel, Coupon>().ReverseMap();
            CreateMap<CouponModel, Discount.Grpc.Protos.CouponModel>().ReverseMap();
            CreateMap<CouponModel, Discount.Grpc.Protos.UpdateDiscountRequest>().ReverseMap();

        }
    }
}
