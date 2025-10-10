using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.ExerciseService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly ILogger<ExerciseController> _logger;

        public ExerciseController(IExerciseService exerciseService, ILogger<ExerciseController> logger)
        {
            _exerciseService = exerciseService;
            _logger = logger;
        }

        // ------------------- CRUD -------------------

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _exerciseService.GetAll();
            return Ok(result.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _exerciseService.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseDto dto)
        {
            var entity = new Exercise
            {
                GymId = dto.GymId,
                Name = dto.Name,
                Description = dto.Description,
                MuscleGroupId = dto.MuscleGroupId,
                Equipment = dto.Equipment,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            var id = await _exerciseService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateExerciseDto dto)
        {
            if (id != dto.ExerciseId) return BadRequest("Mismatched IDs");

            var entity = new Exercise
            {
                ExerciseId = dto.ExerciseId,
                Name = dto.Name,
                Description = dto.Description,
                MuscleGroupId = dto.MuscleGroupId,
                Equipment = dto.Equipment,
                IsActive = dto.IsActive
            };

            var updated = await _exerciseService.Update(entity);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _exerciseService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // ------------------- Filters -------------------

        [HttpGet("gym/{gymId:guid}")]
        public async Task<IActionResult> GetByGym(Guid gymId)
        {
            var result = await _exerciseService.GetByGym(gymId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("gym/{gymId:guid}/active")]
        public async Task<IActionResult> GetActiveByGym(Guid gymId)
        {
            var result = await _exerciseService.GetActiveByGym(gymId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("gym/{gymId:guid}/muscle/{muscleGroupId:int}")]
        public async Task<IActionResult> GetByMuscleGroup(Guid gymId, int muscleGroupId)
        {
            var result = await _exerciseService.GetByMuscleGroup(gymId, muscleGroupId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("gym/{gymId:guid}/equipment")]
        public async Task<IActionResult> GetByEquipment(Guid gymId, [FromQuery] string equipment)
        {
            var result = await _exerciseService.GetByEquipment(gymId, equipment);
            return Ok(result.Select(ToDto));
        }

        // ------------------- Toggle -------------------

        [HttpPost("{id:guid}/toggle")]
        public async Task<IActionResult> ToggleActive(Guid id, [FromQuery] bool isActive)
        {
            var result = await _exerciseService.ToggleActive(id, isActive);
            if (!result) return NotFound();
            return NoContent();
        }

        // ------------------- Helper -------------------

        private static ExerciseDto ToDto(Exercise e) => new ExerciseDto
        {
            ExerciseId = e.ExerciseId,
            GymId = e.GymId,
            Name = e.Name,
            Description = e.Description,
            MuscleGroupId = e.MuscleGroupId,
            Equipment = e.Equipment,
            IsActive = e.IsActive,
            CreatedAt = e.CreatedAt
        };
    }
}
