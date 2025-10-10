using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.BodyMetricService
{
    public interface IBodyMetricService
    {
        Task<IEnumerable<BodyMetric>> GetAll();
        Task<BodyMetric> Get(Guid id);
        Task<Guid> Create(BodyMetric model);
        Task<bool> Update(BodyMetric model);
        Task<bool> Delete(Guid id);

        // Filters
        Task<IEnumerable<BodyMetric>> GetByMember(Guid memberId);
        Task<IEnumerable<BodyMetric>> GetByType(Guid memberId, int metricTypeId);
        Task<IEnumerable<BodyMetric>> GetByDateRange(Guid memberId, DateTime start, DateTime end);
    }
}
