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

        public AuthenticationController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost(template: "Login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IResult> Login(CancellationToken cancellationToken,[FromBody] UserInputDTO userInput)
        {

            var existingUser = await _userService.GetByEmailAsync(cancellationToken, userInput.Email);

            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(userInput.Password, existingUser.PasswordHash))
            {
                return Results.BadRequest("Email ou senha inválidos.");
            }

            var token = _tokenService.GenerateToken(existingUser);

            if (string.IsNullOrEmpty(token))
            {
                return Results.BadRequest("Erro ao gerar token.");
            }

            return Results.Ok(new { Token = token });
        }

        [AllowAnonymous]
        [HttpPost("Register", Name = "Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IResult> Register(CancellationToken cancellationToken,[FromBody] UserInputDTO userInput)
        {
            var existingUser = await _userService.GetByEmailAsync(cancellationToken,userInput.Email);

            if (existingUser != null)
            {
                return Results.Conflict("Email ja existe.");
            }


            var answerRegisteredUser = await _userService.RegisterUserAsync(cancellationToken, userInput);
            if (answerRegisteredUser.IsT0)
            {
                var location = Url.Action(nameof(Register), new { id = answerRegisteredUser.AsT0.Id });
                return Results.Created(location, answerRegisteredUser.AsT0);
            }
            else
            {
                return Results.Conflict(answerRegisteredUser.AsT1);
            }
            
        }

    }
}
