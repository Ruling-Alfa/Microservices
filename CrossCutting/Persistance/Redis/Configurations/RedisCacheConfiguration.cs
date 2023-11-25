using CrossCutting.Persistance.Redis.Helpers;
using CrossCutting.Persistance.Redis.Helpers.Interfaces;
using CrossCutting.Persistance.Redis.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Persistance.Redis.Configurations
{
    public static class RedisCacheConfiguration
    {
        public static IServiceCollection ConfigureRedisCacheInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisConnectionSettings>(
              configuration.GetSection("RedisConnectionSettings"));

            services.AddScoped<ICacheService, CacheService>();
            services.AddSingleton<IRedisConnectionHelper, RedisConnectionHelper>();

            return services;
        }
    }
}
