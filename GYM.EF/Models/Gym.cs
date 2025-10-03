using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class Gym
    {
        public Guid GymId { get; set; }
        public string Name { get; set; }
        public string Timezone { get; set; }
        public string OwnerUserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser Owner { get; set; }
    }
}
