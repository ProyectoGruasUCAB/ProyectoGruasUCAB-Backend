using API_GruasUCAB.Policy.Application.Commands.CreateClient;
using API_GruasUCAB.Policy.Application.Queries.GetClientById;
using API_GruasUCAB.Policy.Application.Queries.GetAllClients;
using API_GruasUCAB.Policy.Infrastructure.DTOs.ClientQueries;
using API_GruasUCAB.Policy.Infrastructure.DTOs.CreateClient;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;

namespace API_GruasUCAB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IMediator mediator, ILogger<ClientController> logger)
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
        [Route("GetAllClients")]
        [ProducesResponseType(typeof(GetAllClientsResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllClients()
        {
            return await ActionExecutor.Execute(async () =>
            {
                var userId = GetUserId();
                var query = new GetAllClientsQuery(userId);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetAllClients");
        }

        [HttpGet]
        [Authorize]
        [Route("GetClientById/{id}")]
        [ProducesResponseType(typeof(GetClientByIdResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var userId = GetUserId();
                var query = new GetClientByIdQuery(userId, id);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetClientById");
        }

        [HttpPost]
        [Authorize]
        [Route("CreateClient")]
        [ProducesResponseType(typeof(CreateClientResponseDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequestDTO request)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var command = new CreateClientCommand(request);
                var response = await _mediator.Send(command);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }, ModelState, _logger, "CreateClient");
        }
    }
}