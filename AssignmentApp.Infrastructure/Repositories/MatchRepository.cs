using AssignmentApp.Application.Interfaces;
using AssignmentApp.Core;
using AssignmentApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp.Infrastructure.Repositories
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext context) : base(context) { }
        
        public void UpdateMatch(Match matchDB, Match updatedMatch)
        {
            matchDB.Description = updatedMatch.Description;
            matchDB.MatchDate = updatedMatch.MatchDate;
            matchDB.MatchTime = updatedMatch.MatchTime;
            matchDB.TeamA = updatedMatch.TeamA;
            matchDB.TeamB = updatedMatch.TeamB;
            matchDB.Sport = updatedMatch.Sport;
        }

        public IEnumerable<Match> GetAllWithIncludes()
        {
            return _context.Matches.Include(x => x.MatchOdds).AsEnumerable().ToList();

        }
        public Match GetWithIncludes(long Id)
        {
            return _context.Matches.Where(x => x.ID == Id)
                                   .Include(x => x.MatchOdds).FirstOrDefault();
        }
    }
}
