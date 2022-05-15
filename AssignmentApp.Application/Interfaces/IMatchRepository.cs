using AssignmentApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp.Application.Interfaces
{
    public interface IMatchRepository : IGenericRepository<Match>
    {
        public void UpdateMatch(Match matchDB, Match updatedMatch);
        IEnumerable<Match> GetAllWithIncludes();
        public Match GetWithIncludes(long Id);
    }
}
