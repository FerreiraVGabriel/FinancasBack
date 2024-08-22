using Infra.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<object> GetAllUsers(CancellationToken cancellationToken)
        {

            var users = await _userService.GetAllUsersAsync(cancellationToken);
            return Ok(users);
        }

        [HttpGet("GetByEmail")]
        public async Task<object> GetByEmail(CancellationToken cancellationToken,string userName)
        {
            var user = await _userService.GetByEmailAsync(cancellationToken, userName);
            return Ok(user);
        }

    }
}
