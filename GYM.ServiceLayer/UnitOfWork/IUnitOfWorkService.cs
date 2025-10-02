using GYM.DataLayer.AttendanceRepository;
using GYM.DataLayer.MemberRepository;

namespace GYM.ServiceLayer.UnitOfWork
{
    public interface IUnitOfWorkService
    {
        IMemberRepository MemberRepository
        {
            get;
        }
        //IUserRepository UserRepository
        //{
        //    get;
        //}

        IAttendanceRepository AttendanceRepository
        {
            get;
        }

        int Commit();
    }
}
