
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Subscriptions
{
    public Guid SubscriptionId { get; set; }

    public Guid MemberId { get; set; }

    public Guid PlanId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int StatusId { get; set; }

    public bool AutoRenew { get; set; }

    public DateOnly? NextBillingDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Invoices> Invoices { get; set; } = new List<Invoices>();

    public virtual Members Member { get; set; }

    public virtual MembershipPlans Plan { get; set; }

    public virtual SubscriptionStatuses Status { get; set; }
}