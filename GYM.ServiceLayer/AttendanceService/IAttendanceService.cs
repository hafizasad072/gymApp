using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer
{
    public interface IAttendanceService
    {
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Attendance>> GetAll();
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Attendance> Get(Guid id);
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> Create(Attendance model);
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Update(Attendance model);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
        /// <summary>
        /// Get By User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<Attendance>> GetByUser(string userId);
        /// <summary>
        /// Get all checkins by Gym
        /// </summary>
        /// <param name="gymId"></param>
        /// <returns></returns>
        Task<IEnumerable<Attendance>> GetByGym(Guid gymId);
        /// <summary>
        /// Get all records of today
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<Attendance>> GetToday(string userId);
        /// <summary>
        /// Update checkout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Checkout(Guid id);
    }
}
