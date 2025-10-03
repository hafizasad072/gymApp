using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.TrainerService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await _trainerService.GetAll();
            return Ok(trainers.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var trainer = await _trainerService.Get(id);
            if (trainer == null) return NotFound();
            return Ok(ToDto(trainer));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTrainerDto dto)
        {
            var entity = new Trainer
            {
                UserId = dto.UserId,
                GymId = dto.GymId,
                Bio = dto.Bio,
                IsAvailable = dto.IsAvailable,
                CreatedAt = DateTime.Now
            };

            var id = await _trainerService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateTrainerDto dto)
        {
            if (id != dto.TrainerId) return BadRequest("Mismatched ids");

            var entity = new Trainer
            {
                TrainerId = dto.TrainerId,
                Bio = dto.Bio,
                IsAvailable = dto.IsAvailable,
            };

            var updated = await _trainerService.Update(entity);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _trainerService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }


        [HttpGet("gym/{gymId:guid}")]
        public async Task<IActionResult> GetByGym(Guid gymId)
        {
            var trainers = await _trainerService.GetByGym(gymId);
            return Ok(trainers.Select(ToDto));
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(string userId)
        {
            var trainer = await _trainerService.GetByUser(userId);
            if (trainer == null) return NotFound();
            return Ok(ToDto(trainer));
        }

        private static TrainerDto ToDto(Trainer t) => new TrainerDto
        {
            TrainerId = t.TrainerId,
            UserId = t.UserId,
            GymId = t.GymId,
            Bio = t.Bio,
            IsAvailable = t.IsAvailable
        };
    }
}
