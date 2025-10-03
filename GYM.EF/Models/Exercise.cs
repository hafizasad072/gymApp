using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class Exercise
    {
        public Guid ExerciseId { get; set; }
        public Guid GymId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MuscleGroupId { get; set; }
        public string Equipment { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Gym Gym { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
