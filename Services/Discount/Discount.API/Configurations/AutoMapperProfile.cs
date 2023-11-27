using AutoMapper;
using Discount.API.Business.Entities;
using Discount.API.Data.Entities;


namespace Discount.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
               CreateMap<CouponModel, Coupon>().ReverseMap();
        }
    }
}
