using System.Collections.Generic;
using CustomerBetsApi.Dtos;

namespace CustomerBetsApi.ServiceProxy.CustomerBetService
{
    public interface ICustomerBetServiceProxy
    {
        List<CustomerBetDto> GetCustomerBets(int customerId);

        List<CustomerBetDto> GetTotalBetAmountPerCustomer();

        double GetTotalBetAmount(int customerId);

        double GetTotalBetAllCustomers();

        double GetTotalBetAmountForRace(int raceId);

        double GetNumberOfBetsPlaced(int horseId);
    }
}
