using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.BO.ViewModels;

namespace GYM.ServiceLayer.AttendanceService
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDto>> GetAllAsync();
        Task<AttendanceDto> GetByIdAsync(long id);
        Task<IEnumerable<AttendanceDto>> GetByUserAsync(Guid userId);
        Task<AttendanceDto> CheckInAsync(CreateAttendanceDto dto);
        Task<bool> CheckOutAsync(long id, CheckOutAttendanceDto dto);
    }
}
