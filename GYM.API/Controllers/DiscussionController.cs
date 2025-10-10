using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.DiscussionService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscussionController : ControllerBase
    {
        private readonly IDiscussionService _discussionService;

        public DiscussionController(IDiscussionService discussionService)
        {
            _discussionService = discussionService;
        }

        // ------------------- Discussions -------------------

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _discussionService.GetAll();
            return Ok(result.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _discussionService.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscussionDto dto)
        {
            var entity = new Discussion
            {
                GymId = dto.GymId,
                CreatedByUserId = dto.CreatedByUserId,
                Title = dto.Title,
                Body = dto.Body,
                CreatedAt = DateTime.Now,
                IsFranchiseWide = dto.IsFranchiseWide
            };

            var id = await _discussionService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateDiscussionDto dto)
        {
            if (id != dto.DiscussionId) return BadRequest("Mismatched ids");

            var entity = new Discussion
            {
                DiscussionId = dto.DiscussionId,
                Title = dto.Title,
                Body = dto.Body,
                IsFranchiseWide = dto.IsFranchiseWide
            };

            var updated = await _discussionService.Update(entity);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _discussionService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // ------------------- Filters -------------------

        [HttpGet("gym/{gymId:guid}")]
        public async Task<IActionResult> GetByGym(Guid gymId)
        {
            var result = await _discussionService.GetByGym(gymId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(string userId)
        {
            var result = await _discussionService.GetByUser(userId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("gym/{gymId:guid}/active")]
        public async Task<IActionResult> GetActive(Guid gymId)
        {
            var result = await _discussionService.GetActive(gymId);
            return Ok(result.Select(ToDto));
        }

        // ------------------- Messages -------------------

        [HttpGet("{discussionId:guid}/messages")]
        public async Task<IActionResult> GetMessages(Guid discussionId)
        {
            var messages = await _discussionService.GetMessages(discussionId);
            return Ok(messages.Select(m => new DiscussionMessageDto
            {
                MessageId = m.MessageId,
                DiscussionId = m.DiscussionId,
                FromUserId = m.FromUserId,
                Message = m.Message,
                CreatedAt = m.CreatedAt
            }));
        }

        [HttpPost("{discussionId:guid}/messages")]
        public async Task<IActionResult> AddMessage(Guid discussionId, CreateDiscussionMessageDto dto)
        {
            var entity = new DiscussionMessage
            {
                DiscussionId = discussionId,
                FromUserId = dto.UserId,
                Message = dto.Message
            };

            var id = await _discussionService.AddMessage(entity);
            return CreatedAtAction(nameof(GetMessages), new { discussionId }, id);
        }

        // ------------------- Helper -------------------

        private static DiscussionDto ToDto(Discussion d) => new DiscussionDto
        {
            DiscussionId = d.DiscussionId,
            GymId = d.GymId.Value,
            CreatedByUserId = d.CreatedByUserId,
            Title = d.Title,
            Body = d.Body,
            CreatedAt = d.CreatedAt,
            IsFranchiseWide = d.IsFranchiseWide
        };
    }
}
