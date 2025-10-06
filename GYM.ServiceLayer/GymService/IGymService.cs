using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.GymService
{
    public interface IGymService
    {
        Task<IEnumerable<Gym>> GetAll();
        Task<Gym> Get(Guid id);
        Task<Guid> Create(Gym model);
        Task<bool> Update(Gym model);
        Task<bool> Delete(Guid id);

        // Extra filters
        Task<IEnumerable<Gym>> GetByOwner(string ownerUserId);
        Task<IEnumerable<Member>> GetMembers(Guid gymId);
        Task<IEnumerable<Trainer>> GetTrainers(Guid gymId);
    }
}
