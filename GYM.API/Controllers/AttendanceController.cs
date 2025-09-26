using GYM.BO.ViewModels;
using GYM.ServiceLayer.AttendanceService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _attendanceService.GetAllAsync();
            return Ok(logs);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var log = await _attendanceService.GetByIdAsync(id);
            if (log == null) return NotFound();
            return Ok(log);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
            var logs = await _attendanceService.GetByUserAsync(userId);
            return Ok(logs);
        }

        [HttpPost("check-in")]
        public async Task<IActionResult> CheckIn([FromBody] CreateAttendanceDto dto)
        {
            var result = await _attendanceService.CheckInAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.AttendanceId }, result);
        }

        [HttpPost("check-out/{id:long}")]
        public async Task<IActionResult> CheckOut(long id, [FromBody] CheckOutAttendanceDto dto)
        {
            var success = await _attendanceService.CheckOutAsync(id, dto);
            if (!success) return BadRequest("Invalid or already checked-out entry.");
            return NoContent();
        }
    }
}
