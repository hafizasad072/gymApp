using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class SessionLog
    {
        public Guid SessionLogId { get; set; }
        public Guid MemberId { get; set; }
        public Guid? TrainerId { get; set; }
        public Guid? WorkoutPlanId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string Notes { get; set; }

        public Member Member { get; set; }
        public Trainer Trainer { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }
    }

}
