using API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.DeleteUser
{
     public class DeleteUserCommand : IRequest<DeleteUserResponseDTO>
     {
          public DeleteUserRequestDTO DeleteUserRequestDTO { get; set; }

          public DeleteUserCommand(DeleteUserRequestDTO deleteUserRequestDTO)
          {
               DeleteUserRequestDTO = deleteUserRequestDTO;
          }
     }
}