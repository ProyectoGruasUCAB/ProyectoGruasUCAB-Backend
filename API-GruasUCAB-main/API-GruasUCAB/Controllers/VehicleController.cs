using API_GruasUCAB.Vehicle.Application.Commands.CreateVehicle;
using API_GruasUCAB.Vehicle.Application.Commands.UpdateVehicle;
using API_GruasUCAB.Vehicle.Application.Queries.GetAllVehicles;
using API_GruasUCAB.Vehicle.Application.Queries.GetVehicleById;
using API_GruasUCAB.Vehicle.Application.Queries.GetVehicleByLicensePlate;
using API_GruasUCAB.Vehicle.Application.Queries.GetVehiclesBySupplierId;
using API_GruasUCAB.Vehicle.Application.Queries.GetVehiclesByDriverIdIsNotNull;
using API_GruasUCAB.Vehicle.Application.Queries.GetVehicleByDriverId;
using API_GruasUCAB.Vehicle.Application.Commands.CreateVehicleType;
using API_GruasUCAB.Vehicle.Application.Commands.UpdateVehicleType;
using API_GruasUCAB.Vehicle.Application.Queries.GetAllVehicleTypes;
using API_GruasUCAB.Vehicle.Application.Queries.GetVehicleTypeById;
using API_GruasUCAB.Vehicle.Application.Queries.GetVehicleTypeByName;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.CreateVehicle;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.UpdateVehicle;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleQueries;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleType;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.VehicleTypeQueries;
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

          [HttpGet]
          [Authorize]
          [Route("GetVehiclesBySupplierId/{supplierId}")]
          [ProducesResponseType(typeof(GetVehiclesBySupplierIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetVehiclesBySupplierId(Guid supplierId)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetVehiclesBySupplierIdQuery(supplierId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetVehiclesBySupplierId");
          }

          [HttpGet]
          [Authorize]
          [Route("GetVehiclesByDriverIdIsNotNull")]
          [ProducesResponseType(typeof(GetVehiclesByDriverIdIsNotNullResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetVehiclesByDriverIdIsNotNull()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetVehiclesByDriverIdIsNotNullQuery();
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetVehiclesByDriverIdIsNotNull");
          }

          [HttpGet]
          [Authorize]
          [Route("GetVehicleByDriverId/{driverId}")]
          [ProducesResponseType(typeof(GetVehicleByDriverIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetVehicleByDriverId(Guid driverId)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetVehicleByDriverIdQuery(driverId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetVehicleByDriverId");
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

          [HttpGet]
          [Authorize]
          [Route("GetAllVehicleTypes")]
          [ProducesResponseType(typeof(GetAllVehicleTypesResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAllVehicleTypes()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetAllVehicleTypesQuery();
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAllVehicleTypes");
          }

          [HttpGet]
          [Authorize]
          [Route("GetVehicleTypeById/{id}")]
          [ProducesResponseType(typeof(GetVehicleTypeByIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetVehicleTypeById(Guid id)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetVehicleTypeByIdQuery(id);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetVehicleTypeById");
          }

          [HttpGet]
          [Authorize]
          [Route("GetVehicleTypeByName/{name}")]
          [ProducesResponseType(typeof(GetVehicleTypeByNameResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetVehicleTypeByName(string name)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetVehicleTypeByNameQuery(name);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetVehicleTypeByName");
          }

          [HttpPost]
          [Authorize]
          [Route("CreateVehicleType")]
          [ProducesResponseType(typeof(CreateVehicleTypeResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> CreateVehicleType([FromBody] CreateVehicleTypeRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new CreateVehicleTypeCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "CreateVehicleType");
          }

          [HttpPut]
          [Authorize]
          [Route("UpdateVehicleType")]
          [ProducesResponseType(typeof(UpdateVehicleTypeResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> UpdateVehicleType([FromBody] UpdateVehicleTypeRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new UpdateVehicleTypeCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "UpdateVehicleType");
          }
     }
}