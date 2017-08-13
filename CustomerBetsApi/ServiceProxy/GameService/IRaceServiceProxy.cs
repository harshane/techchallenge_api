using System.Collections.Generic;
using CustomerBetsApi.Dtos;

namespace CustomerBetsApi.ServiceProxy.GameService
{
    public interface IRaceServiceProxy
    {
        IList<RaceDto> GetRaces();
    }
}
