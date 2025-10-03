using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.BO.ViewModels
{
    public record QuickRegisterRequest([Required] Guid GymId, [Required][EmailAddress] string Email, string Phone, string DisplayName, Guid? InvitedByUserId);
    public record QuickRegisterResponse(Guid UserId, Guid MemberId);

    public record CheckInRequest([Required] Guid GymId, [Required] Guid UserId, int AttendanceTypeId, int SourceId, string Metadata);
    public record CheckOutRequest([Required] Guid GymId, [Required] Guid UserId, string CheckoutSource);

    public record BookClassRequest([Required] Guid ClassScheduleId, [Required] Guid MemberId, Guid? RequestedByUserId);
    public record BookClassResponse(Guid BookingId, string Status);

    public record CancelClassRequest([Required] Guid ClassBookingId, Guid? CancelledByUserId, string Reason);

    public record CreateSubscriptionRequest([Required] Guid MemberId, [Required] Guid PlanId, [Required] DateTime StartDate, [Required] decimal Amount, string Currency, bool AutoRenew = true);
    public record CreateSubscriptionResponse(Guid SubscriptionId, Guid InvoiceId);

    public class BodyMetricRow { public Guid MemberId { get; set; } public int MetricTypeId { get; set; } public decimal Value { get; set; } public string Unit { get; set; } public DateTime? MeasuredAt { get; set; } public int SourceId { get; set; } }
    public record BulkMetricsRequest(IList<BodyMetricRow> Metrics);

    public class AttendanceDto
    {
        public Guid AttendanceId { get; set; }
        public string UserId { get; set; }        // AspNetUsers.Id (string)
        public Guid GymId { get; set; }
        public DateTime CheckinAt { get; set; }
        public DateTime? CheckoutAt { get; set; }
        public int SourceId { get; set; }
        public int AttendanceTypeId { get; set; }
    }

    public class CreateAttendanceDto
    {
        public string UserId { get; set; }
        public Guid GymId { get; set; }
        public DateTime CheckinAt { get; set; }
        public int SourceId { get; set; }
        public int AttendanceTypeId { get; set; }
    }

    public class UpdateAttendanceDto
    {
        public Guid AttendanceId { get; set; }
        public DateTime? CheckoutAt { get; set; }
        public DateTime CheckinAt { get; set; }
        public int SourceId { get; set; }
    }

    public class MemberDto
    {
        public Guid MemberId { get; set; }
        public string UserId { get; set; } 
        public Guid GymId { get; set; }
        public int? LeagueId { get; set; }
        public DateTime JoinDate { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class CreateMemberDto
    {
        public string UserId { get; set; }
        public Guid GymId { get; set; }
        public int? LeagueId { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class UpdateMemberDto
    {
        public Guid MemberId { get; set; }
        public int? LeagueId { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
