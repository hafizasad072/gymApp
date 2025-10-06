using GYM.DataLayer.AttendanceRepository;
using GYM.DataLayer.ClassBookingRepository;
using GYM.DataLayer.ClassRepository;
using GYM.DataLayer.ClassScheduleRepository;
using GYM.DataLayer.GymRepository;
using GYM.DataLayer.MemberRepository;
using GYM.DataLayer.MembershipPlanRepository;
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
        IGymRepository GymRepository
        {
            get;
        }
        IClassRepository ClassRepository
        {
            get;
        }
        IClassScheduleRepository ClassScheduleRepository
        {
            get;
        }
        IClassBookingRepository ClassBookingRepository
        {
            get;
        }
        IMembershipPlanRepository MembershipPlanRepository
        {
            get;
        }
        int Commit();
    }
}
