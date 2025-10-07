using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;

namespace GYM.DataLayer.SubscriptionRepository
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(GymDbContext context) : base(context)
        {
        }
    }
}
