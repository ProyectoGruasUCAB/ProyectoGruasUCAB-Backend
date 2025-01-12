namespace API_GruasUCAB.Auth.Application.Commands.Logout
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