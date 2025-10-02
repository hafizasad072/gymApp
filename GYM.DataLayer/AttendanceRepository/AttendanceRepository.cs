using GYM.DataLayer.Repository;
using GYM.EF.Models;

namespace GYM.DataLayer.AttendanceRepository
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(MuscleUpGYMContext context) : base(context)
        {
        }
    }
}
