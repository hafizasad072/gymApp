
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class AttendanceTypes
{
    public int AttendanceTypeId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Attendance> Attendance { get; set; } = new List<Attendance>();
}