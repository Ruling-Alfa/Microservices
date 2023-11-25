using CrossCutting.Logging.Interfaces;

namespace CrossCutting.Logging
{
    public class FileLoggingFactory : IFileLoggingFactory
    {
        public ILogging GetLogger()
        {
            return new FileLogging();
        }
    }
}
