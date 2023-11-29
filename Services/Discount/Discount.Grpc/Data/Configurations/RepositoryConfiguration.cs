using CrossCutting.Persistance.SQL.Configurations;
using Discount.Grpc.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data.Configurations
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection ConfigureRepositorySettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurePersistanceInfra();

            services.AddDbContext<DiscountContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString(nameof(DiscountContext))));

            services.AddTransient<IDiscountUnitOfWork, DiscountUnitOfWork>();
            services.AddScoped<DbContext, DiscountContext>();
            return services;
        }
    }
}
