namespace API_GruasUCAB.Auth.Application.Commands.ChangePassword
{
     public class ChangePasswordCommand : IRequest<ChangePasswordResponseDTO>
     {
          public ChangePasswordRequestDTO ChangePasswordRequest { get; set; }

          public ChangePasswordCommand(ChangePasswordRequestDTO changePasswordRequest)
          {
               ChangePasswordRequest = changePasswordRequest;
          }
     }
}