using GYM.DataLayer.AttendanceRepository;
using GYM.DataLayer.BodyMetricRepository;
using GYM.DataLayer.ClassBookingRepository;
using GYM.DataLayer.ClassRepository;
using GYM.DataLayer.ClassScheduleRepository;
using GYM.DataLayer.DiscussionMessageRepository;
using GYM.DataLayer.DiscussionRepository;
using GYM.DataLayer.GymRepository;
using GYM.DataLayer.InvoiceRepository;
using GYM.DataLayer.MemberRepository;
using GYM.DataLayer.MembershipPlanRepository;
using GYM.DataLayer.PaymentRepository;
using GYM.DataLayer.SubscriptionRepository;
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
        private IMembershipPlanRepository _membershipPlanRepository;
        private ISubscriptionRepository _subscriptionRepository;
        private IInvoiceRepository _invoiceRepository;
        private IPaymentRepository _paymentRepository;
        private IDiscussionRepository _discussionRepository;
        private IDiscussionMessageRepository _discussionMessageRepository;
        private IBodyMetricRepository _bodyMetricRepository;

        public IUserRepository UserRepository => _userRepository == null ? new UserRepository(context) : _userRepository;
        public IMemberRepository MemberRepository => _memberRepository == null ? new MemberRepository(context) : _memberRepository;
        public IAttendanceRepository AttendanceRepository => _attendanceRepository == null ? new AttendanceRepository(context) : _attendanceRepository;
        public ITrainerRepository TrainerRepository => _trainerRepository == null ? new TrainerRepository(context) : _trainerRepository;
        public IGymRepository GymRepository => _gymRepository == null ? new GymRepository(context) : _gymRepository;
        public IClassRepository ClassRepository => _classRepository == null ? new ClassRepository(context) : _classRepository;
        public IClassScheduleRepository ClassScheduleRepository => _classScheduleRepository == null ? new ClassScheduleRepository(context) : _classScheduleRepository;
        public IClassBookingRepository ClassBookingRepository => _classBookingRepository == null ? new ClassBookingRepository(context) : _classBookingRepository;
        public IMembershipPlanRepository MembershipPlanRepository => _membershipPlanRepository == null ? new MembershipPlanRepository(context) : _membershipPlanRepository;
        public ISubscriptionRepository SubscriptionRepository => _subscriptionRepository == null ? new SubscriptionRepository(context) : _subscriptionRepository;
        public IPaymentRepository PaymentRepository => _paymentRepository == null ? new PaymentRepository(context) : _paymentRepository;
        public IInvoiceRepository InvoiceRepository => _invoiceRepository == null ? new InvoiceRepository(context) : _invoiceRepository;
        public IDiscussionRepository DiscussionRepository => _discussionRepository == null ? new DiscussionRepository(context) : _discussionRepository;
        public IDiscussionMessageRepository DiscussionMessageRepository => _discussionMessageRepository == null ? new DiscussionMessageRepository(context) : _discussionMessageRepository;
        public IBodyMetricRepository BodyMetricRepository => _bodyMetricRepository == null ? new BodyMetricRepository(context) : _bodyMetricRepository;
        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
