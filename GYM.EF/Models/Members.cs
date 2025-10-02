
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Members
{
    public Guid MemberId { get; set; }

    public Guid UserId { get; set; }

    public Guid GymId { get; set; }

    public int? LeagueId { get; set; }

    public DateOnly JoinDate { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Gender { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<BodyMetrics> BodyMetrics { get; set; } = new List<BodyMetrics>();

    public virtual ICollection<ClassBookings> ClassBookings { get; set; } = new List<ClassBookings>();

    public virtual Gyms Gym { get; set; }

    public virtual ICollection<Invoices> Invoices { get; set; } = new List<Invoices>();

    public virtual Leagues League { get; set; }

    public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();

    public virtual ICollection<SessionLogs> SessionLogs { get; set; } = new List<SessionLogs>();

    public virtual ICollection<Subscriptions> Subscriptions { get; set; } = new List<Subscriptions>();

    public virtual Users User { get; set; }

    public virtual ICollection<WorkoutPlans> WorkoutPlans { get; set; } = new List<WorkoutPlans>();
}