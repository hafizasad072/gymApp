
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Discussions
{
    public Guid DiscussionId { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public Guid CreatedByUserId { get; set; }

    public Guid? GymId { get; set; }

    public bool IsFranchiseWide { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Users CreatedByUser { get; set; }

    public virtual ICollection<DiscussionMessages> DiscussionMessages { get; set; } = new List<DiscussionMessages>();

    public virtual Gyms Gym { get; set; }
}