using System.Collections.Generic;
using CustomerBetsApi.Configurations;
using CustomerBetsApi.HttpHandler;
using CustomerBetsApi.ServiceProxy.GameService.Models;
using Newtonsoft.Json;
using CustomerBetsApi.Dtos;
using AutoMapper;
using CustomerBetsApi.ServiceProxy.CustomerBetService;
using System;

namespace CustomerBetsApi.ServiceProxy.GameService
{
    public class RaceServiceProxy : IRaceServiceProxy
    {
        private readonly IConfigurationManager _configrationManager;
        private readonly IHttpHandler _httpHandler;
        private readonly IMapper _mapper;
        private readonly ICustomerBetServiceProxy _customerBetServiceProxy;

        public RaceServiceProxy(IConfigurationManager configurationManager, IHttpHandler httpHandler, IMapper mapper, ICustomerBetServiceProxy customerBetServiceProxy)
        {
            _configrationManager = configurationManager;
            _httpHandler = httpHandler;
            _mapper = mapper;
            _customerBetServiceProxy = customerBetServiceProxy;
        }

        public IList<RaceDto> GetRaces()
        {
            var racesStringData = _httpHandler.GetString(_configrationManager.RaceServiceUrl);

            List<Race> races = new List<Race>();

            if (!string.IsNullOrEmpty(racesStringData))
            {
                races = JsonConvert.DeserializeObject<List<Race>>(racesStringData);
                if (races != null)
                {
                    races.RemoveAll(a => !a.Start.Date.Equals(DateTime.Now.Date));
                }
            }

            var raceDtoList = _mapper.Map<List<Race>, List<RaceDto>>(races);

            if (raceDtoList != null)
            {
                raceDtoList.ForEach(raceDto =>
                {
                    raceDto.TotalBetAmount = _customerBetServiceProxy.GetTotalBetAmountForRace(raceDto.Id);

                    if (raceDto.Horses != null)
                    {
                        raceDto.Horses.ForEach(horseDto => horseDto.NumberOfBets = _customerBetServiceProxy.GetNumberOfBetsPlaced(horseDto.Id));
                    }
                });
            }
            else
            {
                raceDtoList = new List<RaceDto>();
            }

            return raceDtoList;
        }
    }
}
