using Api.Dtos.Output;
using Api.UtilApi;
using AutoMapper;
using Infra.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Services.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public async Task<object> GetAllUsers(CancellationToken cancellationToken)
        {
            int userId = Util.GetUserIdFromToken(HttpContext);
            IEnumerable<User> users = await _userService.GetAllUsersAsync(cancellationToken);
            var usersOutputDTO = _mapper.Map<IEnumerable<UserOutputDTO>>(users);
            return Ok(usersOutputDTO);
        }

        [HttpGet("ByEmail")]
        public async Task<object> GetByEmail(CancellationToken cancellationToken,string userName)
        {
            var user = await _userService.GetByEmailAsync(cancellationToken, userName);
            return Ok(user);
        }

    }
}
