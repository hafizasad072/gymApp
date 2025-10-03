using GYM.DataLayer.AttendanceRepository;
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

        public IUserRepository UserRepository => _userRepository == null ? new UserRepository(context) : _userRepository;
        public IMemberRepository MemberRepository => _memberRepository == null ? new MemberRepository(context) : _memberRepository;
        public IAttendanceRepository AttendanceRepository => _attendanceRepository == null ? new AttendanceRepository(context) : _attendanceRepository;
        public ITrainerRepository TrainerRepository => _trainerRepository == null ? new TrainerRepository(context) : _trainerRepository;

        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
