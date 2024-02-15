using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BasketCheckoutEvent, CheckoutOrderCommand>()
                .ForMember(evt => evt.Id, m => m.MapFrom(_ => 0)).ReverseMap();
        }
    }
}
