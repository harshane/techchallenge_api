using AutoMapper;
using CustomerBetsApi.Configurations;
using CustomerBetsApi.HttpHandler;
using CustomerBetsApi.ServiceProxy.CustomerBetService;
using CustomerBetsApi.ServiceProxy.GameService;
using Moq;
using Xunit;

namespace CustomerBetsApiUnitTests.ServiceProxy.GameServiceTests
{
    public class RaceServiceProxyTests
    {
        private readonly IRaceServiceProxy _raceServiceProxy;

        public RaceServiceProxyTests()
        {
            var configurationManager = new Mock<IConfigurationManager>();
            var httpHandler = new Mock<IHttpHandler>();
            var mapper = new Mock<IMapper>();
            var customerBetService = new Mock<ICustomerBetServiceProxy>();

            httpHandler.Setup(a => a.GetString("test")).Returns("");
            configurationManager.Setup(a => a.RaceServiceUrl).Returns("test");

            _raceServiceProxy = new RaceServiceProxy(configurationManager.Object, httpHandler.Object, mapper.Object, customerBetService.Object);
        }

        [Fact]
        public void GetRaces_Returns_Data()
        {
            var result = _raceServiceProxy.GetRaces();
            Assert.NotEqual(result, null);
        }
    }
}
