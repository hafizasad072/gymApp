using GYM.DataLayer.AttendanceRepository;
using GYM.DataLayer.MemberRepository;
//using GYM.DataLayer.UserRepository;
using GYM.EF.Models;

namespace GYM.ServiceLayer.UnitOfWork
{
    public class UnitOfWorkService(MuscleUpGYMContext context) : IUnitOfWorkService
    {
        private IMemberRepository _memberRepository;
        //private IUserRepository _userRepository;
        private IAttendanceRepository _attendanceRepository;

        public IMemberRepository MemberRepository => _memberRepository == null ? new MemberRepository(context) : _memberRepository;

        //public IUserRepository UserRepository => _userRepository == null ? new UserRepository(context) : _userRepository;

        public IAttendanceRepository AttendanceRepository => _attendanceRepository == null ? new AttendanceRepository(context) : _attendanceRepository;

        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
