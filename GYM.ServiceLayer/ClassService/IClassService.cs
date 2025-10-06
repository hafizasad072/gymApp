using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.ClassService
{
    public interface IClassService
    {
        Task<IEnumerable<Class>> GetAll();
        Task<Class> Get(Guid id);
        Task<Guid> Create(Class model);
        Task<bool> Update(Class model);
        Task<bool> Delete(Guid id);

        // Class-specific filters
        Task<IEnumerable<Class>> GetByGym(Guid gymId);
        Task<IEnumerable<Class>> GetByTrainer(Guid trainerId);
    }
}
