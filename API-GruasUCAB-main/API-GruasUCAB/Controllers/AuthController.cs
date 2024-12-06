using API_GruasUCAB.Auth.Application.Command.Login;
using API_GruasUCAB.Auth.Application.Command.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Application.Command.ChangePassword;
using API_GruasUCAB.Auth.Application.Command.RecoverPassword;
using API_GruasUCAB.Auth.Application.Command.CreateUser;
using API_GruasUCAB.Auth.Application.Command.AssignRole;
using API_GruasUCAB.Auth.Application.Command.DeleteUser;
using API_GruasUCAB.Auth.Application.Command.Logout;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Login;
using API_GruasUCAB.Auth.Infrastructure.DTOs.HandleIncompleteAccount;
using API_GruasUCAB.Auth.Infrastructure.DTOs.ChangePassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.AssignRole;
using API_GruasUCAB.Auth.Infrastructure.DTOs.RecoverPassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Logout;
using API_GruasUCAB.Commons.Exceptions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace API_GruasUCAB.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private async Task<IActionResult> ExecuteAction(Func<Task<IActionResult>> action)
        {
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(new { Errors = errors });
            }
            try
            {
                return await action();
            }
            catch (UnauthorizedException ex)
            {
                return Unauthorized(new { ex.Message, ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(LoginResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetToken([FromBody] LoginRequestDTO request)
        {
            return await ExecuteAction(async () =>
            {
                var command = new LoginCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            });
        }

        [HttpPost]
        [Route("HandleIncompleteAccount")]
        [ProducesResponseType(typeof(IncompleteAccountResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> HandleIncompleteAccount([FromBody] IncompleteAccountRequestDTO request)
        {
            return await ExecuteAction(async () =>
            {
                var command = new HandleIncompleteAccountCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            });
        }

        [HttpPut]
        [Route("ChangePassword")]
        [ProducesResponseType(typeof(ChangePasswordResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDTO request)
        {
            return await ExecuteAction(async () =>
            {
                var command = new ChangePasswordCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            });
        }

        [HttpPost]
        [Route("RecoverPassword")]
        [ProducesResponseType(typeof(RecoverPasswordResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RecoverPassword([FromBody] RecoverPasswordRequestDTO request)
        {
            return await ExecuteAction(async () =>
            {
                var command = new RecoverPasswordCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            });
        }

        [HttpPost]
        [Route("CreateUser")]
        [ProducesResponseType(typeof(CreateUserResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDTO request)
        {
            return await ExecuteAction(async () =>
            {
                var command = new CreateUserCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            });
        }

        [HttpPost]
        [Route("AssignRole")]
        [ProducesResponseType(typeof(AssignRoleResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequestDTO request)
        {
            return await ExecuteAction(async () =>
            {
                var command = new AssignRoleCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            });
        }

        [HttpDelete]
        [Route("DeleteUser")]
        [ProducesResponseType(typeof(DeleteUserResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequestDTO request)
        {
            return await ExecuteAction(async () =>
            {
                var command = new DeleteUserCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            });
        }

        [HttpPost]
        [Route("Logout")]
        [ProducesResponseType(typeof(LogoutResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Logout([FromBody] LogoutRequestDTO request)
        {
            return await ExecuteAction(async () =>
            {
                var command = new LogoutCommand(request);
                var authResponse = await _mediator.Send(command);
                if (authResponse.Success)
                {
                    return Ok(authResponse);
                }
                return BadRequest(authResponse.Message);
            });
        }
    }
}
