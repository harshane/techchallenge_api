using System.Collections.Generic;
using CustomerBetsApi.Dtos;
using CustomerBetsApi.ServiceProxy.CustomerBetService;
using Microsoft.AspNetCore.Mvc;

namespace CustomerBetsApi.Controllers
{
    /// <summary>
    /// Api controller to perform Crud operations on Customer Bets
    /// </summary>
    [Route("bets/customer")]
    public class CustomerBetsController : Controller
    {
        private readonly ICustomerBetServiceProxy _customerBetServiceProxy;

        public CustomerBetsController(ICustomerBetServiceProxy customerBetServiceProxy)
        {
            _customerBetServiceProxy = customerBetServiceProxy;
        }

        /// <summary>
        /// Lists all customer bets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CustomerBetDto> Get()
        {
            return _customerBetServiceProxy.GetTotalBetAmountPerCustomer(); // total amount bet per customer
        }

        /// <summary>
        /// Lists all bets placed for customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IEnumerable<CustomerBetDto> Get(int id)
        {
            return _customerBetServiceProxy.GetCustomerBets(id);
        }

        /// <summary>
        /// Lists total bet amount for a customer
        /// </summary>
        /// <returns>total bet amount for a customer</returns>
        [HttpGet("total/{id}")]
        public double GetTotalBetAmountForAllCustomers(int id)
        {
            return _customerBetServiceProxy.GetTotalBetAmount(id);
        }

        /// <summary>
        /// Lists total amount bet for all customers
        /// </summary>
        /// <returns>total amount bet for all customers</returns>
        [HttpGet("total")]
        public double GetTotalBetAmountForAllCustomers()
        {
            return _customerBetServiceProxy.GetTotalBetAllCustomers();
        }
    }
}
