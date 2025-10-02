
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Gyms
{
    public Guid GymId { get; set; }

    public string Name { get; set; }

    public string Timezone { get; set; }

    public Guid OwnerUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Attendance> Attendance { get; set; } = new List<Attendance>();

    public virtual ICollection<Classes> Classes { get; set; } = new List<Classes>();

    public virtual ICollection<Discussions> Discussions { get; set; } = new List<Discussions>();

    public virtual ICollection<Exercises> Exercises { get; set; } = new List<Exercises>();

    public virtual ICollection<Feedbacks> Feedbacks { get; set; } = new List<Feedbacks>();

    public virtual ICollection<Invoices> Invoices { get; set; } = new List<Invoices>();

    public virtual ICollection<Members> Members { get; set; } = new List<Members>();

    public virtual ICollection<MembershipPlans> MembershipPlans { get; set; } = new List<MembershipPlans>();

    public virtual ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();

    public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();

    public virtual ICollection<Trainers> Trainers { get; set; } = new List<Trainers>();

    public virtual ICollection<WorkoutPlans> WorkoutPlans { get; set; } = new List<WorkoutPlans>();
}