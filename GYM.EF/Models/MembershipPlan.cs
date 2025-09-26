using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class MembershipPlan
    {
        public Guid PlanId { get; set; }
        public Guid GymId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? DurationDays { get; set; }
    }
}
