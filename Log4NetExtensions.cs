using System;
using System.IO;
using log4net;
using log4net.Config;

namespace Redmine.Net.Api.Logging.log4net
{
    /// <summary>
    ///   Extensions for configuring Logging for log4net
    /// </summary>
    public static class Log4NetExtensions
    {
        public static void UseLog4Net(this RedmineManager redmineManager)
        {
            var log = LogManager.GetLogger("Redmine");
            BasicConfigurator.Configure();
            Logger.UseLogger(new Log4NetLogger(log));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="redmineManager"></param>
        /// <param name="configFileName"></param>
        /// <param name="watchFile">Should log4net watch the config file? </param>
        public static void UseLog4Net(this RedmineManager redmineManager, string configFileName, bool watchFile = false)
        {
            var log = LogManager.GetLogger("Redmine");
            if (!string.IsNullOrEmpty(configFileName))
            {
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFileName);
                var configFile = new FileInfo(file);
                if (configFile.Exists)
                {
                    if (watchFile)
                    {
                        XmlConfigurator.ConfigureAndWatch(configFile);
                    }
                    else
                    {
                        XmlConfigurator.Configure(configFile);
                    }
                }
            }
            else
            {
                BasicConfigurator.Configure();
            }
            Logger.UseLogger(new Log4NetLogger(log));
        }
    }
}