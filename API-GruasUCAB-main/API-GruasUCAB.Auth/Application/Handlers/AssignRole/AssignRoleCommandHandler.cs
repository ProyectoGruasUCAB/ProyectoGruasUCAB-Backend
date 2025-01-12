namespace API_GruasUCAB.Auth.Application.Handlers.AssignRole
{
     public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, AssignRoleResponseDTO>
     {
          private readonly IService<AssignRoleRequestDTO, AssignRoleResponseDTO> _assignRoleService;

          public AssignRoleCommandHandler(IService<AssignRoleRequestDTO, AssignRoleResponseDTO> assignRoleService)
          {
               _assignRoleService = assignRoleService;
          }

          public async Task<AssignRoleResponseDTO> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
          {
               return await _assignRoleService.Execute(request.AssignRoleRequest);
          }
     }
}