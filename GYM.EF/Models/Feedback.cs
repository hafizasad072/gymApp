using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class Feedback
    {
        public Guid FeedbackId { get; set; }
        public string FromUserId { get; set; }
        public string ForTrainerId { get; set; }
        public Guid? GymId { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser FromUser { get; set; }
        public Trainer ForTrainer { get; set; }
        public Gym Gym { get; set; }
    }
}
