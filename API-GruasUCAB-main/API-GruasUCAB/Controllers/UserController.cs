using API_GruasUCAB.Users.Application.Commands.RecordUserData;
using API_GruasUCAB.Users.Application.Commands.UpdateUser;
using API_GruasUCAB.Users.Application.Queries.GetAllAdministrators;
using API_GruasUCAB.Users.Application.Queries.GetAdministratorById;
using API_GruasUCAB.Users.Application.Queries.GetAdministratorsByName;
using API_GruasUCAB.Users.Application.Queries.GetAllDrivers;
using API_GruasUCAB.Users.Application.Queries.GetDriverById;
using API_GruasUCAB.Users.Application.Queries.GetDriversByName;
using API_GruasUCAB.Users.Infrastructure.DTOs.RecordUserData;
using API_GruasUCAB.Users.Infrastructure.DTOs.UpdateUser;
using API_GruasUCAB.Users.Infrastructure.DTOs.AdministratorQueries;
using API_GruasUCAB.Users.Infrastructure.DTOs.DriverQueries;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;

namespace API_GruasUCAB.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class UserController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly ILogger<UserController> _logger;

          public UserController(IMediator mediator, ILogger<UserController> logger)
          {
               _mediator = mediator;
               _logger = logger;
          }

          private Guid GetUserId()
          {
               var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
               if (string.IsNullOrEmpty(userId))
               {
                    throw new UnauthorizedAccessException("User ID is missing from the token.");
               }
               return Guid.Parse(userId);
          }

          [HttpGet]
          [Authorize]
          [Route("GetAllAdministrators")]
          [ProducesResponseType(typeof(GetAllAdministratorsResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAllAdministrators()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetAllAdministratorsQuery(userId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAllAdministrators");
          }

          [HttpGet]
          [Authorize]
          [Route("GetAdministratorById/{id}")]
          [ProducesResponseType(typeof(GetAdministratorByIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAdministratorById(Guid id)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetAdministratorByIdQuery(userId, id);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAdministratorById");
          }

          [HttpGet]
          [Authorize]
          [Route("GetAdministratorsByName/{name}")]
          [ProducesResponseType(typeof(GetAdministratorsByNameResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAdministratorsByName(string name)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetAdministratorsByNameQuery(userId, name);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAdministratorsByName");
          }

          [HttpGet]
          [Authorize]
          [Route("GetAllDrivers")]
          [ProducesResponseType(typeof(GetAllDriversResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAllDrivers()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetAllDriversQuery(userId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAllDrivers");
          }

          [HttpGet]
          [Authorize]
          [Route("GetDriverById/{id}")]
          [ProducesResponseType(typeof(GetDriverByIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetDriverById(Guid id)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetDriverByIdQuery(userId, id);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetDriverById");
          }

          [HttpGet]
          [Authorize]
          [Route("GetDriversByName/{name}")]
          [ProducesResponseType(typeof(GetDriversByNameResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetDriversByName(string name)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetDriversByNameQuery(userId, name);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetDriversByName");
          }

          [HttpPost]
          [Authorize]
          [Route("RecordUserData")]
          [ProducesResponseType(typeof(RecordUserDataResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> CreateUser([FromBody] RecordUserDataRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new RecordUserDataCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "RecordUserData");
          }

          [HttpPut]
          [Authorize]
          [Route("UpdateUserData")]
          [ProducesResponseType(typeof(UpdateRecordUserDataResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> UpdateUser([FromBody] UpdateRecordUserDataRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new UpdateRecordUserDataCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "UpdateUserData");
          }
     }
}