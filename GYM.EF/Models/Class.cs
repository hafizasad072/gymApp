using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    
    public class Class
    {
        public Guid ClassId { get; set; }
        public Guid GymId { get; set; }
        public string TrainerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }

        public Gym Gym { get; set; }
        public Trainer Trainer { get; set; }
        public ICollection<ClassSchedule> Schedules { get; set; }
    }
    public class ClassBookingStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
        public ICollection<ClassBooking> ClassBookings { get; set; }
    }
}
