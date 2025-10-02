
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Feedbacks
{
    public Guid FeedbackId { get; set; }

    public Guid FromUserId { get; set; }

    public Guid? ForTrainerId { get; set; }

    public Guid? GymId { get; set; }

    public int? Rating { get; set; }

    public string Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Trainers ForTrainer { get; set; }

    public virtual Users FromUser { get; set; }

    public virtual Gyms Gym { get; set; }
}