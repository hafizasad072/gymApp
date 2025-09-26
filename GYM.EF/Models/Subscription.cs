using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class Subscription
    {
        [Key]
        public Guid SubscriptionId { get; set; }
        public Guid MemberId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }
        public bool AutoRenew { get; set; }
        public DateTime? NextBillingDate { get; set; }
    }
}
