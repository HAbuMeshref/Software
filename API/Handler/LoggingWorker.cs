using Serilog;
using ILogger = Serilog.ILogger;


namespace API.Handler
{
    public class LoggingWorker : BackgroundService
    {
        private readonly ILogger<LoggingWorker> _logger;

        public LoggingWorker(ILogger<LoggingWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("LoggingWorker started at {Time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);  
            }

            _logger.LogInformation("LoggingWorker is stopping.");
        }

    }
}
