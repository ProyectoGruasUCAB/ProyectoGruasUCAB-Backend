namespace API_GruasUCAB.Auth.Application.Commands.RefreshToken
{
     public class RefreshTokenCommand : IRequest<RefreshTokenResponseDTO>
     {
          public RefreshTokenRequestDTO RefreshTokenRequestDTO { get; set; }

          public RefreshTokenCommand(RefreshTokenRequestDTO refreshTokenRequestDTO)
          {
               RefreshTokenRequestDTO = refreshTokenRequestDTO;
          }
     }
}