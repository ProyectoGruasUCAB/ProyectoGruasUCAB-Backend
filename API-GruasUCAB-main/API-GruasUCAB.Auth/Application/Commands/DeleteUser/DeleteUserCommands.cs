namespace API_GruasUCAB.Auth.Application.Commands.DeleteUser
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