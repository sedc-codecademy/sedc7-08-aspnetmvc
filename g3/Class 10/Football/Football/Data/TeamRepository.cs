using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.Models;

namespace Football.Data
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly FootballDbContext _dbContext;

        public TeamRepository(FootballDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Team obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Team obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Team obj)
        {
            throw new NotImplementedException();
        }

        public List<Team> GetAll()
        {
            return _dbContext.Teams.ToList();
        }
    }
}
