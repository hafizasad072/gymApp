using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class NotificationQueue
    {
        [Key]
        public long NotificationId { get; set; }
        public Guid? GymId { get; set; }
        public Guid? ToUserId { get; set; }
        public string Channel { get; set; }
        public string TemplateKey { get; set; }
        public string Payload { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
