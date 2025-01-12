namespace API_GruasUCAB.Auth.Application.Commands.AssignRole
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