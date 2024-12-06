using API_GruasUCAB.Auth.Infrastructure.DTOs.ChangePassword;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.ChangePassword
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