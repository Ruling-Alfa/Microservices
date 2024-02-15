using AutoMapper;
using Basket.API.Business.Models;
using Basket.API.Data.Entities;
using EventBus.Messages.Events;

namespace Basket.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartModel>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemModel>().ReverseMap();
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
            CreateMap<ShoppingCartModel, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
