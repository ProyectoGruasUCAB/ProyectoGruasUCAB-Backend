using API_GruasUCAB.Auth.Application.Command.Login;
using API_GruasUCAB.Auth.Application.Command.CreateUser;
using API_GruasUCAB.Auth.Application.Command.AssignRole;
using API_GruasUCAB.Auth.Application.Command.DeleteUser;
using API_GruasUCAB.Auth.Application.Command.Logout;
using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
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
                return Ok(authResponse);
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
                var result = await _mediator.Send(command);

                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
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
                var response = await _mediator.Send(command);

                if (response.Success)
                {
                    return Ok(response.Message);
                }
                return BadRequest(response.Message);
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
            var command = new DeleteUserCommand(request);
            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
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
                var command = new LogoutCommand(request.RefreshToken);
                var result = await _mediator.Send(command);
                return Ok(result);
            });
        }
    }
}