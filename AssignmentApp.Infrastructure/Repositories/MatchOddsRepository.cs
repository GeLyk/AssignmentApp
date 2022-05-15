using AssignmentApp.Application.Interfaces;
using AssignmentApp.Core;
using AssignmentApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AssignmentApp.Core.Enums;

namespace AssignmentApp.Infrastructure.Repositories
{
    public class MatchOddsRepository : GenericRepository<MatchOdds>, IMatchOddsRepository
    {
        public MatchOddsRepository(ApplicationDbContext context) : base(context) { }

        public void UpdateMatchOdds(Match matchDB, Match updatedMatch)
        {
            matchDB.MatchOdds.Specifier = updatedMatch.MatchOdds.Specifier;
            matchDB.MatchOdds.Odd = updatedMatch.MatchOdds.Odd;
        }
    }
}
