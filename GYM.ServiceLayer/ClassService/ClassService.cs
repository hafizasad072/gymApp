using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.ClassService
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWorkService _uow;

        public ClassService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Class>> GetAll() =>
            await _uow.ClassRepository.GetAll();

        public async Task<Class> Get(Guid id) =>
            await _uow.ClassRepository.GetAsync(x => x.ClassId == id);

        public async Task<Guid> Create(Class model)
        {
            model.ClassId = Guid.NewGuid();
            model.CreatedAt = DateTime.UtcNow;
            await _uow.ClassRepository.InsertAsync(model);
            _uow.Commit();
            return model.ClassId;
        }

        public async Task<bool> Update(Class model)
        {
            var entity = await _uow.ClassRepository.GetAsync(x => x.ClassId == model.ClassId, null, false);
            if (entity == null) return false;

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.Capacity = model.Capacity;

            _uow.Commit();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.ClassRepository.GetAsync(x => x.ClassId == id);
            if (entity == null) return false;

            _uow.ClassRepository.Delete(entity);
            _uow.Commit();
            return true;
        }

        public async Task<IEnumerable<Class>> GetByGym(Guid gymId) =>
            await _uow.ClassRepository.GetAllAsync(x => x.GymId == gymId);

        public async Task<IEnumerable<Class>> GetByTrainer(Guid trainerId) =>
            await _uow.ClassRepository.GetAllAsync(x => x.TrainerId == trainerId);

    }
}
