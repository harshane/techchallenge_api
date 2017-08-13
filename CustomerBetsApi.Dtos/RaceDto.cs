using System.Collections.Generic;

namespace CustomerBetsApi.Dtos
{
    public class RaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalBetAmount { get; set; }
        public bool RaceFinished { get; set; }
        public List<HorsetDto> Horses { get; set; }
    }
}
