using System;
using System.Linq;
using Football.Data;
using Football.Models;
using Football.ViewModels;

namespace Football.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepository<Match> _matchRepository;
        private readonly IRepository<Team> _teamRepository;

        public MatchService(IRepository<Match> matchRepository, IRepository<Team> teamRepository)
        {
            _matchRepository = matchRepository;
            _teamRepository = teamRepository;
        }
        public void AddMatch(MatchViewModel model)
        {
            if(model.AwayTeamId == model.HomeTeamId) 
                throw new ApplicationException("You need to select different teams");

            var match = new Match();
            var homeTeam = _teamRepository.GetAll().FirstOrDefault(x => x.Id == model.HomeTeamId);

            if(homeTeam == null)
                throw new ApplicationException("Home team does not exist");

            var awayTeam = _teamRepository.GetAll().FirstOrDefault(x => x.Id == model.AwayTeamId);

            if (awayTeam == null)
                throw new ApplicationException("Home team does not exist");

            match.Hteam = homeTeam;
            match.HteamId = homeTeam.Id;
            match.Ateam = awayTeam;
            match.AteamId = awayTeam.Id;
            match.Score = model.Score;

            _matchRepository.Create(match);
        }
    }
}
