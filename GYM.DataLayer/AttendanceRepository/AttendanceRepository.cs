using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.DataLayer.MemberRepository;
using GYM.DataLayer.Repository;
using GYM.EF.Models;

namespace GYM.DataLayer.AttendanceRepository
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(GYMContext context) : base(context)
        {
        }
    }
}
