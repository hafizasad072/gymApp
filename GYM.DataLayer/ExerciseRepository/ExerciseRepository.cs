using GYM.DataLayer.ClassBookingRepository;
using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.DataLayer.ExerciseRepository
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(GymDbContext context) : base(context)
        {
        }
    }
}
