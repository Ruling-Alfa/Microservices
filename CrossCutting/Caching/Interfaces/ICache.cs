namespace CrossCutting.Caching.Interfaces
{
    public interface ICache
    {
        public T GetValue<T>(string key);
        public void SetValue<T>(string key, T value);
    }
}
