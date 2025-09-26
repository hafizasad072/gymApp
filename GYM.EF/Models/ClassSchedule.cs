using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class ClassSchedule
    {
        [Key]
        public Guid ClassScheduleId { get; set; }
        public Guid ClassId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}
