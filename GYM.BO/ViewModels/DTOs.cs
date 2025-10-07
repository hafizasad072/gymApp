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

    public class TrainerDto
    {
        public Guid TrainerId { get; set; }
        public string UserId { get; set; }    
        public Guid GymId { get; set; }
        public string Bio { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CreateTrainerDto
    {
        public string UserId { get; set; }
        public Guid GymId { get; set; }
        public string Bio { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class UpdateTrainerDto
    {
        public Guid TrainerId { get; set; }
        public string Bio { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class GymDto
    {
        public Guid GymId { get; set; }
        public string Name { get; set; }
        public string OwnerUserId { get; set; }
        public string Timezone { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateGymDto
    {
        public string Name { get; set; }
        public string OwnerUserId { get; set; }
        public string Timezone { get; set; }
    }

    public class UpdateGymDto
    {
        public Guid GymId { get; set; }
        public string Name { get; set; }
        public string Timezone { get; set; }
    }

    public class ClassDto
    {
        public Guid ClassId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public Guid GymId { get; set; }
        public Guid TrainerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateClassDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public Guid GymId { get; set; }
        public Guid TrainerId { get; set; }
    }

    public class UpdateClassDto
    {
        public Guid ClassId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
    }

    public class ClassScheduleDto
    {
        public Guid ClassScheduleId { get; set; }
        public Guid ClassId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }

    public class CreateClassScheduleDto
    {
        public Guid ClassId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }

    public class ClassBookingDto
    {
        public Guid ClassBookingId { get; set; }
        public Guid ClassScheduleId { get; set; }
        public Guid MemberId { get; set; }
        public int StatusId { get; set; }
        public DateTime BookedAt { get; set; }
    }

    public class CreateClassBookingDto
    {
        public Guid ClassScheduleId { get; set; }
        public Guid MemberId { get; set; }
    }

    public class MembershipPlanDto
    {
        public Guid PlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BillingCycle { get; set; }
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public Guid GymId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateMembershipPlanDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BillingCycle { get; set; }
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public Guid GymId { get; set; }
    }

    public class UpdateMembershipPlanDto
    {
        public Guid PlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BillingCycle { get; set; }
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public bool IsActive { get; set; }
    }
    public class SubscriptionDto
    {
        public Guid SubscriptionId { get; set; }
        public Guid MemberId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
    }

    public class CreateSubscriptionDto
    {
        public Guid MemberId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class UpdateSubscriptionDto
    {
        public Guid SubscriptionId { get; set; }
        public int StatusId { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class InvoiceDto
    {
        public Guid InvoiceId { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid MemberId { get; set; }
        public Guid GymId { get; set; }
        public decimal Amount { get; set; }
        public int StatusId { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class CreateInvoiceDto
    {
        public Guid SubscriptionId { get; set; }
        public Guid MemberId { get; set; }
        public Guid GymId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
    public class PaymentDto
    {
        public Guid PaymentId { get; set; }
        public Guid InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionRef { get; set; }
    }

    public class CreatePaymentDto
    {
        public Guid InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionRef { get; set; }
    }

}
