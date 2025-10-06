using GYM.DataLayer.AttendanceRepository;
using GYM.DataLayer.ClassBookingRepository;
using GYM.DataLayer.ClassRepository;
using GYM.DataLayer.ClassScheduleRepository;
using GYM.DataLayer.GymRepository;
using GYM.DataLayer.MemberRepository;
using GYM.DataLayer.TrainerRepository;
using GYM.DataLayer.UserRepository;
using GYM.EF;

namespace GYM.ServiceLayer.UnitOfWork
{
    public class UnitOfWorkService(GymDbContext context) : IUnitOfWorkService
    {

        private IUserRepository _userRepository;
        private IAttendanceRepository _attendanceRepository;
        private IMemberRepository _memberRepository;
        private ITrainerRepository _trainerRepository;
        private IGymRepository _gymRepository;
        private IClassRepository _classRepository;
        private IClassScheduleRepository _classScheduleRepository;
        private IClassBookingRepository _classBookingRepository;

        public IUserRepository UserRepository => _userRepository == null ? new UserRepository(context) : _userRepository;
        public IMemberRepository MemberRepository => _memberRepository == null ? new MemberRepository(context) : _memberRepository;
        public IAttendanceRepository AttendanceRepository => _attendanceRepository == null ? new AttendanceRepository(context) : _attendanceRepository;
        public ITrainerRepository TrainerRepository => _trainerRepository == null ? new TrainerRepository(context) : _trainerRepository;
        public IGymRepository GymRepository => _gymRepository == null ? new GymRepository(context) : _gymRepository;
        public IClassRepository ClassRepository => _classRepository == null ? new ClassRepository(context) : _classRepository;
        public IClassScheduleRepository ClassScheduleRepository => _classScheduleRepository == null ? new ClassScheduleRepository(context) : _classScheduleRepository;
        public IClassBookingRepository ClassBookingRepository => _classBookingRepository == null ? new ClassBookingRepository(context) : _classBookingRepository;

        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
