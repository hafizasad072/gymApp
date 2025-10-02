
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class MuscleGroups
{
    public int MuscleGroupId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Exercises> Exercises { get; set; } = new List<Exercises>();
}