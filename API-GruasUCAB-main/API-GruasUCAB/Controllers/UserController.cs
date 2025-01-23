using API_GruasUCAB.Users.Application.Commands.RecordUserData;
using API_GruasUCAB.Users.Application.Commands.UpdateUser;
using API_GruasUCAB.Users.Application.Queries.GetAllAdministrators;
using API_GruasUCAB.Users.Application.Queries.GetAdministratorById;
using API_GruasUCAB.Users.Application.Queries.GetAdministratorsByName;
using API_GruasUCAB.Users.Application.Queries.GetAllDrivers;
using API_GruasUCAB.Users.Application.Queries.GetDriverById;
using API_GruasUCAB.Users.Application.Queries.GetDriversByName;
using API_GruasUCAB.Users.Application.Queries.GetDriversBySupplierId;
using API_GruasUCAB.Users.Application.Queries.GetAllWorkers;
using API_GruasUCAB.Users.Application.Queries.GetWorkerById;
using API_GruasUCAB.Users.Application.Queries.GetWorkersByName;
using API_GruasUCAB.Users.Application.Queries.GetWorkersByPosition;
using API_GruasUCAB.Users.Application.Queries.GetAllProviders;
using API_GruasUCAB.Users.Application.Queries.GetProviderById;
using API_GruasUCAB.Users.Application.Queries.GetProvidersByName;
using API_GruasUCAB.Users.Infrastructure.DTOs.RecordUserData;
using API_GruasUCAB.Users.Infrastructure.DTOs.UpdateUser;
using API_GruasUCAB.Users.Infrastructure.DTOs.AdministratorQueries;
using API_GruasUCAB.Users.Infrastructure.DTOs.DriverQueries;
using API_GruasUCAB.Users.Infrastructure.DTOs.WorkerQueries;
using API_GruasUCAB.Users.Infrastructure.DTOs.ProviderQueries;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Claims;

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

          [HttpGet]
          [Authorize]
          [Route("GetDriversBySupplierId/{supplierId}")]
          [ProducesResponseType(typeof(GetDriversBySupplierIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetDriversBySupplierId(Guid supplierId)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetDriversBySupplierIdQuery(supplierId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetDriversBySupplierId");
          }

          [HttpGet]
          [Authorize]
          [Route("GetAllWorkers")]
          [ProducesResponseType(typeof(GetAllWorkersResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAllWorkers()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetAllWorkersQuery(userId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAllWorkers");
          }

          [HttpGet]
          [Authorize]
          [Route("GetWorkerById/{id}")]
          [ProducesResponseType(typeof(GetWorkerByIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetWorkerById(Guid id)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetWorkerByIdQuery(userId, id);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetWorkerById");
          }

          [HttpGet]
          [Authorize]
          [Route("GetWorkersByName/{name}")]
          [ProducesResponseType(typeof(GetWorkersByNameResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetWorkersByName(string name)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetWorkersByNameQuery(userId, name);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetWorkersByName");
          }

          [HttpGet]
          [Authorize]
          [Route("GetWorkersByPosition/{position}")]
          [ProducesResponseType(typeof(GetWorkersByPositionResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetWorkersByPosition(string position)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetWorkersByPositionQuery(userId, position);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetWorkersByPosition");
          }

          [HttpGet]
          [Authorize]
          [Route("GetAllProviders")]
          [ProducesResponseType(typeof(GetAllProvidersResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAllProviders()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetAllProvidersQuery(userId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAllProviders");
          }

          [HttpGet]
          [Authorize]
          [Route("GetProviderById/{id}")]
          [ProducesResponseType(typeof(GetProviderByIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetProviderById(Guid id)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetProviderByIdQuery(userId, id);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetProviderById");
          }

          [HttpGet]
          [Authorize]
          [Route("GetProvidersByName/{name}")]
          [ProducesResponseType(typeof(GetProvidersByNameResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetProvidersByName(string name)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetProvidersByNameQuery(userId, name);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetProvidersByName");
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