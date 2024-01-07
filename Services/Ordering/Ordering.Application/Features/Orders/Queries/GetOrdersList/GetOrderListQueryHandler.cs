using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistance;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVM>>
    {
        private readonly IOrderUnitOfWork _orderUow;
        private readonly IMapper _mapper;
        public GetOrderListQueryHandler(IOrderUnitOfWork orderUow, IMapper mapper)
        {
            _orderUow = orderUow;
            _mapper = mapper;
        }
        public async Task<List<OrdersVM>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderUow.Repository.Get(x => x.UserName == request.UserName);
            return _mapper.Map<List<OrdersVM>>(orders);
        }
    }
}
