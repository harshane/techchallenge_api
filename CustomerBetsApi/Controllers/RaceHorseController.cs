using System.Collections.Generic;
using CustomerBetsApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using CustomerBetsApi.ServiceProxy.GameService;

namespace CustomerBetsApi.Controllers
{
    /// <summary>
    /// Api controller to perform Crud operations on Horses in Race
    /// </summary>
    [Route("horses/race")]
    public class RaceHorseController : Controller
    {
        private readonly IRaceServiceProxy _raceServiceProxy;

        public RaceHorseController(IRaceServiceProxy raceServiceProxy)
        {
            _raceServiceProxy = raceServiceProxy;
        }

        /// <summary>
        /// Lists all horses associated with Race.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IEnumerable<RaceDto> Get(int raceId)
        {
            //ToDo: User for lazy loading of Horses associated with Race
            return _raceServiceProxy.GetRaces(); // total amount bet per customer
        }
    }
}
