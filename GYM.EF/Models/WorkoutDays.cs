
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class WorkoutDays
{
    public Guid WorkoutDayId { get; set; }

    public Guid WorkoutPlanId { get; set; }

    public int DayOrder { get; set; }

    public string DayType { get; set; }

    public virtual ICollection<WorkoutDayExercises> WorkoutDayExercises { get; set; } = new List<WorkoutDayExercises>();

    public virtual WorkoutPlans WorkoutPlan { get; set; }
}