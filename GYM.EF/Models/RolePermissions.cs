
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class RolePermissions
{
    public Guid RolePermissionId { get; set; }

    public Guid RoleId { get; set; }

    public Guid PermissionId { get; set; }

    public virtual Permissions Permission { get; set; }

    public virtual Roles Role { get; set; }
}