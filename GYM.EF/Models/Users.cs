#nullable disable
namespace GYM.EF.Models;

public partial class Users
{
    public Guid UserId { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public string DisplayName { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public virtual ICollection<Attendance> Attendance { get; set; } = new List<Attendance>();

    public virtual ICollection<AuditLogs> AuditLogs { get; set; } = new List<AuditLogs>();

    public virtual ICollection<DiscussionMessages> DiscussionMessages { get; set; } = new List<DiscussionMessages>();

    public virtual ICollection<Discussions> Discussions { get; set; } = new List<Discussions>();

    public virtual ICollection<ExternalProviders> ExternalProviders { get; set; } = new List<ExternalProviders>();

    public virtual ICollection<Feedbacks> Feedbacks { get; set; } = new List<Feedbacks>();

    public virtual ICollection<Members> Members { get; set; } = new List<Members>();

    public virtual ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();

    public virtual Trainers Trainers { get; set; }

    public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();

    public virtual ICollection<WorkoutPlans> WorkoutPlans { get; set; } = new List<WorkoutPlans>();
}