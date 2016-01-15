using log4net;

namespace Redmine.Net.Api.Logging.log4net
{
    public class Log4NetLogger: ILogger
    {
        private readonly ILog log;

        public Log4NetLogger(ILog log)
        {
            this.log = log;
        }

        public void Log(LogEntry entry)
        {
            switch (entry.Severity)
            {
                case LoggingEventType.Debug:
                    log.Debug(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Information:
                    log.Info(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Warning:
                    log.Warn(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Error:
                    log.Error(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Fatal:
                    log.Fatal(entry.Message, entry.Exception);
                    break;
            }
        }
    }
}