using API_GruasUCAB.Auth.Infrastructure.DTOs.AssignRole;
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