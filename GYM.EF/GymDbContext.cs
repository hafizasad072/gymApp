using GYM.EF.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GYM.EF
{
    public class GymDbContext : IdentityDbContext<ApplicationUser>
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { }

        // -----------------------------
        // DbSets
        // -----------------------------
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceSource> AttendanceSources { get; set; }
        public DbSet<AttendanceType> AttendanceTypes { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<BodyMetric> BodyMetrics { get; set; }
        public DbSet<BodyMetricSource> BodyMetricSources { get; set; }
        public DbSet<BodyMetricType> BodyMetricTypes { get; set; }

        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassBooking> ClassBookings { get; set; }
        public DbSet<ClassBookingStatus> ClassBookingStatuses { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }

        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<DiscussionMessage> DiscussionMessages { get; set; }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        public DbSet<ExternalProvider> ExternalProviders { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Member> Members { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionStatus> SubscriptionStatuses { get; set; }

        public DbSet<SessionLog> SessionLogs { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutDay> WorkoutDays { get; set; }
        public DbSet<WorkoutDayExercise> WorkoutDayExercises { get; set; }
        public DbSet<WorkoutDayType> WorkoutDayTypes { get; set; }

        // -----------------------------
        // Model Building
        // -----------------------------
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // -----------------------------
            // Explicit Primary Keys for ALL tables
            // -----------------------------
            builder.Entity<Attendance>().HasKey(e => e.AttendanceId);
            builder.Entity<AttendanceSource>().HasKey(e => e.SourceId);
            builder.Entity<AttendanceType>().HasKey(e => e.AttendanceTypeId);

            builder.Entity<AuditLog>().HasKey(e => e.AuditId);

            builder.Entity<BodyMetric>().HasKey(e => e.BodyMetricId);
            builder.Entity<BodyMetricSource>().HasKey(e => e.SourceId);
            builder.Entity<BodyMetricType>().HasKey(e => e.MetricTypeId);

            builder.Entity<Class>().HasKey(e => e.ClassId);
            builder.Entity<ClassBooking>().HasKey(e => e.ClassBookingId);
            builder.Entity<ClassBookingStatus>().HasKey(e => e.StatusId);
            builder.Entity<ClassSchedule>().HasKey(e => e.ClassScheduleId);

            builder.Entity<Discussion>().HasKey(e => e.DiscussionId);
            builder.Entity<DiscussionMessage>().HasKey(e => e.MessageId);

            builder.Entity<Exercise>().HasKey(e => e.ExerciseId);
            builder.Entity<MuscleGroup>().HasKey(e => e.MuscleGroupId);

            builder.Entity<ExternalProvider>().HasKey(e => e.ProviderId);

            builder.Entity<Feedback>().HasKey(e => e.FeedbackId);

            builder.Entity<Gym>().HasKey(e => e.GymId);

            builder.Entity<Invoice>().HasKey(e => e.InvoiceId);
            builder.Entity<InvoiceStatus>().HasKey(e => e.StatusId);
            builder.Entity<Payment>().HasKey(e => e.PaymentId);

            builder.Entity<Member>().HasKey(e => e.MemberId);
            builder.Entity<League>().HasKey(e => e.LeagueId);
            builder.Entity<MembershipPlan>().HasKey(e => e.PlanId);

            builder.Entity<Notification>().HasKey(e => e.NotificationId);

            builder.Entity<Subscription>().HasKey(e => e.SubscriptionId);
            builder.Entity<SubscriptionStatus>().HasKey(e => e.StatusId);

            builder.Entity<SessionLog>().HasKey(e => e.SessionLogId);

            builder.Entity<Trainer>().HasKey(e => e.TrainerId);

            builder.Entity<WorkoutPlan>().HasKey(e => e.WorkoutPlanId);
            builder.Entity<WorkoutDay>().HasKey(e => e.WorkoutDayId);
            builder.Entity<WorkoutDayExercise>().HasKey(e => e.WorkoutDayExerciseId);
            builder.Entity<WorkoutDayType>().HasKey(e => e.DayTypeId);

            // -----------------------------
            // Foreign Keys & Relationships with Restrict delete
            // -----------------------------
            builder.Entity<Attendance>()
                .HasOne(a => a.Gym)
                .WithMany(g => g.Attendances)
                .HasForeignKey(a => a.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
                .HasOne(a => a.AttendanceType)
                .WithMany(t => t.Attendances)
                .HasForeignKey(a => a.AttendanceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
                .HasOne(a => a.Source)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.SourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AuditLog>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BodyMetric>()
                .HasOne(b => b.Member)
                .WithMany(m => m.BodyMetrics)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BodyMetric>()
                .HasOne(b => b.MetricType)
                .WithMany(t => t.BodyMetrics)
                .HasForeignKey(b => b.MetricTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BodyMetric>()
                .HasOne(b => b.Source)
                .WithMany(s => s.BodyMetrics)
                .HasForeignKey(b => b.SourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Class>()
                .HasOne(c => c.Gym)
                .WithMany(g => g.Classes)
                .HasForeignKey(c => c.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Class>()
                .HasOne(c => c.Trainer)
                .WithMany(t => t.Classes)
                .HasForeignKey(c => c.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Class)
                .WithMany(c => c.Schedules)
                .HasForeignKey(cs => cs.ClassId)
                .OnDelete(DeleteBehavior.Cascade); // Safe cascade

            builder.Entity<ClassBooking>()
                .HasOne(cb => cb.ClassSchedule)
                .WithMany(cs => cs.Bookings)
                .HasForeignKey(cb => cb.ClassScheduleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ClassBooking>()
                .HasOne(cb => cb.Member)
                .WithMany(m => m.ClassBookings)
                .HasForeignKey(cb => cb.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ClassBooking>()
                .HasOne(cb => cb.Status)
                .WithMany(s => s.ClassBookings)
                .HasForeignKey(cb => cb.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Discussion>()
                .HasOne(d => d.CreatedBy)
                .WithMany()
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DiscussionMessage>()
                .HasOne(dm => dm.Discussion)
                .WithMany(d => d.Messages)
                .HasForeignKey(dm => dm.DiscussionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DiscussionMessage>()
                .HasOne(dm => dm.FromUser)
                .WithMany()
                .HasForeignKey(dm => dm.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Exercise>()
                .HasOne(e => e.Gym)
                .WithMany(g => g.Exercises)
                .HasForeignKey(e => e.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Exercise>()
                .HasOne(e => e.MuscleGroup)
                .WithMany(m => m.Exercises)
                .HasForeignKey(e => e.MuscleGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkoutDayExercise>()
                .HasOne(wde => wde.Exercise)
                .WithMany(e => e.WorkoutDayExercises)
                .HasForeignKey(wde => wde.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExternalProvider>()
                .HasOne(ep => ep.User)
                .WithMany()
                .HasForeignKey(ep => ep.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Feedback>()
                .HasOne(f => f.FromUser)
                .WithMany()
                .HasForeignKey(f => f.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Feedback>()
                .HasOne(f => f.ForTrainer)
                .WithMany(t => t.Feedbacks)
                .HasForeignKey(f => f.ForTrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Feedback>()
                .HasOne(f => f.Gym)
                .WithMany(g => g.Feedbacks)
                .HasForeignKey(f => f.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Gym>()
                .HasOne(g => g.Owner)
                .WithMany()
                .HasForeignKey(g => g.OwnerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Invoice>()
                .HasOne(i => i.Subscription)
                .WithMany(s => s.Invoices)
                .HasForeignKey(i => i.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Invoice>()
                .HasOne(i => i.Member)
                .WithMany(m => m.Invoices)
                .HasForeignKey(i => i.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Invoice>()
                .HasOne(i => i.Gym)
                .WithMany(g => g.Invoices)
                .HasForeignKey(i => i.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Invoice>()
                .HasOne(i => i.Status)
                .WithMany(s => s.Invoices)
                .HasForeignKey(i => i.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(p => p.Invoice)
                .WithMany(i => i.Payments)
                .HasForeignKey(p => p.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(p => p.Member)
                .WithMany(m => m.Payments)
                .HasForeignKey(p => p.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(p => p.Gym)
                .WithMany(g => g.Payments)
                .HasForeignKey(p => p.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Member>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Member>()
                .HasOne(m => m.Gym)
                .WithMany(g => g.Members)
                .HasForeignKey(m => m.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Member>()
                .HasOne(m => m.League)
                .WithMany(l => l.Members)
                .HasForeignKey(m => m.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MembershipPlan>()
                .HasOne(mp => mp.Gym)
                .WithMany()
                .HasForeignKey(mp => mp.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Notification>()
                .HasOne(n => n.ToUser)
                .WithMany()
                .HasForeignKey(n => n.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Notification>()
                .HasOne(n => n.Gym)
                .WithMany(g => g.Notifications)
                .HasForeignKey(n => n.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Subscription>()
                .HasOne(s => s.Member)
                .WithMany(m => m.Subscriptions)
                .HasForeignKey(s => s.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Subscription>()
                .HasOne(s => s.Plan)
                .WithMany(mp => mp.Subscriptions)
                .HasForeignKey(s => s.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Subscription>()
                .HasOne(s => s.Status)
                .WithMany(ss => ss.Subscriptions)
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SessionLog>()
                .HasOne(sl => sl.Member)
                .WithMany(m => m.SessionLogs)
                .HasForeignKey(sl => sl.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SessionLog>()
                .HasOne(sl => sl.Trainer)
                .WithMany(t => t.SessionLogs)
                .HasForeignKey(sl => sl.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SessionLog>()
                .HasOne(sl => sl.WorkoutPlan)
                .WithMany(wp => wp.SessionLogs)
                .HasForeignKey(sl => sl.WorkoutPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Trainer>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Trainer>()
                .HasOne(t => t.Gym)
                .WithMany(g => g.Trainers)
                .HasForeignKey(t => t.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkoutPlan>()
                .HasOne(wp => wp.CreatedBy)
                .WithMany()
                .HasForeignKey(wp => wp.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkoutPlan>()
                .HasOne(wp => wp.Gym)
                .WithMany(g => g.WorkoutPlans)
                .HasForeignKey(wp => wp.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkoutPlan>()
                .HasOne(wp => wp.Member)
                .WithMany()
                .HasForeignKey(wp => wp.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkoutDay>()
                .HasOne(wd => wd.WorkoutPlan)
                .WithMany(wp => wp.WorkoutDays)
                .HasForeignKey(wd => wd.WorkoutPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WorkoutDay>()
                .HasOne(wd => wd.DayType)
                .WithMany(dt => dt.WorkoutDays)
                .HasForeignKey(wd => wd.DayTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkoutDayExercise>()
                .HasOne(wde => wde.WorkoutDay)
                .WithMany(wd => wd.Exercises)
                .HasForeignKey(wde => wde.WorkoutDayId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
