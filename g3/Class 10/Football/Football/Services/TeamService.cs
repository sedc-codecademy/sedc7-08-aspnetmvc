using System.Collections.Generic;
using System.Linq;
using Football.Data;
using Football.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Football.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _teamRepository;

        public TeamService(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public List<SelectListItem> GetAllTeams()
        {
            return _teamRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
    }
}
