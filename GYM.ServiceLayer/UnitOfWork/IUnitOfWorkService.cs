using GYM.DataLayer.AttendanceRepository;
using GYM.DataLayer.MemberRepository;
using GYM.DataLayer.TrainerRepository;
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
        IMemberRepository MemberRepository
        {
            get;
        }

        ITrainerRepository TrainerRepository
        {
            get;
        }
        int Commit();
    }
}
