using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class WorkoutPlan
    {
        public Guid WorkoutPlanId { get; set; }
        public Guid GymId { get; set; }
        public Guid? MemberId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTemplate { get; set; }
        public int? DayTypeId { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser CreatedBy { get; set; }
        public Gym Gym { get; set; }
        public Member Member { get; set; }
        public ICollection<WorkoutDay> WorkoutDays { get; set; }
    }

    public class WorkoutDayType
    {
        [Key]
        public int DayTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<WorkoutDay> WorkoutDays { get; set; }
    }

    public class WorkoutDay
    {
        public Guid WorkoutDayId { get; set; }
        public Guid WorkoutPlanId { get; set; }
        public int DayTypeId { get; set; }
        public DateTime CreatedAt { get; set; }

        public WorkoutPlan WorkoutPlan { get; set; }
        public WorkoutDayType DayType { get; set; }
        public ICollection<WorkoutDayExercise> Exercises { get; set; }
    }

    public class WorkoutDayExercise
    {
        public Guid WorkoutDayExerciseId { get; set; }
        public Guid WorkoutDayId { get; set; }
        public Guid ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public decimal? Weight { get; set; }

        public WorkoutDay WorkoutDay { get; set; }
        public Exercise Exercise { get; set; }
    }
}
