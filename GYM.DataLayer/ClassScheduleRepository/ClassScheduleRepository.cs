using GYM.DataLayer.ClassRepository;
using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.DataLayer.ClassScheduleRepository
{
    public class ClassScheduleRepository : GenericRepository<ClassSchedule>, IClassScheduleRepository
    {
        public ClassScheduleRepository(GymDbContext context) : base(context)
        {
        }
    }
}
