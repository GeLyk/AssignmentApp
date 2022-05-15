using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMatchRepository Matches { get; }
        IMatchOddsRepository MatchOdds { get; }
        int Complete();
    }
}
