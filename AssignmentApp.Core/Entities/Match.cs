using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssignmentApp.Core.Entities
{
    public class Match
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public string MatchDate { get; set; }
        public string MatchTime { get; set; }

        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public Enums.Sports Sport { get; set; }

        public MatchOdds MatchOdds { get; set; }
    }
}
