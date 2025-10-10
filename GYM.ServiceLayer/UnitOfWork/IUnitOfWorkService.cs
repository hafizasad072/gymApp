using GYM.DataLayer.AttendanceRepository;
using GYM.DataLayer.BodyMetricRepository;
using GYM.DataLayer.ClassBookingRepository;
using GYM.DataLayer.ClassRepository;
using GYM.DataLayer.ClassScheduleRepository;
using GYM.DataLayer.DiscussionMessageRepository;
using GYM.DataLayer.DiscussionRepository;
using GYM.DataLayer.ExerciseRepository;
using GYM.DataLayer.GymRepository;
using GYM.DataLayer.InvoiceRepository;
using GYM.DataLayer.MemberRepository;
using GYM.DataLayer.MembershipPlanRepository;
using GYM.DataLayer.PaymentRepository;
using GYM.DataLayer.SubscriptionRepository;
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
        ISubscriptionRepository SubscriptionRepository
        {
            get;
        }
        IPaymentRepository PaymentRepository
        {
            get;
        }
        IInvoiceRepository InvoiceRepository
        {
            get;
        }
        IDiscussionRepository DiscussionRepository
        {
            get;
        }
        IDiscussionMessageRepository DiscussionMessageRepository
        {
            get;
        }
        IBodyMetricRepository BodyMetricRepository
        {
            get;
        }
        IExerciseRepository ExerciseRepository
        {
            get;
        }
        int Commit();
    }
}
