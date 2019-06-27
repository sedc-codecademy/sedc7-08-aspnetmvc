using System.Collections.Generic;
using Football.Models;

namespace Football.Data
{
    public class MatchRepository : IRepository<Match>
    {
        private readonly FootballDbContext _dbContext;

        public MatchRepository(FootballDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Match obj)
        {
            _dbContext.Matches.Add(obj);
            _dbContext.SaveChanges();
        }

        public void Update(Match obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Match obj)
        {
            throw new System.NotImplementedException();
        }

        public List<Match> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
