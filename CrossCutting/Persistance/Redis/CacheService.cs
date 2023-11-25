using CrossCutting.Persistance.Redis.Helpers.Interfaces;
using CrossCutting.Persistance.Redis.Interfaces;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrossCutting.Persistance.Redis
{
    public class CacheService : ICacheService
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        private static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
        private readonly IDatabase _db;
        public CacheService(IRedisConnectionHelper redisConnectionHelper)
        {
            _db = redisConnectionHelper.Connection.GetDatabase();
        }
        public async Task<T> GetData<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }
        public async Task<bool> SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = await _db.StringSetAsync(key, JsonSerializer.Serialize(value), expiryTime);
            return isSet;
        }

        public async Task<bool> SetData<T>(string key, T value)
        {
            var isSet = await _db.StringSetAsync(key, JsonSerializer.Serialize(value));
            return isSet;
        }
        public async Task<bool> RemoveData(string key)
        {
            bool _isKeyExist = await _db.KeyExistsAsync(key);
            if (_isKeyExist == true)
            {
                return await _db.KeyDeleteAsync(key);
            }
            return false;
        }
    }
}
