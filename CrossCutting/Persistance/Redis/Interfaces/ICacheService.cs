using System;
using System.Threading.Tasks;

namespace CrossCutting.Persistance.Redis.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetData<T>(string key);
        Task<bool> RemoveData(string key);
        Task<bool> SetData<T>(string key, T value);
        Task<bool> SetData<T>(string key, T value, DateTimeOffset expirationTime);
    }
}