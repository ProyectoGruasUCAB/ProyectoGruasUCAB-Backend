using API_GruasUCAB.Vehicle.Application.Commands.CreateVehicle;
using API_GruasUCAB.Vehicle.Application.Commands.UpdateVehicle;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.CreateVehicle;
using API_GruasUCAB.Vehicle.Infrastructure.DTOs.UpdateVehicle;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

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
          //[Authorize]
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