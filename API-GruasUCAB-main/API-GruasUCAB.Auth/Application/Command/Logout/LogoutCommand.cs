using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.Logout
{
     public class LogoutCommand : IRequest<LogoutResponseDTO>
     {
          public string RefreshToken { get; set; }

          public LogoutCommand(string refreshToken)
          {
               RefreshToken = refreshToken;
          }
     }
}