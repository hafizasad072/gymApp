
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class Leagues
{
    public int LeagueId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Members> Members { get; set; } = new List<Members>();
}