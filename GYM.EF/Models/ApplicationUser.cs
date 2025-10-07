using Microsoft.AspNetCore.Identity;

namespace GYM.EF.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add any custom user properties here
    }

    public class AttendanceSource
    {
        public int SourceId { get; set; }
        public string Name { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }

    public class AttendanceType
    {
        public int AttendanceTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }

    public class Attendance
    {
        public Guid AttendanceId { get; set; }
        public Guid GymId { get; set; }
        public string UserId { get; set; }               // AspNetUsers FK
        public int AttendanceTypeId { get; set; }
        public int SourceId { get; set; }
        public DateTime CheckinAt { get; set; }
        public DateTime? CheckoutAt { get; set; }
        public string Metadata { get; set; }

        public Gym Gym { get; set; }
        public ApplicationUser User { get; set; }
        public AttendanceType AttendanceType { get; set; }
        public AttendanceSource Source { get; set; }
    }

    // -----------------------------
    // Audit
    // -----------------------------
    public class AuditLog
    {
        public Guid AuditId { get; set; }
        public string UserId { get; set; }               // AspNetUsers FK
        public string Action { get; set; }
        public string Entity { get; set; }
        public string EntityId { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser User { get; set; }
    }

    // -----------------------------
    // Body Metrics
    // -----------------------------
    public class BodyMetricSource
    {
        public int SourceId { get; set; }
        public string Name { get; set; }
        public ICollection<BodyMetric> BodyMetrics { get; set; }
    }

    public class BodyMetricType
    {
        public int MetricTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<BodyMetric> BodyMetrics { get; set; }
    }

    public class BodyMetric
    {
        public Guid BodyMetricId { get; set; }
        public Guid MemberId { get; set; }
        public int MetricTypeId { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public DateTime MeasuredAt { get; set; }
        public int SourceId { get; set; }

        public Member Member { get; set; }
        public BodyMetricType MetricType { get; set; }
        public BodyMetricSource Source { get; set; }
    }

    // -----------------------------
    // Classes
    // -----------------------------
    public class ClassBookingStatus
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public ICollection<ClassBooking> ClassBookings { get; set; }
    }

    public class Class
    {
        public Guid ClassId { get; set; }
        public Guid GymId { get; set; }
        public Guid TrainerId { get; set; }              // FK → Trainer
        public string Title { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }

        public Gym Gym { get; set; }
        public Trainer Trainer { get; set; }
        public ICollection<ClassSchedule> Schedules { get; set; }
    }

    public class ClassSchedule
    {
        public Guid ClassScheduleId { get; set; }
        public Guid ClassId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Location { get; set; }

        public Class Class { get; set; }
        public ICollection<ClassBooking> Bookings { get; set; }
    }

    public class ClassBooking
    {
        public Guid ClassBookingId { get; set; }
        public Guid ClassScheduleId { get; set; }
        public Guid MemberId { get; set; }
        public int StatusId { get; set; }
        public DateTime BookedAt { get; set; }
        public DateTime? CancelledAt { get; set; }

        public ClassSchedule ClassSchedule { get; set; }
        public Member Member { get; set; }
        public ClassBookingStatus Status { get; set; }
    }

    // -----------------------------
    // Discussions
    // -----------------------------
    public class Discussion
    {
        public Guid DiscussionId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string CreatedByUserId { get; set; }      // AspNetUsers FK
        public Guid? GymId { get; set; }
        public bool IsFranchiseWide { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser CreatedBy { get; set; }
        public Gym Gym { get; set; }
        public ICollection<DiscussionMessage> Messages { get; set; }
    }

    public class DiscussionMessage
    {
        public Guid MessageId { get; set; }
        public Guid DiscussionId { get; set; }
        public string FromUserId { get; set; }           // AspNetUsers FK
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public Discussion Discussion { get; set; }
        public ApplicationUser FromUser { get; set; }
    }

    // -----------------------------
    // Exercises
    // -----------------------------
    public class MuscleGroup
    {
        public int MuscleGroupId { get; set; }
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }

    public class Exercise
    {
        public Guid ExerciseId { get; set; }
        public Guid GymId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MuscleGroupId { get; set; }
        public string Equipment { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Gym Gym { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
        public ICollection<WorkoutDayExercise> WorkoutDayExercises { get; set; }
    }

    // -----------------------------
    // External Providers
    // -----------------------------
    public class ExternalProvider
    {
        public Guid ProviderId { get; set; }
        public string UserId { get; set; }               // AspNetUsers FK
        public string ProviderName { get; set; }
        public string ExternalUserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? LastSyncAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser User { get; set; }
    }

    // -----------------------------
    // Feedback
    // -----------------------------
    public class Feedback
    {
        public Guid FeedbackId { get; set; }
        public string FromUserId { get; set; }           // AspNetUsers FK
        public Guid ForTrainerId { get; set; }           // FK → Trainer
        public Guid? GymId { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser FromUser { get; set; }
        public Trainer ForTrainer { get; set; }
        public Gym Gym { get; set; }
    }

    // -----------------------------
    // Gyms
    // -----------------------------
    public class Gym
    {
        public Guid GymId { get; set; }
        public string Name { get; set; }
        public string Timezone { get; set; }
        public string OwnerUserId { get; set; }          // AspNetUsers FK
        public DateTime CreatedAt { get; set; }

        public ApplicationUser Owner { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<WorkoutPlan> WorkoutPlans { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }

    // -----------------------------
    // Invoices & Payments
    // -----------------------------
    public class InvoiceStatus
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }

    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid MemberId { get; set; }
        public Guid GymId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaidAt { get; set; }
        public int StatusId { get; set; }

        public Subscription Subscription { get; set; }
        public Member Member { get; set; }
        public Gym Gym { get; set; }
        public InvoiceStatus Status { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }

    public class Payment
    {
        public Guid PaymentId { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid MemberId { get; set; }
        public Guid GymId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
        public string ProviderTransactionId { get; set; }
        public DateTime PaidAt { get; set; }

        public Invoice Invoice { get; set; }
        public Member Member { get; set; }
        public Gym Gym { get; set; }
    }

    // -----------------------------
    // Members
    // -----------------------------
    public class Member
    {
        public Guid MemberId { get; set; }
        public string UserId { get; set; }               // AspNetUsers FK
        public Guid GymId { get; set; }
        public int? LeagueId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser User { get; set; }
        public Gym Gym { get; set; }
        public League League { get; set; }
        public ICollection<BodyMetric> BodyMetrics { get; set; }
        public ICollection<ClassBooking> ClassBookings { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<SessionLog> SessionLogs { get; set; }
    }

    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public ICollection<Member> Members { get; set; }
    }

    // -----------------------------
    // Membership Plans
    // -----------------------------
    public class MembershipPlan
    {
        public Guid PlanId { get; set; }
        public Guid GymId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string BillingCycle { get; set; }
        public int? DurationDays { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Gym Gym { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }

    // -----------------------------
    // Notifications
    // -----------------------------
    public class Notification
    {
        public Guid NotificationId { get; set; }
        public Guid? GymId { get; set; }
        public string ToUserId { get; set; }             // AspNetUsers FK
        public string Channel { get; set; }
        public string TemplateKey { get; set; }
        public string Payload { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }

        public ApplicationUser ToUser { get; set; }
        public Gym Gym { get; set; }
    }

    // -----------------------------
    // Subscriptions
    // -----------------------------
    public class SubscriptionStatus
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }

    public class Subscription
    {
        public Guid SubscriptionId { get; set; }
        public Guid MemberId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }

        public Member Member { get; set; }
        public MembershipPlan Plan { get; set; }
        public SubscriptionStatus Status { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }

    // -----------------------------
    // Session Logs
    // -----------------------------
    public class SessionLog
    {
        public Guid SessionLogId { get; set; }
        public Guid MemberId { get; set; }
        public Guid? TrainerId { get; set; }
        public Guid? WorkoutPlanId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string Notes { get; set; }

        public Member Member { get; set; }
        public Trainer Trainer { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }
    }

    // -----------------------------
    // Trainers
    // -----------------------------
    public class Trainer
    {
        public Guid TrainerId { get; set; }
        public string UserId { get; set; }               // AspNetUsers FK
        public Guid GymId { get; set; }
        public string Bio { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser User { get; set; }
        public Gym Gym { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<SessionLog> SessionLogs { get; set; }
    }

    // -----------------------------
    // Workout Plans
    // -----------------------------
    public class WorkoutPlan
    {
        public Guid WorkoutPlanId { get; set; }
        public Guid GymId { get; set; }
        public Guid? MemberId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTemplate { get; set; }
        public int? DayTypeId { get; set; }
        public string CreatedByUserId { get; set; }      // AspNetUsers FK
        public DateTime CreatedAt { get; set; }

        public ApplicationUser CreatedBy { get; set; }
        public Gym Gym { get; set; }
        public Member Member { get; set; }
        public ICollection<WorkoutDay> WorkoutDays { get; set; }
        public ICollection<SessionLog> SessionLogs { get; set; }
    }

    public class WorkoutDayType
    {
        public int DayTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<WorkoutDay> WorkoutDays { get; set; }
    }

    public class WorkoutDay
    {
        public Guid WorkoutDayId { get; set; }
        public Guid WorkoutPlanId { get; set; }
        public int DayTypeId { get; set; }
        public DateTime CreatedAt { get; set; }

        public WorkoutPlan WorkoutPlan { get; set; }
        public WorkoutDayType DayType { get; set; }
        public ICollection<WorkoutDayExercise> Exercises { get; set; }
    }

    public class WorkoutDayExercise
    {
        public Guid WorkoutDayExerciseId { get; set; }
        public Guid WorkoutDayId { get; set; }
        public Guid ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public decimal? Weight { get; set; }

        public WorkoutDay WorkoutDay { get; set; }
        public Exercise Exercise { get; set; }
    }
}