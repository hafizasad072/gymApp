using GYM.DataLayer.ClassScheduleRepository;
using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.DataLayer.ClassBookingRepository
{
    public class ClassBookingRepository : GenericRepository<ClassBooking>, IClassBookingRepository
    {
        public ClassBookingRepository(GymDbContext context) : base(context)
        {
        }
    }
}
