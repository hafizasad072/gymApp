using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.MemberService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly IMemberService _memberService;

        public MembersController(ILogger<MembersController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> GetMembers()
        {
            try
            {
                var members = await _memberService.GetAllMembers();
                return Ok(members);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching members");
                return StatusCode(500, "Internal server error while fetching members");
            }
        }

        [HttpPost("quick-register")]
        public async Task<IActionResult> QuickRegister([FromBody] QuickRegisterRequest req)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid quick-register request: {@ModelState}", ModelState);
                return BadRequest(ModelState);
            }

            try
            {
                var (userId, memberId) = await _memberService.QuickRegisterAsync(req.GymId, req.Email, req.Phone, req.DisplayName, req.InvitedByUserId);
                var response = new QuickRegisterResponse(userId, memberId);
                return CreatedAtAction(nameof(GetMember), new { id = memberId }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to quick register member for email {Email}", req.Email);
                throw; // middleware will translate to 500
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMember([FromRoute] Guid id)
        {
            var member = await _memberService.GetMember(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMember(Guid id)
        {
            try
            {
                var member = await _memberService.GetMember(id);
                if (member == null)
                {
                    _logger.LogWarning("Member {MemberId} not found for deletion", id);
                    return NotFound(new { message = $"Member with ID {id} not found" });
                }

                await _memberService.DeleteMember(id);

                _logger.LogInformation("Member {MemberId} deleted successfully", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting member {MemberId}", id);
                return StatusCode(500, "Internal server error while deleting member");
            }
        }
    }
}
