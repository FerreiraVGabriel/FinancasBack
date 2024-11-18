using Api.Dtos.Input;
using AutoMapper;
using Infra.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthenticationController(ITokenService tokenService, IUserService userService, IMapper mapper)
        {
            _tokenService = tokenService;
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost(template: "Login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login(CancellationToken cancellationToken,[FromBody] UserInputDTO userInput)
        {

            var existingUser = await _userService.GetByEmailAsync(cancellationToken, userInput.Email);

            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(userInput.Password, existingUser.PasswordHash))
            {
                return Unauthorized();
            }

            var token = _tokenService.GenerateToken(existingUser);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }

        [AllowAnonymous]
        [HttpPost("Register", Name = "Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register(CancellationToken cancellationToken,[FromBody] UserInputDTO userInput)
        {
            var existingUser = await _userService.GetByEmailAsync(cancellationToken,userInput.Email);

            if (existingUser != null)
            {
                return Conflict("Email ja existe.");
            }

            User user = _mapper.Map<UserInputDTO, User>(userInput);

            var registeredUser = await _userService.RegisterUserAsync(cancellationToken,user, userInput.Password);

            return CreatedAtAction(nameof(Register), new { id = registeredUser.Id }, registeredUser);
        }

    }
}
