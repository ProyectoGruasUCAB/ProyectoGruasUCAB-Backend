using API_GruasUCAB.Department.Application.Commands.CreateDepartment;
using API_GruasUCAB.Department.Application.Commands.UpdateDepartment;
using API_GruasUCAB.Department.Infrastructure.DTOs.CreateDepartment;
using API_GruasUCAB.Department.Infrastructure.DTOs.UpdateDepartment;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Department.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IMediator mediator, ILogger<DepartmentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        [Route("CreateDepartment")]
        [ProducesResponseType(typeof(CreateDepartmentResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new CreateDepartmentCommand(request);
                var response = await _mediator.Send(command);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }, ModelState, _logger, "CreateDepartment");
        }

        [HttpPut]
        //[Authorize]
        [Route("UpdateDepartment")]
        [ProducesResponseType(typeof(UpdateDepartmentResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new UpdateDepartmentCommand(request);
                var response = await _mediator.Send(command);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }, ModelState, _logger, "UpdateDepartment");
        }
    }
}