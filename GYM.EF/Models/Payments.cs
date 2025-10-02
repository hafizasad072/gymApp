
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Payments
{
    public Guid PaymentId { get; set; }

    public Guid? InvoiceId { get; set; }

    public Guid MemberId { get; set; }

    public Guid GymId { get; set; }

    public decimal Amount { get; set; }

    public string Method { get; set; }

    public string ProviderTransactionId { get; set; }

    public DateTime PaidAt { get; set; }

    public virtual Gyms Gym { get; set; }

    public virtual Invoices Invoice { get; set; }

    public virtual Members Member { get; set; }
}