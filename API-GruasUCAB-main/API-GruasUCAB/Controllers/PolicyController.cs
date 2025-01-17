using API_GruasUCAB.Policy.Application.Commands.CreatePolicy;
using API_GruasUCAB.Policy.Application.Queries.GetPolicyByPolicyNumber;
using API_GruasUCAB.Policy.Application.Queries.GetPolicyById;
using API_GruasUCAB.Policy.Application.Queries.GetAllPolicies;
using API_GruasUCAB.Policy.Infrastructure.DTOs.PolicyQueries;
using API_GruasUCAB.Policy.Infrastructure.DTOs.CreatePolicy;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;

namespace API_GruasUCAB.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class PolicyController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly ILogger<PolicyController> _logger;

          public PolicyController(IMediator mediator, ILogger<PolicyController> logger)
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
          [Route("GetAllPolicies")]
          [ProducesResponseType(typeof(GetAllPoliciesResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetAllPolicies()
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetAllPoliciesQuery(userId);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetAllPolicies");
          }

          [HttpGet]
          [Authorize]
          [Route("GetPolicyById/{id}")]
          [ProducesResponseType(typeof(GetPolicyByIdResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetPolicyById(Guid id)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetPolicyByIdQuery(userId, id);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetPolicyById");
          }

          [HttpGet]
          [Authorize]
          [Route("GetPolicyByPolicyNumber/{policyNumber}")]
          [ProducesResponseType(typeof(GetPolicyByPolicyNumberResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> GetPolicyByPolicyNumber(string policyNumber)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var userId = GetUserId();
                    var query = new GetPolicyByPolicyNumberQuery(userId, policyNumber);
                    var response = await _mediator.Send(query);
                    return Ok(response);
               }, ModelState, _logger, "GetPolicyByPolicyNumber");
          }

          [HttpPost]
          [Authorize]
          [Route("CreatePolicy")]
          [ProducesResponseType(typeof(CreatePolicyResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> CreatePolicy([FromBody] CreatePolicyRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new CreatePolicyCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "CreatePolicy");
          }
     }
}