using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    
    public class Attendance
    {
        public long AttendanceId { get; set; }
        public Guid GymId { get; set; }
        public string UserId { get; set; } 
        public int AttendanceTypeId { get; set; }
        public int SourceId { get; set; }
        public DateTime CheckinAt { get; set; }
        public DateTime? CheckoutAt { get; set; }
        public string Metadata { get; set; }

        public AttendanceType AttendanceType { get; set; }
        public AttendanceSource Source { get; set; }
        public Gym Gym { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class AttendanceSource
    {
        [Key]
        public int SourceId { get; set; }
        public string Name { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }

    public class AttendanceType
    {
        [Key]
        public int AttendanceTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
