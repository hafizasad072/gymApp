using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class ClassBooking
    {
        [Key]
        public Guid ClassBookingId { get; set; }
        public Guid ClassScheduleId { get; set; }
        public Guid MemberId { get; set; }
        public int StatusId { get; set; }
        public DateTime BookedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
    }
}
