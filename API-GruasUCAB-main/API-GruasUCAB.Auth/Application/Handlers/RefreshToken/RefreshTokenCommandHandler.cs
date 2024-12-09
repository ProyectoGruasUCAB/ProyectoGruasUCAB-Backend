using API_GruasUCAB.Auth.Application.Command.RefreshToken;
using API_GruasUCAB.Core.Application.Services;
using API_GruasUCAB.Auth.Infrastructure.DTOs.RefreshToken;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

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