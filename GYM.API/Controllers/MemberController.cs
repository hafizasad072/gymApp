using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.MemberService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _memberService.GetAll();
            return Ok(result.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _memberService.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberDto dto)
        {
            var entity = new Member
            {
                UserId = dto.UserId,
                GymId = dto.GymId,
                LeagueId = dto.LeagueId,
                JoinDate = DateTime.UtcNow,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                CreatedAt = DateTime.Now
            };

            var id = await _memberService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateMemberDto dto)
        {
            if (id != dto.MemberId) return BadRequest("Mismatched ids");

            var entity = new Member
            {
                MemberId = dto.MemberId,
                LeagueId = dto.LeagueId,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender
            };

            var updated = await _memberService.Update(entity);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _memberService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("gym/{gymId:guid}")]
        public async Task<IActionResult> GetByGym(Guid gymId)
        {
            var result = await _memberService.GetByGym(gymId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("league/{leagueId:int}")]
        public async Task<IActionResult> GetByLeague(int leagueId)
        {
            var result = await _memberService.GetByLeague(leagueId);
            return Ok(result.Select(ToDto));
        }

        private static MemberDto ToDto(Member m) => new MemberDto
        {
            MemberId = m.MemberId,
            UserId = m.UserId,
            GymId = m.GymId,
            LeagueId = m.LeagueId,
            JoinDate = m.JoinDate,
            DateOfBirth = m.DateOfBirth.Value,
            Gender = m.Gender,
        };
    }
}
