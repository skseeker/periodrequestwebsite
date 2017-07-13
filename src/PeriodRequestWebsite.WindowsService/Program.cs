using System;
using System.IO;
using System.ServiceProcess;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace PeriodRequestWebsite.WindowsService
{
    static class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger("PeriodRequestWebsite");

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(System.Environment.CurrentDirectory + Path.DirectorySeparatorChar + "log4net.config"));

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new PeriodRequestWebsiteService()
            };
            ServiceBase.Run(ServicesToRun);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;

            _logger.Error(exception.Message);

        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            _logger.Error(e.Exception.Message);
        }
    }
}
