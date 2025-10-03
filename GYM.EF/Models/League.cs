using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}
