using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeExpensiveController : ControllerBase
    {
        public TypeExpensiveController()
        {
        }

        [Authorize]
        [HttpGet("GetAllTypeExpensive")]
        public async Task<object> GetAllTypeExpensive(CancellationToken cancellationToken)
        {
            var userIdFromToken = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return null;
        }

    }
}
