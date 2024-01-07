using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderUnitOfWork _orderUow;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IOrderUnitOfWork orderUow, IMapper mapper, ILogger<DeleteOrderCommandHandler> logger)
        {
            _orderUow = orderUow ?? throw new ArgumentNullException(nameof(IOrderUnitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderUow.Repository.GetByID(request.Id);
            if (orderToDelete == null)
            {
                _logger.LogError($"Order {request.Id} doesn't exist in DB");
                throw new NotFoundException(nameof(Order), request.Id);
            }

            _orderUow.Repository.Delete(orderToDelete);
            await _orderUow.Save();

            _logger.LogInformation($"Order {orderToDelete.Id} is successfully deleted.");
        }
    }
}
