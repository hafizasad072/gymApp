using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.TrainerService
{
    public interface ITrainerService
    {
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Trainer>> GetAll();
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Trainer> Get(Guid id);
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> Create(Trainer model);
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Update(Trainer model);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
        /// <summary>
        /// Get By Gym
        /// </summary>
        /// <param name="gymId"></param>
        /// <returns></returns>
        Task<IEnumerable<Trainer>> GetByGym(Guid gymId);
        /// <summary>
        /// Get By User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Trainer> GetByUser(string userId);
    }
}
