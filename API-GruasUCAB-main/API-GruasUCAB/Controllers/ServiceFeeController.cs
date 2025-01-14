using API_GruasUCAB.ServiceFee.Application.Commands.CreateServiceFee;
using API_GruasUCAB.ServiceFee.Application.Commands.UpdateServiceFee;
using API_GruasUCAB.ServiceFee.Application.Queries.GetAllServiceFees;
using API_GruasUCAB.ServiceFee.Application.Queries.GetServiceFeeById;
using API_GruasUCAB.ServiceFee.Application.Queries.GetServiceFeeByName;
using API_GruasUCAB.ServiceFee.Infrastructure.DTOs.CreateServiceFee;
using API_GruasUCAB.ServiceFee.Infrastructure.DTOs.UpdateServiceFee;
using API_GruasUCAB.ServiceFee.Infrastructure.DTOs.ServiceFeeQueries;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;

namespace API_GruasUCAB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceFeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ServiceFeeController> _logger;

        public ServiceFeeController(IMediator mediator, ILogger<ServiceFeeController> logger)
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
        [Route("GetAllServiceFees")]
        [ProducesResponseType(typeof(GetAllServiceFeesResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllServiceFees()
        {
            return await ActionExecutor.Execute(async () =>
            {
                var userId = GetUserId();
                var query = new GetAllServiceFeesQuery(userId);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetAllServiceFees");
        }

        [HttpGet]
        [Authorize]
        [Route("GetServiceFeeById/{id}")]
        [ProducesResponseType(typeof(GetServiceFeeByIdResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetServiceFeeById(Guid id)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var userId = GetUserId();
                var query = new GetServiceFeeByIdQuery(userId, id);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetServiceFeeById");
        }

        [HttpGet]
        [Authorize]
        [Route("GetServiceFeeByName/{name}")]
        [ProducesResponseType(typeof(GetServiceFeeByNameResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetServiceFeeByName(string name)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var userId = GetUserId();
                var query = new GetServiceFeeByNameQuery(userId, name);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetServiceFeeByName");
        }

        [HttpPost]
        [Authorize]
        [Route("CreateServiceFee")]
        [ProducesResponseType(typeof(CreateServiceFeeResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateServiceFee([FromBody] CreateServiceFeeRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new CreateServiceFeeCommand(request);
                var response = await _mediator.Send(command);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }, ModelState, _logger, "CreateServiceFee");
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateServiceFee")]
        [ProducesResponseType(typeof(UpdateServiceFeeResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateServiceFee([FromBody] UpdateServiceFeeRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new UpdateServiceFeeCommand(request);
                var response = await _mediator.Send(command);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }, ModelState, _logger, "UpdateServiceFee");
        }
    }
}