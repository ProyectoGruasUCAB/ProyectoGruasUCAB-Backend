using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.AssignRole
{
     public class AssignRoleCommand : IRequest<AssignRoleResponseDTO>
     {
          public AssignRoleRequestDTO AssignRoleRequest { get; set; }

          public AssignRoleCommand(AssignRoleRequestDTO assignRoleRequest)
          {
               AssignRoleRequest = assignRoleRequest;
          }
     }
}