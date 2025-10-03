using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;
    private readonly ILogger<AttendanceController> _logger;

    public AttendanceController(IAttendanceService attendanceService, ILogger<AttendanceController> logger)
    {
        _attendanceService = attendanceService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _attendanceService.GetAll();
            return Ok(result.Select(ToDto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving attendances");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var entity = await _attendanceService.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving attendance {id}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAttendanceDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var entity = new Attendance
            {
                AttendanceId = Guid.NewGuid(),
                UserId = dto.UserId,
                GymId = dto.GymId,
                CheckinAt = dto.CheckinAt,
                SourceId = dto.SourceId,
                AttendanceTypeId = dto.AttendanceTypeId
            };

            var id = await _attendanceService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating attendance");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAttendanceDto dto)
    {
        if (id != dto.AttendanceId) return BadRequest("Mismatched Ids");

        try
        {
            var entity = new Attendance
            {
                AttendanceId = dto.AttendanceId,
                CheckinAt = dto.CheckinAt,
                CheckoutAt = dto.CheckoutAt,
                SourceId = dto.SourceId
            };

            var updated = await _attendanceService.Update(entity);
            if (!updated) return NotFound();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error updating attendance {id}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var deleted = await _attendanceService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error deleting attendance {id}");
            return StatusCode(500, "Internal server error");
        }
    }


    /// <summary>
    /// Get all attendance for a user
    /// </summary>
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(string userId)
    {
        try
        {
            var result = await _attendanceService.GetAll();
            var filtered = result.Where(x => x.UserId == userId);
            return Ok(filtered.Select(ToDto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving attendance for user {userId}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get all attendance for a gym
    /// </summary>
    [HttpGet("gym/{gymId:guid}")]
    public async Task<IActionResult> GetByGym(Guid gymId)
    {
        try
        {
            var result = await _attendanceService.GetAll();
            var filtered = result.Where(x => x.GymId == gymId);
            return Ok(filtered.Select(ToDto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving attendance for gym {gymId}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get today’s attendance for a user
    /// </summary>
    [HttpGet("today/{userId}")]
    public async Task<IActionResult> GetToday(string userId)
    {
        try
        {
            var result = await _attendanceService.GetAll();
            var today = result
                .Where(x => x.UserId == userId && x.CheckinAt.Date == DateTime.UtcNow.Date);
            return Ok(today.Select(ToDto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving today's attendance for user {userId}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Mark checkout time for an attendance record
    /// </summary>
    [HttpPut("{id:guid}/checkout")]
    public async Task<IActionResult> Checkout(Guid id)
    {
        try
        {
            var entity = await _attendanceService.Get(id);
            if (entity == null) return NotFound();

            entity.CheckoutAt = DateTime.UtcNow;
            var updated = await _attendanceService.Update(entity);

            if (!updated) return BadRequest("Unable to checkout");
            return Ok(ToDto(entity));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error checking out attendance {id}");
            return StatusCode(500, "Internal server error");
        }
    }

    private static AttendanceDto ToDto(Attendance x) => new AttendanceDto
    {
        AttendanceId = x.AttendanceId,
        UserId = x.UserId,
        GymId = x.GymId,
        CheckinAt = x.CheckinAt,
        CheckoutAt = x.CheckoutAt,
        SourceId = x.SourceId,
        AttendanceTypeId = x.AttendanceTypeId
    };
}
