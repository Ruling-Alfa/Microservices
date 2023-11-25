using CrossCutting.Logging.Interfaces;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace CrossCutting.Logging
{
    public class FileLogging : IFileLogging
    {
        private readonly string _filename = "log.txt";
        private readonly string _directoryPath = "Logs";
        private Serilog.Core.Logger _logger;
        public FileLogging()
        {
            if (!Directory.Exists($"{_directoryPath}"))
            {
                Directory.CreateDirectory($"{_directoryPath}");
            }

            _logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.File($"{_directoryPath}\\{_filename}",
                fileSizeLimitBytes: 1_000_000,
                rollOnFileSizeLimit: true,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1))
            .CreateLogger();
        }

        public void LogInfo(string info)
        {
            _logger.Information(info);
        }
        public void LogError(string info)
        {
            _logger.Error(info);
        }
    }
}
