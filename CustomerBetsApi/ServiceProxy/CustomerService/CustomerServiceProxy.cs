using System.Collections.Generic;
using AutoMapper;
using CustomerBetsApi.Configurations;
using CustomerBetsApi.Dtos;
using CustomerBetsApi.HttpHandler;
using CustomerBetsApi.ServiceProxy.CustomerService.Models;
using Newtonsoft.Json;

namespace CustomerBetsApi.ServiceProxy.CustomerService
{
    public class CustomerServiceProxy : ICustomerServiceProxy
    {
        private readonly IConfigurationManager _configrationManager;
        private readonly IHttpHandler _httpHandler;
        private readonly IMapper _mapper;

        public CustomerServiceProxy(IConfigurationManager configurationManager, IHttpHandler httpHandler, IMapper mapper)
        {
            _configrationManager = configurationManager;
            _httpHandler = httpHandler;
            _mapper = mapper;
        }

        public List<CustomerDto> GetCustomer()
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(_httpHandler.GetString(_configrationManager.CustomerServiceUrl));
            return _mapper.Map<List<Customer>, List<CustomerDto>>(customers);
        }
    }
}
