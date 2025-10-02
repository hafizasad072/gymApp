
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class BodyMetricTypes
{
    public int MetricTypeId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<BodyMetrics> BodyMetrics { get; set; } = new List<BodyMetrics>();
}