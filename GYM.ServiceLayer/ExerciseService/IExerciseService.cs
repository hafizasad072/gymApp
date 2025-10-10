using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.ExerciseService
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetAll();
        Task<Exercise> Get(Guid id);
        Task<Guid> Create(Exercise model);
        Task<bool> Update(Exercise model);
        Task<bool> Delete(Guid id);

        // Filters
        Task<IEnumerable<Exercise>> GetByGym(Guid gymId);
        Task<IEnumerable<Exercise>> GetByMuscleGroup(Guid gymId, int muscleGroupId);
        Task<IEnumerable<Exercise>> GetByEquipment(Guid gymId, string equipment);
        Task<IEnumerable<Exercise>> GetActiveByGym(Guid gymId);
        Task<bool> ToggleActive(Guid id, bool isActive);
    }
}
