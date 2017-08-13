using System.Collections.Generic;
using CustomerBetsApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using CustomerBetsApi.ServiceProxy.GameService;

namespace CustomerBetsApi.Controllers
{
    /// <summary>
    /// Api controller to perform Crud operations on Races
    /// </summary>
    [Route("races")]
    public class RaceController : Controller
    {
        private readonly IRaceServiceProxy _raceServiceProxy;

        public RaceController(IRaceServiceProxy raceServiceProxy)
        {
            _raceServiceProxy = raceServiceProxy;
        }

        /// <summary>
        /// Lists all races
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<RaceDto> Get()
        {
            return _raceServiceProxy.GetRaces(); // total amount bet per customer
        }
    }
}
