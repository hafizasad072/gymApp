
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Roles
{
    public Guid RoleId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<RolePermissions> RolePermissions { get; set; } = new List<RolePermissions>();

    public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
}