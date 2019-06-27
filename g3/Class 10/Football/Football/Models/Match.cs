using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string Score { get; set; }
        public int HteamId { get; set; }
        public Team Hteam { get; set; }
        public int AteamId { get; set; }
        public Team Ateam { get; set; }
        
      
    }
}
