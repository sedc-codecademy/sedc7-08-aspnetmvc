using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Football.Services
{
    public interface ITeamService
    {
        List<SelectListItem> GetAllTeams();
    }
}
