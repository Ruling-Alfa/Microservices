namespace CrossCutting.Logging.Interfaces
{
    public interface ILogging
    {
        void LogError(string info);
        void LogInfo(string info);
    }
}