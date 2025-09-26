using Microsoft.EntityFrameworkCore;

namespace GYM.EF.Models
{
    public class GYMContext : DbContext
    {
        public GYMContext(DbContextOptions<GYMContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<ClassBooking> ClassBookings { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<BodyMetric> BodyMetrics { get; set; }
        public DbSet<NotificationQueue> Notifications { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure keys, relationships, indexes if needed
            modelBuilder.Entity<ClassBooking>()
                .HasIndex(cb => new { cb.ClassScheduleId, cb.MemberId })
                .IsUnique();

            modelBuilder.Entity<User>()
           .HasKey(m => m.UserId);

            modelBuilder.Entity<Member>()
           .HasKey(m => m.MemberId);

            modelBuilder.Entity<Trainer>()
           .HasKey(m => m.TrainerId);

            modelBuilder.Entity<Attendance>()
           .HasKey(m => m.AttendanceId);

            modelBuilder.Entity<ClassSchedule>()
           .HasKey(m => m.ClassScheduleId);

            modelBuilder.Entity<ClassBooking>()
           .HasKey(m => m.ClassBookingId);

            modelBuilder.Entity<MembershipPlan>()
           .HasKey(m => m.PlanId);

            modelBuilder.Entity<Subscription>()
           .HasKey(m => m.SubscriptionId);

            modelBuilder.Entity<Invoice>()
           .HasKey(m => m.InvoiceId);

            modelBuilder.Entity<BodyMetric>()
           .HasKey(m => m.BodyMetricId);

            modelBuilder.Entity<NotificationQueue>()
           .HasKey(m => m.NotificationId);

            // keep it minimal here
        }
    }
}
