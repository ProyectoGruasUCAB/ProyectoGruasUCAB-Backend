using API_GruasUCAB.Vehicle.Application.Commands.CreateVehicle;
using API_GruasUCAB.Vehicle.Application.Commands.UpdateVehicle;
using API_GruasUCAB.Vehicle.Application.Queries.GetAllVehicles;
using API_GruasUCAB.Vehicle.Application.Queries.GetVehicleById;
using API_GruasUCAB.Vehicle.Application.Queries.GetVehicleByLicensePlate;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.CreateVehicle;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.UpdateVehicle;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleQueries;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Claims;

namespace API_GruasUCAB.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class VehicleController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly ILogger<VehicleController> _logger;

          public VehicleController(IMediator mediator, ILogger<VehicleController> logger)
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
          [Route("GetAllVehicles")]
          [ProducesResponseType(typeof(GetAllVehiclesResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAllVehicles()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetAllVehiclesQuery(userId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAllVehicles");
          }

          [HttpGet]
          [Authorize]
          [Route("GetVehicleById/{id}")]
          [ProducesResponseType(typeof(GetVehicleByIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetVehicleById(Guid id)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetVehicleByIdQuery(userId, id);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetVehicleById");
          }

          [HttpGet]
          [Authorize]
          [Route("GetVehicleByLicensePlate/{licensePlate}")]
          [ProducesResponseType(typeof(GetVehicleByLicensePlateResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetVehicleByLicensePlate(string licensePlate)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetVehicleByLicensePlateQuery(userId, licensePlate);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetVehicleByLicensePlate");
          }

          [HttpPost]
          [Authorize]
          [Route("CreateVehicle")]
          [ProducesResponseType(typeof(CreateVehicleResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new CreateVehicleCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "CreateVehicle");
          }

          [HttpPut]
          [Authorize]
          [Route("UpdateVehicle")]
          [ProducesResponseType(typeof(UpdateVehicleResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> UpdateVehicle([FromBody] UpdateVehicleRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new UpdateVehicleCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "UpdateVehicle");
          }
     }
}