using CrossCutting.Persistance.Mongo.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Persistance.Mongo.Configurations
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection ConfigureCrosscuttingMongoRepositorySettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSettings>(
               configuration.GetSection("MongoDatabaseSettings"));

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            return services;
        }
    }
}
