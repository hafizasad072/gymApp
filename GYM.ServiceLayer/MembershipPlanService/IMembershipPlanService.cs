using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.MembershipPlanService
{
    public interface IMembershipPlanService
    {
        Task<IEnumerable<MembershipPlan>> GetAll();
        Task<MembershipPlan> Get(Guid id);
        Task<Guid> Create(MembershipPlan model);
        Task<bool> Update(MembershipPlan model);
        Task<bool> Delete(Guid id);

        // Additional Queries
        Task<IEnumerable<MembershipPlan>> GetByGym(Guid gymId);
        Task<IEnumerable<MembershipPlan>> GetActivePlans(Guid gymId);
        Task<IEnumerable<MembershipPlan>> GetByDurationRange(int minDays, int maxDays);
    }
}
