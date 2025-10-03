using GYM.DataLayer.AttendanceRepository;
using GYM.DataLayer.UserRepository;
using GYM.EF;

namespace GYM.ServiceLayer.UnitOfWork
{
    public class UnitOfWorkService(GymDbContext context) : IUnitOfWorkService
    {

        private IUserRepository _userRepository;
        private IAttendanceRepository _attendanceRepository;

        public IUserRepository UserRepository => _userRepository == null ? new UserRepository(context) : _userRepository;

        public IAttendanceRepository AttendanceRepository => _attendanceRepository == null ? new AttendanceRepository(context) : _attendanceRepository;
        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
