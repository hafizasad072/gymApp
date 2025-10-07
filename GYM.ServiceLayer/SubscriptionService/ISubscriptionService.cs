using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.SubscriptionService
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> GetAll();
        Task<Subscription> Get(Guid id);
        Task<Guid> Create(Subscription model);
        Task<bool> Update(Subscription model);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Subscription>> GetByMember(Guid memberId);
        Task<IEnumerable<Subscription>> GetByGym(Guid gymId);
        Task<IEnumerable<Subscription>> GetActiveByGym(Guid gymId);
        Task<IEnumerable<Subscription>> GetExpired();
        Task<bool> Cancel(Guid id);
        Task<bool> Renew(Guid id);
    }
}
