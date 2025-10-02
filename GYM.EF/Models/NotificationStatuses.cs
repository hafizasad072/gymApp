
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class NotificationStatuses
{
    public int StatusId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();
}