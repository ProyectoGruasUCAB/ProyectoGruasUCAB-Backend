using API_GruasUCAB.Auth.Infrastructure.DTOs.Logout;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.Logout
{
     public class LogoutCommand : IRequest<LogoutResponseDTO>
     {
          public LogoutRequestDTO LogoutRequestDTO { get; set; }

          public LogoutCommand(LogoutRequestDTO logoutRequestDTO)
          {
               LogoutRequestDTO = logoutRequestDTO;
          }
     }
}