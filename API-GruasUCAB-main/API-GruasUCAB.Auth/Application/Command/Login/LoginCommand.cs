using API_GruasUCAB.Auth.Infrastructure.DTOs.Login;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.Login
{
     public class LoginCommand : IRequest<LoginResponseDTO>
     {
          public LoginRequestDTO LoginRequestDTO { get; set; }

          public LoginCommand(LoginRequestDTO loginRequestDTO)
          {
               LoginRequestDTO = loginRequestDTO;
          }
     }
}