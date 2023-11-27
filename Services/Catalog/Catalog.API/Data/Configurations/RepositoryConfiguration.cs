using Catalog.API.Data;
using Catalog.API.Data.Interfaces;
using CrossCutting.Persistance.Mongo.Configurations;

namespace Catalog.API.Data.Configurations
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection ConfigureRepositorySettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureCrosscuttingMongoRepositorySettings(configuration);
            services.AddScoped<ICatalogRepository,CatalogRepository>();
            return services;
        }
    }
}
