using API_GruasUCAB.Core.Utilities.ActionExecutor;
using API_GruasUCAB.Policy.Infrastructure.Adapters.DTOs;
using API_GruasUCAB.Policy.Infrastructure.Adapters.DTOs.CreateClient;
using API_GruasUCAB.Policy.Infrastructure.Adapters.Services.CreateClient;
using API_GruasUCAB.Policy.Infrastructure.Adapters.Queries;
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
        private readonly CreateClientService _createClientService;

        public ClientController(IMediator mediator, ILogger<ClientController> logger, CreateClientService createClientService)
        {
            _mediator = mediator;
            _logger = logger;
            _createClientService = createClientService;
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
                var response = await _createClientService.Execute(request);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }, ModelState, _logger, "CreateClient");
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllClients")]
        [ProducesResponseType(typeof(List<ClientDTO>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllClients()
        {
            return await ActionExecutor.Execute(async () =>
            {
                var query = new GetAllClientsQuery();
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetAllClients");
        }

        [HttpGet]
        [Authorize]
        [Route("GetClientById/{id}")]
        [ProducesResponseType(typeof(ClientDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var query = new GetClientByIdQuery(id);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetClientById");
        }

        [HttpGet]
        [Authorize]
        [Route("GetClientByClientNumber/{clientNumber}")]
        [ProducesResponseType(typeof(ClientDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetClientByClientNumber(string clientNumber)
        {
            return await ActionExecutor.Execute(async () =>
            {
                var query = new GetClientByClientNumberQuery(clientNumber);
                var response = await _mediator.Send(query);
                return Ok(response);
            }, ModelState, _logger, "GetClientByClientNumber");
        }
    }
}