using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderUnitOfWork _orderUow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateOrderCommandHandler(IOrderUnitOfWork orderUow, IMapper mapper, ILogger<UpdateOrderCommandHandler> logger)
        {
            _orderUow = orderUow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderUow.Repository.GetByID(request.Id);
            if (orderToUpdate == null)
            {
                _logger.LogError($"Order {request.Id} doesn't exist in DB");
                throw new NotFoundException(nameof(Order), request.Id);
            }

            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));

            _orderUow.Repository.Update(orderToUpdate);
            await _orderUow.Save();

            _logger.LogInformation($"Order {orderToUpdate.Id} is successfully updated.");
        }
    }
}
