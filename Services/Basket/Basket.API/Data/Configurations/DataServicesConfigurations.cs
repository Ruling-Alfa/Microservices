using Basket.API.Data.Interfaces;

namespace Basket.API.Data.Configurations
{
    public static class DataServicesConfigurations
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services)
        {
            services.AddTransient<IBasketRepository, BasketRepository>();
            return services;
        }
    }
}
