using AssignmentApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp.Application.Interfaces
{
    public interface IMatchOddsRepository : IGenericRepository<MatchOdds>
    {
        public void UpdateMatchOdds(Match matchDB, Match updatedMatch);
    }
}
