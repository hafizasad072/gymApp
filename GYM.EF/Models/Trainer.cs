using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class Trainer
    {
        public Guid TrainerId { get; set; }
        public string UserId { get; set; }
        public Guid GymId { get; set; }
        public string Bio { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser User { get; set; }
        public Gym Gym { get; set; }

        public ICollection<Trainer> Trainers { get; set; }
    }
}
