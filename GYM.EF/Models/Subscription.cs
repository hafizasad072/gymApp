using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class SubscriptionStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }

    public class Subscription
    {
        public Guid SubscriptionId { get; set; }
        public Guid MemberId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }

        public Member Member { get; set; }
        public MembershipPlan Plan { get; set; }
        public SubscriptionStatus Status { get; set; }
    }
}
