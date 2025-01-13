using API_GruasUCAB.Supplier.Application.Commands.CreateSupplier;
using API_GruasUCAB.Supplier.Application.Commands.UpdateSupplier;
using API_GruasUCAB.Supplier.Infrastructure.DTOs.CreateSupplier;
using API_GruasUCAB.Supplier.Infrastructure.DTOs.UpdateSupplier;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace API_GruasUCAB.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class SupplierController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly ILogger<SupplierController> _logger;

          public SupplierController(IMediator mediator, ILogger<SupplierController> logger)
          {
               _mediator = mediator;
               _logger = logger;
          }

          [HttpPost]
          [Authorize]
          [Route("CreateSupplier")]
          [ProducesResponseType(typeof(CreateSupplierResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new CreateSupplierCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "CreateSupplier");
          }

          [HttpPut]
          //[Authorize]
          [Route("UpdateSupplier")]
          [ProducesResponseType(typeof(UpdateSupplierResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new UpdateSupplierCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "UpdateSupplier");
          }
     }
}