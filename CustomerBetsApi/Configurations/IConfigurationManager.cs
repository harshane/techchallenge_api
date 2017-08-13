namespace CustomerBetsApi.Configurations
{
    public interface IConfigurationManager
    {
        string CustomerServiceUrl { get; }
        string BetServiceUrl { get; }
        string RaceServiceUrl { get; }
    }
}
