using AutoMapper;
using CustomerBetsApi.Configurations;
using CustomerBetsApi.Controllers;
using CustomerBetsApi.Dtos;
using CustomerBetsApi.HttpHandler;
using CustomerBetsApi.ServiceProxy.CustomerService;
using CustomerBetsApi.ServiceProxy.CustomerService.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CustomerBetsApiUnitTests.Controllers
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _customerController;
        private readonly Mock<IMapper> _mapper;

        public CustomerControllerTests()
        {
            var configurationManager = new Mock<IConfigurationManager>();
            var httpHandler = new Mock<IHttpHandler>();
            _mapper = new Mock<IMapper>();

            httpHandler.Setup(a => a.GetString("test")).Returns("[{\"id\": 1,\"name\": \"Rob\"}]");
            configurationManager.Setup(a => a.CustomerServiceUrl).Returns("test");

            var customerServiceProxy = new CustomerServiceProxy(configurationManager.Object, httpHandler.Object, _mapper.Object);
            _customerController = new CustomerController(customerServiceProxy);
        }

        [Fact]
        public void Get_Returns_Data()
        {
            var result = _customerController.Get();
            _mapper.Verify(a => a.Map<List<Customer>, List<CustomerDto>>(It.IsAny<List<Customer>>()));
        }
    }
}
