using System;
using System.Collections.Generic;

namespace CustomerBetsApi.ServiceProxy.GameService.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public string Status { get; set; }
        public IList<Horse> Horses { get; set; }
    }
}
