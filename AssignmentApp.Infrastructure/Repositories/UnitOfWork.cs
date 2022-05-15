using AssignmentApp.Application.Interfaces;
using AssignmentApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IMatchRepository Matches { get; }
        public IMatchOddsRepository MatchOdds { get; }
        public UnitOfWork(ApplicationDbContext applicationDbContext,
            IMatchRepository matchRepository,
            IMatchOddsRepository matchOddsRepository)
        {
            _context = applicationDbContext;

            Matches = matchRepository;
            MatchOdds = matchOddsRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
