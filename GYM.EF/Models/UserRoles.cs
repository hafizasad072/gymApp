
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class UserRoles
{
    public Guid UserRoleId { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public Guid? GymId { get; set; }

    public DateTime AssignedAt { get; set; }

    public virtual Roles Role { get; set; }

    public virtual Users User { get; set; }
}