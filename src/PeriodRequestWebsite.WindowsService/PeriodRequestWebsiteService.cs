using System;
using System.Configuration;
using System.Net.Http;
using System.ServiceProcess;
using System.Timers;
using log4net;

namespace PeriodRequestWebsite.WindowsService
{
    public partial class PeriodRequestWebsiteService : ServiceBase
    {
        private HttpClient _httpClient = new HttpClient();
        private ILog _logger = LogManager.GetLogger("PeriodRequestWebsite");
        private TargetWebsiteSettingConfigurationSection _targetWebsiteSetting;

        private Timer _timer;

        public PeriodRequestWebsiteService()
        {
            InitializeComponent();

            try
            {
                _targetWebsiteSetting = ConfigurationManager.GetSection("targetWebsiteSetting") as TargetWebsiteSettingConfigurationSection;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }
        }

        protected override void OnStart(string[] args)
        {
            _logger.Info("Service Starting");

            _timer = new Timer(1000 * _targetWebsiteSetting.IntervalSecond);
            
            _timer.Elapsed += (sender, eventArgs) => Request(sender, _targetWebsiteSetting.Websites);
            _timer.Start();
        }

        protected override void OnStop()
        {
            _logger.Info("Service Stop");

            _timer.Stop();
            _timer = null;
        }

        protected async void Request(object sender, Websites websites)
        {
            foreach (Website website in websites)
            {
                if (!string.IsNullOrEmpty(website.Url))
                {
                    try
                    {
                        _logger.Info(string.Format("Requesting Website: {0}", website.Name));

                        HttpResponseMessage response = await _httpClient.GetAsync(website.Url);

                        _logger.Info(string.Format("Url: {0} Response StatusCode: {1}", website.Url, response.StatusCode.ToString()));
                    }
                    catch (HttpRequestException exception)
                    {
                        _logger.Error(string.Format("Url: {0} Throw HttpRequestException: {1}", website.Url, exception.Message));
                    }
                    catch (Exception exception)
                    {
                        _logger.Error(string.Format("Url: {0} Throw Exception: {1}", website.Url, exception.Message));
                    }
                }
            }
        }
    }
}
