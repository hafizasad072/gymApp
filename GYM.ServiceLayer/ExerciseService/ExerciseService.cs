using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.ExerciseService
{
    public class ExerciseService : IExerciseService
    {
        private readonly IUnitOfWorkService _uow;

        public ExerciseService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        // ------------------- CRUD -------------------

        public async Task<IEnumerable<Exercise>> GetAll()
            => await _uow.ExerciseRepository.GetAll();

        public async Task<Exercise> Get(Guid id)
            => await _uow.ExerciseRepository.GetAsync(x => x.ExerciseId == id);

        public async Task<Guid> Create(Exercise model)
        {
            model.ExerciseId = Guid.NewGuid();
            model.CreatedAt = DateTime.UtcNow;
            model.IsActive = true;

            await _uow.ExerciseRepository.InsertAsync(model);
            _uow.Commit();

            return model.ExerciseId;
        }

        public async Task<bool> Update(Exercise model)
        {
            var entity = await _uow.ExerciseRepository.GetAsync(x => x.ExerciseId == model.ExerciseId, null, false);
            if (entity == null) return false;

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.MuscleGroupId = model.MuscleGroupId;
            entity.Equipment = model.Equipment;
            entity.IsActive = model.IsActive;

            _uow.Commit();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.ExerciseRepository.GetAsync(x => x.ExerciseId == id);
            if (entity == null) return false;

            _uow.ExerciseRepository.Delete(entity);
            _uow.Commit();
            return true;
        }

        // ------------------- Filters -------------------

        public async Task<IEnumerable<Exercise>> GetByGym(Guid gymId)
            => await _uow.ExerciseRepository.GetAllAsync(x => x.GymId == gymId);

        public async Task<IEnumerable<Exercise>> GetByMuscleGroup(Guid gymId, int muscleGroupId)
            => await _uow.ExerciseRepository.GetAllAsync(
                x => x.GymId == gymId && x.MuscleGroupId == muscleGroupId);

        public async Task<IEnumerable<Exercise>> GetByEquipment(Guid gymId, string equipment)
            => await _uow.ExerciseRepository.GetAllAsync(
                x => x.GymId == gymId && x.Equipment.Contains(equipment));

        public async Task<IEnumerable<Exercise>> GetActiveByGym(Guid gymId)
            => await _uow.ExerciseRepository.GetAllAsync(
                x => x.GymId == gymId && x.IsActive);

        public async Task<bool> ToggleActive(Guid id, bool isActive)
        {
            var entity = await _uow.ExerciseRepository.GetAsync(x => x.ExerciseId == id, null, false);
            if (entity == null) return false;

            entity.IsActive = isActive;
            _uow.Commit();
            return true;
        }
    }

}
