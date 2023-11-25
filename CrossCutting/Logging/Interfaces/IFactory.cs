namespace CrossCutting.Logging.Interfaces
{
    public interface IFactory<T>
    {
        T Create();
    }
}
