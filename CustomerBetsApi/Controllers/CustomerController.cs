using System.Collections.Generic;
using CustomerBetsApi.Dtos;
using CustomerBetsApi.ServiceProxy.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace CustomerBetsApi.Controllers
{
    /// <summary>
    /// Api controller to perform Crud operations on Customer entity
    /// </summary>
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerServiceProxy _customerServiceProxy;

        public CustomerController(ICustomerServiceProxy customerServiceProxy)
        {
            _customerServiceProxy = customerServiceProxy;
        }

        /// <summary>
        /// List all customers
        /// </summary>
        /// <returns> Customers </returns>
        [HttpGet]
        public List<CustomerDto> Get()
        {
            return _customerServiceProxy.GetCustomer();
        }
    }
}
