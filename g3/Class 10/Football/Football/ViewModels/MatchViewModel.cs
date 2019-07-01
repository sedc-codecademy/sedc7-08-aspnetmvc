using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Football.ViewModels
{
    public class MatchViewModel
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string Score { get; set; }
        public List<SelectListItem> AllTeams { get; set; }

        public MatchViewModel()
        {
            AllTeams = new List<SelectListItem>();
        }
    }
}
