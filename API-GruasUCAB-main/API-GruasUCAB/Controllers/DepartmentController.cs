using API_GruasUCAB.Department.Application.Commands.CreateDepartment;
using API_GruasUCAB.Department.Application.Commands.UpdateDepartment;
using API_GruasUCAB.Department.Application.Queries.GetAllDepartments;
using API_GruasUCAB.Department.Application.Queries.GetDepartmentById;
using API_GruasUCAB.Department.Application.Queries.GetDepartmentByName;
using API_GruasUCAB.Department.Infrastructure.DTOs.CreateDepartment;
using API_GruasUCAB.Department.Infrastructure.DTOs.UpdateDepartment;
using API_GruasUCAB.Department.Infrastructure.DTOs.DepartmentQueries;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;

namespace API_GruasUCAB.Controllers
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
        [Route("GetAllDepartments")]
        [ProducesResponseType(typeof(GetAllDepartmentsResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllDepartments()
        {
            return await ActionExecutor.Execute(async () =>
            {
                var userId = GetUserId();
                var query = new GetAllDepartmentsQuery(userId);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetAllDepartments");
        }

        [HttpGet]
        [Authorize]
        [Route("GetDepartmentById/{id}")]
        [ProducesResponseType(typeof(GetDepartmentByIdResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("The department ID cannot be empty.");
            }

            return await ActionExecutor.Execute(async () =>
            {
                var userId = GetUserId();
                var query = new GetDepartmentByIdQuery(userId, id);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetDepartmentById");
        }

        [HttpGet]
        [Authorize]
        [Route("GetDepartmentByName/{name}")]
        [ProducesResponseType(typeof(GetDepartmentByNameResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetDepartmentByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("The department name cannot be empty.");
            }

            return await ActionExecutor.Execute(async () =>
            {
                var userId = GetUserId();
                var query = new GetDepartmentByNameQuery(userId, name);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetDepartmentByName");
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
        [Authorize]
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