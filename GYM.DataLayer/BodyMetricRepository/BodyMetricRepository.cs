using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;

namespace GYM.DataLayer.BodyMetricRepository
{
    public class BodyMetricRepository : GenericRepository<BodyMetric>, IBodyMetricRepository
    {
        public BodyMetricRepository(GymDbContext context) : base(context)
        {
        }
    }
}
