using AutoMapper;
using Basket.API.Business.Models;
using Basket.API.Data.Entities;

namespace Basket.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartModel>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemModel>().ReverseMap();
        }
    }
}
