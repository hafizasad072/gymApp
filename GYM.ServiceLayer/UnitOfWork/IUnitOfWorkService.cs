using GYM.DataLayer.AttendanceRepository;
using GYM.DataLayer.UserRepository;

namespace GYM.ServiceLayer.UnitOfWork
{
    public interface IUnitOfWorkService
    {
        IUserRepository UserRepository
        {
            get;
        }
        IAttendanceRepository AttendanceRepository
        {
            get;
        }
        int Commit();
    }
}
