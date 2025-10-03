using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Accessible by any authenticated user
        [HttpGet("user")]
        [Authorize]
        public IActionResult GetForUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.Identity?.Name;

            return Ok(new
            {
                Message = "Hello, authenticated user!",
                UserId = userId,
                UserName = userName
            });
        }

        // Role-based authorization
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetForAdmin()
        {
            return Ok("Hello Admin! You have access to this endpoint.");
        }

        // Claim-based authorization
        [HttpGet("special")]
        [Authorize(Policy = "SpecialAccess")]
        public IActionResult GetForSpecialClaim()
        {
            return Ok("You have the special claim required to access this.");
        }

        // Manual claim/role check (alternative way)
        [HttpGet("check")]
        [Authorize]
        public IActionResult CheckUserRights()
        {
            bool isAdmin = User.IsInRole("Admin");
            bool hasSpecialClaim = User.HasClaim("Permission", "SpecialAccess");

            return Ok(new
            {
                IsAdmin = isAdmin,
                HasSpecialClaim = hasSpecialClaim
            });
        }
    }
}
