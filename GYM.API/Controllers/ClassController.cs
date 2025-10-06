using GYM.BO.Enums;
using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.ClassBookingService;
using GYM.ServiceLayer.ClassScheduleService;
using GYM.ServiceLayer.ClassService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IClassBookingService _classBookingService;
        private readonly IClassScheduleService _classScheduleService;
        private readonly ILogger<ClassController> _logger;

        public ClassController(IClassService classService, ILogger<ClassController> logger, IClassBookingService classBookingService, IClassScheduleService classScheduleService)
        {
            _classService = classService;
            _logger = logger;
            _classBookingService = classBookingService;
            _classScheduleService = classScheduleService;
        }

        #region Classes

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _classService.GetAll();
            return Ok(result.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _classService.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClassDto dto)
        {
            var entity = new Class
            {
                Title = dto.Title,
                Description = dto.Description,
                Capacity = dto.Capacity,
                GymId = dto.GymId,
                TrainerId = dto.TrainerId,
                CreatedAt = DateTime.UtcNow
            };

            var id = await _classService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateClassDto dto)
        {
            if (id != dto.ClassId) return BadRequest("Mismatched ids");

            var entity = new Class
            {
                ClassId = dto.ClassId,
                Title = dto.Title,
                Description = dto.Description,
                Capacity = dto.Capacity
            };

            var updated = await _classService.Update(entity);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _classService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        #endregion

        #region Filters

        [HttpGet("gym/{gymId:guid}")]
        public async Task<IActionResult> GetByGym(Guid gymId)
        {
            var result = await _classService.GetByGym(gymId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("trainer/{trainerId:guid}")]
        public async Task<IActionResult> GetByTrainer(Guid trainerId)
        {
            var result = await _classService.GetByTrainer(trainerId);
            return Ok(result.Select(ToDto));
        }

        #endregion

        #region Schedules

        [HttpGet("{classId:guid}/schedules")]
        public async Task<IActionResult> GetSchedules(Guid classId)
        {
            var schedules = await _classScheduleService.GetSchedules(classId);
            return Ok(schedules.Select(s => new ClassScheduleDto
            {
                ClassScheduleId = s.ClassScheduleId,
                ClassId = s.ClassId,
                StartTime = s.StartAt,
                EndTime = s.EndAt,
                Location = s.Location
            }));
        }

        [HttpPost("{classId:guid}/schedules")]
        public async Task<IActionResult> AddSchedule(Guid classId, CreateClassScheduleDto dto)
        {
            var entity = new ClassSchedule
            {
                ClassId = classId,
                StartAt = dto.StartTime,
                EndAt = dto.EndTime,
                Location = dto.Location
            };

            var id = await _classScheduleService.AddSchedule(entity);
            return CreatedAtAction(nameof(GetSchedules), new { classId }, id);
        }

        [HttpDelete("schedules/{scheduleId:guid}")]
        public async Task<IActionResult> RemoveSchedule(Guid scheduleId)
        {
            var removed = await _classScheduleService.RemoveSchedule(scheduleId);
            if (!removed) return NotFound();
            return NoContent();
        }

        #endregion

        #region Bookings

        [HttpGet("schedules/{scheduleId:guid}/bookings")]
        public async Task<IActionResult> GetBookings(Guid scheduleId)
        {
            var result = await _classBookingService.GetBookings(scheduleId);
            return Ok(result.Select(b => new ClassBookingDto
            {
                ClassBookingId = b.ClassBookingId,
                ClassScheduleId = b.ClassScheduleId,
                MemberId = b.MemberId,
                StatusId = b.StatusId,
                BookedAt = b.BookedAt
            }));
        }

        [HttpPost("schedules/{scheduleId:guid}/bookings")]
        public async Task<IActionResult> CreateBooking(Guid scheduleId, CreateClassBookingDto dto)
        {
            var booking = new ClassBooking
            {
                ClassScheduleId = scheduleId,
                MemberId = dto.MemberId,
                StatusId = (int)BookingStatus.Booked,
                BookedAt = DateTime.UtcNow
            };

            var id = await _classBookingService.CreateBooking(booking);
            return CreatedAtAction(nameof(GetBookings), new { scheduleId }, id);
        }

        [HttpPut("bookings/{bookingId:guid}/cancel")]
        public async Task<IActionResult> CancelBooking(Guid bookingId)
        {
            var canceled = await _classBookingService.CancelBooking(bookingId);
            if (!canceled) return NotFound();
            return NoContent();
        }

        #endregion

        #region Helper
        private static ClassDto ToDto(Class c) => new ClassDto
        {
            ClassId = c.ClassId,
            Title = c.Title,
            Description = c.Description,
            Capacity = c.Capacity,
            GymId = c.GymId,
            TrainerId = c.TrainerId,
            CreatedAt = c.CreatedAt
        };
        #endregion
    }
}
