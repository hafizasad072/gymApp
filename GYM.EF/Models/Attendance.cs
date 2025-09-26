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
        [Key]
        public long AttendanceId { get; set; }
        public Guid GymId { get; set; }
        public Guid UserId { get; set; }
        public int AttendanceTypeId { get; set; }
        public int SourceId { get; set; }
        public DateTime CheckinAt { get; set; }
        public DateTime? CheckoutAt { get; set; }
        public string Metadata { get; set; }

    }
}
