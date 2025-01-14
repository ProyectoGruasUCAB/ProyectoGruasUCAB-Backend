using API_GruasUCAB.Supplier.Application.Commands.CreateSupplier;
using API_GruasUCAB.Supplier.Application.Commands.UpdateSupplier;
using API_GruasUCAB.Supplier.Application.Queries.GetAllSuppliers;
using API_GruasUCAB.Supplier.Application.Queries.GetSupplierById;
using API_GruasUCAB.Supplier.Application.Queries.GetSupplierByType;
using API_GruasUCAB.Supplier.Infrastructure.DTOs.CreateSupplier;
using API_GruasUCAB.Supplier.Infrastructure.DTOs.UpdateSupplier;
using API_GruasUCAB.Supplier.Infrastructure.DTOs.SupplierQueries;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Claims;

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
          [Route("GetAllSuppliers")]
          [ProducesResponseType(typeof(GetAllSuppliersResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAllSuppliers()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetAllSuppliersQuery(userId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAllSuppliers");
          }

          [HttpGet]
          [Authorize]
          [Route("GetSupplierById/{id}")]
          [ProducesResponseType(typeof(GetSupplierByIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetSupplierById(Guid id)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetSupplierByIdQuery(userId, id);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetSupplierById");
          }

          [HttpGet]
          [Authorize]
          [Route("GetSupplierByType/{type}")]
          [ProducesResponseType(typeof(GetSupplierByTypeResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetSupplierByType(string type)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetSupplierByTypeQuery(userId, type);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetSupplierByType");
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
          [Authorize]
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