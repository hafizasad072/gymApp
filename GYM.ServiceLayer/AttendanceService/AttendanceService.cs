using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer
{
    public class AttendanceService(IUnitOfWorkService _uow) : IAttendanceService
    {
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Attendance>> GetAll()
        {
            return await _uow.AttendanceRepository.GetAll();
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> Create(Attendance model)
        {
            model.Metadata = string.Empty;
            await _uow.AttendanceRepository.InsertAsync(model);
            _uow.Commit();

            return model.AttendanceId;
        }
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Attendance> Get(Guid id)
        {
            return await _uow.AttendanceRepository.GetAsync(x => x.AttendanceId == id);
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(Attendance model)
        {
            var entity = await _uow.AttendanceRepository.GetAsync(x => x.AttendanceId == model.AttendanceId);

            if (entity == null)
                return false;

            entity.CheckoutAt = model.CheckoutAt;
            entity.CheckinAt = model.CheckinAt;
            entity.SourceId = model.SourceId;
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
            var model = await _uow.AttendanceRepository.GetAsync(x => x.AttendanceId == id, null);
            if (model == null)
                return false;

            _uow.AttendanceRepository.Delete(model);
            _uow.Commit();
            return true;
        }
        /// <summary>
        /// Get By User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Attendance>> GetByUser(string userId)
        {
            return await _uow.AttendanceRepository.GetAllAsync(x => x.UserId == userId);
        }
        /// <summary>
        /// Get all checkins by Gym
        /// </summary>
        /// <param name="gymId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Attendance>> GetByGym(Guid gymId)
        {
            return await _uow.AttendanceRepository.GetAllAsync(x => x.GymId == gymId);
        }
        /// <summary>
        /// Get all records of today
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Attendance>> GetToday(string userId)
        {
            var today = DateTime.UtcNow.Date;
            return await _uow.AttendanceRepository.GetAllAsync(
                x => x.UserId == userId && x.CheckinAt.Date == today
            );
        }
        /// <summary>
        /// Update checkout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Checkout(Guid id)
        {
            var entity = await _uow.AttendanceRepository.GetAsync(x => x.AttendanceId == id);
            if (entity == null) return false;

            entity.CheckoutAt = DateTime.UtcNow;
            _uow.Commit();
            return true;
        }
    }
}
