using GYM.DataLayer.Repository;
using GYM.EF.Models;
using GYM.EF;

namespace GYM.DataLayer.MembershipPlanRepository
{
    public class MembershipPlanRepository : GenericRepository<MembershipPlan>, IMembershipPlanRepository
    {
        public MembershipPlanRepository(GymDbContext context) : base(context)
        {
        }
    }
}
