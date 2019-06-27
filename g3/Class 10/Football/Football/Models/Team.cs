using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Football.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players{ get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public ICollection<Match> Hmatches { get; set; }
        public ICollection<Match> Amatches { get; set; }

    }
}