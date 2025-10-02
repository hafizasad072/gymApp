
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Invoices
{
    public Guid InvoiceId { get; set; }

    public Guid SubscriptionId { get; set; }

    public Guid MemberId { get; set; }

    public Guid GymId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; }

    public DateTime IssuedAt { get; set; }

    public DateTime? PaidAt { get; set; }

    public int StatusId { get; set; }

    public virtual Gyms Gym { get; set; }

    public virtual Members Member { get; set; }

    public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();

    public virtual InvoiceStatuses Status { get; set; }

    public virtual Subscriptions Subscription { get; set; }
}