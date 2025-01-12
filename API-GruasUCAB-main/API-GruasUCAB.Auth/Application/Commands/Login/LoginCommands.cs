namespace API_GruasUCAB.Auth.Application.Commands.Login
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