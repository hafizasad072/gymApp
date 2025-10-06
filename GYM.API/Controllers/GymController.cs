using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.GymService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymController : ControllerBase
    {
        private readonly IGymService _gymService;

        public GymController(IGymService gymService)
        {
            _gymService = gymService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gyms = await _gymService.GetAll();
            return Ok(gyms.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var gym = await _gymService.Get(id);
            if (gym == null) return NotFound();
            return Ok(ToDto(gym));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGymDto dto)
        {
            var entity = new Gym
            {
                Name = dto.Name,
                Timezone = dto.Timezone,
                OwnerUserId = dto.OwnerUserId,
                CreatedAt = DateTime.UtcNow
            };

            var id = await _gymService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateGymDto dto)
        {
            if (id != dto.GymId) return BadRequest("Mismatched ids");

            var entity = new Gym
            {
                GymId = dto.GymId,
                Name = dto.Name,
                Timezone = dto.Timezone
            };

            var updated = await _gymService.Update(entity);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _gymService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // -----------------------------
        // EXTRA ENDPOINTS
        // -----------------------------

        /// <summary>
        /// Get gyms owned by a specific user
        /// </summary>
        [HttpGet("owner/{ownerUserId}")]
        public async Task<IActionResult> GetByOwner(string ownerUserId)
        {
            var gyms = await _gymService.GetByOwner(ownerUserId);
            return Ok(gyms.Select(ToDto));
        }

        /// <summary>
        /// Get members of a gym
        /// </summary>
        [HttpGet("{gymId:guid}/members")]
        public async Task<IActionResult> GetMembers(Guid gymId)
        {
            var members = await _gymService.GetMembers(gymId);
            return Ok(members.Select(m => new
            {
                m.MemberId,
                m.UserId,
                m.GymId,
                m.LeagueId,
                m.JoinDate,
                m.DateOfBirth.Value,
                m.Gender
            }));
        }

        /// <summary>
        /// Get trainers of a gym
        /// </summary>
        [HttpGet("{gymId:guid}/trainers")]
        public async Task<IActionResult> GetTrainers(Guid gymId)
        {
            var trainers = await _gymService.GetTrainers(gymId);
            return Ok(trainers.Select(t => new
            {
                t.TrainerId,
                t.UserId,
                t.GymId,
                t.Bio,
                t.IsAvailable
            }));
        }

        private static GymDto ToDto(Gym g) => new GymDto
        {
            GymId = g.GymId,
            Name = g.Name,
            Timezone = g.Timezone,
            OwnerUserId = g.OwnerUserId,
            CreatedAt = g.CreatedAt
        };
    }
}
