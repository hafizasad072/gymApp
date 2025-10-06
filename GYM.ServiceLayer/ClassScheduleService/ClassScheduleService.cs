using GYM.EF.Models;
using GYM.ServiceLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.ClassScheduleService
{
    public class ClassScheduleService : IClassScheduleService
    {
        private readonly IUnitOfWorkService _uow;

        public ClassScheduleService(IUnitOfWorkService uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ClassSchedule>> GetSchedules(Guid classId) =>
            await _uow.ClassScheduleRepository.GetAllAsync(x => x.ClassId == classId);

        public async Task<Guid> AddSchedule(ClassSchedule schedule)
        {
            schedule.ClassScheduleId = Guid.NewGuid();
            await _uow.ClassScheduleRepository.InsertAsync(schedule);
            _uow.Commit();
            return schedule.ClassScheduleId;
        }

        public async Task<bool> RemoveSchedule(Guid scheduleId)
        {
            var entity = await _uow.ClassScheduleRepository.GetAsync(x => x.ClassScheduleId == scheduleId);
            if (entity == null) return false;
            _uow.ClassScheduleRepository.Delete(entity);
            _uow.Commit();
            return true;
        }
    }
}
