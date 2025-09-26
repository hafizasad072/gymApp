using Microsoft.EntityFrameworkCore;

namespace GYM.EF.Models
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> opts) : base(opts) { }

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

            // keep it minimal here
        }
    }
}
