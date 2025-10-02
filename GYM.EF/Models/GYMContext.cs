
#nullable disable
using Microsoft.EntityFrameworkCore;

namespace GYM.EF.Models;

public partial class GYMContext : DbContext
{
    public GYMContext(DbContextOptions<GYMContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendance { get; set; }

    public virtual DbSet<AttendanceSources> AttendanceSources { get; set; }

    public virtual DbSet<AttendanceTypes> AttendanceTypes { get; set; }

    public virtual DbSet<AuditLogs> AuditLogs { get; set; }

    public virtual DbSet<BodyMetricSources> BodyMetricSources { get; set; }

    public virtual DbSet<BodyMetricTypes> BodyMetricTypes { get; set; }

    public virtual DbSet<BodyMetrics> BodyMetrics { get; set; }

    public virtual DbSet<ClassBookingStatuses> ClassBookingStatuses { get; set; }

    public virtual DbSet<ClassBookings> ClassBookings { get; set; }

    public virtual DbSet<ClassSchedules> ClassSchedules { get; set; }

    public virtual DbSet<Classes> Classes { get; set; }

    public virtual DbSet<DiscussionMessages> DiscussionMessages { get; set; }

    public virtual DbSet<Discussions> Discussions { get; set; }

    public virtual DbSet<Exercises> Exercises { get; set; }

    public virtual DbSet<ExternalProviders> ExternalProviders { get; set; }

    public virtual DbSet<Feedbacks> Feedbacks { get; set; }

    public virtual DbSet<Gyms> Gyms { get; set; }

    public virtual DbSet<InvoiceStatuses> InvoiceStatuses { get; set; }

    public virtual DbSet<Invoices> Invoices { get; set; }

    public virtual DbSet<Leagues> Leagues { get; set; }

    public virtual DbSet<Members> Members { get; set; }

    public virtual DbSet<MembershipPlans> MembershipPlans { get; set; }

    public virtual DbSet<MuscleGroups> MuscleGroups { get; set; }

    public virtual DbSet<NotificationStatuses> NotificationStatuses { get; set; }

    public virtual DbSet<Notifications> Notifications { get; set; }

    public virtual DbSet<Payments> Payments { get; set; }

    public virtual DbSet<Permissions> Permissions { get; set; }

    public virtual DbSet<RolePermissions> RolePermissions { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<SessionLogs> SessionLogs { get; set; }

    public virtual DbSet<SubscriptionStatuses> SubscriptionStatuses { get; set; }

    public virtual DbSet<Subscriptions> Subscriptions { get; set; }

    public virtual DbSet<Trainers> Trainers { get; set; }

    public virtual DbSet<UserRoles> UserRoles { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<WorkoutDayExercises> WorkoutDayExercises { get; set; }

    public virtual DbSet<WorkoutDayTypes> WorkoutDayTypes { get; set; }

    public virtual DbSet<WorkoutDays> WorkoutDays { get; set; }

    public virtual DbSet<WorkoutPlans> WorkoutPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69261C2F0980EB");

            entity.Property(e => e.CheckinAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.CheckoutAt).HasPrecision(3);

            entity.HasOne(d => d.AttendanceType).WithMany(p => p.Attendance)
                .HasForeignKey(d => d.AttendanceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Atten__30C33EC3");

            entity.HasOne(d => d.Gym).WithMany(p => p.Attendance)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__GymId__2EDAF651");

            entity.HasOne(d => d.Source).WithMany(p => p.Attendance)
                .HasForeignKey(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Sourc__31B762FC");

            entity.HasOne(d => d.User).WithMany(p => p.Attendance)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__UserI__2FCF1A8A");
        });

        modelBuilder.Entity<AttendanceSources>(entity =>
        {
            entity.HasKey(e => e.SourceId).HasName("PK__Attendan__16E01919881B938B");

            entity.Property(e => e.SourceId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<AttendanceTypes>(entity =>
        {
            entity.HasKey(e => e.AttendanceTypeId).HasName("PK__Attendan__F843372C499D0905");

            entity.Property(e => e.AttendanceTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<AuditLogs>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AuditLog__A17F23980ED1BCCD");

            entity.Property(e => e.Action)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Entity).HasMaxLength(200);
            entity.Property(e => e.EntityId).HasMaxLength(200);

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__AuditLogs__UserI__0D44F85C");
        });

        modelBuilder.Entity<BodyMetricSources>(entity =>
        {
            entity.HasKey(e => e.SourceId).HasName("PK__BodyMetr__16E01919974C543E");

            entity.Property(e => e.SourceId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<BodyMetricTypes>(entity =>
        {
            entity.HasKey(e => e.MetricTypeId).HasName("PK__BodyMetr__79DBA0640DC350AC");

            entity.Property(e => e.MetricTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<BodyMetrics>(entity =>
        {
            entity.HasKey(e => e.BodyMetricId).HasName("PK__BodyMetr__98BBF337F3D97F61");

            entity.HasIndex(e => new { e.MemberId, e.MeasuredAt }, "IX_BodyMetrics_Member_MeasuredAt").IsDescending(false, true);

            entity.Property(e => e.MeasuredAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Unit).HasMaxLength(20);
            entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Member).WithMany(p => p.BodyMetrics)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BodyMetri__Membe__70A8B9AE");

            entity.HasOne(d => d.MetricType).WithMany(p => p.BodyMetrics)
                .HasForeignKey(d => d.MetricTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BodyMetri__Metri__719CDDE7");

            entity.HasOne(d => d.Source).WithMany(p => p.BodyMetrics)
                .HasForeignKey(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BodyMetri__Sourc__73852659");
        });

        modelBuilder.Entity<ClassBookingStatuses>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__ClassBoo__C8EE2063275BC5E9");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<ClassBookings>(entity =>
        {
            entity.HasKey(e => e.ClassBookingId).HasName("PK__ClassBoo__65EFAA38F1AD8842");

            entity.HasIndex(e => new { e.ClassScheduleId, e.MemberId }, "UQ_ClassBooking_Member_Schedule").IsUnique();

            entity.Property(e => e.ClassBookingId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BookedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.CancelledAt).HasPrecision(3);

            entity.HasOne(d => d.ClassSchedule).WithMany(p => p.ClassBookings)
                .HasForeignKey(d => d.ClassScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassBook__Class__01D345B0");

            entity.HasOne(d => d.Member).WithMany(p => p.ClassBookings)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassBook__Membe__02C769E9");

            entity.HasOne(d => d.Status).WithMany(p => p.ClassBookings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassBook__Statu__03BB8E22");
        });

        modelBuilder.Entity<ClassSchedules>(entity =>
        {
            entity.HasKey(e => e.ClassScheduleId).HasName("PK__ClassSch__6A8D56FECA019668");

            entity.Property(e => e.ClassScheduleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.EndAt).HasPrecision(3);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.StartAt).HasPrecision(3);

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSchedules)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__ClassSche__Class__7E02B4CC");
        });

        modelBuilder.Entity<Classes>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927C0A818FADD");

            entity.Property(e => e.ClassId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Capacity).HasDefaultValue(20);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Gym).WithMany(p => p.Classes)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__GymId__7755B73D");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__Classes__Trainer__7849DB76");
        });

        modelBuilder.Entity<DiscussionMessages>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Discussi__C87C0C9C288520FD");

            entity.Property(e => e.MessageId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Message).IsRequired();

            entity.HasOne(d => d.Discussion).WithMany(p => p.DiscussionMessages)
                .HasForeignKey(d => d.DiscussionId)
                .HasConstraintName("FK__Discussio__Discu__24285DB4");

            entity.HasOne(d => d.FromUser).WithMany(p => p.DiscussionMessages)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Discussio__FromU__251C81ED");
        });

        modelBuilder.Entity<Discussions>(entity =>
        {
            entity.HasKey(e => e.DiscussionId).HasName("PK__Discussi__7E8E39C0DADA1FB5");

            entity.Property(e => e.DiscussionId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(300);

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Discussions)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Discussio__Creat__1D7B6025");

            entity.HasOne(d => d.Gym).WithMany(p => p.Discussions)
                .HasForeignKey(d => d.GymId)
                .HasConstraintName("FK__Discussio__GymId__1E6F845E");
        });

        modelBuilder.Entity<Exercises>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK__Exercise__A074AD2FED041E25");

            entity.Property(e => e.ExerciseId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Equipment).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Gym).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exercises__GymId__5F7E2DAC");

            entity.HasOne(d => d.MuscleGroup).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.MuscleGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exercises__Muscl__607251E5");
        });

        modelBuilder.Entity<ExternalProviders>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("PK__External__B54C687DE6358206");

            entity.Property(e => e.ProviderId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ExpiresAt).HasPrecision(3);
            entity.Property(e => e.ExternalUserId).HasMaxLength(200);
            entity.Property(e => e.LastSyncAt).HasPrecision(3);
            entity.Property(e => e.ProviderName)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.ExternalProviders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ExternalP__UserI__1209AD79");
        });

        modelBuilder.Entity<Feedbacks>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD6FFA03952");

            entity.Property(e => e.FeedbackId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.ForTrainer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ForTrainerId)
                .HasConstraintName("FK__Feedbacks__ForTr__17C286CF");

            entity.HasOne(d => d.FromUser).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__FromU__16CE6296");

            entity.HasOne(d => d.Gym).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.GymId)
                .HasConstraintName("FK__Feedbacks__GymId__18B6AB08");
        });

        modelBuilder.Entity<Gyms>(entity =>
        {
            entity.HasKey(e => e.GymId).HasName("PK__Gyms__1A3A7C96E4CB0A10");

            entity.Property(e => e.GymId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Timezone).HasMaxLength(64);
        });

        modelBuilder.Entity<InvoiceStatuses>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__InvoiceS__C8EE206316AC62B4");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Invoices>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoices__D796AAB5CF7DD1D9");

            entity.Property(e => e.InvoiceId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Currency)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("USD");
            entity.Property(e => e.IssuedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.PaidAt).HasPrecision(3);

            entity.HasOne(d => d.Gym).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__GymId__45BE5BA9");

            entity.HasOne(d => d.Member).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__Member__44CA3770");

            entity.HasOne(d => d.Status).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__Status__489AC854");

            entity.HasOne(d => d.Subscription).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.SubscriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__Subscr__43D61337");
        });

        modelBuilder.Entity<Leagues>(entity =>
        {
            entity.HasKey(e => e.LeagueId).HasName("PK__Leagues__10ABBCF4A25A99DB");

            entity.Property(e => e.LeagueId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Members>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B18A7D8BA1C");

            entity.Property(e => e.MemberId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.JoinDate).HasDefaultValueSql("(CONVERT([date],sysutcdatetime()))");

            entity.HasOne(d => d.Gym).WithMany(p => p.Members)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Members__GymId__2180FB33");

            entity.HasOne(d => d.League).WithMany(p => p.Members)
                .HasForeignKey(d => d.LeagueId)
                .HasConstraintName("FK__Members__LeagueI__22751F6C");

            entity.HasOne(d => d.User).WithMany(p => p.Members)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Members__UserId__208CD6FA");
        });

        modelBuilder.Entity<MembershipPlans>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("PK__Membersh__755C22B704D891B6");

            entity.Property(e => e.PlanId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BillingCycle)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Gym).WithMany(p => p.MembershipPlans)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Membershi__GymId__367C1819");
        });

        modelBuilder.Entity<MuscleGroups>(entity =>
        {
            entity.HasKey(e => e.MuscleGroupId).HasName("PK__MuscleGr__097AE866E153F62E");

            entity.Property(e => e.MuscleGroupId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<NotificationStatuses>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Notifica__C8EE2063D1AB1289");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Notifications>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E12864F96B5");

            entity.Property(e => e.Channel)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.SentAt).HasPrecision(3);
            entity.Property(e => e.TemplateKey)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Gym).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.GymId)
                .HasConstraintName("FK__Notificat__GymId__078C1F06");

            entity.HasOne(d => d.Status).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Statu__09746778");

            entity.HasOne(d => d.ToUser).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.ToUserId)
                .HasConstraintName("FK__Notificat__ToUse__0880433F");
        });

        modelBuilder.Entity<Payments>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A3826148D30");

            entity.Property(e => e.PaymentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Method)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.PaidAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ProviderTransactionId).HasMaxLength(200);

            entity.HasOne(d => d.Gym).WithMany(p => p.Payments)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__GymId__4E53A1AA");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__Payments__Invoic__4C6B5938");

            entity.HasOne(d => d.Member).WithMany(p => p.Payments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Member__4D5F7D71");
        });

        modelBuilder.Entity<Permissions>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB2F54488543");

            entity.HasIndex(e => e.Name, "UQ__Permissi__737584F6A9828297").IsUnique();

            entity.Property(e => e.PermissionId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<RolePermissions>(entity =>
        {
            entity.HasKey(e => e.RolePermissionId).HasName("PK__RolePerm__120F46BA5E7A4791");

            entity.Property(e => e.RolePermissionId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__17036CC0");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__160F4887");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A4107754E");

            entity.HasIndex(e => e.Name, "UQ__Roles__737584F6D98D07C1").IsUnique();

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<SessionLogs>(entity =>
        {
            entity.HasKey(e => e.SessionLogId).HasName("PK__SessionL__96CBDF0B9E9C409A");

            entity.Property(e => e.SessionLogId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.PerformedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Member).WithMany(p => p.SessionLogs)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SessionLo__Membe__6BE40491");

            entity.HasOne(d => d.Trainer).WithMany(p => p.SessionLogs)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__SessionLo__Train__6CD828CA");

            entity.HasOne(d => d.WorkoutPlan).WithMany(p => p.SessionLogs)
                .HasForeignKey(d => d.WorkoutPlanId)
                .HasConstraintName("FK__SessionLo__Worko__6AEFE058");
        });

        modelBuilder.Entity<SubscriptionStatuses>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Subscrip__C8EE20630325CFAA");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Subscriptions>(entity =>
        {
            entity.HasKey(e => e.SubscriptionId).HasName("PK__Subscrip__9A2B249DCD118F9D");

            entity.Property(e => e.SubscriptionId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AutoRenew).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Member).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subscript__Membe__3C34F16F");

            entity.HasOne(d => d.Plan).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subscript__PlanI__3D2915A8");

            entity.HasOne(d => d.Status).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subscript__Statu__3E1D39E1");
        });

        modelBuilder.Entity<Trainers>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainers__366A1A7CC4A1A9D0");

            entity.HasIndex(e => e.UserId, "UQ__Trainers__1788CC4DB7EF9D51").IsUnique();

            entity.Property(e => e.TrainerId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);

            entity.HasOne(d => d.Gym).WithMany(p => p.Trainers)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trainers__GymId__2A164134");

            entity.HasOne(d => d.User).WithOne(p => p.Trainers)
                .HasForeignKey<Trainers>(d => d.UserId)
                .HasConstraintName("FK__Trainers__UserId__29221CFB");
        });

        modelBuilder.Entity<UserRoles>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A35D0E87002");

            entity.Property(e => e.UserRoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AssignedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRoles__RoleI__1BC821DD");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRoles__UserI__1AD3FDA4");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C409A861D");

            entity.HasIndex(e => e.Email, "IX_Users_Email");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534E64ADB0B").IsUnique();

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DisplayName).HasMaxLength(200);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.LastLoginAt).HasPrecision(3);
            entity.Property(e => e.PasswordHash).HasMaxLength(512);
            entity.Property(e => e.PasswordSalt).HasMaxLength(128);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<WorkoutDayExercises>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkoutD__3214EC07295EC375");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Reps).HasMaxLength(50);

            entity.HasOne(d => d.Exercise).WithMany(p => p.WorkoutDayExercises)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkoutDa__Exerc__671F4F74");

            entity.HasOne(d => d.WorkoutDay).WithMany(p => p.WorkoutDayExercises)
                .HasForeignKey(d => d.WorkoutDayId)
                .HasConstraintName("FK__WorkoutDa__Worko__662B2B3B");
        });

        modelBuilder.Entity<WorkoutDayTypes>(entity =>
        {
            entity.HasKey(e => e.DayTypeId).HasName("PK__WorkoutD__8E02B0F4DA8F24ED");

            entity.Property(e => e.DayTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<WorkoutDays>(entity =>
        {
            entity.HasKey(e => e.WorkoutDayId).HasName("PK__WorkoutD__D459FCA9E8FE936A");

            entity.Property(e => e.WorkoutDayId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DayType).HasMaxLength(100);

            entity.HasOne(d => d.WorkoutPlan).WithMany(p => p.WorkoutDays)
                .HasForeignKey(d => d.WorkoutPlanId)
                .HasConstraintName("FK__WorkoutDa__Worko__5BAD9CC8");
        });

        modelBuilder.Entity<WorkoutPlans>(entity =>
        {
            entity.HasKey(e => e.WorkoutPlanId).HasName("PK__WorkoutP__8C51607B9968A4ED");

            entity.Property(e => e.WorkoutPlanId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.WorkoutPlans)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkoutPl__Creat__56E8E7AB");

            entity.HasOne(d => d.DayType).WithMany(p => p.WorkoutPlans)
                .HasForeignKey(d => d.DayTypeId)
                .HasConstraintName("FK__WorkoutPl__DayTy__55F4C372");

            entity.HasOne(d => d.Gym).WithMany(p => p.WorkoutPlans)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkoutPl__GymId__531856C7");

            entity.HasOne(d => d.Member).WithMany(p => p.WorkoutPlans)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__WorkoutPl__Membe__540C7B00");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}