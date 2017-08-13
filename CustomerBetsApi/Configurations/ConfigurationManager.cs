using Microsoft.Extensions.Configuration;

namespace CustomerBetsApi.Configurations
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CustomerServiceUrl => _configuration.GetValue<string>("ServiceProxyUrls:CustomerServiceUrl");
        public string BetServiceUrl => _configuration.GetValue<string>("ServiceProxyUrls:BetServiceUrl");
        public string RaceServiceUrl => _configuration.GetValue<string>("ServiceProxyUrls:RaceServiceUrl");
    }
}
