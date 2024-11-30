using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_GruasUCAB.Auth.Application.Command.AssignRole
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