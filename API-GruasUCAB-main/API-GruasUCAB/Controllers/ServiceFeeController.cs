using API_GruasUCAB.ServiceFee.Application.Commands.CreateServiceFee;
using API_GruasUCAB.ServiceFee.Application.Commands.UpdateServiceFee;
using API_GruasUCAB.ServiceFee.Infrastructure.DTOs.UpdateServiceFee;
using API_GruasUCAB.ServiceFee.Infrastructure.DTOs.CreateServiceFee;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ServiceFeeModule.Controllers
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