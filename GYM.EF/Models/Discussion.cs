using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{
    public class Discussion
    {
        public Guid DiscussionId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string CreatedByUserId { get; set; }
        public Guid? GymId { get; set; }
        public bool IsFranchiseWide { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser CreatedBy { get; set; }
        public Gym Gym { get; set; }
        public ICollection<DiscussionMessage> Messages { get; set; }
    }

    public class DiscussionMessage
    {
        [Key]
        public Guid MessageId { get; set; }
        public Guid DiscussionId { get; set; }
        public string FromUserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public Discussion Discussion { get; set; }
        public ApplicationUser FromUser { get; set; }
    }

}
