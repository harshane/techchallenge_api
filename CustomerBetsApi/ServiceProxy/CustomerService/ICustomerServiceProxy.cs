using System.Collections.Generic;
using CustomerBetsApi.Dtos;

namespace CustomerBetsApi.ServiceProxy.CustomerService
{
    public interface ICustomerServiceProxy
    {
        List<CustomerDto> GetCustomer();
    }
}
