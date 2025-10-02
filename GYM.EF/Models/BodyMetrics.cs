
#nullable disable
using System;
using System.Collections.Generic;

namespace GYM.EF.Models;

public partial class BodyMetrics
{
    public long BodyMetricId { get; set; }

    public Guid MemberId { get; set; }

    public int MetricTypeId { get; set; }

    public decimal Value { get; set; }

    public string Unit { get; set; }

    public DateTime MeasuredAt { get; set; }

    public int SourceId { get; set; }

    public virtual Members Member { get; set; }

    public virtual BodyMetricTypes MetricType { get; set; }

    public virtual BodyMetricSources Source { get; set; }
}