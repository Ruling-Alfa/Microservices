namespace CrossCutting.Logging.Interfaces
{
    public interface ILoggingFactory
    {
        ILogging GetLogger();
    }
}