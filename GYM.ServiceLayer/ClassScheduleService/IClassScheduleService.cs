using GYM.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.ServiceLayer.ClassScheduleService
{
    public interface IClassScheduleService
    {
        Task<IEnumerable<ClassSchedule>> GetSchedules(Guid classId);
        Task<Guid> AddSchedule(ClassSchedule schedule);
        Task<bool> RemoveSchedule(Guid scheduleId);
    }
}
