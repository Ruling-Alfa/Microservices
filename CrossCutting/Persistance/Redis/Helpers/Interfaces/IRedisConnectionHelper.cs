using StackExchange.Redis;

namespace CrossCutting.Persistance.Redis.Helpers.Interfaces
{
    public interface IRedisConnectionHelper
    {
        ConnectionMultiplexer Connection { get; }
    }
}