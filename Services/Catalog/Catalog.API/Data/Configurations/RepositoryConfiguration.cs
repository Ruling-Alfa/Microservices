using Catalog.API.Data;
using Catalog.API.Data.Interfaces;

namespace CrossCutting.Persistance.Mongo.Configurations
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
