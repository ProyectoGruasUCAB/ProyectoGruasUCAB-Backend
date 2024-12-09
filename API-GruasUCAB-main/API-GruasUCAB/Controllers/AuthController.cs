using API_GruasUCAB.Auth.Application.Command.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Application.Command.RecoverPassword;
using API_GruasUCAB.Auth.Application.Command.ChangePassword;
using API_GruasUCAB.Auth.Application.Command.RefreshToken;
using API_GruasUCAB.Auth.Application.Command.AssignRole;
using API_GruasUCAB.Auth.Application.Command.CreateUser;
using API_GruasUCAB.Auth.Application.Command.DeleteUser;
using API_GruasUCAB.Auth.Application.Command.Logout;
using API_GruasUCAB.Auth.Application.Command.Login;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Login;
using API_GruasUCAB.Auth.Infrastructure.DTOs.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Infrastructure.DTOs.RecoverPassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs.ChangePassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs.RefreshToken;
using API_GruasUCAB.Auth.Infrastructure.DTOs.AssignRole;
using API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Logout;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;

namespace API_GruasUCAB.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(LoginResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetToken([FromBody] LoginRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new LoginCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            }, ModelState, _logger, "Login");
        }

        [HttpPost]
        [Route("RefreshToken")]
        [ProducesResponseType(typeof(RefreshTokenResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new RefreshTokenCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            }, ModelState, _logger, "RefreshToken");
        }

        [HttpPut]
        [Authorize]
        [Route("ChangePassword")]
        [ProducesResponseType(typeof(ChangePasswordResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new ChangePasswordCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            }, ModelState, _logger, "ChangePassword");
        }

        [HttpPost]
        [Route("HandleIncompleteAccount")]
        [ProducesResponseType(typeof(IncompleteAccountResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> HandleIncompleteAccount([FromBody] IncompleteAccountRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new HandleIncompleteAccountCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            }, ModelState, _logger, "HandleIncompleteAccount");
        }

        [HttpPost]
        [Route("RecoverPassword")]
        [ProducesResponseType(typeof(RecoverPasswordResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RecoverPassword([FromBody] RecoverPasswordRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new RecoverPasswordCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            }, ModelState, _logger, "RecoverPassword");
        }

        [HttpPost]
        [Authorize]
        [Route("CreateUser")]
        [ProducesResponseType(typeof(CreateUserResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new CreateUserCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            }, ModelState, _logger, "CreateUser");
        }

        [HttpPost]
        [Authorize]
        [Route("AssignRole")]
        [ProducesResponseType(typeof(AssignRoleResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new AssignRoleCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            }, ModelState, _logger, "AssignRole");
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteUser")]
        [ProducesResponseType(typeof(DeleteUserResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new DeleteUserCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            }, ModelState, _logger, "DeleteUser");
        }

        [HttpPost]
        [Authorize]
        [Route("Logout")]
        [ProducesResponseType(typeof(LogoutResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Logout([FromBody] LogoutRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new LogoutCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            }, ModelState, _logger, "Logout");
        }
    }
}
