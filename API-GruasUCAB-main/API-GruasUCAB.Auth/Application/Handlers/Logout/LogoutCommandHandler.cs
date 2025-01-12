namespace API_GruasUCAB.Auth.Application.Handlers.Logout
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
               return await _logoutService.Execute(request.LogoutRequestDTO);
          }
     }
}