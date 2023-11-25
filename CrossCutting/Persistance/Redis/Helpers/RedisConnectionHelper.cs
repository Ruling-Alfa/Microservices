using CrossCutting.Persistance.Redis.Configurations;
using CrossCutting.Persistance.Redis.Helpers.Interfaces;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;

namespace CrossCutting.Persistance.Redis.Helpers
{
    public class RedisConnectionHelper : IRedisConnectionHelper
    {
        public RedisConnectionHelper(IOptions<RedisConnectionSettings> options)
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(options.Value.RedisUrl);
            });
        }
        private Lazy<ConnectionMultiplexer> lazyConnection;
        public ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
