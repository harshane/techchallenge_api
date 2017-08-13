using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CustomerBetsApi.Configurations;
using CustomerBetsApi.Dtos;
using CustomerBetsApi.HttpHandler;
using CustomerBetsApi.ServiceProxy.CustomerBetService.Models;
using Newtonsoft.Json;

namespace CustomerBetsApi.ServiceProxy.CustomerBetService
{
    public class CustomerBetServiceProxy : ICustomerBetServiceProxy
    {
        private readonly IConfigurationManager _configrationManager;
        private readonly IHttpHandler _httpHandler;
        private readonly IMapper _mapper;

        public CustomerBetServiceProxy(IConfigurationManager configurationManager, IHttpHandler httpHandler, IMapper mapper)
        {
            _configrationManager = configurationManager;
            _httpHandler = httpHandler;
            _mapper = mapper;
        }

        private List<CustomerBet> GetCustomerBets()
        {
            var customerBets = _httpHandler.GetString(_configrationManager.BetServiceUrl);
            
            if(string.IsNullOrEmpty(customerBets))
            {
                return new List<CustomerBet>();
            }

            return JsonConvert.DeserializeObject<List<CustomerBet>>(customerBets);
        }

        public List<CustomerBetDto> GetCustomerBets(int customerId)
        {
            var customerBets = _mapper.Map<List<CustomerBet>, List<CustomerBetDto>>(GetCustomerBets());
            return customerBets?.Where(a => a.CustomerId == customerId).ToList();
        }

        public List<CustomerBetDto> GetTotalBetAmountPerCustomer()
        {
            return GetCustomerBets().GroupBy(a => a.CustomerId).Select(g => new CustomerBetDto
            {
                CustomerId = g.Key,
                Stake = g.Sum(i => i.Stake)
            }).ToList();
        }

        public double GetTotalBetAmount(int customerId)
        {
            return GetCustomerBets().Where(a => a.CustomerId == customerId).Sum(a => a.Stake);
        }

        public double GetTotalBetAllCustomers()
        {
            return GetCustomerBets().Sum(a => a.Stake);
        }

        public double GetTotalBetAmountForRace(int raceId)
        {
            return GetCustomerBets().Where(a => a.RaceId == raceId).Sum(a => a.Stake);
        }

        public double GetNumberOfBetsPlaced(int horseId)
        {
            return GetCustomerBets().Where(a => a.HorseId == horseId).Count();
        }
    }
}
