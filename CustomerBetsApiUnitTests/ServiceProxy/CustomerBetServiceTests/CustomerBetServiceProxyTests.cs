using AutoMapper;
using CustomerBetsApi.Configurations;
using CustomerBetsApi.Dtos;
using CustomerBetsApi.HttpHandler;
using CustomerBetsApi.ServiceProxy.CustomerBetService;
using CustomerBetsApi.ServiceProxy.CustomerBetService.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CustomerBetsApiUnitTests.ServiceProxy.CustomerBetServiceTests
{
    public class CustomerBetServiceProxyTests
    {
        private readonly ICustomerBetServiceProxy _customerBetServiceProxy;
        private readonly Mock<IMapper> _mapper;

        public CustomerBetServiceProxyTests()
        {
            var configurationManager = new Mock<IConfigurationManager>();
            var httpHandler = new Mock<IHttpHandler>();
            _mapper = new Mock<IMapper>();

            httpHandler.Setup(a => a.GetString("test")).Returns("[{\"customerId\": 1,\"raceId\": 1}]");
            configurationManager.Setup(a => a.RaceServiceUrl).Returns("test");

            _customerBetServiceProxy = new CustomerBetServiceProxy(configurationManager.Object, httpHandler.Object, _mapper.Object);
        }

        [Fact]
        public void GetRaces_Returns_Data()
        {
            var result = _customerBetServiceProxy.GetCustomerBets(1);
            _mapper.Verify(a => a.Map<List<CustomerBet>, List<CustomerBetDto>>(It.IsAny<List<CustomerBet>>()));
        }
    }
}
