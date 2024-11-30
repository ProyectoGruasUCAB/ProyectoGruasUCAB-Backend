using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.RecoverPassword
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