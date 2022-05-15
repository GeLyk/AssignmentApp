using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssignmentApp.Core.Entities
{
    public class MatchOdds
    {
        public long ID { get; set; }
        public string Specifier { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Odd { get; set; }

        public long MatchID { get; set; }
        public Match Match { get; set; }
    }
}
