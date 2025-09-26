using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.MemberService;
using GYM.ServiceLayer.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace GYM.ServiceLayer.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly ILogger<AttendanceService> _logger;
        private IUnitOfWorkService _unitOfWork;

        public AttendanceService(ILogger<AttendanceService> logger, IUnitOfWorkService uow) { _logger = logger; _unitOfWork = uow; }

        public async Task<IEnumerable<AttendanceDto>> GetAllAsync()
        {
            var logs = await _unitOfWork.AttendanceRepository.GetAllAsync(a => true);
            return logs.Select(MapToDto);
        }

        public async Task<AttendanceDto> GetByIdAsync(long id)
        {
            var log = await _unitOfWork.AttendanceRepository.GetByIdAsync(id);
            return log == null ? null : MapToDto(log);
        }

        public async Task<IEnumerable<AttendanceDto>> GetByUserAsync(Guid userId)
        {
            var logs = await _unitOfWork.AttendanceRepository.GetAllAsync(a=>a.UserId == userId);
            return logs.Select(MapToDto);
        }

        public async Task<AttendanceDto> CheckInAsync(CreateAttendanceDto dto)
        {
            var attendance = new Attendance
            {
                GymId = dto.GymId,
                UserId = dto.UserId,
                AttendanceTypeId = dto.AttendanceTypeId,
                SourceId = dto.SourceId,
                CheckinAt = DateTime.UtcNow
            };

            await _unitOfWork.AttendanceRepository.InsertAsync(attendance);
            _unitOfWork.Commit();

            return MapToDto(attendance);
        }

        public async Task<bool> CheckOutAsync(long id, CheckOutAttendanceDto dto)
        {
            var attendance = await _unitOfWork.AttendanceRepository.GetByIdAsync(id);
            if (attendance == null || attendance.CheckoutAt != null)
                return false;

            attendance.CheckoutAt = dto.CheckoutAt;
            _unitOfWork.Commit();
            return true;
        }

        private AttendanceDto MapToDto(Attendance a)
        {
            return new AttendanceDto
            {
                AttendanceId = a.AttendanceId,
                GymId = a.GymId,
                UserId = a.UserId,
                AttendanceTypeId = a.AttendanceTypeId,
                SourceId = a.SourceId,
                CheckinAt = a.CheckinAt,
                CheckoutAt = a.CheckoutAt
            };
        }
    }
}
