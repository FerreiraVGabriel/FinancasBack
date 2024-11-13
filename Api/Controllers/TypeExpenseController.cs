using Api.Dtos.Input;
using Infra.Entities.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Security.Claims;
using Api.UtilApi;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeExpenseController : ControllerBase
    {
        public TypeExpenseController()
        {
        }

        [Authorize]
        [HttpGet]
        public async Task<object> GetAllTypeExpensive(CancellationToken cancellationToken)
        {
            var userIdFromToken = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return null;
        }

        [Authorize]
        [HttpGet("Pagination")]
        public async Task<object> Pagination([FromQuery] SearchParams searchParams, CancellationToken cancellationToken)
        {
            int userId = Util.GetUserIdFromToken(HttpContext);
            return null;
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<object> Create(CancellationToken cancellationToken, TypeExpenseInputDTO typeExpenseInputDTO)
        //{

        //}

    }
}
