using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.GymService
{
    public class GymService : IGymService
    {
        private readonly IUnitOfWorkService _uow;

        public GymService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Gym>> GetAll()
        {
            return await _uow.GymRepository.GetAll();
        }

        public async Task<Gym> Get(Guid id)
        {
            return await _uow.GymRepository.GetAsync(x => x.GymId == id);
        }

        public async Task<Guid> Create(Gym model)
        {
            model.GymId = Guid.NewGuid();
            model.CreatedAt = DateTime.UtcNow;

            await _uow.GymRepository.InsertAsync(model);
            _uow.Commit();

            return model.GymId;
        }

        public async Task<bool> Update(Gym model)
        {
            var entity = await _uow.GymRepository.GetAsync(x => x.GymId == model.GymId, null, false);
            if (entity == null) return false;

            entity.Name = model.Name;
            entity.Timezone = model.Timezone;

            _uow.Commit();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.GymRepository.GetAsync(x => x.GymId == id);
            if (entity == null) return false;

            _uow.GymRepository.Delete(entity);
            _uow.Commit();

            return true;
        }

        public async Task<IEnumerable<Gym>> GetByOwner(string ownerUserId)
        {
            return await _uow.GymRepository.GetAllAsync(x => x.OwnerUserId == ownerUserId);
        }

        public async Task<IEnumerable<Member>> GetMembers(Guid gymId)
        {
            return await _uow.MemberRepository.GetAllAsync(x => x.GymId == gymId);
        }

        public async Task<IEnumerable<Trainer>> GetTrainers(Guid gymId)
        {
            return await _uow.TrainerRepository.GetAllAsync(x => x.GymId == gymId);
        }
    }
}
