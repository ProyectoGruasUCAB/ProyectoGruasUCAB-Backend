using API_GruasUCAB.Users.Application.Commands.RecordUserData;
using API_GruasUCAB.Users.Application.Commands.UpdateUser;
using API_GruasUCAB.Users.Infrastructure.DTOs.RecordUserData;
using API_GruasUCAB.Users.Infrastructure.DTOs.UpdateUser;
using API_GruasUCAB.Core.Utilities.ActionExecutor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Users.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class UserController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly ILogger<UserController> _logger;

          public UserController(IMediator mediator, ILogger<UserController> logger)
          {
               _mediator = mediator;
               _logger = logger;
          }

          [HttpPost]
          [Authorize]
          [Route("RecordUserData")]
          [ProducesResponseType(typeof(RecordUserDataResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> CreateUser([FromBody] RecordUserDataRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new RecordUserDataCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "RecordUserData");
          }

          [HttpPut]
          //[Authorize]
          [Route("UpdateUserData")]
          [ProducesResponseType(typeof(UpdateRecordUserDataResponseDTO), 200)]
          [ProducesResponseType(400)]
          [ProducesResponseType(401)]
          [ProducesResponseType(500)]
          public async Task<IActionResult> UpdateUser([FromBody] UpdateRecordUserDataRequestDTO request)
          {
               return await ActionExecutor.Execute(async () =>
               {
                    var command = new UpdateRecordUserDataCommand(request);
                    var response = await _mediator.Send(command);
                    if (response.Success)
                    {
                         return Ok(response);
                    }
                    return BadRequest(response);
               }, ModelState, _logger, "UpdateUserData");
          }
     }
}