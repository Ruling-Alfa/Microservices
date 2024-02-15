using EventBus.Messages.Common;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.Messages
{
    public static class EventBusConfigurations
    {
        public static IServiceCollection ConfigureRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            //Mass transit RabbitMQ Config
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration.GetValue<string>("EventBusSettings:HostAddress"));
                });
            });

            //services.AddMassTransitHostedService();

            return services;
        }

        public static IServiceCollection ConfigureConsumerRabbitMQ<TConsumer>(this IServiceCollection services, IConfiguration configuration) where TConsumer : class, IConsumer 
        {
            //Mass transit RabbitMQ Config
            services.AddMassTransit(config =>
            {
                config.AddConsumer<TConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration.GetValue<string>("EventBusSettings:HostAddress"));
                    cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
                    {
                        c.ConfigureConsumer<TConsumer>(ctx);
                    });
                });
            });

            //services.AddMassTransitHostedService();

            return services;
        }
    }
}
