using API_GruasUCAB.Auth.Application.Command.DeleteUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser;
using API_GruasUCAB.Core.Application.Services;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Handlers.DeleteUser
{
     public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponseDTO>
     {
          private readonly IService<DeleteUserRequestDTO, DeleteUserResponseDTO> _deleteUserService;

          public DeleteUserCommandHandler(IService<DeleteUserRequestDTO, DeleteUserResponseDTO> deleteUserService)
          {
               _deleteUserService = deleteUserService;
          }

          public async Task<DeleteUserResponseDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
          {
               return await _deleteUserService.Execute(request.DeleteUserRequestDTO);
          }
     }
}