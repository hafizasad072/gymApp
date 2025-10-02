
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class AuditLogs
{
    public long AuditId { get; set; }

    public Guid? UserId { get; set; }

    public string Action { get; set; }

    public string Entity { get; set; }

    public string EntityId { get; set; }

    public string Data { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Users User { get; set; }
}