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

        [HttpGet]
        public async Task<object> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsers(cancellationToken);
            return Ok(users);
        }


    }
}
