using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class Member
    {
        public Guid MemberId { get; set; }
        public Guid UserId { get; set; }
        public Guid GymId { get; set; }
        public int? LeagueId { get; set; }
    }

}
