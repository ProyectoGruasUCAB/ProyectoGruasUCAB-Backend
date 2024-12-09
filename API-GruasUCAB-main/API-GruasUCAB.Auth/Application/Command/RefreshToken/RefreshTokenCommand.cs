using API_GruasUCAB.Auth.Infrastructure.DTOs.RefreshToken;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.RefreshToken
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