using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.Logout
{
     public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponseDTO>
     {
          private readonly IService<LogoutRequestDTO, LogoutResponseDTO> _logoutService;

          public LogoutCommandHandler(IService<LogoutRequestDTO, LogoutResponseDTO> logoutService)
          {
               _logoutService = logoutService;
          }

          public async Task<LogoutResponseDTO> Handle(LogoutCommand request, CancellationToken cancellationToken)
          {
               var logoutRequest = new LogoutRequestDTO { RefreshToken = request.RefreshToken };
               return await _logoutService.Execute(logoutRequest);
          }
     }
}