using AutoMapper;
using CustomerBetsApi.Constants;
using CustomerBetsApi.Dtos;
using CustomerBetsApi.ServiceProxy.CustomerBetService.Models;
using CustomerBetsApi.ServiceProxy.CustomerService.Models;
using CustomerBetsApi.ServiceProxy.GameService.Models;
using System;

namespace CustomerBetsApi.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerBet, CustomerBetDto>();
            CreateMap<Horse, HorsetDto>()
                .ForMember(d => d.WinningAmount, opt => opt.MapFrom(s => s.Odds));
            CreateMap<Race, RaceDto>()
                .ForMember(d => d.RaceFinished, opt => opt.MapFrom(s => s.Status.Equals(RaceStatus.completed.ToString(), StringComparison.CurrentCultureIgnoreCase)));
        }
    }
}
