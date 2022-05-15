using AssignmentApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentApp.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOdds> MatchOdds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasData(new Match
            {
                ID = 1,
                Description = "OSFP-PAO",
                MatchDate = String.Format("{0:dd/MM/yyyy}", new DateTime(2022, 5, 12, 12, 0, 0)),
                MatchTime = String.Format("{0:HH:mm}", new DateTime(2022, 5, 12, 12, 0, 0)),
                TeamA = "OSFP",
                TeamB = "PAO",
                Sport = Enums.Sports.Football
            });

            modelBuilder.Entity<MatchOdds>().HasData(new MatchOdds
            {
                ID = 1,
                MatchID = 1,
                Odd = 1.5m,
                Specifier = "X"
            });
        }
    }
}
