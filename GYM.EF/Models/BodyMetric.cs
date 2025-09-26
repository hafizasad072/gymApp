using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.EF.Models
{

    public class BodyMetric
    {
        public long BodyMetricId { get; set; }
        public Guid MemberId { get; set; }
        public int MetricTypeId { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public DateTime MeasuredAt { get; set; }
        public int SourceId { get; set; }
    }
}
