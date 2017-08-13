namespace CustomerBetsApi.ServiceProxy.CustomerBetService.Models
{
    public class CustomerBet
    {
        public int CustomerId { get; set; }
        public int RaceId { get; set; }
        public int HorseId { get; set; }
        public double Stake { get; set; }
    }
}