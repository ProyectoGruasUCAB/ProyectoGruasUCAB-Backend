namespace API_GruasUCAB.Auth.Application.Handlers.RefreshToken
{
     public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponseDTO>
     {
          private readonly IService<RefreshTokenRequestDTO, RefreshTokenResponseDTO> _refreshTokenService;

          public RefreshTokenCommandHandler(IService<RefreshTokenRequestDTO, RefreshTokenResponseDTO> refreshTokenService)
          {
               _refreshTokenService = refreshTokenService;
          }

          public async Task<RefreshTokenResponseDTO> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
          {
               return await _refreshTokenService.Execute(request.RefreshTokenRequestDTO);
          }
     }
}