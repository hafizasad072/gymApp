using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.TrainerService
{
    public class TrainerService(IUnitOfWorkService _uow) : ITrainerService
    {
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Trainer>> GetAll()
        {
            return await _uow.TrainerRepository.GetAll();
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Trainer> Get(Guid id)
        {
            return await _uow.TrainerRepository.GetAsync(x => x.TrainerId == id);
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> Create(Trainer model)
        {
            model.TrainerId = Guid.NewGuid();
            model.CreatedAt = DateTime.Now;
            await _uow.TrainerRepository.InsertAsync(model);
            _uow.Commit();

            return model.TrainerId;
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(Trainer model)
        {
            var entity = await _uow.TrainerRepository.GetAsync(x => x.TrainerId == model.TrainerId, null, false);
            if (entity == null) return false;

            entity.Bio = model.Bio;
            entity.IsAvailable = model.IsAvailable;
            _uow.Commit();
            return true;
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.TrainerRepository.GetAsync(x => x.TrainerId == id);
            if (entity == null) return false;

            _uow.TrainerRepository.Delete(entity);
            _uow.Commit();

            return true;
        }
        /// <summary>
        /// Get By Gym
        /// </summary>
        /// <param name="gymId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Trainer>> GetByGym(Guid gymId)
        {
            return await _uow.TrainerRepository.GetAllAsync(x => x.GymId == gymId);
        }
        /// <summary>
        /// Get By User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Trainer> GetByUser(string userId)
        {
            return await _uow.TrainerRepository.GetAsync(x => x.UserId == userId);
        }
    }
}
