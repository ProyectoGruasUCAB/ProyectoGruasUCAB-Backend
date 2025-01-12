namespace API_GruasUCAB.Auth.Application.Commands.RecoverPassword
{
     public class RecoverPasswordCommand : IRequest<RecoverPasswordResponseDTO>
     {
          public RecoverPasswordRequestDTO Request { get; set; }

          public RecoverPasswordCommand(RecoverPasswordRequestDTO request)
          {
               Request = request;
          }
     }
}