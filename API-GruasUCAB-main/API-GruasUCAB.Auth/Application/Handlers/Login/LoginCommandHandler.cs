using API_GruasUCAB.Auth.Application.Command.Login;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Login;
using API_GruasUCAB.Core.Application.Services;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Handlers.Login
{
     public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDTO>
     {
          private readonly IService<LoginRequestDTO, LoginResponseDTO> _loginService;

          public LoginCommandHandler(IService<LoginRequestDTO, LoginResponseDTO> loginService)
          {
               _loginService = loginService;
          }

          public async Task<LoginResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
          {
               return await _loginService.Execute(request.LoginRequestDTO);
          }
     }
}