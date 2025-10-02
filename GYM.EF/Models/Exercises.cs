
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Exercises
{
    public Guid ExerciseId { get; set; }

    public Guid GymId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int MuscleGroupId { get; set; }

    public string Equipment { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Gyms Gym { get; set; }

    public virtual MuscleGroups MuscleGroup { get; set; }

    public virtual ICollection<WorkoutDayExercises> WorkoutDayExercises { get; set; } = new List<WorkoutDayExercises>();
}