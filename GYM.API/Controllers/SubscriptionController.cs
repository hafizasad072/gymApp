using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.SubscriptionService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly ILogger<SubscriptionController> _logger;

        public SubscriptionController(ISubscriptionService subscriptionService, ILogger<SubscriptionController> logger)
        {
            _subscriptionService = subscriptionService;
            _logger = logger;
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _subscriptionService.GetAll();
            return Ok(result.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _subscriptionService.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriptionDto dto)
        {
            var entity = new Subscription
            {
                MemberId = dto.MemberId,
                PlanId = dto.PlanId,
                StartDate = dto.StartDate
            };

            var id = await _subscriptionService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateSubscriptionDto dto)
        {
            if (id != dto.SubscriptionId) return BadRequest("Mismatched ids");

            var entity = new Subscription
            {
                SubscriptionId = dto.SubscriptionId,
                StatusId = dto.StatusId,
                EndDate = dto.EndDate
            };

            var updated = await _subscriptionService.Update(entity);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _subscriptionService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        #endregion

        #region Filter Helper

        [HttpGet("member/{memberId:guid}")]
        public async Task<IActionResult> GetByMember(Guid memberId)
        {
            var subs = await _subscriptionService.GetByMember(memberId);
            return Ok(subs.Select(ToDto));
        }

        [HttpGet("gym/{gymId:guid}")]
        public async Task<IActionResult> GetByGym(Guid gymId)
        {
            var subs = await _subscriptionService.GetByGym(gymId);
            return Ok(subs.Select(ToDto));
        }

        [HttpGet("gym/{gymId:guid}/active")]
        public async Task<IActionResult> GetActiveByGym(Guid gymId)
        {
            var subs = await _subscriptionService.GetActiveByGym(gymId);
            return Ok(subs.Select(ToDto));
        }

        [HttpGet("expired")]
        public async Task<IActionResult> GetExpired()
        {
            var subs = await _subscriptionService.GetExpired();
            return Ok(subs.Select(ToDto));
        }

        #endregion

        #region Actions

        [HttpPost("{id:guid}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var result = await _subscriptionService.Cancel(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPost("{id:guid}/renew")]
        public async Task<IActionResult> Renew(Guid id)
        {
            var result = await _subscriptionService.Renew(id);
            if (!result) return NotFound();
            return NoContent();
        }

        #endregion

        private static SubscriptionDto ToDto(Subscription s) => new SubscriptionDto
        {
            SubscriptionId = s.SubscriptionId,
            MemberId = s.MemberId,
            PlanId = s.PlanId,
            StartDate = s.StartDate,
            EndDate = s.EndDate.HasValue ? s.EndDate.Value : DateTime.MinValue,
            StatusId = s.StatusId
        };
    }
}
