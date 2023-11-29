using Discount.Grpc.Business;
using Discount.Grpc.Business.Interfaces;

namespace Discount.Grpc.Configurations
{
    public static class BusinessServicesConfiguration
    {
        public static IServiceCollection ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IDiscountService, DiscountService>();

            return services;
        }
    }
}
