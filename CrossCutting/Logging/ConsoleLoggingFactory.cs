using CrossCutting.Logging.Interfaces;

namespace CrossCutting.Logging
{
    public class ConsoleLoggingFactory : IConsoleLoggingFactory
    {
        public ILogging GetLogger()
        {
            return new ConsoleLogging();
        }
    }
}
