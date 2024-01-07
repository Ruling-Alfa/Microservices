using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderUnitOfWork _orderUow;
        private readonly IMapper _mapper;
        private readonly IEmailServices _emailServices;
        private readonly ILogger _logger;
        public CheckoutOrderCommandHandler(IOrderUnitOfWork orderUow, IMapper mapper,
            IEmailServices emailServices, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderUow = orderUow;
            _mapper = mapper;
            _emailServices = emailServices;
            _logger = logger;
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var newOrderEntity = await _orderUow.Repository.Insert(orderEntity);
            await _orderUow.Save();

            var newOrder = newOrderEntity.Entity;

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            await SendMail(newOrder);

            return newOrder.Id;
        }

        private async Task SendMail(Order order)
        {
            var email = new Email() { To = "someEmail@gmail.com", Body = $"Order was created.", Subject = "Order was created" };

            try
            {
                await _emailServices.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}
