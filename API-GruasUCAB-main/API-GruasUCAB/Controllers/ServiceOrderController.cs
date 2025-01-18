using API_GruasUCAB.ServiceOrder.Application.Commands.CreateServiceOrder;
using API_GruasUCAB.ServiceOrder.Application.Commands.UpdateServiceOrder;
using API_GruasUCAB.ServiceOrder.Application.Queries.GetServiceOrderById;
using API_GruasUCAB.ServiceOrder.Application.Queries.GetAllServiceOrders;
using API_GruasUCAB.ServiceOrder.Application.Queries.GetServiceOrdersByStatus;
using API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.CreateServiceOrder;
using API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.UpdateServiceOrder;
using API_GruasUCAB.ServiceOrder.Infrastructure.DTOs.ServiceOrderQueries;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;

namespace API_GruasUCAB.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class ServiceOrderController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly ILogger<ServiceOrderController> _logger;

          public ServiceOrderController(IMediator mediator, ILogger<ServiceOrderController> logger)
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
          [Route("GetServiceOrderById/{serviceOrderId}")]
          [ProducesResponseType(typeof(GetServiceOrderByIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetServiceOrderById(Guid serviceOrderId)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetServiceOrderByIdQuery(GetUserId(), serviceOrderId);
                    var response = await _mediator.Send(query);
                    if (response.ServiceOrder != null)
                    {
                         return Ok(response);
                    }
                    return NotFound(response);
               }, ModelState, _logger, "GetServiceOrderById");
          }

          [HttpGet]
          [Authorize]
          [Route("GetAllServiceOrders")]
          [ProducesResponseType(typeof(GetAllServiceOrdersResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAllServiceOrders()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetAllServiceOrdersQuery(GetUserId());
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAllServiceOrders");
          }

          [HttpGet]
          [Authorize]
          [Route("GetServiceOrdersByStatus/{status}")]
          [ProducesResponseType(typeof(GetServiceOrdersByStatusResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetServiceOrdersByStatus(string status)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var query = new GetServiceOrdersByStatusQuery(GetUserId(), status);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetServiceOrdersByStatus");
          }

          [HttpPost]
          [Authorize]
          [Route("CreateServiceOrder")]
          [ProducesResponseType(typeof(CreateServiceOrderResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> CreateServiceOrder([FromBody] CreateServiceOrderRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new CreateServiceOrderCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "CreateServiceOrder");
          }

          [HttpPut]
          [Authorize]
          [Route("UpdateServiceOrder")]
          [ProducesResponseType(typeof(UpdateServiceOrderResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> UpdateServiceOrder([FromBody] UpdateServiceOrderRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new UpdateServiceOrderCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "UpdateServiceOrder");
          }
     }
}