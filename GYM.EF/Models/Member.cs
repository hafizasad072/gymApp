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
        public string UserId { get; set; }
        public Guid GymId { get; set; }
        public int? LeagueId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser User { get; set; }
        public Gym Gym { get; set; }
        public League League { get; set; }
    }
}
