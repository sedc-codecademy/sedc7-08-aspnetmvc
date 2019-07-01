using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.Services;
using Football.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    public class MatchController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IMatchService _matchService;

        public MatchController(ITeamService teamService, IMatchService matchService)
        {
            _teamService = teamService;
            _matchService = matchService;
        }

        public IActionResult Match()
        {
            var matchViewModel = new MatchViewModel {AllTeams = _teamService.GetAllTeams()};
            return View(matchViewModel);
        }

        [HttpPost]
        public IActionResult Match(MatchViewModel model)
        {
            _matchService.AddMatch(model);

            return RedirectToAction("Index", "Home");
        }
    }
}