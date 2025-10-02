
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Attendance
{
    public long AttendanceId { get; set; }

    public Guid GymId { get; set; }

    public Guid UserId { get; set; }

    public int AttendanceTypeId { get; set; }

    public int SourceId { get; set; }

    public DateTime CheckinAt { get; set; }

    public DateTime? CheckoutAt { get; set; }

    public string Metadata { get; set; }

    public virtual AttendanceTypes AttendanceType { get; set; }

    public virtual Gyms Gym { get; set; }

    public virtual AttendanceSources Source { get; set; }

    public virtual Users User { get; set; }
}