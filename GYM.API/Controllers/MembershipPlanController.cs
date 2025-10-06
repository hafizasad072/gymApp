using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.MembershipPlanService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipPlanController : ControllerBase
    {
        private readonly IMembershipPlanService _membershipPlanService;
        private readonly ILogger<MembershipPlanController> _logger;

        public MembershipPlanController(IMembershipPlanService membershipPlanService, ILogger<MembershipPlanController> logger)
        {
            _membershipPlanService = membershipPlanService;
            _logger = logger;
        }

        #region Membership Plan CRUD
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _membershipPlanService.GetAll();
            return Ok(result.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _membershipPlanService.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMembershipPlanDto dto)
        {
            var entity = new MembershipPlan
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                DurationDays = dto.DurationDays,
                BillingCycle = dto.BillingCycle,
                GymId = dto.GymId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            var id = await _membershipPlanService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateMembershipPlanDto dto)
        {
            if (id != dto.PlanId) return BadRequest("Mismatched ids");

            var entity = new MembershipPlan
            {
                PlanId = dto.PlanId,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                BillingCycle = dto.BillingCycle,
                DurationDays = dto.DurationDays,
                IsActive = dto.IsActive
            };

            var updated = await _membershipPlanService.Update(entity);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _membershipPlanService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        #endregion

        #region Helper Methods

        [HttpGet("gym/{gymId:guid}")]
        public async Task<IActionResult> GetByGym(Guid gymId)
        {
            var plans = await _membershipPlanService.GetByGym(gymId);
            return Ok(plans.Select(ToDto));
        }

        [HttpGet("gym/{gymId:guid}/active")]
        public async Task<IActionResult> GetActivePlans(Guid gymId)
        {
            var plans = await _membershipPlanService.GetActivePlans(gymId);
            return Ok(plans.Select(ToDto));
        }

        [HttpGet("duration-range")]
        public async Task<IActionResult> GetByDurationRange([FromQuery] int minDays, [FromQuery] int maxDays)
        {
            var plans = await _membershipPlanService.GetByDurationRange(minDays, maxDays);
            return Ok(plans.Select(ToDto));
        }

        #endregion

        private static MembershipPlanDto ToDto(MembershipPlan p) => new MembershipPlanDto
        {
            PlanId = p.PlanId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            DurationDays = p.DurationDays ?? 0,
            GymId = p.GymId,
            IsActive = p.IsActive,
            CreatedAt = p.CreatedAt
        };
    }
}
